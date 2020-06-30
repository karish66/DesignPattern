using Presentation.ModeOfCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation
{
    public class HelpNotification : NotificationAbstract
    {
        readonly NotificationType nNotificationType;
        public HelpNotification(NotificationType notificationType)
        {
            nNotificationType = notificationType;
        }

        public override void Deliver(string description)
        {
            EmailNotify emailNotify = new EmailNotify();
            emailNotify.Notify(description);
            SMSNotify smsNotify = new SMSNotify();
            smsNotify.Notify(description);
        }
    }
}