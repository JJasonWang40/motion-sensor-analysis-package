namespace ActigraphAuswertung
{
    /// <summary>
    /// Show all detected days and their activity start and end times and the daily active time.
    /// </summary>
    partial class ShowParsedFileDailyStartEndTimes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileContentDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileContentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileContentDataGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 486);
            this.panel1.TabIndex = 0;
            // 
            // fileContentDataGrid
            // 
            this.fileContentDataGrid.AllowUserToAddRows = false;
            this.fileContentDataGrid.AllowUserToDeleteRows = false;
            this.fileContentDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fileContentDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.fileContentDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileContentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileContentDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileContentDataGrid.Location = new System.Drawing.Point(0, 0);
            this.fileContentDataGrid.MultiSelect = false;
            this.fileContentDataGrid.Name = "fileContentDataGrid";
            this.fileContentDataGrid.ReadOnly = true;
            this.fileContentDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fileContentDataGrid.Size = new System.Drawing.Size(649, 486);
            this.fileContentDataGrid.TabIndex = 0;
            // 
            // ShowParsedFileDailyStartEndTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(649, 486);
            this.Controls.Add(this.panel1);
            this.Name = "ShowParsedFileDailyStartEndTimes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show daily start and endtimes of ";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileContentDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView fileContentDataGrid;
    }
}