using Presentation.Models;
using Service.Models;
using Service.ServiceContact;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// This helps the admin to create the notification.
    /// Based on the various templates the user can create notification.
    /// The mode of communictaion of respective template will be called.
    /// </summary>
    [Authorization]
    public class AdminController : Controller
    {
        private NagarroContext db = new NagarroContext();
       

        // GET: Admin/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }


        //To create the notification as per the template
        // GET: Admin/CreateNotification
        public ActionResult CreateNotification()
        {
            return View();
        }
        // POST: Admin/CreateNotification
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNotification([Bind(Include = "Id, NotificationType, Subject, Description")] Notification notification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //save the record in Notification table
                    db.Notifications.Add(notification);
                    db.SaveChanges();

                    //save the record in the MapRelation table
                    var columnofuserid = from s in db.Users
                                         select s.Id;

                    foreach (int userid in columnofuserid)
                    {
                        MapRelation mapRelation = new MapRelation
                        {
                            UserId = userid,
                            NotificationId = notification.Id
                        };
                        db.MapRelations.Add(mapRelation);
                    }
                    db.SaveChanges();

                    //Call the templates of the notification based on the NotificationType and implements the
                    //relevatant mode of communication
                    NotificationAbstract notificationObj = NotificationFactory.GetNotification(notification.NotificationType);
                    notificationObj.Deliver(notification.Description);

                    ModelState.Clear();
                    return RedirectToAction("CreateNotification");
                }
                
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to register. Please try again. If the problem persists see your system administrator.");
            }
            return View(notification);
        }


        //To logout from the current session
        //GET: Admin/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("AdminLogin", "Home");
        }
    }
}