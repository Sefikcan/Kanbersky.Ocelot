using Kanbersky.Ocelot.Core.Helpers.Pagination;

namespace Kanbersky.Product.Business.DTO.Response
{
    public class ProductServiceResponseModel
    {
        public int ProductId { get; set; }

        [Sortable(OrderBy ="ProductName")]
        public string ProductName { get; set; }

        public int StockQuantity { get; set; }

        public CategoryServiceResponseModel CategoryServiceResponseModel { get; set; }
    }
}
