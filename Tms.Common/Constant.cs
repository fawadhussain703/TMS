using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tms.Core
{
    public class Constant
    {

        #region Local
        public static string BASE_URL = "http://localhost:52852/";
        public static string DB_SERVER = "51.38.41.235";
        public static string DB_NAME = "TMS";
        public static bool DB_Integrated_Security = false;
        public static string DB_UID = "DOTNET";
        public static string DB_PWD = "sql#@int123";
        #endregion

        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
