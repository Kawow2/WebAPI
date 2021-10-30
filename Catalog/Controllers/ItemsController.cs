using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Entities;
using WEBAPI.Repositories;

namespace WEBAPI.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase 
    {
        private readonly InMemItemsRepository repository; 

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems() 
        {
            return repository.GetItems();
        }
    }
}