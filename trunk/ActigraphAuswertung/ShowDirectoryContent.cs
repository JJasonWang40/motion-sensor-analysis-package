using System;
using System.IO;
using System.Windows.Forms;

namespace ActigraphAuswertung
{    
    /// <summary>
    /// Displays all jpg-files of a directory.
    /// </summary>
    public partial class ShowDirectoryContent : Form
    {
        private String directory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directory">The directory</param>
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

        // display selected picture
        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pictureBox.LoadAsync(this.directory + "\\" + this.fileListBox.SelectedItem);
        }
    }
}
