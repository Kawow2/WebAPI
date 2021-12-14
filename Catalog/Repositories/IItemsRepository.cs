using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WEBAPI.Entities;

namespace WEBAPI.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItemDto(Item item);

        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}