using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.DTOS;
using Catalog;
using WEBAPI.Repositories;
using WEBAPI.Entities;
using Catalog.DTOS;

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

        [HttpPost]
        [Route("")]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new () {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            repository.CreateItemDto(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());

        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateItem(Guid id , UpdateItemDto itemDto)
        {
            var ei = repository.GetItem(id);

            if (ei == null)
            {
                return NotFound();
            }

            var updatedItem = ei with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);
        

            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var ei = repository.GetItem(id);

            if (ei == null)
            {
                return NotFound();
            }


            repository.DeleteItem(id);
        

            return NoContent(); 

        }



    }
}