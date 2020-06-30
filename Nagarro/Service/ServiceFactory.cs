using DataAccess.Repository;
using DataAccess.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Factory Pattern to hide the creational logic.
    /// We defined a interface for creating an object.
    /// </summary>
    public class ServiceFactory
    {
        public static IHomeRepository GetHomeRepository()
        {
            return new HomeRepository();
        }

    }
}
