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
        public String SignUp([FromBody]User user){
           return repository.signUp(user);
        }
    }
}