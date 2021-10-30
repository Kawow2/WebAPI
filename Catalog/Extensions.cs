using System.Threading;
using WEBAPI.DTOS;
using WEBAPI.Entities;

namespace WEBAPI
{
    public static class Extensions{
        public static ItemDto AsDto(this Item item)
        {
            return  new ItemDto {
                Id = item.Id,
                Name = item.Name,
                CreatedDate = item.CreatedDate,
                Price = item.Price,

            };
        }
    }
}