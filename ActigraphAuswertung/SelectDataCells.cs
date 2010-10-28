using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung
{
    /// <summary>
    /// Form to ask for one <see cref="Model.SensorData"/> for each model.
    /// </summary>
    public partial class SelectDataCells : Form
    {
        // Saves the associated radio group for each model.
        private Dictionary<CsvModel, FlowLayoutPanel> modelRadioRelation = new Dictionary<CsvModel, FlowLayoutPanel>();

        // Saves the associated SensorData for each model.
        private Dictionary<CsvModel, SensorData> modelCellSelection = new Dictionary<CsvModel, SensorData>();

        /// <summary>
        /// The selected <see cref="Model.SensorData"/> for each <see cref="Model.CsvModel"/>.
        /// </summary>
        public Dictionary<CsvModel, SensorData> ModelCellSelection
        {
            get { return this.modelCellSelection; }
        }

        private FunctionStartExport callback;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="datasets">The models to ask for selection</param>
        /// <param name="callback">The callback on selection</param>
        public SelectDataCells(List<CsvModel> datasets, FunctionStartExport callback)
        {
            InitializeComponent();

            this.callback = callback;

            // Lot of style stuff for each model
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

                // Add a radio button for each supported value
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

        // Callback from ok-button
        private void export_start_button_Click(object sender, EventArgs e)
        {
            Dictionary<CsvModel, SensorData> modelCellSelection = new Dictionary<CsvModel, SensorData>();

            // save the selected value for each model (or ignore if none was selected)
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

            // Close window and call the callback with the result.
            this.Close();
            this.callback(modelCellSelection);
        }
    }
}
