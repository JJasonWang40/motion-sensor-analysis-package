﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ActigraphAuswertung.Filter;
using ActigraphAuswertung.Model;
using ActigraphAuswertung.RExport;
using ActigraphAuswertung.CommandManager.Commands;
using ActigraphAuswertung.Model.Calculators;

namespace ActigraphAuswertung
{
    /// <summary>
    /// Delegate to start the export (callback from the SelectDataCells form).
    /// </summary>
    /// <param name="modelCellSelection"></param>
    public delegate void FunctionStartExport(Dictionary<CsvModel, SensorData> modelCellSelection);

    public partial class Form1 : Form
    {
        // All imported models
        private  BindingList<CsvModel> parsedFiles = new BindingList<CsvModel>();

        // Command manager
        private CommandManager.Manager commandManager = new CommandManager.Manager();

        /// <summary>
        /// Absolute path to the application directory.
        /// </summary>
        public static string APP_PATH = "";

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

            APP_PATH = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
            InitializeComponent();
            
            // Custom init
            #region Custom Init
            this.processGridView.AutoGenerateColumns = false;
            this.processGridView.DataSource = this.commandManager.Commands;

            DataGridViewTextBoxColumn taskNameColumn = new DataGridViewTextBoxColumn();
            taskNameColumn.DataPropertyName = "Description";
            taskNameColumn.HeaderText = "Task";
            this.processGridView.Columns.Add(taskNameColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.HeaderText = "Status";
            this.processGridView.Columns.Add(statusColumn);

            DataGridViewTextBoxColumn priorityColumn = new DataGridViewTextBoxColumn();
            priorityColumn.DataPropertyName = "Priority";
            priorityColumn.HeaderText = "Priority";
            this.processGridView.Columns.Add(priorityColumn);

            DataGridViewTextBoxColumn messageColumn = new DataGridViewTextBoxColumn();
            messageColumn.DataPropertyName = "Message";
            messageColumn.HeaderText = "Message";
            this.processGridView.Columns.Add(messageColumn);

            this.parsedFilesGridView.AutoGenerateColumns = false;
            this.parsedFilesGridView.DataSource = this.parsedFiles;

            DataGridViewTextBoxColumn fileNameColumn = new DataGridViewTextBoxColumn();
            fileNameColumn.DataPropertyName = "FileName";
            fileNameColumn.HeaderText = "File";
            this.parsedFilesGridView.Columns.Add(fileNameColumn);

            DataGridViewTextBoxColumn rowCountColumn = new DataGridViewTextBoxColumn();
            rowCountColumn.DataPropertyName = "Count";
            rowCountColumn.HeaderText = "# Rows";
            this.parsedFilesGridView.Columns.Add(rowCountColumn);

            DataGridViewTextBoxColumn startDateTimeColumn = new DataGridViewTextBoxColumn();
            startDateTimeColumn.DataPropertyName = "StartDate";
            startDateTimeColumn.HeaderText = "Start Date/Time";
            this.parsedFilesGridView.Columns.Add(startDateTimeColumn);

            DataGridViewTextBoxColumn endDateTimeColumn = new DataGridViewTextBoxColumn();
            endDateTimeColumn.HeaderText = "End Date/Time";
            endDateTimeColumn.DataPropertyName = "EndDate";
            this.parsedFilesGridView.Columns.Add(endDateTimeColumn);

            DataGridViewTextBoxColumn filePathColumn = new DataGridViewTextBoxColumn();
            filePathColumn.DataPropertyName = "AbsoluteFileName";
            filePathColumn.HeaderText = "Absolute filename";
            this.parsedFilesGridView.Columns.Add(filePathColumn);

            this.filter_method_all.Tag = FilterMethod.ALL;
            this.filter_method_either.Tag = FilterMethod.EITHER;
            this.filter_method_none.Tag = FilterMethod.NONE;

            this.export_function_dropdown.DataSource = ExportScriptsExtensions.ToList();
            this.export_function_dropdown.ValueMember = "Key";
            this.export_function_dropdown.DisplayMember = "Value";

            #endregion
            // End Custom init
        }

        #region datagrid events
        // Display helper for Row Context Menu, display only if clicked on row
        // used as property of datagridview always displays the contextmenu
        private void parsedFilesGridView_showContextMenu(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = this.parsedFileContextMenu;
            this.parsedFilesGridView.Rows[e.RowIndex].Selected = true;
        }

