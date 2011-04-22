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

        #region constructor
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
        #endregion

        #region datagrid events

        private void fileContentDataGrid_ColumnDividerDoubleClick(Object sender, DataGridViewColumnDividerDoubleClickEventArgs e)
        {
            e.Handled = true;
            //// get mouse coordinates
            //System.Drawing.Point mousePoint = fileContentDataGrid.PointToClient(Cursor.Position);
            //DataGridView.HitTestInfo hitTestInfo = fileContentDataGrid.HitTest(mousePoint.X, mousePoint.Y);
            //// need to use reflection here to get access to the typeInternal field value which is declared as internal
            //FieldInfo fieldInfo = hitTestInfo.GetType().GetField("typeInternal",
            //    BindingFlags.Instance | BindingFlags.NonPublic);
            //string value = fieldInfo.GetValue(hitTestInfo).ToString();
            //throw new Exception(value);
            //if (value.Contains("Resize"))
            //{
            //    // one of resize areas is double clicked; stop processing here      
            //    return;
            //}
            //else
            //{
            //    // continue normal processing of the cell double click event
            //}
        }
        #endregion
    }
}
