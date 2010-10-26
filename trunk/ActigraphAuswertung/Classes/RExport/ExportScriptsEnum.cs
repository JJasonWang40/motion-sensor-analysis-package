using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using ActigraphAuswertung.Model;

namespace ActigraphAuswertung.RExport
{
    public enum ExportScripts
    {
        [Description("Select Script"), Class(typeof(ExportUnknown))]
        Unknown,
        [Description("Cross correlation"), Class(typeof(ExportCrossCorrelation))]
        CrossCorrelation,        
        [Description("Daily"), Class(typeof(ExportDaily))]
        Daily,
        [Description("Daily Avg"), Class(typeof(ExportDailyAvg))]
        DailyAvg,
        [Description("Hourly Avg"), Class(typeof(ExportHourlyAvg))]
        HourlyAvg,
        [Description("Levels"), Class(typeof(ExportLevels))]
        Levels,
        [Description("Linear Regression"), Class(typeof(ExportRegressionLinear))]
        RegressionLinear,
        [Description("Scatter"), Class(typeof(ExportScatter))]
        Scatter,
        [Description("Steps"), Class(typeof(ExportSteps))]
        Steps,
        [Description("Worn"), Class(typeof(ExportWorn))]
        Worn
    }

    /**
     * Associates a Enum-Fields with a class
     * 
     * Usage: [Class(typeof(ClassToAssociateWith))]
     * Only one class can be bound to a field!
     */
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class ClassAttribute : Attribute
    { 
        protected Type instance;

        public ClassAttribute(Type instance)
        {
            this.instance = instance;
        }

        public override String ToString()
        {
            return this.instance.ToString();
        }

        public Type Type
        {
            get { return this.instance; }
        }
    }

    /**
     * Extends the Enum ExportScripts
     */
    public static class ExportScriptsExtensions
    {
        /**
         * Get the description of a field or an empty string if not set
         */
        public static string ToDescription(this ExportScripts val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;        
        }

        /**
         * Get the class name as string of a field or an empty string if not set
         */
        public static String ToClassName(this ExportScripts val)
        {
            ClassAttribute[] attributes = (ClassAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(ClassAttribute), false);
            return attributes.Length > 0 ? attributes[0].ToString() : string.Empty; 
        }

        /**
         * Get the class type of a field. 
         * 
         * Throws an exception if no class is bound to the field.
         */
        public static Type ToClassType(this ExportScripts val)
        {
            ClassAttribute[] attributes = (ClassAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(ClassAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Type;
            }
            throw new NotSupportedException(val.ToString() + " has no class associated with");
        }

        /**
         * Get an instance of the class the field is bound to. 
         * 
         * Throws an exception if no class is bound to the field 
         * or the class does not inherit from the Abstract base class.
         */
        public static Abstract ToClass(this ExportScripts val)
        {
            Type classType = val.ToClassType();

            if (classType.IsSubclassOf(typeof(Abstract)))
            {
                return (Abstract)Activator.CreateInstance(classType);
            }
            throw new Exception(val.ToString() + " has class " + classType.ToString() + " associated with which does not inherit from Abstract");
        }

        /**
         * Returns a list of all Values and their description in defined for the enum ExportScripts
         */
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