        // Show file contents of the selected file
        // context menu event
        private void parsedFilesGridView_showParsedFileContent(object sender, EventArgs e)
        {
            int rowIndex = this.parsedFilesGridView.SelectedRows[0].Index;
            CsvModel data = (CsvModel)this.parsedFilesGridView.Rows[rowIndex].DataBoundItem;
            ShowParsedFileContent viewCsvForm = new ShowParsedFileContent(data);
            viewCsvForm.Show();
        }

        // Show daily start- and endtimes of the seleced file
        // context menu event
        private void parsedFilesGridView_showDailyStartEndTimes(object sender, EventArgs e)
        {
            int rowIndex = this.parsedFilesGridView.SelectedRows[0].Index;
            CsvModel data = (CsvModel)this.parsedFilesGridView.Rows[rowIndex].DataBoundItem;
            ShowParsedFileDailyStartEndTimes viewCsvForm = new ShowParsedFileDailyStartEndTimes(data);
            viewCsvForm.Show();
        }

        // Selected file changed, update quick-information and filter
        private void parsedFilesGridView_selectionChanged(object sender, EventArgs e)
        {
            if (this.parsedFilesGridView.SelectedRows.Count != 1)
            {
                // @todo: reset summary
                this.filter_days_list.Items.Clear();
                this.filter_apply.Enabled = false;

                Application.DoEvents();
                return;
            }

            // get selected dataset
            int rowIndex = this.parsedFilesGridView.SelectedRows[0].Index;
            CsvModel data = (CsvModel)this.parsedFilesGridView.Rows[rowIndex].DataBoundItem;

            // set time calucations
            this.wearingtotaltimebox.Text = String.Format("{0:([d’.’]hh’:’mm’:’ss)}", data.ActiveTimeCalculator.ActiveTime.ToString());
            this.wearingstarttimebox.Text = String.Format("{0:([d’.’]hh’:’mm’:’ss)}", data.ActiveTimeCalculator.AvgStartTime.ToString());
            this.wearingendtimebox.Text = String.Format("{0:([d’.’]hh’:’mm’:’ss)}", data.ActiveTimeCalculator.AvgEndTime.ToString());

            // set activity calculations
            ActivityLevelsCalculator.ActivityLevel alevel;
            int alevelSteps = data.ActivityLevelCalculator.Steps;
            alevel = data.ActivityLevelCalculator.getActivityLevel(ActivityLevels.VERYVIGOROUS);
            this.activitylevel_veryvigorous_perc.Text = Math.Round(alevel.Percent, 2).ToString() + " %";
            this.activitylevel_veryvigorous_time.Text = new TimeSpan(data.EpochPeriod.Ticks * alevel.Count * alevelSteps).ToString();
            this.activitylevel_veryvigorous_values.Text = alevel.Count + " / " + alevel.Count * alevelSteps;

            alevel = data.ActivityLevelCalculator.getActivityLevel(ActivityLevels.VIGOROUS);
            this.activitylevel_vigorous_perc.Text = Math.Round(alevel.Percent,2 ).ToString() + " %";
            this.activitylevel_vigorous_time.Text = new TimeSpan(data.EpochPeriod.Ticks * alevel.Count * alevelSteps).ToString();
            this.activitylevel_vigorous_values.Text = alevel.Count + " / " + alevel.Count * alevelSteps;

            alevel = data.ActivityLevelCalculator.getActivityLevel(ActivityLevels.MODERATE);
            this.activitylevel_moderate_perc.Text = Math.Round(alevel.Percent, 2).ToString() + " %";
            this.activitylevel_moderate_time.Text = new TimeSpan(data.EpochPeriod.Ticks * alevel.Count * alevelSteps).ToString();
            this.activitylevel_moderate_values.Text = alevel.Count + " / " + alevel.Count * alevelSteps;

            alevel = data.ActivityLevelCalculator.getActivityLevel(ActivityLevels.LIGHT);
            this.activitylevel_light_perc.Text = Math.Round(alevel.Percent, 2).ToString() + " %";
            this.activitylevel_light_time.Text = new TimeSpan(data.EpochPeriod.Ticks * alevel.Count * alevelSteps).ToString();
            this.activitylevel_light_values.Text = alevel.Count + " / " + alevel.Count * alevelSteps;

            alevel = data.ActivityLevelCalculator.getActivityLevel(ActivityLevels.SEDENTARY);
            this.activitylevel_sedentary_perc.Text = Math.Round(alevel.Percent, 2).ToString() + " %";
            this.activitylevel_sedentary_time.Text = new TimeSpan(data.EpochPeriod.Ticks * alevel.Count * alevelSteps).ToString();
            this.activitylevel_sedentary_values.Text = alevel.Count + " / " + alevel.Count * alevelSteps;

            // set filter options
            this.filter_method_all.Checked = true;
            this.filter_apply.Enabled = true;

            // time based filter
            this.filter_time_enabled.Checked = true;
            this.filter_time_start.Text = data.ActiveTimeCalculator.AvgStartTime.ToString();
            this.filter_time_end.Text = data.ActiveTimeCalculator.AvgEndTime.ToString();

            // day based filter
            this.filter_days_enabled.Checked = true;
            this.filter_days_list.Items.Clear();
            foreach(SensorStartEndWearing day in data.DayStartEndCalculator.DayStartEndList)
            {
                this.filter_days_list.Items.Add(day.Date);
                if (!day.ActiveTime.Equals(new TimeSpan()))
                {
                    this.filter_days_list.SetItemChecked(this.filter_days_list.Items.IndexOf(day.Date), true);
                }
            }
            this.filter_days_list.SetItemChecked(0, false);
            this.filter_days_list.SetItemChecked(this.filter_days_list.Items.Count-1, false);

            Application.DoEvents();
        }

