using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.DTOS;
using Catalog;
using WEBAPI.Repositories;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items =  repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
    }
}