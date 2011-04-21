namespace ActigraphAuswertung.Model.Calculators
{
    /// <summary>
    /// Interface that all calculators shade
    /// </summary>
    interface CalculatorInterface
    {
        /// <summary>
        /// Called by the model when a new entry is added.
        /// </summary>
        /// <param name="entry">The entry to be added</param>
        void Add(RowEntry entry);

        /// <summary>
        /// Called by the model on a new day.
        /// </summary>
        void NewDay();
    }
}
