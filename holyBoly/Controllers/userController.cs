using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using holyBoly.Repositories;
using holyBoly.Entities;

namespace holyBoly.Controllers{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository repository;

        public UserController(){
            repository = new UserRepository();
        }
        [HttpPost]
        [Route("signUp")]
        public Message SignUp([FromBody]User user){
           return repository.signUp(user);
        }
        [HttpPost]
        [Route("login")]
        public Message login([FromBody]User user){
           return repository.login(user);
        }
          [HttpPost]
        [Route("changeProfile")]
        public Message changeProfile([FromBody]User user){
           return repository.updateProfile(user);
        }
    }
}