using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using saltingandhashing.Models;
using saltingandhashing.Models.DTO;
using saltingandhashing.Services;

namespace saltingandhashing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //create global variable to access service
        private readonly UserService _data;
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }

        //function to add our user type of CreateAccountDTO called UserToAdd, this will return a bool once our user is added

        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }

        //GetAllUsers
        [HttpGet("GetAllUsers")]

        //ienumerable helps us iterate through a collection of data and gives flexibility between lists, arrays, etc. (various objects)
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();
        }

        //GetUserByUsername

        [HttpGet("GetUserByUserName")]

        public UserIdDTO GetUserDTOUserName(string username)
        {
            return _data.GetUserIdDTOByUserName(username);
        }
        //Login Endpoint

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        [HttpPost("DeleteUser/{userToDelete}")]
    
            public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        //update user

        [HttpPut("UpdateUser{username}")]
        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUser(id, username);
        }

    }
}