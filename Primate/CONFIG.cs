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
        public static string ApiKey { get; set; }
        public static string ProjectTag { get; set; }
        public static string TrapApiKey { get; set; }
        public static string TrapEmail { get; set; }
        public static string TrapAccount { get; set; }
        public static string SubAccount { get; set; }
        public static string FromEmail { get; set; }
        public static string FromName { get; set; }

        public static void SetConfig(string apiKey, string fromEmail, string fromName)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(fromName))
                throw new ArgumentException("You must provide an API key, from emal and from name as a minimum.");

            // Set config values.
            CONFIG.ApiKey = apiKey;
            CONFIG.FromEmail = fromEmail;
            CONFIG.FromName = fromName;

            // Set other defaults.
            CONFIG.ProjectTag = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.ProjectTag"], DEFAULT.PROJECT_TAG);
            CONFIG.TrapAccount = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.Account"], DEFAULT.TRAP_ACCOUNT);
            CONFIG.TrapEmail = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.Email"], DEFAULT.TRAP_EMAIL);
            CONFIG.TrapApiKey = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.ApiKey"], DEFAULT.TRAP_KEY);
            CONFIG.SubAccount = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.SubAccount"], DEFAULT.SUB_ACCOUNT);
        }

        public static void SetConfig(string apiKey, string fromEmail, string fromName, string projectTag)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(fromName))
                throw new ArgumentException("You must provide an API key, from emal and from name as a minimum.");

            // Set config values.
            CONFIG.ApiKey = apiKey;
            CONFIG.FromEmail = fromEmail;
            CONFIG.FromName = fromName;
            CONFIG.ProjectTag = projectTag;

            // Set other defaults.
            CONFIG.TrapAccount = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.Account"], DEFAULT.TRAP_ACCOUNT);
            CONFIG.TrapEmail = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.Email"], DEFAULT.TRAP_EMAIL);
            CONFIG.TrapApiKey = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.ApiKey"], DEFAULT.TRAP_KEY);
            CONFIG.SubAccount = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.SubAccount"], DEFAULT.SUB_ACCOUNT);
        }

        public static void SetConfig(string apiKey, string fromEmail, string fromName, string projectTag, string subAccount)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(fromName))
                throw new ArgumentException("You must provide an API key, from emal and from name as a minimum.");

            // Set config values.
            CONFIG.ApiKey = apiKey;
            CONFIG.FromEmail = fromEmail;
            CONFIG.FromName = fromName;
            CONFIG.ProjectTag = projectTag;
            CONFIG.SubAccount = subAccount;

            // Set other defaults.
            CONFIG.TrapAccount = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.Account"], DEFAULT.TRAP_ACCOUNT);
            CONFIG.TrapEmail = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.Email"], DEFAULT.TRAP_EMAIL);
            CONFIG.TrapApiKey = DEFAULT.ConfigResolver(ConfigurationManager.AppSettings["Mandrill.Trap.ApiKey"], DEFAULT.TRAP_KEY);
        }
    }
}
