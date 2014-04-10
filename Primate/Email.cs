using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primate
{
    public class Email
    {
        /// <summary>
        /// Send a basic email.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        public static void Send(string to, string subject, string body)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);
            SendToMandrill(email);
        }

        /// <summary>
        /// Send an email to a person and all cc'd.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="cc">A list of email addresses to CC.</param>
        public static void Send(string to, string subject, string body, List<string> cc)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all CC recipients to a list of emailaddress.
            List<Mandrill.EmailAddress> recipients = ConvertRecipients(cc);

            // Send the email to mandrill.
            SendToMandrill(email, recipients);
        }

        /// <summary>
        /// Send an email with files attached.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="files">A list of file attachments to send with the email.</param>
        public static void Send(string to, string subject, string body, List<Model.Attachment> files)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all attachments to a list of attachment.
            List<Mandrill.attachment> attachments = ConvertAttachments(files);

            // Send the email to mandrill.
            SendToMandrill(email, attachments: attachments);
        }

        /// <summary>
        /// Send an email with one file attached.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="file">A single file attachment to send with the email.</param>
        public static void Send(string to, string subject, string body, Model.Attachment file)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all attachments to a list of attachment.
            List<Model.Attachment> files = new List<Model.Attachment>();
            files.Add(file);
            List<Mandrill.attachment> attachments = ConvertAttachments(files);

            // Send the email to mandrill.
            SendToMandrill(email, attachments: attachments);
        }

        /// <summary>
        /// Send an email with one file attached to multiple people.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="cc">A list of email addresses to CC.</param>
        /// <param name="files">A list of file attachments to send with the email.</param>
        public static void Send(string to, string subject, string body, List<string> cc, List<Model.Attachment> files)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all CC recipients to a list of emailaddress.
            List<Mandrill.EmailAddress> recipients = ConvertRecipients(cc);

            // Add all attachments to a list of attachment.
            List<Mandrill.attachment> attachments = ConvertAttachments(files);

            // Send the email to mandrill.
            SendToMandrill(email, recipients, attachments);
        }

        /// <summary>
        /// Send an email to multiple people and tag the email in mandrill.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="cc">A list of email addresses to CC.</param>
        /// <param name="tags">A list of tags to attach to the email.</param>
        public static void Send(string to, string subject, string body, List<string> cc, List<string> tags)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all CC recipients to a list of emailaddress.
            List<Mandrill.EmailAddress> recipients = ConvertRecipients(cc);

            // Send the email to mandrill.
            SendToMandrill(email, recipients, tags:tags);
        }

        /// <summary>
        /// Send an email with multiple files attached to multiple people and tag the email in mandrill.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="cc">A list of email addresses to CC.</param>
        /// <param name="files">A list of file attachments to send with the email.</param>
        /// <param name="tags">A list of tags to attach to the email.</param>
        public static void Send(string to, string subject, string body, List<string> cc, List<Model.Attachment> files, List<string> tags)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all CC recipients to a list of emailaddress.
            List<Mandrill.EmailAddress> recipients = ConvertRecipients(cc);

            // Add all attachments to a list of attachment.
            List<Mandrill.attachment> attachments = ConvertAttachments(files);

            // Send the email to mandrill.
            SendToMandrill(email, recipients, attachments, tags:tags);
        }

        /// <summary>
        /// Send an email with all extra parameters optional.
        /// Only those provided will be used.
        /// </summary>
        /// <param name="to">The to email address.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        /// <param name="cc">A list of email addresses to CC.</param>
        /// <param name="files">A list of file attachments to send with the email.</param>
        /// <param name="tags">A list of tags to attach to the email.</param>
        /// <param name="tracking">Whether to track clicks and opens.</param>
        /// <param name="replyto">The reply to address(es) for the email.</param>
        /// <param name="plain">A plain text version of the email.</param>
        public static void Send(string to, string subject, string body, List<string> cc = null, List<Model.Attachment> files = null,
                                List<string> tags = null, bool tracking = false, string replyto = null, string plain = null)
        {
            Mandrill.EmailMessage email = BaseEmail(to, subject, body);

            // Add all CC recipients to a list of emailaddress.
            List<Mandrill.EmailAddress> recipients = (cc == null ? null : ConvertRecipients(cc));

            // Add all attachments to a list of attachment.
            List<Mandrill.attachment> attachments = (files == null ? null : ConvertAttachments(files));

            // Send the email to mandrill.
            SendToMandrill(email, recipients, attachments, replyto, tags, tracking, plain);
        }

        /// <summary>
        /// Sends the constructed email to mandrill,
        /// adding required extra parameters.
        /// </summary>
        private static void SendToMandrill(Mandrill.EmailMessage email, List<Mandrill.EmailAddress> cc = null,
                                           List<Mandrill.attachment> attachments = null, string replyTo = null,
                                           List<string> tags = null, bool tracking = false, string plain = null)
        {
            Mandrill.MandrillApi api = new Mandrill.MandrillApi(CONFIG.ApiKey);

            // Loop through and add all recipients to the mandrill email.
            if (cc != null)
            {
                List<Mandrill.EmailAddress> recipients = (List<Mandrill.EmailAddress>) email.to.ToList();
                foreach (Mandrill.EmailAddress address in cc) {
                    recipients.Add(address);
                }
                email.to = recipients;
            }

            // Add tags if required, as well as project tag.
            if (tags == null) { tags = new List<string>(); };
            tags.Add(CONFIG.ProjectTag);
            if (tags != null)
            {
                
            }
            email.tags = tags;

            // Add plain text if required.
            if (plain != null)
            {
                email.text = plain;
            }

            // Set reply-to address.
            if (replyTo != null)
            {
                email.AddHeader("Reply-To", replyTo);
            }

            // Add any attachments.
            if (attachments != null) 
            {
                email.attachments = attachments;
            }

            // Set subaccount if required.
            if (CONFIG.SubAccount != null)
            {
                email.subaccount = CONFIG.SubAccount;
            }
            else
            {
                if (CONFIG.TrapApiKey == CONFIG.ApiKey && CONFIG.TrapAccount != null)
                {
                    email.subaccount = CONFIG.TrapAccount;
                }
            }

            // Set tracking options.
            email.track_clicks = tracking;
            email.track_opens = tracking;

            try
            {
                api.SendMessage(email);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get a base EmailMessage from the to,
        /// subject and body fields using CONFIG options.
        /// </summary>
        private static Mandrill.EmailMessage BaseEmail(string to, string subject, string body)
        {
            Mandrill.EmailMessage email = new Mandrill.EmailMessage();

            // Add to recipient.
            // Uses trap email if the trap API key is being used.
            List<Mandrill.EmailAddress> recipients = new List<Mandrill.EmailAddress>();
            recipients.Add(new Mandrill.EmailAddress() { email = (CONFIG.ApiKey != CONFIG.TrapApiKey ? to : CONFIG.TrapEmail) });

            // Add basic options and defaults.
            email.to = recipients;
            email.subject = subject;
            email.html = body;
            email.from_name = CONFIG.FromName;
            email.from_email = CONFIG.FromEmail;

            return email;
        }

        /// <summary>
        /// Convert a list of CC strings to a list of EmailAddress.
        /// Uses trap email if the trap API key is being used.
        /// </summary>
        private static List<Mandrill.EmailAddress> ConvertRecipients(List<string> cc)
        {
            List<Mandrill.EmailAddress> recipients = new List<Mandrill.EmailAddress>();
            foreach (string recipient in cc)
            {
                recipients.Add(new Mandrill.EmailAddress() { email = (CONFIG.ApiKey != CONFIG.TrapApiKey ? recipient : CONFIG.TrapEmail) });
            }
            return recipients;
        }

        /// <summary>
        /// Converts a list of model.attachment to a list of mandrill.attachment.
        /// </summary>
        private static List<Mandrill.attachment> ConvertAttachments(List<Model.Attachment> files)
        {
            List<Mandrill.attachment> attachments = new List<Mandrill.attachment>();
            foreach (Model.Attachment file in files)
            {
                attachments.Add(new Mandrill.attachment { content = Convert.ToBase64String(file.data), name = file.name, type = "application/octet-stream" });
            }
            return attachments;
        }
    }
}
