using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primate
{
    public class Template
    {
        /// <summary>
        /// Gets the template code with no parameters
        /// formatted into place.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public static string Get(string name)
        {
            Mandrill.MandrillApi api = new Mandrill.MandrillApi(CONFIG.ApiKey);
            List<Mandrill.Models.TemplateInfo> templates = api.ListTemplates();

            foreach (Mandrill.Models.TemplateInfo template in templates)
            {
                if (template.name == name)
                {
                    return template.code;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the template code with  the specified
        /// parameters formatted into place.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        /// <param name="args">A list of arguments to place into the template.</param>
        public static string Get(string name, params object[] args)
        {
            Mandrill.MandrillApi api = new Mandrill.MandrillApi(CONFIG.ApiKey);
            List<Mandrill.Models.TemplateInfo> templates = api.ListTemplates();

            // Get the template code from the list of templates.
            foreach (Mandrill.Models.TemplateInfo template in templates)
            {
                if (template.name == name)
                {
                    return String.Format(template.code, args);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the template code with  the specified
        /// parameters formatted into place, and with a
        /// specified outside wrapper.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        /// <param name="wrapper">The name of template used to wrap the email (for style etc.).</param>
        /// <param name="args">A list of arguments to place into the template.</param>
        public static string Get(string name, string wrapper, params object[] args)
        {
            Mandrill.MandrillApi api = new Mandrill.MandrillApi(CONFIG.ApiKey);
            List<Mandrill.Models.TemplateInfo> templates = api.ListTemplates();
            string wrapHTML = string.Empty;
            string fullHTML = string.Empty;

            // Get wrapper HTML.
            foreach (Mandrill.Models.TemplateInfo template in templates)
            {
                if (template.name == wrapper)
                {
                    wrapHTML = template.code;
                }
            }

            // Get the template code from the list of templates.
            foreach (Mandrill.Models.TemplateInfo template in templates)
            {
                if (template.name == name)
                {
                    fullHTML = String.Format(template.code, args);
                }
            }

            return String.Format(wrapHTML, fullHTML);
        }
    }
}
