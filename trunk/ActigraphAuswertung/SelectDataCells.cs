using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung
{
    public partial class SelectDataCells : Form
    {
        private Dictionary<CsvModel, FlowLayoutPanel> modelRadioRelation = new Dictionary<CsvModel, FlowLayoutPanel>();

        private Dictionary<CsvModel, SensorData> modelCellSelection = new Dictionary<CsvModel, SensorData>();

        public Dictionary<CsvModel, SensorData> ModelCellSelection
        {
            get { return this.modelCellSelection; }
        }

        private FunctionStartExport callback;

        public SelectDataCells(List<CsvModel> datasets, FunctionStartExport callback)
        {
            InitializeComponent();

            this.callback = callback;

            foreach (CsvModel row in datasets)
            {
                FlowLayoutPanel rowPanel = new FlowLayoutPanel();
                rowPanel.AutoSize = true;
                rowPanel.WrapContents = false;

                Label rowLabel = new Label();
                rowLabel.Text = row.FileName;
                rowLabel.Margin = new Padding(7);

                FlowLayoutPanel rowDataPanel = new FlowLayoutPanel();
                rowDataPanel.AutoSize = true;
                rowDataPanel.Margin = new Padding(0);
                rowDataPanel.WrapContents = false;

                foreach (SensorData d in row.SupportedValues)
                {
                    RadioButton entry = new RadioButton();
                    entry.Text = d.ToString();
                    entry.Tag = d;
                    rowDataPanel.Controls.Add(entry);
                }
                rowPanel.Controls.Add(rowLabel);
                rowPanel.Controls.Add(rowDataPanel);

                this.modelRadioRelation.Add(row, rowDataPanel);
                this.cellSelectionPanel.Controls.Add(rowPanel);
            }
        }

        private void export_start_button_Click(object sender, EventArgs e)
        {
            Dictionary<CsvModel, SensorData> modelCellSelection = new Dictionary<CsvModel, SensorData>();

            foreach (KeyValuePair<CsvModel, FlowLayoutPanel> entry in this.modelRadioRelation)
            {
                foreach (RadioButton button in entry.Value.Controls)
                {
                    if (button.Checked)
                    { 
                        modelCellSelection.Add(entry.Key, (SensorData) button.Tag);
                    }
                }
            }

            this.Close();
            this.callback(modelCellSelection);
        }
    }
}
