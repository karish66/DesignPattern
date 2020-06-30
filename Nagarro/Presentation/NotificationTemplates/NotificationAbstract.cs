using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation
{
    public abstract class NotificationAbstract
    {
        public abstract void Deliver(string description);

    }
}