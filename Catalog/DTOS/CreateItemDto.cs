using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace  WEBAPI.DTOS
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
        
        
    }
}