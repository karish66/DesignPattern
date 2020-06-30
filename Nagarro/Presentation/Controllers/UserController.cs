using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// This controller helps to view the notification and 
    /// delete the notification.
    /// </summary>

    [Authenticate]
    public class UserController : Controller
    {
        private NagarroContext db = new NagarroContext();

        // GET: User/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        //To see the list of notification
        // GET: User/SeeNotification
        public ActionResult SeeNotification()
        {
            int CurrentUserId = (int)Session["CurrentUserId"];
            var count =  from y in db.MapRelations
                         where y.UserId == CurrentUserId
                         select y.NotificationId;
           
            List<Notification>  table = new List<Notification>();
            foreach (int i in count)
            {
                var record = from y in db.Notifications
                            where y.Id == i
                            select y;
                table.AddRange(record);
            }
            return View(table.ToList());
        }

        //To deletes the notification
        public ActionResult Delete(bool? saveChangesError = false)
        {
            int CurrentUserId = (int)Session["CurrentUserId"];
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var count =  from y in db.MapRelations
                         where y.UserId == CurrentUserId
                         select y;

            
            foreach (var i in count) {
                var x = (from y in db.MapRelations
                         where y.UserId == CurrentUserId
                         select y).FirstOrDefault();
                db.MapRelations.Remove(x);
            }
            db.SaveChanges();
            return RedirectToAction("SeeNotification", "User");
        }


        //To logout from the current session
        //GET: User/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("UserLogin", "Home");
        }

    }
}