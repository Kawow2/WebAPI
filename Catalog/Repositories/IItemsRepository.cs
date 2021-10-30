using System;
using System.Collections.Generic;
using WEBAPI.Entities;

namespace WEBAPI.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}