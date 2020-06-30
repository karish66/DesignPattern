using Service.Service;
using Service.ServiceContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation
{
    /// <summary>
    /// Factory Pattern to hide the creational logic.
    /// We defined a interface for creating an object.
    /// </summary>
    public class ServiceFactory
    {
        public static IHomeService GetHomeService()
        {
            return new HomeService();
        }
    }
}