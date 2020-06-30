using Presentation.ModeOfCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.NotificationTemplates
{
    public class NewsNotification : NotificationAbstract
    {
        readonly NotificationType nNotificationType;
        public NewsNotification(NotificationType notificationType)
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