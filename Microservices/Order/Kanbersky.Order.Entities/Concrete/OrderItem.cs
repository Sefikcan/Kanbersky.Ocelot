using Kanbersky.Ocelot.Core.Entity;
using Kanbersky.Order.Entities.Abstract;

namespace Kanbersky.Order.Entities.Concrete
{
    public class OrderItem : BaseEntity, IEntity
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public decimal OrderItemTotal { get; set; }

        public Order Order { get; set; }
    }
}
