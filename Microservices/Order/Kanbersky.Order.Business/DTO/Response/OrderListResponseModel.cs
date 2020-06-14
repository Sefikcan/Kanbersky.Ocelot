using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.Entities.Concrete;
using System.Collections.Generic;

namespace Kanbersky.Order.Business.DTO.Response
{
    public class OrderListResponseModel
    {
        [Sortable(OrderBy = "OrderTotal")]
        public decimal OrderTotal { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
