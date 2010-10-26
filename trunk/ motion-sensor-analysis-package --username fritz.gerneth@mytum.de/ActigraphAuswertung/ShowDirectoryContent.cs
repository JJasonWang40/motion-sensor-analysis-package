using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ActigraphAuswertung
{
    public partial class ShowDirectoryContent : Form
    {
        private String directory;

        public ShowDirectoryContent(String directory)
        {
            InitializeComponent();

            this.Text = "Content of " + directory;

            this.directory = directory;
            DirectoryInfo dirInfo = new DirectoryInfo(directory);

            foreach (FileInfo file in dirInfo.GetFiles("*.jpg"))
            {
                this.fileListBox.Items.Add(file.Name);
            }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pictureBox.LoadAsync(this.directory + "\\" + this.fileListBox.SelectedItem);
        }
    }
}
