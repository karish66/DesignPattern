using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.ModeOfCommunication
{
    public class PortalNotify : IModeOfCommunication
    {
        public void Notify(string description)
        {
            System.Diagnostics.Debug.WriteLine("Notify through Portal");
        }
    }
}