using System;

namespace ActigraphAuswertung.CommandManager.Commands
{
    /// <summary>
    /// Command for import. For stand-alone use, use the <see cref="Factory.parse"/> method directly.
    /// </summary>
    class ImportCommand : AbstractCommand
    {
        private String file;
        private int minSedantary;
        private int minLight;
        private int minModerate;
        private int minHeavy;
        private int minVeryheavy;

        /// <summary>
        /// Constructor. Lower limit values are used for the <see cref="Model.ActivityLevelsCalculator"/>.
        /// </summary>
        /// <param name="file">The file to be imported</param>
        /// <param name="minSedantary">Lower limit for sedantary activity</param>
        /// <param name="minLight">Lower limit for light activity</param>
        /// <param name="minModerate">Lower limit for moderate activity</param>
        /// <param name="minHeavy">Lower limit for heavy activity</param>
        /// <param name="minVeryheavy">Lower limit for very heavy activity</param>
        /// <param name="callback">The callback for successful imports</param>
        public ImportCommand(String file,
            int minSedantary,
            int minLight,
            int minModerate,
            int minHeavy,
            int minVeryheavy,
            CommandFinishedDelegate callback)
            : base(Priority.Medium, callback)
        {
            this.file = file;
            this.minSedantary = minSedantary;
            this.minLight = minLight;
            this.minModerate = minModerate;
            this.minHeavy = minHeavy;
            this.minVeryheavy = minVeryheavy;
            this.description = "Import file " + this.file;
        }

        /// <summary>
        /// Import execution entry point.
        /// </summary>
        /// <returns>The imported data: <see cref="Model.CsvModel"/></returns>
        public override object execute()
        {
            return Mapper.Factory.parse(
                this.file,
                this.minSedantary,
                this.minLight,
                this.minModerate,
                this.minHeavy,
                this.minVeryheavy
            );
        }
    }
}
