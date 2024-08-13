using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Managers
{
    /// <summary>
    /// This class contains the main mail operations
    /// </summary>
    public class MailManager
    {
        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Send mail from the server</summary>                             ///
        /// <param name="subject">Message subject</param>                             ///
        /// <param name="body">Message body</param>                                   ///
        /// <param name="recipients">List<User> (Optional)                            ///
        /// <returns>boolean</returns>                                                ///
        /////////////////////////////////////////////////////////////////////////////////
        public bool SendMail(String subject, string body, List<User> recipients, bool IsBodyHtml)
        {            
            //Instantiate new mail object
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Complete recipient mail address / addresses 
            //if empty send to default address 
            if (recipients == null || recipients.Count == 0) mmsg.To.Add("info@torneocampoy.tk");
            else
            {
                foreach (var item in recipients)
                {
                    mmsg.To.Add(item.Email);
                }
            }

            //Message subject
            mmsg.Subject = subject;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Message body
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = IsBodyHtml;

            //Sender mail addredd
            //Eliminado por seguridad

            //Instantiate new mail client objet
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            //Mail credentials
            client.Credentials = new System.Net.NetworkCredential("a@aa.com", "aaa");
            client.Host = "eliminado por seguridad";

            try
            {
                //Send message  
                client.Send(mmsg);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}