using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.Models;
using UserManager.Services;

namespace UserManager.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices services;

        public UserController(IUserServices _services)
        {
            services = _services;
        }

        [HttpGet]
        [Route("users/{id}")]
        public ActionResult<UserModel> GetUsers(int id)
        {
            var _user = services.GetUser(id);

            if (_user == null)
                return NotFound();

            return Ok(_user);
        }

        [HttpGet]
        [Route("users")]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            var _users = services.GetUsers();

            if (_users.Count() == 0)
                return NotFound();

            return Ok(_users);
        }
        
        [HttpPost]
        [Route("users")]
        public ActionResult<UserModel> AddUser(User user)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var _user = services.AddUser(user);

            if (_user == null)
                return NotFound();

            return Ok(_user);
        }

        [HttpPut]
        [Route("users/{id}")]
        public ActionResult<UserModel> EditUser(int id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (user.Id != id)
                return BadRequest();

            var _user = services.GetUser(id);
            if (_user == null)
                return NotFound();

            var addadUser = services.AddUser(user);

            if (addadUser == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete]
        [Route("users/{id}")]
        public ActionResult<UserModel> RemoveUser(int id)
        {
            var user = services.GetUser(id);
            if(user == null)
                return NotFound();

            services.RemoveUser(id);
            return Ok(user);
        }
    }
}