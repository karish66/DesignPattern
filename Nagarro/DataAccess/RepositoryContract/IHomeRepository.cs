using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryContract
{
    /// <summary>
    /// The interface contains unimplemented functions
    /// The subclasses decides which class to instantiate
    /// </summary>
    public interface IHomeRepository
    {
        IQueryable<User> UserFound(User user);
        void CreateUserSession(User user);
        IQueryable<string> DuplicateRecord(User user);
        void RegisterUser(User user);
        IQueryable<Admin> AdminFound(Admin admin);
    }
}
