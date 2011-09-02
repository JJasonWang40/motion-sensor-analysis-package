using System;
using System.IO;
using ActigraphAuswertung.Mapper.LineParser;
using ActigraphAuswertung.Model;
using ActigraphAuswertung.Model.Storage;
using System.Security.Cryptography;

namespace ActigraphAuswertung.Model.Mapper
{
    class FileImportMapper
    {
        // all available line parsers, ascending priority
        private static AbstractLineParser[] lineParsers = {
               new SingleEntryLineParser(),
               new DateTimeActivityStepsLineParser(),
               new ActivityUnknownLineParser(),
               new DateTimeActivity3dVMUStepsInclLineParser(),
               new DateTimeActivity2dVMUStepsInclLineParser(),
               new Activity3dVMULineParser(),
               new Activity2dVMULineParser(),
               new NoDate3dActivityStepsLineParser(),
               new DateTime3dActivityStepsLineParser(),
               new DateTimeActivityLineParser(),
               new RExportedLineParser(),
               new RT3LineParser(),
               new RT3SemicolomSepLineParser()
            };

        /// <summary>
        /// Imports a csv-file into <see cref="CsvModelList"/>
        /// </summary>
        /// <param name="storage">The reference to the storage where the imported data is saved to</param>
        /// <param name="file">The absolute filepath to the file to import</param>
        /// <returns>The ID of the imported CsvModel</returns>
        public static DatabaseDataSet parse(string file)
        {
            // the active line parser
            AbstractLineParser activeLineParser = null;

            // calculates the ID of the input file
            string fileID = FileImportMapper.calculateID(file);

            // prevent locking the file when an exception occures
            using (StreamReader reader = new StreamReader(file))
            {
                String line;

                // we need a buffer to parse the line that is overwritten after testing
                String bufferline = "";

                // as long as we have lines to read but haven't found a valid format
                while ((line = reader.ReadLine()) != null && activeLineParser == null)
                {
                    // iterate over all available line parsers
                    foreach (AbstractLineParser parser in FileImportMapper.lineParsers)
                    {
                        // this line parser does match the given line
                        if (parser.test(line) == true)
                        {
                            activeLineParser = parser;
                            bufferline = line;
                            break;
                        }
                    }
                }

                // reached eof with no line parser matching
                if (activeLineParser == null)
                {
                    throw new LineparserException("No valid line format found for file " + file);
                }

                Console.WriteLine("Detected lineparser: " + activeLineParser.ToString());

                DatabaseDataSet dataset = Program.storage.getDataSet(fileID);
                dataset.AbsoluteFileName = file;
                dataset.SupportedValues = activeLineParser.SupportedValues;

                if (dataset.locked)
                {
                    dataset.loadData();
                }
                else
                {
                    dataset.AddNewFile();
                    // Add the two lines consumed by lineparser testing
                    dataset.Add(activeLineParser.parseLine(bufferline));
                    dataset.Add(activeLineParser.parseLine(line));

                    //iterate over all remaining lines with
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Trim().Length > 0)
                        {
                            dataset.Add(activeLineParser.parseLine(line));
                        }
                    }

                    // finish model
                    dataset.locked = true;
                    dataset.finishImport();
                }
                return dataset;
            }
        }

        private static string calculateID(string path)
        {
            byte[] hashValueByteArray;
            string hashValueString;

            // Initialize a RIPE160 hash object.
            RIPEMD160 myRIPEMD160 = RIPEMD160Managed.Create();
            // Create a fileStream for the file.
            FileStream fileStream = new FileStream(path, FileMode.Open);
            // Compute the hash of the fileStream.
            hashValueByteArray = myRIPEMD160.ComputeHash(fileStream);
            // Close the file.
            fileStream.Close();
            // Convert to String
            hashValueString = System.BitConverter.ToString(hashValueByteArray);
            hashValueString = hashValueString.Replace("-", "");
            // Return hash value.
            return hashValueString;
        }
    }
}
