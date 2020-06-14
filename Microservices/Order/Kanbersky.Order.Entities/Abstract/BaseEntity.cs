using System.ComponentModel.DataAnnotations;

namespace Kanbersky.Order.Entities.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
