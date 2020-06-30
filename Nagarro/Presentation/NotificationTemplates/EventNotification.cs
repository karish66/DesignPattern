using Presentation.ModeOfCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation
{
    public class EventNotification: NotificationAbstract
    {
        readonly NotificationType nNotificationType;
        public EventNotification(NotificationType notificationType) {
            nNotificationType = notificationType;
        }

        public override void Deliver(string description) {
            EmailNotify emailNotify = new EmailNotify();
            emailNotify.Notify(description);
            PortalNotify portalNotify = new PortalNotify();
            portalNotify.Notify(description);
        }

    }
}