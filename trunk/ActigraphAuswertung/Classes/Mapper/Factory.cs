using System;
using System.IO;
using ActigraphAuswertung.Mapper.LineParser;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.Mapper
{
    /// <summary>
    /// Factory for <see cref="CsvModel"/>s. 
    /// Provides functions for importing and filtering data.
    /// </summary>
    class Factory
    {
        /// <summary>
        /// Imports a csv-file into <see cref="CsvModel"/> with the given
        /// lower limits for the activitylevel calculator
        /// </summary>
        /// <param name="file">The absolute filepath to the file to import</param>
        /// <param name="minSedantary">Lower limit for sedantary activity</param>
        /// <param name="minLight">Lower limit for light activity</param>
        /// <param name="minModerate">Lower limit for moderate activity</param>
        /// <param name="minHeavy">Lower limit for heavy activity</param>
        /// <param name="minVeryheavy">Lower limit for very heavy activity</param>
        /// <returns>The imported CsvModel</returns>
        public static CsvModel parse(
            String file,
            int minSedantary,
            int minLight,
            int minModerate,
            int minHeavy,
            int minVeryheavy
        )
        {
            // all available line parsers, ascending priority
            AbstractLineParser[] lineParsers = {
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

            // the active line parser
            AbstractLineParser activeLineParser = null;

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
                    foreach (AbstractLineParser parser in lineParsers)
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
                if(activeLineParser == null)
                {
                    throw new LineparserException("No valid line format found for file " + file);
                }

                Console.WriteLine("Detected lineparser: " + activeLineParser.ToString());

                // construct model with supported values
                CsvModel model = new CsvModel(activeLineParser.SupportedValues);
                // set limits for the activitylevel calculator

                model.ActivityLevelCalculator.MinSedantary = minSedantary;
                model.ActivityLevelCalculator.MinLight = minLight;
                model.ActivityLevelCalculator.MinModerate = minModerate;
                model.ActivityLevelCalculator.MinHeavy = minHeavy;
                model.ActivityLevelCalculator.MinVeryheavy = minVeryheavy;


                // Set filename
                model.AbsoluteFileName = file;
                // Add the two lines consumed by lineparser testing
                model.Add(activeLineParser.parseLine(bufferline));
                model.Add(activeLineParser.parseLine(line));

                //iterate over all remaining lines with
                while((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        model.Add(activeLineParser.parseLine(line));
                    }
                }

                // finish model
                model.finishParsing(); 

                return model;
            }
        }

        /// <summary>
        /// Factory function for filtering a <see cref="CsvModel"/>.
        /// </summary>
        /// <param name="data">The data to be filtered</param>
        /// <param name="filterCollection">The filter collection to be applied</param>
        /// <param name="method">The filter method</param>
        /// <returns>The filtered data</returns>
        public static CsvModel filter(
            CsvModel data,
            Filter.FilterCollection filterCollection,
            Filter.FilterMethod method
        )
        {
            CsvModel model = new CsvModel(data.SupportedValues);

            // set limits of the activitylevel calculator of the new model
            model.ActivityLevelCalculator.MinVeryheavy = data.ActivityLevelCalculator.MinVeryheavy;
            model.ActivityLevelCalculator.MinHeavy = data.ActivityLevelCalculator.MinHeavy;
            model.ActivityLevelCalculator.MinModerate = data.ActivityLevelCalculator.MinModerate;
            model.ActivityLevelCalculator.MinLight = data.ActivityLevelCalculator.MinLight;
            model.ActivityLevelCalculator.MinSedantary = data.ActivityLevelCalculator.MinSedantary;

            // set filename and supported values
            model.AbsoluteFileName = data.AbsoluteFileName;
            model.SupportedValues = data.SupportedValues;

            // do the filtering
            filterCollection.filter(data, model, method);

            // finish model
            model.finishParsing();

            return model;
        }
    }
}
