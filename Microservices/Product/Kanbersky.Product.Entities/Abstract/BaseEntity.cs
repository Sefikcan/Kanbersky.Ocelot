using System.ComponentModel.DataAnnotations;

namespace Kanbersky.Product.Entities.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
