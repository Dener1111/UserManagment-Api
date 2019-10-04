using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Models;
using UserManager.Repository;

namespace UserManager.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<UserModel> repo;

        public UserServices(IRepository<UserModel> repository)
        {
            repo = repository;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return repo.GetAll();
        }

        public UserModel GetUser(int id)
        {
            return repo.Get(id);
        }

        public UserModel AddUser(User user)
        {
            UserModel _user = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Birthday = user.Birthday > DateTime.Now ? new DateTime(1970, 1, 1) : user.Birthday,
                Address = user.Address,
                Phone = user.Phone,
                CreationTime = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
            };

            repo.AddOrUpdate(_user);
            return GetUser(user.Id);
        }
        
        public void RemoveUser(int id)
        {
            repo.Remove(id);
        }
    }
}
