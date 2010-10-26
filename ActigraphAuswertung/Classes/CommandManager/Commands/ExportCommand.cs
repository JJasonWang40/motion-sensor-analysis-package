namespace ActigraphAuswertung.CommandManager.Commands
{
    /// <summary>
    /// Command for R-Export. For stand-alone use, use the <see cref="RExport.Abstract"/>export class directly.
    /// </summary>
    class ExportCommand : AbstractCommand
    {
        private RExport.Abstract exportClass;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exportClass">The Export-Class</param>
        /// <param name="callback">The callback for successful exports</param>
        public ExportCommand(RExport.Abstract exportClass, CommandFinishedDelegate callback) : base(Priority.VeryHigh, callback)
        {
            this.exportClass = exportClass;
            this.description = "Export file(s)";
        }

        /// <summary>
        /// Command execution entry point.
        /// </summary>
        /// <returns>The export-class used: <see cref="RExport.Abstract"/></returns>
        public override object execute()
        {
            exportClass.execute();

            return this.exportClass;
        }
    }
}
