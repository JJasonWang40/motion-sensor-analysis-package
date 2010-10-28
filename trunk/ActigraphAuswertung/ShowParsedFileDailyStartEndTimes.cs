using System.ComponentModel;
using System.Windows.Forms;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung
{
    /// <summary>
    /// Show all detected days and their activity start and end times and the daily active time.
    /// </summary>
    public partial class ShowParsedFileDailyStartEndTimes : Form
    {
        private BindingList<SensorStartEndWearing> data;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">The model</param>
        public ShowParsedFileDailyStartEndTimes(CsvModel data)
        {
            this.data = data.DayStartEndCalculator.DayStartEndList;

            InitializeComponent();

            #region Custom Init
            this.Text += " " + data.FileName;

            this.fileContentDataGrid.AutoGenerateColumns = false;
            this.fileContentDataGrid.DataSource = this.data;

            DataGridViewTextBoxColumn dateTimeColumn = new DataGridViewTextBoxColumn();
            dateTimeColumn.DataPropertyName = "Date";
            dateTimeColumn.HeaderText = "Date";
            this.fileContentDataGrid.Columns.Add(dateTimeColumn);

            DataGridViewTextBoxColumn startTimeColumn = new DataGridViewTextBoxColumn();
            startTimeColumn.DataPropertyName = "StartTime";
            startTimeColumn.HeaderText = "Start";
            startTimeColumn.DefaultCellStyle.Format = "HH:mm:ss";
            this.fileContentDataGrid.Columns.Add(startTimeColumn);

            DataGridViewTextBoxColumn endTimeColumn = new DataGridViewTextBoxColumn();
            endTimeColumn.DataPropertyName = "EndTime";
            endTimeColumn.HeaderText = "End";
            endTimeColumn.DefaultCellStyle.Format = "HH:mm:ss";
            this.fileContentDataGrid.Columns.Add(endTimeColumn);

            DataGridViewTextBoxColumn activeTimeColumn = new DataGridViewTextBoxColumn();
            activeTimeColumn.DataPropertyName = "ActiveTime";
            activeTimeColumn.HeaderText = "Active Time";
            this.fileContentDataGrid.Columns.Add(activeTimeColumn);

            #endregion
        }
    }
}
