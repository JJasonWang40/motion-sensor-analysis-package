using System.ComponentModel;

namespace ActigraphAuswertung.Model
{
    /// <summary>
    /// Enum for all possible sensor datas and their plaintext description.
    /// </summary>
    public enum SensorData
    {
        /// <summary>
        /// Date and time of the entry.
        /// </summary>
        [Description("Date & Time")]
        Date,

        /// <summary>
        /// Activity (X) of the entry.
        /// </summary>
        [Description("Activity")]
        Activity,

        /// <summary>
        /// Y-Activity of the entry.
        /// </summary>
        [Description("Activity Y")]
        ActivityY,

        /// <summary>
        /// Z-Activity of the entry.
        /// </summary>
        [Description("Activity Z")]
        ActivityZ,

        /// <summary>
        /// Vmu of the entry.
        /// </summary>
        [Description("Vmu")]
        Vmu,

        /// <summary>
        /// Step-Counter of the entry.
        /// </summary>
        [Description("Steps")]
        Steps,

        /// <summary>
        /// Inclinometer of the entry.
        /// </summary>
        [Description("Inclinometer")]
        Inclinometer,
        
        /// <summary>
        /// Total calories of the entry.
        /// </summary>
        [Description("Calories (Total)")]
        CaloriesTotal,

        /// <summary>
        /// Activity calories of the entry.
        /// </summary>
        [Description("Calories (Activity)")]
        CaloriesActivity
    };
}
