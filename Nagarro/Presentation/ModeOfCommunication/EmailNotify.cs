using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Presentation.ModeOfCommunication
{
    public class EmailNotify : IModeOfCommunication
    {
        private NagarroContext db = new NagarroContext();
        public void Notify(string description)
        {
            System.Diagnostics.Debug.WriteLine("Notifying through Email");
            
            var columnOfEmailId = from s in db.Users
                                        select s.EmailId;

            foreach (string msgRecepient in columnOfEmailId)
            {
                System.Diagnostics.Debug.WriteLine(description + "Email sent to :" + msgRecepient);
                //MailMessage mailMessage = new MailMessage("testmvc475@gmail.com", user);
                //mailMessage.Subject = eventmodel.EventType + "---" + eventmodel.EventName;
                //mailMessage.Body = eventmodel.EventDescription;
                //mailMessage.IsBodyHtml = false;
                //SmtpClient smtpClient = new SmtpClient();
                //smtpClient.Host = "smtp.gmail.com";
                //smtpClient.Port = 587;
                //smtpClient.EnableSsl = true;
                //NetworkCredential networkCredential = new NetworkCredential("testmvc475@gmail.com", "1@notification");
                //smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = networkCredential;
                //smtpClient.Send(mailMessage);

            }
        }
    }
}