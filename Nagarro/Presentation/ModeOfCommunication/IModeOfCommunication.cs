using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.ModeOfCommunication
{
    public interface IModeOfCommunication
    {
        void Notify(string description);
    }
}