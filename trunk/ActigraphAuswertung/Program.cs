// Visual Studio can define DEBUG itself depending on the context and configuration
// #define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActigraphAuswertung.Model.Storage;

// macro for debuging

namespace ActigraphAuswertung
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //new DBStorage();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
