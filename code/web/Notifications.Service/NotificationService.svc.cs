using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FluentEmail;

namespace Notifications.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NotificationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NotificationService.svc or NotificationService.svc.cs at the Solution Explorer and start debugging.
    public class NotificationService : INotificationService
    {
        private const string EmailAccount = "mailtestingproj@gmail.com";
        private const string EmailPassword = "mailtestingproj__";
        public void SendEmail(string userEmail, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential(EmailAccount, EmailPassword);
            client.EnableSsl = true;
            try
            {
                Email.From(EmailAccount)
               .To(userEmail)
               .Subject("Your AsiTech Order")
               .Body(message)
               .UsingClient(client)
               .Send();
            }
            catch
            {

            }


        }
    }
}
