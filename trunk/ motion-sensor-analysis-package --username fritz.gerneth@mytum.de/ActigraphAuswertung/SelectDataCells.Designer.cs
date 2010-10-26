namespace ActigraphAuswertung
{
    partial class SelectDataCells
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
            this.cellSelectionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.export_start_button = new System.Windows.Forms.Button();
            this.cellSelectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellSelectionPanel
            // 
            this.cellSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cellSelectionPanel.AutoSize = true;
            this.cellSelectionPanel.Controls.Add(this.export_start_button);
            this.cellSelectionPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.cellSelectionPanel.Location = new System.Drawing.Point(12, 12);
            this.cellSelectionPanel.Name = "cellSelectionPanel";
            this.cellSelectionPanel.Size = new System.Drawing.Size(275, 85);
            this.cellSelectionPanel.TabIndex = 0;
            this.cellSelectionPanel.WrapContents = false;
            // 
            // export_start_button
            // 
            this.export_start_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.export_start_button.Location = new System.Drawing.Point(3, 59);
            this.export_start_button.Name = "export_start_button";
            this.export_start_button.Size = new System.Drawing.Size(75, 23);
            this.export_start_button.TabIndex = 0;
            this.export_start_button.Text = "Export";
            this.export_start_button.UseVisualStyleBackColor = true;
            this.export_start_button.Click += new System.EventHandler(this.export_start_button_Click);
            // 
            // SelectDataCells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(299, 109);
            this.Controls.Add(this.cellSelectionPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDataCells";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select data cells for export";
            this.TopMost = true;
            this.cellSelectionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel cellSelectionPanel;
        private System.Windows.Forms.Button export_start_button;

    }
}