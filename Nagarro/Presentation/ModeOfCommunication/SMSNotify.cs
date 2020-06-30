using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Configuration;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace Presentation.ModeOfCommunication
{
    
    public class SMSNotify : IModeOfCommunication
    {
        private NagarroContext db = new NagarroContext();
        public void Notify(string description)
        {
            System.Diagnostics.Debug.WriteLine("Notifying through SMS");
            //TwilioClient.Init(
            //Environment.GetEnvironmentVariable("AccountSID", "AC669b1cacba5199a98e28b903c981d22b"),
            //Environment.GetEnvironmentVariable("AuthToken", "208a4bf91d4f692e19d253e96839fa31")
            //);


            var columnOfContactNumber = from s in db.Users
                                        select s.ContactNumber;

            foreach (string msgRecepient in columnOfContactNumber)
            {
                System.Diagnostics.Debug.WriteLine(description+"messgage sent to :" + msgRecepient);
                //var to = new PhoneNumber(msgRecepient);
                //var from = new PhoneNumber("+12057281412");
                //var body = description;
                //MessageResource.Create(
                //        to: to,
                //        from: from,
                //        body: body);

            }

        }
    }
}