using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.RepositoryContract;
using Service.Models;
using Service.ServiceContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Service.Service
{
    public class HomeService: IHomeService
    {

        //Dependency Injection
        IHomeRepository homeRepository;
        public HomeService()
        {
            homeRepository= ServiceFactory.GetHomeRepository();
        }

        
        //if the credential exist create session and return true
        //else return false
        public bool IsUserExist(UserModel userModel)
        {
            User user = new User
            {
                UserName = userModel.UserName,
                Password = userModel.Password
            };
            if (homeRepository.UserFound(user).Any())
            {
                homeRepository.CreateUserSession(user);
                return true;
            }
            return false;
        }

        //If the user name already exist returns true else returns false
        public bool IsUserNameAlreadyExist(UserModel userModel) {
            User user = new User
            {
                UserName = userModel.UserName,
            };
            if (homeRepository.DuplicateRecord(user).Any())
            {
                return true;
            }
            return false;
        }


        //Register the details of the user
        public void RegisterUser(UserModel userModel)
        {
            User user = new User
            {
                FullName = userModel.FullName,
                UserName = userModel.UserName,
                Password = userModel.Password,
                ContactNumber = userModel.ContactNumber,
                EmailId = userModel.EmailId
            };
            homeRepository.RegisterUser(user);
        }

        //if the credential exist create session and return true
        //else return false
        public bool IsAdminExist(AdminModel adminModel)
        {
            Admin admin = new Admin
            {
                UserName = adminModel.UserName,
                Password = adminModel.Password
            };
            if (homeRepository.AdminFound(admin).Any())
            {
                HttpContext.Current.Session["Role"] = "Admin";
                return true;
            }
            return false;
        }



    }
}
