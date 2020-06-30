using Presentation.NotificationTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation
{
    public class NotificationFactory
    {
        public static NotificationAbstract GetNotification(NotificationType type) {
            if (type == NotificationType.Event)
            {
                return new EventNotification(type);
            }
            else if (type == NotificationType.Help)
            {
                return new HelpNotification(type);
            }
            else if (type == NotificationType.Holiday)
            {
                return new HolidayNotification(type);
            }
            else if (type == NotificationType.News)
            {
                return new NewsNotification(type);
            }
            else if (type == NotificationType.Policy)
            {
                return new PolicyNotification(type);
            }


            return null;
        }
    }
}