        #endregion

        #region filter events
        // uncheck all days
        private void filter_days_none_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < this.filter_days_list.Items.Count; i++)
            {
                this.filter_days_list.SetItemChecked(i, false);
            }
        }

        // check all days
        private void filter_days_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.filter_days_list.Items.Count; i++)
            {
                this.filter_days_list.SetItemChecked(i, true);
            }
        }

        // check weekends only
        private void filter_days_weekend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.filter_days_list.Items.Count; i++)
            {
                DateTime day = (DateTime) this.filter_days_list.Items[i];
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    this.filter_days_list.SetItemChecked(i, true);
                }
                else
                {
                    this.filter_days_list.SetItemChecked(i, false);
                }
            }
        }

        // check weekdays only
        private void filter_days_weekday_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.filter_days_list.Items.Count; i++)
            {
                DateTime day = (DateTime)this.filter_days_list.Items[i];
                if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                {
                    this.filter_days_list.SetItemChecked(i, true);
                }
                else
                {
                    this.filter_days_list.SetItemChecked(i, false);
                }
            }
        }

        // Apply filters to selected file
        private void filter_apply_Click(object sender, EventArgs e)
        {
            // get model to filter
            int rowIndex = this.parsedFilesGridView.SelectedRows[0].Index;
            CsvModel data = (CsvModel)this.parsedFilesGridView.Rows[rowIndex].DataBoundItem;
            FilterCollection filterCollection = new FilterCollection();

            // get filter method
            FilterMethod filterMethod = FilterMethod.ALL ;
            if (this.filter_method_all.Checked)
            {
                filterMethod = FilterMethod.ALL;
            }
            else if (this.filter_method_either.Checked)
            {
                filterMethod = FilterMethod.EITHER;
            }
            else if (this.filter_method_none.Checked)
            {
                filterMethod = FilterMethod.NONE;
            }

            // setup time based filter
            if (this.filter_time_enabled.Checked)
            {
                TimeSpan startTime = TimeSpan.Parse(this.filter_time_start.Text);
                TimeSpan endTime = TimeSpan.Parse(this.filter_time_end.Text);

                Filter.Filters.Time timeFilter = new Filter.Filters.Time(
                    startTime, endTime
                );
                filterCollection.Add(timeFilter);
            }

            // setup day based filter
            if (this.filter_days_enabled.Checked)
            {
                List<DateTime> dates = new List<DateTime>();
                foreach (Object day in this.filter_days_list.CheckedItems)
                {
                    dates.Add((DateTime)day);
                }
                Filter.Filters.Day dayFilter = new Filter.Filters.Day(
                    dates
                );
                filterCollection.Add(dayFilter);
            }

            // do filtering
            this.commandManager.addCommand(new FilterCommand(data, filterCollection, filterMethod, this.filter_command_callback));
        }

        private void filter_command_callback(Object result)
        {
            this.parsedFiles.Add(result as CsvModel);
        }
        #endregion

        #region Import events
        /**
         * Opens a list of files, trys to parse them and add them to the parsed-files list.
         * If parsing of one file fails, the exception will be displayed and the next file
         * will be parsed.
         */
        private void openFileDialog_OpenFiles(object sender, CancelEventArgs e)
        {
            foreach (string filePath in openFileDialog.FileNames)
            {
                this.import_general_files.Text += "\"" + filePath + "\",";
            }
        }

        private void import_general_browse_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void import_general_action_Click(object sender, EventArgs e)
        {
            // parse activity level settings
            int minSedantary = int.Parse(this.import_activity_sedantary.Text);
            int minLight = int.Parse(this.import_activity_light.Text);
            int minModerate = int.Parse(this.import_activity_moderate.Text);
            int minHeavy = int.Parse(this.import_activity_heavy.Text);
            int minVeryHeavy = int.Parse(this.import_activity_veryheavy.Text);

            // iterate over all files to be opend
            foreach (string filePath in openFileDialog.FileNames)
            {
                // Add import to background worker
                this.commandManager.addCommand(
                    new ImportCommand(filePath,
                        minSedantary, minLight, minModerate, minHeavy, minVeryHeavy,
                        this.import_task_finished
                    )
                );
            }
        }

        private void import_task_finished(object result)
        {
            CsvModel model = (CsvModel)result;
            if (model != null)
            {
                this.parsedFiles.Add((CsvModel)result);
            }
        }
        #endregion

        #region Export events
        private void export_function_button_Click(object sender, EventArgs e)
        {
            if (this.parsedFilesGridView.SelectedRows.Count == 0)
            {
                return;
            }

            List<CsvModel> datasets = new List<CsvModel>();
            foreach (DataGridViewRow row in this.parsedFilesGridView.SelectedRows)
            {
                datasets.Add((CsvModel) row.DataBoundItem);
            }

            SelectDataCells selectCellsWindow = new SelectDataCells(datasets, this.export_function_callback);
            selectCellsWindow.Show();            
        }

        private void export_function_callback(Dictionary<CsvModel, SensorData> modelCellSelection)
        {
            if (modelCellSelection.Count == 0)
            {
                return;
            }

            try
            {
                RSettings rSettings = new RSettings();
                rSettings.OutputHeight = int.Parse(this.export_output_height_box.Text);
                rSettings.OutputWidth = int.Parse(this.export_output_width_box.Text);
                rSettings.FilePrefix = this.export_output_prefix_box.Text;
                rSettings.PathToOutput = this.export_ouput_directory_box.Text;
                rSettings.PathToR = this.export_r_path_box.Text;
                rSettings.CopyInvoledFiles = this.export_output_copyall_checkbox.Checked;
                rSettings.CopyROutput = this.export_r_console_checkbox.Checked;
                rSettings.PathToTmp = APP_PATH + "\\Temp\\";
                rSettings.PathToApplication = APP_PATH + "\\";

                Dictionary<String, KeyValuePair<String, Object>> parameters = new Dictionary<string, KeyValuePair<string, object>>();

                foreach (Control element in this.export_parameter_flowlayoutpanel.Controls)
                {
                    if (element is TextBox)
                    {
                        Console.WriteLine(element.Tag.ToString() + ": " + element.Text);
                        parameters.Add(element.Tag.ToString(), new KeyValuePair<string, object>(null, element.Text));
                    }
                }

                RExport.Abstract exportClass = ((RExport.ExportScripts)this.export_function_dropdown.SelectedValue).ToClass();
                exportClass.Datasets = modelCellSelection;
                exportClass.RSettings = rSettings;
                exportClass.Parameters = parameters;
                this.commandManager.addCommand(new ExportCommand(exportClass, this.export_command_callback));
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input in export settings");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void export_command_callback(object result)
        { 
            RExport.Abstract exportClass = (RExport.Abstract) result;
            ShowDirectoryContent imageBrowser = new ShowDirectoryContent(exportClass.RSettings.PathToOutput);
            imageBrowser.Show();
        }

        private void export_r_path_browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = this.selectPathToRDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.export_r_path_box.Text = this.selectPathToRDialog.FileName;
            }
        }

        private void export_output_directorybrowse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = this.exportOutputDirectoryDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.export_ouput_directory_box.Text = this.exportOutputDirectoryDialog.SelectedPath;
            }
        }

        private void export_function_dropdown_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                RExport.Abstract exportClass = ((RExport.ExportScripts)this.export_function_dropdown.SelectedValue).ToClass();
                this.export_parameter_flowlayoutpanel.Controls.Clear();

                foreach (KeyValuePair<String, KeyValuePair<String, Object>> property in exportClass.Parameters)
                {
                    Label pLabel = new Label();
                    pLabel.Text = property.Value.Key;
                    pLabel.Margin = new Padding(7);

                    TextBox pValue = new TextBox();
                    pValue.Tag = property.Key;
                    pValue.Width = 50;
                    if (property.Value.Value != null)
                    {
                        pValue.Text = property.Value.Value.ToString();
                    }

                    this.export_parameter_flowlayoutpanel.Controls.Add(pLabel);
                    this.export_parameter_flowlayoutpanel.Controls.Add(pValue);
                    this.export_parameter_flowlayoutpanel.SetFlowBreak(pValue, true);
                }
            }
            catch { }
        }
        #endregion
    }
}