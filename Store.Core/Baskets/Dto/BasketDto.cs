using System.Collections.Generic;

namespace Store.Core.Baskets.Dto
{
    public class BasketDto
    {

        public string Id { get; set; }

        public List<BasketItemDto> Items { get; set; }
    }
}
