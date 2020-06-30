using Presentation.ModeOfCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.NotificationTemplates
{
    public class HolidayNotification: NotificationAbstract
    {
        readonly NotificationType nNotificationType;
        public HolidayNotification(NotificationType notificationType)
        {
            nNotificationType = notificationType;
        }

        public override void Deliver(string description)
        {
            PortalNotify portalNotify = new PortalNotify();
            portalNotify.Notify(description);
        }
    }
}