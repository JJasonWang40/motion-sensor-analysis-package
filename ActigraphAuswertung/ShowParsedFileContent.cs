using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung
{
    /// <summary>
    /// Show all entries of the selected model.
    /// </summary>
    public partial class ShowParsedFileContent : Form
    {
        private CsvModel data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The model to show all entrys of</param>
        public ShowParsedFileContent(CsvModel data)
        {
            // set bindinglist for gridview
            this.data = data;

            InitializeComponent();

            #region Custom Init

            // Display filename in title
            this.Text += " " + data.FileName;

            // prepare for custom data-source and columns
            this.fileContentDataGrid.AutoGenerateColumns = false;
            this.fileContentDataGrid.DataSource = this.data;

            // add columns supported by data
            foreach (SensorData t in Enum.GetValues(typeof(SensorData)))
            {
                FieldInfo fi = t.GetType().GetField(t.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if(data.SupportedValues.Contains(t)) {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.DataPropertyName = t.ToString();
                    col.HeaderText = attributes[0].Description;
                    this.fileContentDataGrid.Columns.Add(col);
                }
            }

            #endregion
        }
    }
}
