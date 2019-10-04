using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Services
{
    public interface IUserServices
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUser(int id);
        UserModel AddUser(User users);
        void RemoveUser(int id);
    }
}
