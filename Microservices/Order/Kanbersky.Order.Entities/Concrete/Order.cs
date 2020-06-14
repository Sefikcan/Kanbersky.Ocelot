using Kanbersky.Ocelot.Core.Entity;
using Kanbersky.Order.Entities.Abstract;
using System.Collections.Generic;

namespace Kanbersky.Order.Entities.Concrete
{
    public class Order : BaseEntity, IEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public decimal OrderTotal { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
