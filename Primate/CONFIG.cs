using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Primate
{
    public static class CONFIG
    {
        public static string MANDRILL_API_KEY = ConfigurationSettings.AppSettings["MANDRILL_API"];
        public static string MANDRILL_PROJECT_TAG = ConfigurationSettings.AppSettings["MANDRILL_PROJECT_TAG"];
        public static string MANDRILL_TRAP_KEY = ConfigurationSettings.AppSettings["MANDRILL_TRAP_KEY"];
        public static string MANDRILL_TRAP_EMAIL = ConfigurationSettings.AppSettings["MANDRILL_TRAP_EMAIL"];
        public static string MANDRILL_TRAP_ACCOUNT = ConfigurationSettings.AppSettings["MANDRILL_TRAP_ACCOUNT"];
        public static string MANDRILL_SUB_ACCOUNT = ConfigurationSettings.AppSettings["MANDRILL_SUB_ACCOUNT"];
        public static string MANDRILL_FROM_EMAIL = ConfigurationSettings.AppSettings["MANDRILL_FROM_EMAIL"];
        public static string MANDRILL_FROM_NAME = ConfigurationSettings.AppSettings["MANDRILL_FROM_NAME"];
    }
}
