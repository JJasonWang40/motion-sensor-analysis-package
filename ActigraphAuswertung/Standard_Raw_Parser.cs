using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActigraphAuswertung
{
    public partial class Standard_Raw_Parser : Form
    {

        private String path = Application.StartupPath + "sensorConfig";

        public Standard_Raw_Parser()
        {
            InitializeComponent();
        }

        #region controls
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = Application.StartupPath+ "/";
            label1.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
