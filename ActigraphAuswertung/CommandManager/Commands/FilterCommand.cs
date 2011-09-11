using ActigraphAuswertung.Filter;
using ActigraphAuswertung.Mapper;
using ActigraphAuswertung.Model;
using ActigraphAuswertung.Model.Mapper;

namespace ActigraphAuswertung.CommandManager.Commands
{
    /// <summary>
    /// Command for filtering a CSVModel. For stand-alone use, use the <see cref="Factory.filter"/> method directly.
    /// </summary>
    class FilterCommand : AbstractCommand
    {
        private DatabaseDataSet filterData;

        private FilterCollection filterCollection;

        private FilterMethod filterMethod;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filterData">The data to be filtered</param>
        /// <param name="filterCollection">The filtercollectio to be applied to</param>
        /// <param name="filterMethod">The filtermethod</param>
        /// <param name="callback">The callback for successfull filtering</param>
        public FilterCommand(DatabaseDataSet filterData, FilterCollection filterCollection, FilterMethod filterMethod, CommandFinishedDelegate callback)
            : base(Priority.Low, callback)
        {
            this.filterData = filterData;
            this.filterCollection = filterCollection;
            this.filterMethod = filterMethod;

            this.description = "Filter file " + this.filterData.AbsoluteFileName;
        }

        /// <summary>
        /// Filter command execution entry point
        /// </summary>
        /// <returns>The filtered data: <see cref="CsvModel"/></returns>
        public override object execute()
        {
            return FileImportMapper.filter(filterData, filterCollection, filterMethod);
        }
    }
}
