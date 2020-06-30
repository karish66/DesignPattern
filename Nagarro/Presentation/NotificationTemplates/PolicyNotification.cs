using Presentation.ModeOfCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.NotificationTemplates
{
    public class PolicyNotification : NotificationAbstract
    {
        NotificationType nNotificationType;
        public PolicyNotification(NotificationType notificationType)
        {
            nNotificationType = notificationType;
        }

        public override void Deliver(string description)
        {
            EmailNotify emailNotify = new EmailNotify();
            emailNotify.Notify(description);
            PortalNotify portalNotify = new PortalNotify();
            portalNotify.Notify(description);
        }
    }
}