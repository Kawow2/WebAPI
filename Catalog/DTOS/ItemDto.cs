using System;

namespace WEBAPI.DTOS
{
    public record ItemDto {

        public Guid Id { get; init; } // init = setvalue seulement à l'initialisation 
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    } 
}