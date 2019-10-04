using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Repository
{
    public class UserRepository : IRepository<UserModel>
    {
        private List<UserModel> context;

        public UserRepository()
        {
            context = new List<UserModel>();
        }

        public void AddOrUpdate(UserModel user)//REDO
        {
            UserModel _user = Get(user.Id);

            if (_user == null)
                context.Add(user);
            else
            {
                _user.Name = user.Name;
                _user.Birthday = user.Birthday;
                _user.Address = user.Address;
                _user.Phone = user.Phone;
            }
        }

        public UserModel Get(int id)//redo
        {
            UserModel user = null;
            try
            {
                user = context.First(u => u.Id == id);

            }
            catch (Exception e)
            { }
            return user;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return context;
        }

        public void Remove(int id)
        {
            context.Remove(Get(id));
        }
    }
}
