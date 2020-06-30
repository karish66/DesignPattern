using Presentation.Models;
using Service.Models;
using Service.Service;
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
    /// This controller hepls to Register New User to the portal
    /// allow User SignIn and Admin SignIn.
    /// Apparently, for Admin LogIn you can use
    /// UserName : Admin and Password: xyz@123
    /// Apparently, for User LogIn you can use
    /// UserName : Karish66 and Password: karishma@kesari
    /// </summary>

    [AllowAnonymous]
    public class HomeController : Controller
    {
      
        //Dependency Injection
        IHomeService homeService;
        public HomeController()
        {
            homeService = ServiceFactory.GetHomeService();
        }


        //takes the user to home page
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }


        //takes the user to user login page
        // GET: Home/UserLogin
        public ActionResult UserLogin()
        {            
            return View();
        }
        // POST: Home/UserLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin([Bind(Include = "UserName, Password")] User user)
        {
            UserModel userModel = new UserModel
            {
                UserName = user.UserName,
                Password = user.Password
            };
            //if the user exist redirect to the dashboard with a different layout
            //else sends validation error
            if (homeService.IsUserExist(userModel)) {
                return RedirectToAction("Dashboard", "User");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName and Password.");
            }
            return View();
        }


        //takes the user to Sign Up page , if the user is not registered yet
        // GET: Home/SignUp
        public ActionResult SignUp()
        {
            return View();
        }
        // POST: Home/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "FullName, UserName, Password, ContactNumber, EmailId")]User user)
        {
            try
            {
                //if the fields are not valid returns the validation error
                if (!ModelState.IsValid) {
                    return View();
                }

                UserModel userModel = new UserModel
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Password = user.Password,
                    ContactNumber = user.ContactNumber,
                    EmailId = user.EmailId
                };
                //if the username already exist return validation error
                if (homeService.IsUserNameAlreadyExist(userModel))
                {
                    ModelState.AddModelError("UserName", "This User Name is already  registered.");
                }
                //register the details of the user
                homeService.RegisterUser(userModel);
                return RedirectToAction("UserLogin");
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to register. Please try again. If the problem persists see your system administrator.");
            }
            return View();
        }



        // GET: Home/AdminLogin
        public ActionResult AdminLogin()
        {
           return View();
        }
        // POST: Home/AdminLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin([Bind(Include = "UserName, Password")] Admin admin)
        {
            AdminModel adminModel = new AdminModel
            {
                UserName = admin.UserName,
                Password = admin.Password
            };
            //if admin exist redirect to the dashboard with different layout
            //else return validation error
            if (homeService.IsAdminExist(adminModel))
            {
                return RedirectToAction("Dashboard","Admin");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName and Password.");
            }
            return View();
        }
    }
}