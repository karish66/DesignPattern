using DataAccess.Entities;
using DataAccess.RepositoryContract;
using System;
using System.Linq;
using System.Web;

namespace DataAccess.Repository
{
    public class HomeRepository :IHomeRepository
    {
        private NagarroContext db = new NagarroContext();


        //Return the record of the user if found
        public IQueryable<User> UserFound(User user)
        {
            var z = from q in db.Users
                    where q.UserName == user.UserName
                    && q.Password == user.Password
                    select q;
            return z;
        }

        //Create the session of the user for authentication and authorization
        public void CreateUserSession(User user)
        {
            var z = from q in db.Users
                    where q.UserName == user.UserName
                    select q.Id;
            HttpContext.Current.Session["CurrentUserId"] = z.First();
            HttpContext.Current.Session["Role"] = "User";
        }


        //Returns the duplicate Username if found
        public IQueryable<String> DuplicateRecord(User user) {
            var z = from u in db.Users
                    where u.UserName == user.UserName
                    select u.UserName;
            return z;
        }


        //Stores the details of the user as a record in the database
        public void RegisterUser(User user) {
            db.Users.Add(user);
            db.SaveChanges();
        }


        //Return the record of the admin if found
        public IQueryable<Admin> AdminFound(Admin admin)
        {
            var s = from q in db.Admins
                    where q.UserName == admin.UserName
                    && q.Password == admin.Password
                    select q;
            return s;
        }
    }
}
