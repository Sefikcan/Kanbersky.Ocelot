using Kanbersky.Ocelot.Core.Entity;
using Kanbersky.Product.Entities.Abstract;

namespace Kanbersky.Product.Entities.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public string ProductName { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
