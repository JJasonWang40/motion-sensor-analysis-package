using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ActigraphAuswertung.Classes
{
    class Settings
    {
        private static string _pathToR = null;
        public static string PathToR
        {
            get
            {
                if (_pathToR == null)
                {
                    readSettingsFromFile();
                    if (_pathToR == null)
                    {
                        return @"C:\Program Files\R\R-2.10.1\bin\R.exe";
                    }
                }
                return _pathToR;
            }
            set
            {
                _pathToR = value;
                writeSettingsToFile();
            }
        }

        private static string _settingsFilePath = "aa.ini";
        public static string settingsFilePath
        {
            get
            {
                return Form1.APP_PATH + "\\" + _settingsFilePath;
            }
        }

        private static void readSettingsFromFile()
        {
            try
            {
                FileStream settingsFile = new FileStream(settingsFilePath, FileMode.Open);
                StreamReader settingsReader = new StreamReader(settingsFile);
                string line = "";
                while (line != null)
                {
                    line = settingsReader.ReadLine();
                    try
                    {
                        string[] lineSplit = Regex.Split(line, "=");
                        for (int i = 0; i < lineSplit.Length; i++)
                        {
                            lineSplit[i] = lineSplit[i].Trim();
                        }

                        switch (lineSplit[0])
                        {
                            case "PathToR":
                                PathToR = lineSplit[1];
                                break;
                        }
                    }
                    catch { }
                }
                settingsReader.Close();
            }
            catch { }
        }

        private static void writeSettingsToFile()
        {
            try
            {
                FileStream settingsFile = new FileStream(settingsFilePath, FileMode.Create);
                StreamWriter settingsWriter = new StreamWriter(settingsFile);
                settingsWriter.WriteLine("PathToR = " + PathToR);
                settingsWriter.Close();
            }
            catch { }
        }
    }
}
