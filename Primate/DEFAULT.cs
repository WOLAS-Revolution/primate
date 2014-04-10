using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primate
{
    public class DEFAULT
    {
        public static string PROJECT_TAG = "Primate";
        public static string SUB_ACCOUNT = null;
        public static string TRAP_ACCOUNT = null;
        public static string TRAP_KEY = null;
        public static string TRAP_EMAIL = null;

        /// <summary>
        /// Checks to see if the provided config value
        /// is null or empty. If not then the value
        /// is converted to the required type.
        /// </summary>
        /// <param name="value">The string config value to check</param>
        /// <param name="defaultValue">The default value of the config value</param>
        public static T ConfigResolver<T>(string value, T defaultValue)
        {
            if (String.IsNullOrEmpty(value))
                return defaultValue;

            return ((T)Convert.ChangeType(value, typeof(T)));
        }
    }
}
