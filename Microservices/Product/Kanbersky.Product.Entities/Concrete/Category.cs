using Kanbersky.Ocelot.Core.Entity;
using Kanbersky.Product.Entities.Abstract;
using System.Collections.Generic;

namespace Kanbersky.Product.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
