namespace ActigraphAuswertung
{
    /// <summary>
    /// Application main window.
    /// </summary>
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quickoptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.import_activity_sedantary = new System.Windows.Forms.TextBox();
            this.import_activity_light = new System.Windows.Forms.TextBox();
            this.import_activity_moderate = new System.Windows.Forms.TextBox();
            this.import_activity_heavy = new System.Windows.Forms.TextBox();
            this.import_activity_veryheavy = new System.Windows.Forms.TextBox();
            this.import_activity_sedantary_label = new System.Windows.Forms.Label();
            this.import_activity_veryheavy_label = new System.Windows.Forms.Label();
            this.import_activity_light_label = new System.Windows.Forms.Label();
            this.import_activity_heavy_label = new System.Windows.Forms.Label();
            this.import_activity_moderate_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.import_general_action = new System.Windows.Forms.Button();
            this.import_general_browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.import_general_files = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wearingtotaltimebox = new System.Windows.Forms.Label();
            this.wearingendtimebox = new System.Windows.Forms.Label();
            this.wearingstarttimebox = new System.Windows.Forms.Label();
            this.wearingtotaltimelabel = new System.Windows.Forms.Label();
            this.wearingendtimelabel = new System.Windows.Forms.Label();
            this.wearingstartimelabel = new System.Windows.Forms.Label();
            this.activitylevel_groupbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.activitylevel_sedentary_label = new System.Windows.Forms.Label();
            this.activitylevel_light_label = new System.Windows.Forms.Label();
            this.activitylevel_moderate_label = new System.Windows.Forms.Label();
            this.activitylevel_vigorous_label = new System.Windows.Forms.Label();
            this.activitylevel_veryvigorous_label = new System.Windows.Forms.Label();
            this.activitylevels_collabel_totaltime = new System.Windows.Forms.Label();
            this.activitylevel_veryvigorous_time = new System.Windows.Forms.Label();
            this.activitylevel_vigorous_time = new System.Windows.Forms.Label();
            this.activitylevel_moderate_time = new System.Windows.Forms.Label();
            this.activitylevel_light_time = new System.Windows.Forms.Label();
            this.activitylevel_sedentary_time = new System.Windows.Forms.Label();
            this.activitylevels_collabel_perc = new System.Windows.Forms.Label();
            this.activitylevel_veryvigorous_perc = new System.Windows.Forms.Label();
            this.activitylevel_vigorous_perc = new System.Windows.Forms.Label();
            this.activitylevel_moderate_perc = new System.Windows.Forms.Label();
            this.activitylevel_light_perc = new System.Windows.Forms.Label();
            this.activitylevel_sedentary_perc = new System.Windows.Forms.Label();
            this.activitylevels_collabel_count = new System.Windows.Forms.Label();
            this.activitylevel_veryvigorous_values = new System.Windows.Forms.Label();
            this.activitylevel_vigorous_values = new System.Windows.Forms.Label();
            this.activitylevel_moderate_values = new System.Windows.Forms.Label();
            this.activitylevel_light_values = new System.Windows.Forms.Label();
            this.activitylevel_sedentary_values = new System.Windows.Forms.Label();
            this.activitylevel_veryvigorous_limit = new System.Windows.Forms.Label();
            this.activitylevel_vigorous_limit = new System.Windows.Forms.Label();
            this.activitylevel_moderate_limit = new System.Windows.Forms.Label();
            this.activitylevel_light_limit = new System.Windows.Forms.Label();
            this.activitylevel_sedentary_limit = new System.Windows.Forms.Label();
            this.activitylevels_collabel_limits = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.plot_output_directory_browse_button = new System.Windows.Forms.Button();
            this.plot_output_directory_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.plot_r_script_path_browse_button = new System.Windows.Forms.Button();
            this.plot_rscript_path_box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.plot_filetype_dropdown = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.plot_parameter_dropdown = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.filter_apply = new System.Windows.Forms.Button();
            this.filter_days_none = new System.Windows.Forms.Button();
            this.filter_method_panel = new System.Windows.Forms.Panel();
            this.filter_method_either = new System.Windows.Forms.RadioButton();
            this.filter_method_none = new System.Windows.Forms.RadioButton();
            this.filter_method_all = new System.Windows.Forms.RadioButton();
            this.filter_days_all = new System.Windows.Forms.Button();
            this.filter_time_start = new System.Windows.Forms.TextBox();
            this.filter_days_weekday = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.filter_days_weekend = new System.Windows.Forms.Button();
            this.filter_time_end = new System.Windows.Forms.TextBox();
            this.filter_days_enabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filter_days_list = new System.Windows.Forms.CheckedListBox();
            this.filter_time_enabled = new System.Windows.Forms.CheckBox();
            this.quickoptions_export_tab = new System.Windows.Forms.TabPage();
            this.export_parameter_box = new System.Windows.Forms.GroupBox();
            this.export_parameter_flowlayoutpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.export_r_box = new System.Windows.Forms.GroupBox();
            this.export_r_console_checkbox = new System.Windows.Forms.CheckBox();
            this.export_r_console_label = new System.Windows.Forms.Label();
            this.export_r_path_browse_button = new System.Windows.Forms.Button();
            this.export_r_path_box = new System.Windows.Forms.TextBox();
            this.export_r_path_label = new System.Windows.Forms.Label();
            this.export_output_box = new System.Windows.Forms.GroupBox();
            this.export_output_copyall_checkbox = new System.Windows.Forms.CheckBox();
            this.export_output_copyall_label = new System.Windows.Forms.Label();
            this.export_output_directorybrowse_button = new System.Windows.Forms.Button();
            this.export_output_directory_label = new System.Windows.Forms.Label();
            this.export_ouput_directory_box = new System.Windows.Forms.TextBox();
            this.export_output_prefix_box = new System.Windows.Forms.TextBox();
            this.export_output_prefix_label = new System.Windows.Forms.Label();
            this.export_output_height_box = new System.Windows.Forms.TextBox();
            this.export_output_width_box = new System.Windows.Forms.TextBox();
            this.export_output_height_label = new System.Windows.Forms.Label();
            this.export_output_width_label = new System.Windows.Forms.Label();
            this.export_function_box = new System.Windows.Forms.GroupBox();
            this.export_function_dropdown = new System.Windows.Forms.ComboBox();
            this.export_function_button = new System.Windows.Forms.Button();
            this.quickoptions_about_tab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parsedFilesGridView = new System.Windows.Forms.DataGridView();
            this.processGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.parsedFileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDailyStartEndtimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPathToRDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportOutputDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectPathToRScriptDialog = new System.Windows.Forms.OpenFileDialog();
            this.plotOutputDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.quickoptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.activitylevel_groupbox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.filter_method_panel.SuspendLayout();
            this.quickoptions_export_tab.SuspendLayout();
            this.export_parameter_box.SuspendLayout();
            this.export_r_box.SuspendLayout();
            this.export_output_box.SuspendLayout();
            this.export_function_box.SuspendLayout();
            this.quickoptions_about_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parsedFilesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processGridView)).BeginInit();
            this.parsedFileContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.parsedFilesGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.processGridView, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 475);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quickoptions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 237);
            this.panel1.TabIndex = 2;
            // 
            // quickoptions
            // 
            this.quickoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quickoptions.Controls.Add(this.tabPage1);
            this.quickoptions.Controls.Add(this.tabPage2);
            this.quickoptions.Controls.Add(this.tabPage4);
            this.quickoptions.Controls.Add(this.tabPage3);
            this.quickoptions.Controls.Add(this.quickoptions_export_tab);
            this.quickoptions.Controls.Add(this.quickoptions_about_tab);
            this.quickoptions.HotTrack = true;
            this.quickoptions.Location = new System.Drawing.Point(0, 3);
            this.quickoptions.Name = "quickoptions";
            this.quickoptions.SelectedIndex = 0;
            this.quickoptions.Size = new System.Drawing.Size(795, 231);
            this.quickoptions.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.quickoptions.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(787, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.import_activity_sedantary);
            this.groupBox3.Controls.Add(this.import_activity_light);
            this.groupBox3.Controls.Add(this.import_activity_moderate);
            this.groupBox3.Controls.Add(this.import_activity_heavy);
            this.groupBox3.Controls.Add(this.import_activity_veryheavy);
            this.groupBox3.Controls.Add(this.import_activity_sedantary_label);
            this.groupBox3.Controls.Add(this.import_activity_veryheavy_label);
            this.groupBox3.Controls.Add(this.import_activity_light_label);
            this.groupBox3.Controls.Add(this.import_activity_heavy_label);
            this.groupBox3.Controls.Add(this.import_activity_moderate_label);
            this.groupBox3.Location = new System.Drawing.Point(281, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 192);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Activity levels (lower limit)";
            // 
            // import_activity_sedantary
            // 
            this.import_activity_sedantary.Location = new System.Drawing.Point(96, 135);
            this.import_activity_sedantary.Name = "import_activity_sedantary";
            this.import_activity_sedantary.Size = new System.Drawing.Size(100, 20);
            this.import_activity_sedantary.TabIndex = 13;
            this.import_activity_sedantary.Text = "0";
            // 
            // import_activity_light
            // 
            this.import_activity_light.Location = new System.Drawing.Point(96, 108);
            this.import_activity_light.Name = "import_activity_light";
            this.import_activity_light.Size = new System.Drawing.Size(100, 20);
            this.import_activity_light.TabIndex = 12;
            this.import_activity_light.Text = "100";
            // 
            // import_activity_moderate
            // 
            this.import_activity_moderate.Location = new System.Drawing.Point(96, 81);
            this.import_activity_moderate.Name = "import_activity_moderate";
            this.import_activity_moderate.Size = new System.Drawing.Size(100, 20);
            this.import_activity_moderate.TabIndex = 11;
            this.import_activity_moderate.Text = "2000";
            // 
            // import_activity_heavy
            // 
            this.import_activity_heavy.Location = new System.Drawing.Point(96, 55);
            this.import_activity_heavy.Name = "import_activity_heavy";
            this.import_activity_heavy.Size = new System.Drawing.Size(100, 20);
            this.import_activity_heavy.TabIndex = 10;
            this.import_activity_heavy.Text = "5750";
            // 
            // import_activity_veryheavy
            // 
            this.import_activity_veryheavy.Location = new System.Drawing.Point(96, 29);
            this.import_activity_veryheavy.Name = "import_activity_veryheavy";
            this.import_activity_veryheavy.Size = new System.Drawing.Size(100, 20);
            this.import_activity_veryheavy.TabIndex = 9;
            this.import_activity_veryheavy.Text = "7500";
            // 
            // import_activity_sedantary_label
            // 
            this.import_activity_sedantary_label.AutoSize = true;
            this.import_activity_sedantary_label.Location = new System.Drawing.Point(17, 138);
            this.import_activity_sedantary_label.Name = "import_activity_sedantary_label";
            this.import_activity_sedantary_label.Size = new System.Drawing.Size(55, 13);
            this.import_activity_sedantary_label.TabIndex = 8;
            this.import_activity_sedantary_label.Text = "Sedantary";
            // 
            // import_activity_veryheavy_label
            // 
            this.import_activity_veryheavy_label.AutoSize = true;
            this.import_activity_veryheavy_label.Location = new System.Drawing.Point(17, 32);
            this.import_activity_veryheavy_label.Name = "import_activity_veryheavy_label";
            this.import_activity_veryheavy_label.Size = new System.Drawing.Size(60, 13);
            this.import_activity_veryheavy_label.TabIndex = 4;
            this.import_activity_veryheavy_label.Text = "Very heavy";
            // 
            // import_activity_light_label
            // 
            this.import_activity_light_label.AutoSize = true;
            this.import_activity_light_label.Location = new System.Drawing.Point(17, 111);
            this.import_activity_light_label.Name = "import_activity_light_label";
            this.import_activity_light_label.Size = new System.Drawing.Size(30, 13);
            this.import_activity_light_label.TabIndex = 7;
            this.import_activity_light_label.Text = "Light";
            // 
            // import_activity_heavy_label
            // 
            this.import_activity_heavy_label.AutoSize = true;
            this.import_activity_heavy_label.Location = new System.Drawing.Point(17, 58);
            this.import_activity_heavy_label.Name = "import_activity_heavy_label";
            this.import_activity_heavy_label.Size = new System.Drawing.Size(38, 13);
            this.import_activity_heavy_label.TabIndex = 5;
            this.import_activity_heavy_label.Text = "Heavy";
            // 
            // import_activity_moderate_label
            // 
            this.import_activity_moderate_label.AutoSize = true;
            this.import_activity_moderate_label.Location = new System.Drawing.Point(17, 84);
            this.import_activity_moderate_label.Name = "import_activity_moderate_label";
            this.import_activity_moderate_label.Size = new System.Drawing.Size(52, 13);
            this.import_activity_moderate_label.TabIndex = 6;
            this.import_activity_moderate_label.Text = "Moderate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.import_general_action);
            this.groupBox1.Controls.Add(this.import_general_browse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.import_general_files);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // import_general_action
            // 
            this.import_general_action.Location = new System.Drawing.Point(76, 74);
            this.import_general_action.Name = "import_general_action";
            this.import_general_action.Size = new System.Drawing.Size(75, 23);
            this.import_general_action.TabIndex = 3;
            this.import_general_action.Text = "Import";
            this.import_general_action.UseVisualStyleBackColor = true;
            this.import_general_action.Click += new System.EventHandler(this.import_general_action_Click);
            // 
            // import_general_browse
            // 
            this.import_general_browse.Location = new System.Drawing.Point(227, 30);
            this.import_general_browse.Name = "import_general_browse";
            this.import_general_browse.Size = new System.Drawing.Size(25, 23);
            this.import_general_browse.TabIndex = 2;
            this.import_general_browse.Text = "...";
            this.import_general_browse.UseVisualStyleBackColor = true;
            this.import_general_browse.Click += new System.EventHandler(this.import_general_browse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File";
            // 
            // import_general_files
            // 
            this.import_general_files.Location = new System.Drawing.Point(76, 30);
            this.import_general_files.Name = "import_general_files";
            this.import_general_files.Size = new System.Drawing.Size(145, 20);
            this.import_general_files.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.activitylevel_groupbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(787, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File summary";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wearingtotaltimebox);
            this.groupBox2.Controls.Add(this.wearingendtimebox);
            this.groupBox2.Controls.Add(this.wearingstarttimebox);
            this.groupBox2.Controls.Add(this.wearingtotaltimelabel);
            this.groupBox2.Controls.Add(this.wearingendtimelabel);
            this.groupBox2.Controls.Add(this.wearingstartimelabel);
            this.groupBox2.Location = new System.Drawing.Point(6, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 187);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Times";
            // 
            // wearingtotaltimebox
            // 
            this.wearingtotaltimebox.AutoSize = true;
            this.wearingtotaltimebox.Location = new System.Drawing.Point(112, 76);
            this.wearingtotaltimebox.Name = "wearingtotaltimebox";
            this.wearingtotaltimebox.Size = new System.Drawing.Size(0, 13);
            this.wearingtotaltimebox.TabIndex = 33;
            // 
            // wearingendtimebox
            // 
            this.wearingendtimebox.AutoSize = true;
            this.wearingendtimebox.Location = new System.Drawing.Point(112, 49);
            this.wearingendtimebox.Name = "wearingendtimebox";
            this.wearingendtimebox.Size = new System.Drawing.Size(0, 13);
            this.wearingendtimebox.TabIndex = 32;
            // 
            // wearingstarttimebox
            // 
            this.wearingstarttimebox.AutoSize = true;
            this.wearingstarttimebox.Location = new System.Drawing.Point(112, 23);
            this.wearingstarttimebox.Name = "wearingstarttimebox";
            this.wearingstarttimebox.Size = new System.Drawing.Size(0, 13);
            this.wearingstarttimebox.TabIndex = 31;
            // 
            // wearingtotaltimelabel
            // 
            this.wearingtotaltimelabel.AutoSize = true;
            this.wearingtotaltimelabel.Location = new System.Drawing.Point(10, 76);
            this.wearingtotaltimelabel.Name = "wearingtotaltimelabel";
            this.wearingtotaltimelabel.Size = new System.Drawing.Size(90, 13);
            this.wearingtotaltimelabel.TabIndex = 30;
            this.wearingtotaltimelabel.Text = "Total Active Time";
            // 
            // wearingendtimelabel
            // 
            this.wearingendtimelabel.AutoSize = true;
            this.wearingendtimelabel.Location = new System.Drawing.Point(10, 49);
            this.wearingendtimelabel.Name = "wearingendtimelabel";
            this.wearingendtimelabel.Size = new System.Drawing.Size(77, 13);
            this.wearingendtimelabel.TabIndex = 29;
            this.wearingendtimelabel.Text = "Avg. End Time";
            // 
            // wearingstartimelabel
            // 
            this.wearingstartimelabel.AutoSize = true;
            this.wearingstartimelabel.Location = new System.Drawing.Point(10, 23);
            this.wearingstartimelabel.Name = "wearingstartimelabel";
            this.wearingstartimelabel.Size = new System.Drawing.Size(80, 13);
            this.wearingstartimelabel.TabIndex = 28;
            this.wearingstartimelabel.Text = "Avg. Start Time";
            // 
            // activitylevel_groupbox
            // 
            this.activitylevel_groupbox.Controls.Add(this.tableLayoutPanel2);
            this.activitylevel_groupbox.Location = new System.Drawing.Point(220, 11);
            this.activitylevel_groupbox.Name = "activitylevel_groupbox";
            this.activitylevel_groupbox.Size = new System.Drawing.Size(444, 187);
            this.activitylevel_groupbox.TabIndex = 55;
            this.activitylevel_groupbox.TabStop = false;
            this.activitylevel_groupbox.Text = "Activity levels";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_sedentary_label, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_light_label, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_moderate_label, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_vigorous_label, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_veryvigorous_label, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.activitylevels_collabel_totaltime, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_veryvigorous_time, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_vigorous_time, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_moderate_time, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_light_time, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_sedentary_time, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.activitylevels_collabel_perc, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_veryvigorous_perc, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_vigorous_perc, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_moderate_perc, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_light_perc, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_sedentary_perc, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.activitylevels_collabel_count, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_veryvigorous_values, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_vigorous_values, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_moderate_values, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_light_values, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_sedentary_values, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_veryvigorous_limit, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_vigorous_limit, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_moderate_limit, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_light_limit, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.activitylevel_sedentary_limit, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.activitylevels_collabel_limits, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(432, 158);
            this.tableLayoutPanel2.TabIndex = 60;
            // 
            // activitylevel_sedentary_label
            // 
            this.activitylevel_sedentary_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activitylevel_sedentary_label.AutoSize = true;
            this.activitylevel_sedentary_label.Location = new System.Drawing.Point(4, 139);
            this.activitylevel_sedentary_label.Name = "activitylevel_sedentary_label";
            this.activitylevel_sedentary_label.Size = new System.Drawing.Size(55, 13);
            this.activitylevel_sedentary_label.TabIndex = 51;
            this.activitylevel_sedentary_label.Text = "Sedentary";
            // 
            // activitylevel_light_label
            // 
            this.activitylevel_light_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activitylevel_light_label.AutoSize = true;
            this.activitylevel_light_label.Location = new System.Drawing.Point(4, 115);
            this.activitylevel_light_label.Name = "activitylevel_light_label";
            this.activitylevel_light_label.Size = new System.Drawing.Size(30, 13);
            this.activitylevel_light_label.TabIndex = 50;
            this.activitylevel_light_label.Text = "Light";
            // 
            // activitylevel_moderate_label
            // 
            this.activitylevel_moderate_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activitylevel_moderate_label.AutoSize = true;
            this.activitylevel_moderate_label.Location = new System.Drawing.Point(4, 92);
            this.activitylevel_moderate_label.Name = "activitylevel_moderate_label";
            this.activitylevel_moderate_label.Size = new System.Drawing.Size(52, 13);
            this.activitylevel_moderate_label.TabIndex = 52;
            this.activitylevel_moderate_label.Text = "Moderate";
            // 
            // activitylevel_vigorous_label
            // 
            this.activitylevel_vigorous_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activitylevel_vigorous_label.AutoSize = true;
            this.activitylevel_vigorous_label.Location = new System.Drawing.Point(4, 69);
            this.activitylevel_vigorous_label.Name = "activitylevel_vigorous_label";
            this.activitylevel_vigorous_label.Size = new System.Drawing.Size(48, 13);
            this.activitylevel_vigorous_label.TabIndex = 53;
            this.activitylevel_vigorous_label.Text = "Vigorous";
            // 
            // activitylevel_veryvigorous_label
            // 
            this.activitylevel_veryvigorous_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activitylevel_veryvigorous_label.AutoSize = true;
            this.activitylevel_veryvigorous_label.Location = new System.Drawing.Point(4, 46);
            this.activitylevel_veryvigorous_label.Name = "activitylevel_veryvigorous_label";
            this.activitylevel_veryvigorous_label.Size = new System.Drawing.Size(84, 13);
            this.activitylevel_veryvigorous_label.TabIndex = 54;
            this.activitylevel_veryvigorous_label.Text = "Very vigorous";
            // 
            // activitylevels_collabel_totaltime
            // 
            this.activitylevels_collabel_totaltime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activitylevels_collabel_totaltime.AutoSize = true;
            this.activitylevels_collabel_totaltime.Location = new System.Drawing.Point(370, 14);
            this.activitylevels_collabel_totaltime.Name = "activitylevels_collabel_totaltime";
            this.activitylevels_collabel_totaltime.Size = new System.Drawing.Size(53, 13);
            this.activitylevels_collabel_totaltime.TabIndex = 63;
            this.activitylevels_collabel_totaltime.Text = "Total time";
            // 
            // activitylevel_veryvigorous_time
            // 
            this.activitylevel_veryvigorous_time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_veryvigorous_time.AutoSize = true;
            this.activitylevel_veryvigorous_time.Location = new System.Drawing.Point(394, 46);
            this.activitylevel_veryvigorous_time.Name = "activitylevel_veryvigorous_time";
            this.activitylevel_veryvigorous_time.Size = new System.Drawing.Size(34, 13);
            this.activitylevel_veryvigorous_time.TabIndex = 40;
            this.activitylevel_veryvigorous_time.Text = "00:00";
            // 
            // activitylevel_vigorous_time
            // 
            this.activitylevel_vigorous_time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_vigorous_time.AutoSize = true;
            this.activitylevel_vigorous_time.Location = new System.Drawing.Point(394, 69);
            this.activitylevel_vigorous_time.Name = "activitylevel_vigorous_time";
            this.activitylevel_vigorous_time.Size = new System.Drawing.Size(34, 13);
            this.activitylevel_vigorous_time.TabIndex = 39;
            this.activitylevel_vigorous_time.Text = "00:00";
            // 
            // activitylevel_moderate_time
            // 
            this.activitylevel_moderate_time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_moderate_time.AutoSize = true;
            this.activitylevel_moderate_time.Location = new System.Drawing.Point(394, 92);
            this.activitylevel_moderate_time.Name = "activitylevel_moderate_time";
            this.activitylevel_moderate_time.Size = new System.Drawing.Size(34, 13);
            this.activitylevel_moderate_time.TabIndex = 38;
            this.activitylevel_moderate_time.Text = "00:00";
            // 
            // activitylevel_light_time
            // 
            this.activitylevel_light_time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_light_time.AutoSize = true;
            this.activitylevel_light_time.Location = new System.Drawing.Point(394, 115);
            this.activitylevel_light_time.Name = "activitylevel_light_time";
            this.activitylevel_light_time.Size = new System.Drawing.Size(34, 13);
            this.activitylevel_light_time.TabIndex = 36;
            this.activitylevel_light_time.Text = "00:00";
            // 
            // activitylevel_sedentary_time
            // 
            this.activitylevel_sedentary_time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_sedentary_time.AutoSize = true;
            this.activitylevel_sedentary_time.Location = new System.Drawing.Point(394, 139);
            this.activitylevel_sedentary_time.Name = "activitylevel_sedentary_time";
            this.activitylevel_sedentary_time.Size = new System.Drawing.Size(34, 13);
            this.activitylevel_sedentary_time.TabIndex = 37;
            this.activitylevel_sedentary_time.Text = "00:00";
            // 
            // activitylevels_collabel_perc
            // 
            this.activitylevels_collabel_perc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activitylevels_collabel_perc.AutoSize = true;
            this.activitylevels_collabel_perc.Location = new System.Drawing.Point(297, 14);
            this.activitylevels_collabel_perc.Name = "activitylevels_collabel_perc";
            this.activitylevels_collabel_perc.Size = new System.Drawing.Size(62, 13);
            this.activitylevels_collabel_perc.TabIndex = 62;
            this.activitylevels_collabel_perc.Text = "Percentage";
            // 
            // activitylevel_veryvigorous_perc
            // 
            this.activitylevel_veryvigorous_perc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_veryvigorous_perc.AutoSize = true;
            this.activitylevel_veryvigorous_perc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitylevel_veryvigorous_perc.Location = new System.Drawing.Point(332, 46);
            this.activitylevel_veryvigorous_perc.Name = "activitylevel_veryvigorous_perc";
            this.activitylevel_veryvigorous_perc.Size = new System.Drawing.Size(27, 13);
            this.activitylevel_veryvigorous_perc.TabIndex = 42;
            this.activitylevel_veryvigorous_perc.Text = "0 %";
            // 
            // activitylevel_vigorous_perc
            // 
            this.activitylevel_vigorous_perc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_vigorous_perc.AutoSize = true;
            this.activitylevel_vigorous_perc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitylevel_vigorous_perc.Location = new System.Drawing.Point(332, 69);
            this.activitylevel_vigorous_perc.Name = "activitylevel_vigorous_perc";
            this.activitylevel_vigorous_perc.Size = new System.Drawing.Size(27, 13);
            this.activitylevel_vigorous_perc.TabIndex = 43;
            this.activitylevel_vigorous_perc.Text = "0 %";
            // 
            // activitylevel_moderate_perc
            // 
            this.activitylevel_moderate_perc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_moderate_perc.AutoSize = true;
            this.activitylevel_moderate_perc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitylevel_moderate_perc.Location = new System.Drawing.Point(332, 92);
            this.activitylevel_moderate_perc.Name = "activitylevel_moderate_perc";
            this.activitylevel_moderate_perc.Size = new System.Drawing.Size(27, 13);
            this.activitylevel_moderate_perc.TabIndex = 44;
            this.activitylevel_moderate_perc.Text = "0 %";
            // 
            // activitylevel_light_perc
            // 
            this.activitylevel_light_perc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_light_perc.AutoSize = true;
            this.activitylevel_light_perc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitylevel_light_perc.Location = new System.Drawing.Point(332, 115);
            this.activitylevel_light_perc.Name = "activitylevel_light_perc";
            this.activitylevel_light_perc.Size = new System.Drawing.Size(27, 13);
            this.activitylevel_light_perc.TabIndex = 45;
            this.activitylevel_light_perc.Text = "0 %";
            // 
            // activitylevel_sedentary_perc
            // 
            this.activitylevel_sedentary_perc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_sedentary_perc.AutoSize = true;
            this.activitylevel_sedentary_perc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitylevel_sedentary_perc.Location = new System.Drawing.Point(332, 139);
            this.activitylevel_sedentary_perc.Name = "activitylevel_sedentary_perc";
            this.activitylevel_sedentary_perc.Size = new System.Drawing.Size(27, 13);
            this.activitylevel_sedentary_perc.TabIndex = 46;
            this.activitylevel_sedentary_perc.Text = "0 %";
            // 
            // activitylevels_collabel_count
            // 
            this.activitylevels_collabel_count.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activitylevels_collabel_count.AutoSize = true;
            this.activitylevels_collabel_count.Location = new System.Drawing.Point(183, 8);
            this.activitylevels_collabel_count.Name = "activitylevels_collabel_count";
            this.activitylevels_collabel_count.Size = new System.Drawing.Size(89, 26);
            this.activitylevels_collabel_count.TabIndex = 61;
            this.activitylevels_collabel_count.Text = "Grouped count / Absolute count";
            // 
            // activitylevel_veryvigorous_values
            // 
            this.activitylevel_veryvigorous_values.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_veryvigorous_values.AutoSize = true;
            this.activitylevel_veryvigorous_values.Location = new System.Drawing.Point(260, 46);
            this.activitylevel_veryvigorous_values.Name = "activitylevel_veryvigorous_values";
            this.activitylevel_veryvigorous_values.Size = new System.Drawing.Size(30, 13);
            this.activitylevel_veryvigorous_values.TabIndex = 55;
            this.activitylevel_veryvigorous_values.Text = "0 / 0";
            this.activitylevel_veryvigorous_values.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // activitylevel_vigorous_values
            // 
            this.activitylevel_vigorous_values.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_vigorous_values.AutoSize = true;
            this.activitylevel_vigorous_values.Location = new System.Drawing.Point(260, 69);
            this.activitylevel_vigorous_values.Name = "activitylevel_vigorous_values";
            this.activitylevel_vigorous_values.Size = new System.Drawing.Size(30, 13);
            this.activitylevel_vigorous_values.TabIndex = 56;
            this.activitylevel_vigorous_values.Text = "0 / 0";
            this.activitylevel_vigorous_values.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // activitylevel_moderate_values
            // 
            this.activitylevel_moderate_values.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_moderate_values.AutoSize = true;
            this.activitylevel_moderate_values.Location = new System.Drawing.Point(260, 92);
            this.activitylevel_moderate_values.Name = "activitylevel_moderate_values";
            this.activitylevel_moderate_values.Size = new System.Drawing.Size(30, 13);
            this.activitylevel_moderate_values.TabIndex = 57;
            this.activitylevel_moderate_values.Text = "0 / 0";
            this.activitylevel_moderate_values.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // activitylevel_light_values
            // 
            this.activitylevel_light_values.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_light_values.AutoSize = true;
            this.activitylevel_light_values.Location = new System.Drawing.Point(260, 115);
            this.activitylevel_light_values.Name = "activitylevel_light_values";
            this.activitylevel_light_values.Size = new System.Drawing.Size(30, 13);
            this.activitylevel_light_values.TabIndex = 58;
            this.activitylevel_light_values.Text = "0 / 0";
            this.activitylevel_light_values.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // activitylevel_sedentary_values
            // 
            this.activitylevel_sedentary_values.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_sedentary_values.AutoSize = true;
            this.activitylevel_sedentary_values.Location = new System.Drawing.Point(260, 139);
            this.activitylevel_sedentary_values.Name = "activitylevel_sedentary_values";
            this.activitylevel_sedentary_values.Size = new System.Drawing.Size(30, 13);
            this.activitylevel_sedentary_values.TabIndex = 59;
            this.activitylevel_sedentary_values.Text = "0 / 0";
            this.activitylevel_sedentary_values.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // activitylevel_veryvigorous_limit
            // 
            this.activitylevel_veryvigorous_limit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_veryvigorous_limit.AutoSize = true;
            this.activitylevel_veryvigorous_limit.Location = new System.Drawing.Point(128, 46);
            this.activitylevel_veryvigorous_limit.Name = "activitylevel_veryvigorous_limit";
            this.activitylevel_veryvigorous_limit.Size = new System.Drawing.Size(31, 13);
            this.activitylevel_veryvigorous_limit.TabIndex = 64;
            this.activitylevel_veryvigorous_limit.Text = "7500";
            // 
            // activitylevel_vigorous_limit
            // 
            this.activitylevel_vigorous_limit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_vigorous_limit.AutoSize = true;
            this.activitylevel_vigorous_limit.Location = new System.Drawing.Point(128, 69);
            this.activitylevel_vigorous_limit.Name = "activitylevel_vigorous_limit";
            this.activitylevel_vigorous_limit.Size = new System.Drawing.Size(31, 13);
            this.activitylevel_vigorous_limit.TabIndex = 65;
            this.activitylevel_vigorous_limit.Text = "5750";
            // 
            // activitylevel_moderate_limit
            // 
            this.activitylevel_moderate_limit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_moderate_limit.AutoSize = true;
            this.activitylevel_moderate_limit.Location = new System.Drawing.Point(128, 92);
            this.activitylevel_moderate_limit.Name = "activitylevel_moderate_limit";
            this.activitylevel_moderate_limit.Size = new System.Drawing.Size(31, 13);
            this.activitylevel_moderate_limit.TabIndex = 66;
            this.activitylevel_moderate_limit.Text = "2000";
            // 
            // activitylevel_light_limit
            // 
            this.activitylevel_light_limit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_light_limit.AutoSize = true;
            this.activitylevel_light_limit.Location = new System.Drawing.Point(134, 115);
            this.activitylevel_light_limit.Name = "activitylevel_light_limit";
            this.activitylevel_light_limit.Size = new System.Drawing.Size(25, 13);
            this.activitylevel_light_limit.TabIndex = 67;
            this.activitylevel_light_limit.Text = "100";
            // 
            // activitylevel_sedentary_limit
            // 
            this.activitylevel_sedentary_limit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activitylevel_sedentary_limit.AutoSize = true;
            this.activitylevel_sedentary_limit.Location = new System.Drawing.Point(146, 139);
            this.activitylevel_sedentary_limit.Name = "activitylevel_sedentary_limit";
            this.activitylevel_sedentary_limit.Size = new System.Drawing.Size(13, 13);
            this.activitylevel_sedentary_limit.TabIndex = 68;
            this.activitylevel_sedentary_limit.Text = "0";
            // 
            // activitylevels_collabel_limits
            // 
            this.activitylevels_collabel_limits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activitylevels_collabel_limits.AutoSize = true;
            this.activitylevels_collabel_limits.Location = new System.Drawing.Point(99, 14);
            this.activitylevels_collabel_limits.Name = "activitylevels_collabel_limits";
            this.activitylevels_collabel_limits.Size = new System.Drawing.Size(56, 13);
            this.activitylevels_collabel_limits.TabIndex = 69;
            this.activitylevels_collabel_limits.Text = "Lower limit";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(787, 205);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Plot";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.plot_output_directory_browse_button);
            this.groupBox5.Controls.Add(this.plot_output_directory_box);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.plot_r_script_path_browse_button);
            this.groupBox5.Controls.Add(this.plot_rscript_path_box);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(243, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(508, 188);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "R-Statistics options";
            // 
            // plot_output_directory_browse_button
            // 
            this.plot_output_directory_browse_button.Location = new System.Drawing.Point(474, 82);
            this.plot_output_directory_browse_button.Name = "plot_output_directory_browse_button";
            this.plot_output_directory_browse_button.Size = new System.Drawing.Size(24, 23);
            this.plot_output_directory_browse_button.TabIndex = 8;
            this.plot_output_directory_browse_button.Text = "...";
            this.plot_output_directory_browse_button.UseVisualStyleBackColor = true;
            this.plot_output_directory_browse_button.Click += new System.EventHandler(this.plot_output_directory_browse_button_Click);
            // 
            // plot_output_directory_box
            // 
            this.plot_output_directory_box.Location = new System.Drawing.Point(107, 84);
            this.plot_output_directory_box.Name = "plot_output_directory_box";
            this.plot_output_directory_box.Size = new System.Drawing.Size(340, 20);
            this.plot_output_directory_box.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Output directory";
            // 
            // plot_r_script_path_browse_button
            // 
            this.plot_r_script_path_browse_button.Location = new System.Drawing.Point(474, 27);
            this.plot_r_script_path_browse_button.Name = "plot_r_script_path_browse_button";
            this.plot_r_script_path_browse_button.Size = new System.Drawing.Size(24, 23);
            this.plot_r_script_path_browse_button.TabIndex = 2;
            this.plot_r_script_path_browse_button.Text = "...";
            this.plot_r_script_path_browse_button.UseVisualStyleBackColor = true;
            this.plot_r_script_path_browse_button.Click += new System.EventHandler(this.plot_r_script_path_browse_button_Click);
            // 
            // plot_rscript_path_box
            // 
            this.plot_rscript_path_box.Location = new System.Drawing.Point(107, 29);
            this.plot_rscript_path_box.Name = "plot_rscript_path_box";
            this.plot_rscript_path_box.Size = new System.Drawing.Size(340, 20);
            this.plot_rscript_path_box.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Path to Rscript.exe";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.plot_filetype_dropdown);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.plot_parameter_dropdown);
            this.groupBox4.Location = new System.Drawing.Point(5, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 120);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameter";
            // 
            // plot_filetype_dropdown
            // 
            this.plot_filetype_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot_filetype_dropdown.FormattingEnabled = true;
            this.plot_filetype_dropdown.Items.AddRange(new object[] {
            "png",
            "jpeg",
            "bmp",
            "pdf"});
            this.plot_filetype_dropdown.Location = new System.Drawing.Point(10, 50);
            this.plot_filetype_dropdown.Name = "plot_filetype_dropdown";
            this.plot_filetype_dropdown.Size = new System.Drawing.Size(121, 21);
            this.plot_filetype_dropdown.TabIndex = 9;
            this.plot_filetype_dropdown.Tag = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Plot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.plot);
            // 
            // plot_parameter_dropdown
            // 
            this.plot_parameter_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plot_parameter_dropdown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.plot_parameter_dropdown.Items.AddRange(new object[] {
            "Steps",
            "VMU",
            "X",
            "Y",
            "Z"});
            this.plot_parameter_dropdown.Location = new System.Drawing.Point(10, 20);
            this.plot_parameter_dropdown.Name = "plot_parameter_dropdown";
            this.plot_parameter_dropdown.Size = new System.Drawing.Size(121, 21);
            this.plot_parameter_dropdown.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.filter_apply);
            this.tabPage3.Controls.Add(this.filter_days_none);
            this.tabPage3.Controls.Add(this.filter_method_panel);
            this.tabPage3.Controls.Add(this.filter_days_all);
            this.tabPage3.Controls.Add(this.filter_time_start);
            this.tabPage3.Controls.Add(this.filter_days_weekday);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.filter_days_weekend);
            this.tabPage3.Controls.Add(this.filter_time_end);
            this.tabPage3.Controls.Add(this.filter_days_enabled);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.filter_days_list);
            this.tabPage3.Controls.Add(this.filter_time_enabled);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(787, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cut data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Apply with filter.jar and Method=all";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.filter_with_jar);
            // 
            // filter_apply
            // 
            this.filter_apply.Enabled = false;
            this.filter_apply.Location = new System.Drawing.Point(401, 49);
            this.filter_apply.Name = "filter_apply";
            this.filter_apply.Size = new System.Drawing.Size(100, 23);
            this.filter_apply.TabIndex = 23;
            this.filter_apply.Text = "Apply";
            this.filter_apply.UseVisualStyleBackColor = true;
            this.filter_apply.Click += new System.EventHandler(this.filter_apply_Click);
            // 
            // filter_days_none
            // 
            this.filter_days_none.Location = new System.Drawing.Point(246, 134);
            this.filter_days_none.Name = "filter_days_none";
            this.filter_days_none.Size = new System.Drawing.Size(75, 23);
            this.filter_days_none.TabIndex = 22;
            this.filter_days_none.Text = "None";
            this.filter_days_none.UseVisualStyleBackColor = true;
            this.filter_days_none.Click += new System.EventHandler(this.filter_days_none_Click);
            // 
            // filter_method_panel
            // 
            this.filter_method_panel.Controls.Add(this.filter_method_either);
            this.filter_method_panel.Controls.Add(this.filter_method_none);
            this.filter_method_panel.Controls.Add(this.filter_method_all);
            this.filter_method_panel.Location = new System.Drawing.Point(401, 15);
            this.filter_method_panel.Name = "filter_method_panel";
            this.filter_method_panel.Size = new System.Drawing.Size(191, 25);
            this.filter_method_panel.TabIndex = 4;
            // 
            // filter_method_either
            // 
            this.filter_method_either.AutoSize = true;
            this.filter_method_either.Location = new System.Drawing.Point(56, 4);
            this.filter_method_either.Name = "filter_method_either";
            this.filter_method_either.Size = new System.Drawing.Size(52, 17);
            this.filter_method_either.TabIndex = 2;
            this.filter_method_either.TabStop = true;
            this.filter_method_either.Text = "Either";
            this.filter_method_either.UseVisualStyleBackColor = true;
            // 
            // filter_method_none
            // 
            this.filter_method_none.AutoSize = true;
            this.filter_method_none.Location = new System.Drawing.Point(114, 4);
            this.filter_method_none.Name = "filter_method_none";
            this.filter_method_none.Size = new System.Drawing.Size(51, 17);
            this.filter_method_none.TabIndex = 1;
            this.filter_method_none.TabStop = true;
            this.filter_method_none.Text = "None";
            this.filter_method_none.UseVisualStyleBackColor = true;
            // 
            // filter_method_all
            // 
            this.filter_method_all.AutoSize = true;
            this.filter_method_all.Location = new System.Drawing.Point(4, 4);
            this.filter_method_all.Name = "filter_method_all";
            this.filter_method_all.Size = new System.Drawing.Size(36, 17);
            this.filter_method_all.TabIndex = 0;
            this.filter_method_all.TabStop = true;
            this.filter_method_all.Text = "All";
            this.filter_method_all.UseVisualStyleBackColor = true;
            // 
            // filter_days_all
            // 
            this.filter_days_all.Location = new System.Drawing.Point(246, 105);
            this.filter_days_all.Name = "filter_days_all";
            this.filter_days_all.Size = new System.Drawing.Size(75, 23);
            this.filter_days_all.TabIndex = 21;
            this.filter_days_all.Text = "All";
            this.filter_days_all.UseVisualStyleBackColor = true;
            this.filter_days_all.Click += new System.EventHandler(this.filter_days_all_Click);
            // 
            // filter_time_start
            // 
            this.filter_time_start.Location = new System.Drawing.Point(85, 18);
            this.filter_time_start.Name = "filter_time_start";
            this.filter_time_start.Size = new System.Drawing.Size(100, 20);
            this.filter_time_start.TabIndex = 10;
            // 
            // filter_days_weekday
            // 
            this.filter_days_weekday.Location = new System.Drawing.Point(246, 76);
            this.filter_days_weekday.Name = "filter_days_weekday";
            this.filter_days_weekday.Size = new System.Drawing.Size(75, 23);
            this.filter_days_weekday.TabIndex = 20;
            this.filter_days_weekday.Text = "Weekdays";
            this.filter_days_weekday.UseVisualStyleBackColor = true;
            this.filter_days_weekday.Click += new System.EventHandler(this.filter_days_weekday_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "to";
            // 
            // filter_days_weekend
            // 
            this.filter_days_weekend.Location = new System.Drawing.Point(246, 47);
            this.filter_days_weekend.Name = "filter_days_weekend";
            this.filter_days_weekend.Size = new System.Drawing.Size(75, 23);
            this.filter_days_weekend.TabIndex = 19;
            this.filter_days_weekend.Text = "Weekends";
            this.filter_days_weekend.UseVisualStyleBackColor = true;
            this.filter_days_weekend.Click += new System.EventHandler(this.filter_days_weekend_Click);
            // 
            // filter_time_end
            // 
            this.filter_time_end.Location = new System.Drawing.Point(213, 17);
            this.filter_time_end.Name = "filter_time_end";
            this.filter_time_end.Size = new System.Drawing.Size(100, 20);
            this.filter_time_end.TabIndex = 12;
            // 
            // filter_days_enabled
            // 
            this.filter_days_enabled.AutoSize = true;
            this.filter_days_enabled.Location = new System.Drawing.Point(10, 46);
            this.filter_days_enabled.Name = "filter_days_enabled";
            this.filter_days_enabled.Size = new System.Drawing.Size(50, 17);
            this.filter_days_enabled.TabIndex = 18;
            this.filter_days_enabled.Text = "Days";
            this.filter_days_enabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Method";
            // 
            // filter_days_list
            // 
            this.filter_days_list.FormattingEnabled = true;
            this.filter_days_list.Location = new System.Drawing.Point(85, 47);
            this.filter_days_list.Name = "filter_days_list";
            this.filter_days_list.Size = new System.Drawing.Size(155, 94);
            this.filter_days_list.TabIndex = 17;
            // 
            // filter_time_enabled
            // 
            this.filter_time_enabled.AutoSize = true;
            this.filter_time_enabled.Location = new System.Drawing.Point(10, 18);
            this.filter_time_enabled.Name = "filter_time_enabled";
            this.filter_time_enabled.Size = new System.Drawing.Size(49, 17);
            this.filter_time_enabled.TabIndex = 16;
            this.filter_time_enabled.Text = "Time";
            this.filter_time_enabled.UseVisualStyleBackColor = true;
            // 
            // quickoptions_export_tab
            // 
            this.quickoptions_export_tab.Controls.Add(this.export_parameter_box);
            this.quickoptions_export_tab.Controls.Add(this.export_r_box);
            this.quickoptions_export_tab.Controls.Add(this.export_output_box);
            this.quickoptions_export_tab.Controls.Add(this.export_function_box);
            this.quickoptions_export_tab.Location = new System.Drawing.Point(4, 22);
            this.quickoptions_export_tab.Name = "quickoptions_export_tab";
            this.quickoptions_export_tab.Padding = new System.Windows.Forms.Padding(3);
            this.quickoptions_export_tab.Size = new System.Drawing.Size(787, 205);
            this.quickoptions_export_tab.TabIndex = 3;
            this.quickoptions_export_tab.Text = "Export";
            this.quickoptions_export_tab.UseVisualStyleBackColor = true;
            // 
            // export_parameter_box
            // 
            this.export_parameter_box.Controls.Add(this.export_parameter_flowlayoutpanel);
            this.export_parameter_box.Location = new System.Drawing.Point(7, 108);
            this.export_parameter_box.Name = "export_parameter_box";
            this.export_parameter_box.Size = new System.Drawing.Size(182, 87);
            this.export_parameter_box.TabIndex = 3;
            this.export_parameter_box.TabStop = false;
            this.export_parameter_box.Text = "Parameter";
            // 
            // export_parameter_flowlayoutpanel
            // 
            this.export_parameter_flowlayoutpanel.AutoScroll = true;
            this.export_parameter_flowlayoutpanel.AutoSize = true;
            this.export_parameter_flowlayoutpanel.Location = new System.Drawing.Point(7, 15);
            this.export_parameter_flowlayoutpanel.Name = "export_parameter_flowlayoutpanel";
            this.export_parameter_flowlayoutpanel.Size = new System.Drawing.Size(169, 66);
            this.export_parameter_flowlayoutpanel.TabIndex = 0;
            // 
            // export_r_box
            // 
            this.export_r_box.Controls.Add(this.export_r_console_checkbox);
            this.export_r_box.Controls.Add(this.export_r_console_label);
            this.export_r_box.Controls.Add(this.export_r_path_browse_button);
            this.export_r_box.Controls.Add(this.export_r_path_box);
            this.export_r_box.Controls.Add(this.export_r_path_label);
            this.export_r_box.Location = new System.Drawing.Point(430, 7);
            this.export_r_box.Name = "export_r_box";
            this.export_r_box.Size = new System.Drawing.Size(200, 188);
            this.export_r_box.TabIndex = 2;
            this.export_r_box.TabStop = false;
            this.export_r_box.Text = "R-Statistics options";
            // 
            // export_r_console_checkbox
            // 
            this.export_r_console_checkbox.AutoSize = true;
            this.export_r_console_checkbox.Location = new System.Drawing.Point(149, 58);
            this.export_r_console_checkbox.Name = "export_r_console_checkbox";
            this.export_r_console_checkbox.Size = new System.Drawing.Size(15, 14);
            this.export_r_console_checkbox.TabIndex = 4;
            this.export_r_console_checkbox.UseVisualStyleBackColor = true;
            // 
            // export_r_console_label
            // 
            this.export_r_console_label.AutoSize = true;
            this.export_r_console_label.Location = new System.Drawing.Point(6, 58);
            this.export_r_console_label.Name = "export_r_console_label";
            this.export_r_console_label.Size = new System.Drawing.Size(117, 13);
            this.export_r_console_label.TabIndex = 3;
            this.export_r_console_label.Text = "Save R output (Debug)";
            // 
            // export_r_path_browse_button
            // 
            this.export_r_path_browse_button.Location = new System.Drawing.Point(170, 27);
            this.export_r_path_browse_button.Name = "export_r_path_browse_button";
            this.export_r_path_browse_button.Size = new System.Drawing.Size(24, 23);
            this.export_r_path_browse_button.TabIndex = 2;
            this.export_r_path_browse_button.Text = "...";
            this.export_r_path_browse_button.UseVisualStyleBackColor = true;
            this.export_r_path_browse_button.Click += new System.EventHandler(this.export_r_path_browse_button_Click);
            // 
            // export_r_path_box
            // 
            this.export_r_path_box.Location = new System.Drawing.Point(64, 29);
            this.export_r_path_box.Name = "export_r_path_box";
            this.export_r_path_box.Size = new System.Drawing.Size(100, 20);
            this.export_r_path_box.TabIndex = 1;
            this.export_r_path_box.Text = "C:\\Program Files\\R\\R-2.9.2\\bin\\R.exe";
            // 
            // export_r_path_label
            // 
            this.export_r_path_label.AutoSize = true;
            this.export_r_path_label.Location = new System.Drawing.Point(6, 32);
            this.export_r_path_label.Name = "export_r_path_label";
            this.export_r_path_label.Size = new System.Drawing.Size(52, 13);
            this.export_r_path_label.TabIndex = 0;
            this.export_r_path_label.Text = "Path to R";
            // 
            // export_output_box
            // 
            this.export_output_box.Controls.Add(this.export_output_copyall_checkbox);
            this.export_output_box.Controls.Add(this.export_output_copyall_label);
            this.export_output_box.Controls.Add(this.export_output_directorybrowse_button);
            this.export_output_box.Controls.Add(this.export_output_directory_label);
            this.export_output_box.Controls.Add(this.export_ouput_directory_box);
            this.export_output_box.Controls.Add(this.export_output_prefix_box);
            this.export_output_box.Controls.Add(this.export_output_prefix_label);
            this.export_output_box.Controls.Add(this.export_output_height_box);
            this.export_output_box.Controls.Add(this.export_output_width_box);
            this.export_output_box.Controls.Add(this.export_output_height_label);
            this.export_output_box.Controls.Add(this.export_output_width_label);
            this.export_output_box.Location = new System.Drawing.Point(195, 7);
            this.export_output_box.Name = "export_output_box";
            this.export_output_box.Size = new System.Drawing.Size(229, 188);
            this.export_output_box.TabIndex = 1;
            this.export_output_box.TabStop = false;
            this.export_output_box.Text = "Graph options";
            // 
            // export_output_copyall_checkbox
            // 
            this.export_output_copyall_checkbox.AutoSize = true;
            this.export_output_copyall_checkbox.Location = new System.Drawing.Point(172, 144);
            this.export_output_copyall_checkbox.Name = "export_output_copyall_checkbox";
            this.export_output_copyall_checkbox.Size = new System.Drawing.Size(15, 14);
            this.export_output_copyall_checkbox.TabIndex = 10;
            this.export_output_copyall_checkbox.UseVisualStyleBackColor = true;
            // 
            // export_output_copyall_label
            // 
            this.export_output_copyall_label.AutoSize = true;
            this.export_output_copyall_label.Location = new System.Drawing.Point(6, 145);
            this.export_output_copyall_label.Name = "export_output_copyall_label";
            this.export_output_copyall_label.Size = new System.Drawing.Size(108, 13);
            this.export_output_copyall_label.TabIndex = 9;
            this.export_output_copyall_label.Text = "Copy all involved files";
            // 
            // export_output_directorybrowse_button
            // 
            this.export_output_directorybrowse_button.Location = new System.Drawing.Point(193, 116);
            this.export_output_directorybrowse_button.Name = "export_output_directorybrowse_button";
            this.export_output_directorybrowse_button.Size = new System.Drawing.Size(26, 23);
            this.export_output_directorybrowse_button.TabIndex = 8;
            this.export_output_directorybrowse_button.Text = "...";
            this.export_output_directorybrowse_button.UseVisualStyleBackColor = true;
            this.export_output_directorybrowse_button.Click += new System.EventHandler(this.export_output_directorybrowse_button_Click);
            // 
            // export_output_directory_label
            // 
            this.export_output_directory_label.AutoSize = true;
            this.export_output_directory_label.Location = new System.Drawing.Point(6, 121);
            this.export_output_directory_label.Name = "export_output_directory_label";
            this.export_output_directory_label.Size = new System.Drawing.Size(82, 13);
            this.export_output_directory_label.TabIndex = 7;
            this.export_output_directory_label.Text = "Output directory";
            // 
            // export_ouput_directory_box
            // 
            this.export_ouput_directory_box.Location = new System.Drawing.Point(87, 118);
            this.export_ouput_directory_box.Name = "export_ouput_directory_box";
            this.export_ouput_directory_box.Size = new System.Drawing.Size(100, 20);
            this.export_ouput_directory_box.TabIndex = 6;
            // 
            // export_output_prefix_box
            // 
            this.export_output_prefix_box.Location = new System.Drawing.Point(87, 94);
            this.export_output_prefix_box.Name = "export_output_prefix_box";
            this.export_output_prefix_box.Size = new System.Drawing.Size(100, 20);
            this.export_output_prefix_box.TabIndex = 5;
            // 
            // export_output_prefix_label
            // 
            this.export_output_prefix_label.AutoSize = true;
            this.export_output_prefix_label.Location = new System.Drawing.Point(6, 97);
            this.export_output_prefix_label.Name = "export_output_prefix_label";
            this.export_output_prefix_label.Size = new System.Drawing.Size(51, 13);
            this.export_output_prefix_label.TabIndex = 4;
            this.export_output_prefix_label.Text = "File prefix";
            // 
            // export_output_height_box
            // 
            this.export_output_height_box.Location = new System.Drawing.Point(87, 55);
            this.export_output_height_box.Name = "export_output_height_box";
            this.export_output_height_box.Size = new System.Drawing.Size(100, 20);
            this.export_output_height_box.TabIndex = 3;
            this.export_output_height_box.Text = "600";
            // 
            // export_output_width_box
            // 
            this.export_output_width_box.Location = new System.Drawing.Point(87, 29);
            this.export_output_width_box.Name = "export_output_width_box";
            this.export_output_width_box.Size = new System.Drawing.Size(100, 20);
            this.export_output_width_box.TabIndex = 2;
            this.export_output_width_box.Text = "800";
            // 
            // export_output_height_label
            // 
            this.export_output_height_label.AutoSize = true;
            this.export_output_height_label.Location = new System.Drawing.Point(6, 58);
            this.export_output_height_label.Name = "export_output_height_label";
            this.export_output_height_label.Size = new System.Drawing.Size(68, 13);
            this.export_output_height_label.TabIndex = 1;
            this.export_output_height_label.Text = "Graph height";
            // 
            // export_output_width_label
            // 
            this.export_output_width_label.AutoSize = true;
            this.export_output_width_label.Location = new System.Drawing.Point(6, 32);
            this.export_output_width_label.Name = "export_output_width_label";
            this.export_output_width_label.Size = new System.Drawing.Size(64, 13);
            this.export_output_width_label.TabIndex = 0;
            this.export_output_width_label.Text = "Graph width";
            // 
            // export_function_box
            // 
            this.export_function_box.Controls.Add(this.export_function_dropdown);
            this.export_function_box.Controls.Add(this.export_function_button);
            this.export_function_box.Location = new System.Drawing.Point(7, 7);
            this.export_function_box.Name = "export_function_box";
            this.export_function_box.Size = new System.Drawing.Size(182, 94);
            this.export_function_box.TabIndex = 0;
            this.export_function_box.TabStop = false;
            this.export_function_box.Text = "Function";
            // 
            // export_function_dropdown
            // 
            this.export_function_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.export_function_dropdown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.export_function_dropdown.Location = new System.Drawing.Point(6, 29);
            this.export_function_dropdown.Name = "export_function_dropdown";
            this.export_function_dropdown.Size = new System.Drawing.Size(121, 21);
            this.export_function_dropdown.TabIndex = 1;
            this.export_function_dropdown.SelectedValueChanged += new System.EventHandler(this.export_function_dropdown_SelectedValueChanged);
            // 
            // export_function_button
            // 
            this.export_function_button.Location = new System.Drawing.Point(52, 58);
            this.export_function_button.Name = "export_function_button";
            this.export_function_button.Size = new System.Drawing.Size(75, 23);
            this.export_function_button.TabIndex = 0;
            this.export_function_button.Text = "Export";
            this.export_function_button.UseVisualStyleBackColor = true;
            this.export_function_button.Click += new System.EventHandler(this.export_function_button_Click);
            // 
            // quickoptions_about_tab
            // 
            this.quickoptions_about_tab.Controls.Add(this.label8);
            this.quickoptions_about_tab.Controls.Add(this.label7);
            this.quickoptions_about_tab.Controls.Add(this.label6);
            this.quickoptions_about_tab.Controls.Add(this.label3);
            this.quickoptions_about_tab.Location = new System.Drawing.Point(4, 22);
            this.quickoptions_about_tab.Name = "quickoptions_about_tab";
            this.quickoptions_about_tab.Padding = new System.Windows.Forms.Padding(3);
            this.quickoptions_about_tab.Size = new System.Drawing.Size(787, 205);
            this.quickoptions_about_tab.TabIndex = 4;
            this.quickoptions_about_tab.Text = "About";
            this.quickoptions_about_tab.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Version 3: Fritz Gerneth";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Version 2: Andreas Gast";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Version 1: Sascha Päppinghaus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ActiGraph Auswertung 3.0";
            // 
            // parsedFilesGridView
            // 
            this.parsedFilesGridView.AllowUserToAddRows = false;
            this.parsedFilesGridView.AllowUserToDeleteRows = false;
            this.parsedFilesGridView.AllowUserToOrderColumns = true;
            this.parsedFilesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parsedFilesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parsedFilesGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parsedFilesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.parsedFilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.parsedFilesGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.parsedFilesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.parsedFilesGridView.Location = new System.Drawing.Point(3, 246);
            this.parsedFilesGridView.Name = "parsedFilesGridView";
            this.parsedFilesGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parsedFilesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.parsedFilesGridView.RowHeadersWidth = 43;
            this.parsedFilesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parsedFilesGridView.Size = new System.Drawing.Size(798, 105);
            this.parsedFilesGridView.TabIndex = 1;
            this.parsedFilesGridView.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.parsedFilesGridView_showContextMenu);
            this.parsedFilesGridView.SelectionChanged += new System.EventHandler(this.parsedFilesGridView_selectionChanged);
            // 
            // processGridView
            // 
            this.processGridView.AllowUserToAddRows = false;
            this.processGridView.AllowUserToDeleteRows = false;
            this.processGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.processGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.processGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processGridView.Location = new System.Drawing.Point(3, 365);
            this.processGridView.Name = "processGridView";
            this.processGridView.ReadOnly = true;
            this.processGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.processGridView.Size = new System.Drawing.Size(798, 107);
            this.processGridView.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.csv";
            this.openFileDialog.Filter = "CSV-Dateien (*.csv)|*.csv";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Bitte wählen Sie alle gewünschten Rohdaten-Dateien (CSV-Format) aus";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_OpenFiles);
            // 
            // parsedFileContextMenu
            // 
            this.parsedFileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDatasetsToolStripMenuItem,
            this.displayDailyStartEndtimesToolStripMenuItem});
            this.parsedFileContextMenu.Name = "parsedFileContextMenu";
            this.parsedFileContextMenu.Size = new System.Drawing.Size(273, 48);
            // 
            // showDatasetsToolStripMenuItem
            // 
            this.showDatasetsToolStripMenuItem.Name = "showDatasetsToolStripMenuItem";
            this.showDatasetsToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.showDatasetsToolStripMenuItem.Text = "Display dataset";
            this.showDatasetsToolStripMenuItem.Click += new System.EventHandler(this.parsedFilesGridView_showParsedFileContent);
            // 
            // displayDailyStartEndtimesToolStripMenuItem
            // 
            this.displayDailyStartEndtimesToolStripMenuItem.Name = "displayDailyStartEndtimesToolStripMenuItem";
            this.displayDailyStartEndtimesToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.displayDailyStartEndtimesToolStripMenuItem.Text = "Display daily daily start and end times";
            this.displayDailyStartEndtimesToolStripMenuItem.Click += new System.EventHandler(this.parsedFilesGridView_showDailyStartEndTimes);
            // 
            // selectPathToRDialog
            // 
            this.selectPathToRDialog.DefaultExt = "exe";
            this.selectPathToRDialog.FileName = "R.exe";
            this.selectPathToRDialog.InitialDirectory = "C:\\Program Files\\R\\R-2.9.2\\bin";
            this.selectPathToRDialog.RestoreDirectory = true;
            // 
            // exportOutputDirectoryDialog
            // 
            this.exportOutputDirectoryDialog.Description = "Output directory for R";
            this.exportOutputDirectoryDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // selectPathToRScriptDialog
            // 
            this.selectPathToRScriptDialog.DefaultExt = "exe";
            this.selectPathToRScriptDialog.FileName = "Rscript.exe";
            this.selectPathToRScriptDialog.InitialDirectory = "C:\\Program Files\\R";
            this.selectPathToRScriptDialog.RestoreDirectory = true;
            this.selectPathToRScriptDialog.Title = "Bitte wählen Sie die Rscript.exe aus";
            // 
            // plotOutputDirectoryDialog
            // 
            this.plotOutputDirectoryDialog.Description = "Output directory for a preview pdf";
            this.plotOutputDirectoryDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 475);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "ActigraphAuswertung";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.quickoptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.activitylevel_groupbox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.filter_method_panel.ResumeLayout(false);
            this.filter_method_panel.PerformLayout();
            this.quickoptions_export_tab.ResumeLayout(false);
            this.export_parameter_box.ResumeLayout(false);
            this.export_parameter_box.PerformLayout();
            this.export_r_box.ResumeLayout(false);
            this.export_r_box.PerformLayout();
            this.export_output_box.ResumeLayout(false);
            this.export_output_box.PerformLayout();
            this.export_function_box.ResumeLayout(false);
            this.quickoptions_about_tab.ResumeLayout(false);
            this.quickoptions_about_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parsedFilesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processGridView)).EndInit();
            this.parsedFileContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView parsedFilesGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label wearingstartimelabel;
        private System.Windows.Forms.Label wearingtotaltimelabel;
        private System.Windows.Forms.Label wearingendtimelabel;
        private System.Windows.Forms.Label activitylevel_sedentary_time;
        private System.Windows.Forms.Label activitylevel_light_time;
        private System.Windows.Forms.Label activitylevel_veryvigorous_time;
        private System.Windows.Forms.Label activitylevel_vigorous_time;
        private System.Windows.Forms.Label activitylevel_moderate_time;
        private System.Windows.Forms.Label activitylevel_sedentary_perc;
        private System.Windows.Forms.Label activitylevel_light_perc;
        private System.Windows.Forms.Label activitylevel_moderate_perc;
        private System.Windows.Forms.Label activitylevel_vigorous_perc;
        private System.Windows.Forms.Label activitylevel_veryvigorous_perc;
        private System.Windows.Forms.Label activitylevel_veryvigorous_label;
        private System.Windows.Forms.Label activitylevel_vigorous_label;
        private System.Windows.Forms.Label activitylevel_moderate_label;
        private System.Windows.Forms.Label activitylevel_sedentary_label;
        private System.Windows.Forms.Label activitylevel_light_label;
        private System.Windows.Forms.GroupBox activitylevel_groupbox;
        private System.Windows.Forms.ContextMenuStrip parsedFileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem showDatasetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayDailyStartEndtimesToolStripMenuItem;
        private System.Windows.Forms.Label activitylevel_sedentary_values;
        private System.Windows.Forms.Label activitylevel_light_values;
        private System.Windows.Forms.Label activitylevel_moderate_values;
        private System.Windows.Forms.Label activitylevel_vigorous_values;
        private System.Windows.Forms.Label activitylevel_veryvigorous_values;
        private System.Windows.Forms.Panel filter_method_panel;
        private System.Windows.Forms.RadioButton filter_method_none;
        private System.Windows.Forms.RadioButton filter_method_all;
        private System.Windows.Forms.RadioButton filter_method_either;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filter_time_end;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filter_time_start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox filter_days_enabled;
        private System.Windows.Forms.CheckedListBox filter_days_list;
        private System.Windows.Forms.CheckBox filter_time_enabled;
        private System.Windows.Forms.Button filter_apply;
        private System.Windows.Forms.Button filter_days_none;
        private System.Windows.Forms.Button filter_days_all;
        private System.Windows.Forms.Button filter_days_weekday;
        private System.Windows.Forms.Button filter_days_weekend;
        private System.Windows.Forms.Label wearingendtimebox;
        private System.Windows.Forms.Label wearingstarttimebox;
        private System.Windows.Forms.Label wearingtotaltimebox;
        private System.Windows.Forms.TabControl quickoptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button import_general_browse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox import_general_files;
        private System.Windows.Forms.Label import_activity_sedantary_label;
        private System.Windows.Forms.Label import_activity_light_label;
        private System.Windows.Forms.Label import_activity_moderate_label;
        private System.Windows.Forms.Label import_activity_heavy_label;
        private System.Windows.Forms.Label import_activity_veryheavy_label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox import_activity_sedantary;
        private System.Windows.Forms.TextBox import_activity_light;
        private System.Windows.Forms.TextBox import_activity_moderate;
        private System.Windows.Forms.TextBox import_activity_heavy;
        private System.Windows.Forms.TextBox import_activity_veryheavy;
        private System.Windows.Forms.Button import_general_action;
        private System.Windows.Forms.TabPage quickoptions_export_tab;
        private System.Windows.Forms.TabPage quickoptions_about_tab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox export_function_box;
        private System.Windows.Forms.GroupBox export_output_box;
        private System.Windows.Forms.GroupBox export_r_box;
        private System.Windows.Forms.TextBox export_output_prefix_box;
        private System.Windows.Forms.Label export_output_prefix_label;
        private System.Windows.Forms.TextBox export_output_height_box;
        private System.Windows.Forms.TextBox export_output_width_box;
        private System.Windows.Forms.Label export_output_height_label;
        private System.Windows.Forms.Label export_output_width_label;
        private System.Windows.Forms.CheckBox export_output_copyall_checkbox;
        private System.Windows.Forms.Label export_output_copyall_label;
        private System.Windows.Forms.Button export_output_directorybrowse_button;
        private System.Windows.Forms.Label export_output_directory_label;
        private System.Windows.Forms.TextBox export_ouput_directory_box;
        private System.Windows.Forms.Button export_r_path_browse_button;
        private System.Windows.Forms.TextBox export_r_path_box;
        private System.Windows.Forms.Label export_r_path_label;
        private System.Windows.Forms.ComboBox export_function_dropdown;
        private System.Windows.Forms.Button export_function_button;
        private System.Windows.Forms.OpenFileDialog selectPathToRDialog;
        private System.Windows.Forms.FolderBrowserDialog exportOutputDirectoryDialog;
        private System.Windows.Forms.CheckBox export_r_console_checkbox;
        private System.Windows.Forms.Label export_r_console_label;
        private System.Windows.Forms.GroupBox export_parameter_box;
        private System.Windows.Forms.FlowLayoutPanel export_parameter_flowlayoutpanel;
        private System.Windows.Forms.DataGridView processGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label activitylevels_collabel_count;
        private System.Windows.Forms.Label activitylevels_collabel_perc;
        private System.Windows.Forms.Label activitylevels_collabel_totaltime;
        private System.Windows.Forms.Label activitylevel_veryvigorous_limit;
        private System.Windows.Forms.Label activitylevel_vigorous_limit;
        private System.Windows.Forms.Label activitylevel_moderate_limit;
        private System.Windows.Forms.Label activitylevel_light_limit;
        private System.Windows.Forms.Label activitylevel_sedentary_limit;
        private System.Windows.Forms.Label activitylevels_collabel_limits;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button plot_r_script_path_browse_button;
        private System.Windows.Forms.TextBox plot_rscript_path_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox plot_parameter_dropdown;
        private System.Windows.Forms.OpenFileDialog selectPathToRScriptDialog;
        private System.Windows.Forms.Button plot_output_directory_browse_button;
        private System.Windows.Forms.TextBox plot_output_directory_box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FolderBrowserDialog plotOutputDirectoryDialog;
        private System.Windows.Forms.ComboBox plot_filetype_dropdown;
        private System.Windows.Forms.Button button1;
    }
}

