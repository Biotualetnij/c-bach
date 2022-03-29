using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using holyBoly.Repositories;
using holyBoly.Entities;

namespace holyBoly.Controllers{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemsController(){
            repository = new InMemItemsRepository();
        }
        [HttpGet] 
        public IEnumerable<Item> GetItems(){
            var items = repository.GetItems();
            return items;
        }
        [HttpPost]
        [Route("createItem")]
        public Message login([FromBody]Item user){
           return repository.createItem(user);
        }
    }
}