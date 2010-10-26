using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ActigraphAuswertung.Model;
using ActigraphAuswertung.Mapper.LineParser;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ActigraphAuswertung.Mapper
{
    class Factory
    {
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
               new RT3KommaSepLineParser()
            };

            // the active line parser
            AbstractLineParser activeLineParser = null;

            // prevent locking the file when an exception occures
            using (StreamReader reader = new StreamReader(file))
            {
#if DEBUG
                Console.WriteLine("Parsing file " + file);
#endif
                // current line buffer
                String line;
                CsvModel model = new CsvModel();
                model.ActivityLevelCalculator.MinSedantary = minSedantary;
                model.ActivityLevelCalculator.MinLight = minLight;
                model.ActivityLevelCalculator.MinModerate = minModerate;
                model.ActivityLevelCalculator.MinHeavy = minHeavy;
                model.ActivityLevelCalculator.MinVeryheavy = minVeryheavy;

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
                        }
                    }
                }

                // reached eof with no line parser matching
                if(activeLineParser == null)
                {
                    throw new Exception("No valid line format found for file " + file);
                }

                Console.WriteLine("Using lineparser " + activeLineParser.ToString());

                model.SupportedValues = activeLineParser.SupportedValues;
                model.AbsoluteFileName = file;
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

        public static CsvModel filter(
            CsvModel data,
            Filter.FilterCollection filterCollection,
            Filter.FilterMethod method
        )
        {
            CsvModel model = new CsvModel();

            model.ActivityLevelCalculator.MinVeryheavy = data.ActivityLevelCalculator.MinVeryheavy;
            model.ActivityLevelCalculator.MinHeavy = data.ActivityLevelCalculator.MinHeavy;
            model.ActivityLevelCalculator.MinModerate = data.ActivityLevelCalculator.MinModerate;
            model.ActivityLevelCalculator.MinLight = data.ActivityLevelCalculator.MinLight;
            model.ActivityLevelCalculator.MinSedantary = data.ActivityLevelCalculator.MinSedantary;

            model.AbsoluteFileName = data.AbsoluteFileName;
            model.SupportedValues = data.SupportedValues;

            filterCollection.filter(data, model, method);

            model.finishParsing();

            return model;
        }
    }
}
