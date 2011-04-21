using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ActigraphAuswertung.RExport
{
    /// <summary>
    /// Enum of all available export scripts with their plaintext description 
    /// and the handling class.
    /// </summary>
    public enum ExportScripts
    {
        /// <summary>
        /// Undefined script. Used to force selection.
        /// </summary>
        [Description("Select Script"), Class(typeof(ExportUnknown))]
        Unknown,

        /// <summary>
        /// Export script to cross correlation.
        /// </summary>
        [Description("Cross correlation"), Class(typeof(ExportCrossCorrelation))]
        CrossCorrelation,     
   
        /// <summary>
        /// Export script to daily actitivy.
        /// </summary>
        [Description("Daily"), Class(typeof(ExportDaily))]
        Daily,

        /// <summary>
        /// Export script to daily avarage activity.
        /// </summary>
        [Description("Daily Avg"), Class(typeof(ExportDailyAvg))]
        DailyAvg,

        /// <summary>
        /// Export script to hourly avarage actitivy.
        /// </summary>
        [Description("Hourly Avg"), Class(typeof(ExportHourlyAvg))]
        HourlyAvg,

        /// <summary>
        /// Export script to actitivy levels.
        /// </summary>
        [Description("Levels"), Class(typeof(ExportLevels))]
        Levels,

        /// <summary>
        /// Export script to linear regression analysis.
        /// </summary>
        [Description("Linear Regression"), Class(typeof(ExportRegressionLinear))]
        RegressionLinear,

        /// <summary>
        /// Export script to scatter graph.
        /// </summary>
        [Description("Scatter"), Class(typeof(ExportScatter))]
        Scatter,
        
        /// <summary>
        /// Export script to steps graph.
        /// </summary>
        [Description("Steps"), Class(typeof(ExportSteps))]
        Steps,

        /// <summary>
        /// Export script to worn graph.
        /// </summary>
        [Description("Worn"), Class(typeof(ExportWorn))]
        Worn
    }

    /// <summary>
    /// Attribute definition to assign a class to an enum value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class ClassAttribute : Attribute
    { 
        /// <summary>
        /// The type of the associated class.
        /// </summary>
        protected Type instance;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="instance">Type of the associated class.</param>
        public ClassAttribute(Type instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// Returns the name of the associated class.
        /// </summary>
        /// <returns>Name of the class</returns>
        public override String ToString()
        {
            return this.instance.ToString();
        }

        /// <summary>
        /// Type of the associated class.
        /// </summary>
        public Type Type
        {
            get { return this.instance; }
        }
    }

    /// <summary>
    /// Extension methods for <see cref="ExportScripts"/>.
    /// </summary>
    public static class ExportScriptsExtensions
    {
        /// <summary>
        /// Gets the description of a value or an empty string.
        /// </summary>
        /// <param name="val">Value to get the description of</param>
        /// <returns>The description</returns>
        public static string ToDescription(this ExportScripts val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;        
        }

        /// <summary>
        /// Gets the class name of the value or an empty string.
        /// </summary>
        /// <param name="val">Value to get the class name of</param>
        /// <returns>The class name</returns>
        public static String ToClassName(this ExportScripts val)
        {
            ClassAttribute[] attributes = (ClassAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(ClassAttribute), false);
            return attributes.Length > 0 ? attributes[0].ToString() : string.Empty; 
        }

        /// <summary>
        /// Gets the class type of the value
        /// </summary>
        /// <param name="val">Value to get the class type of</param>
        /// <returns>The associated class type</returns>
        /// <exception cref="NotSupportedException">If the value has no associated class type.</exception>
        public static Type ToClassType(this ExportScripts val)
        {
            ClassAttribute[] attributes = (ClassAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(ClassAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Type;
            }
            throw new NotSupportedException(val.ToString() + " has no class associated with");
        }

        /// <summary>
        /// Returns an instance of the class of the value.
        /// </summary>
        /// <param name="val">Value to get the instance of</param>
        /// <returns>Associated class instance</returns>
        /// <exception cref="NotSupportedException">If the value has no associated class type.</exception>
        public static Abstract ToClass(this ExportScripts val)
        {
            Type classType = val.ToClassType();

            if (classType.IsSubclassOf(typeof(Abstract)))
            {
                return (Abstract)Activator.CreateInstance(classType);
            }
            throw new NotSupportedException(val.ToString() + " has class " + classType.ToString() + " associated with which does not inherit from Abstract");
        }

        /// <summary>
        /// Returns a list of all values of <see cref="ExportScripts"/> and their description.
        /// </summary>
        /// <returns></returns>
        public static ArrayList ToList()
        {
            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(typeof(ExportScripts));

            foreach (ExportScripts value in enumValues)
            {
                list.Add(new KeyValuePair<ExportScripts, string>(value, value.ToDescription()));
            }

            return list;
        }
    }
}
