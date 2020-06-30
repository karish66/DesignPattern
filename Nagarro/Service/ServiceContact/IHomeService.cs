using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceContact
{
    /// <summary>
    /// The interface contains unimplemented functions
    /// The subclasses decides which class to instantiate
    /// </summary>
    public interface IHomeService
    {
        bool IsUserExist(UserModel userModel);
        bool IsUserNameAlreadyExist(UserModel userModel);
        void RegisterUser(UserModel userModel);
        bool IsAdminExist(AdminModel adminModel);
    }
}
