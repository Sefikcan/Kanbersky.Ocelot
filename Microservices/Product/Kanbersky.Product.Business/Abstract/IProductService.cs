using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Product.Business.DTO.Request;
using Kanbersky.Product.Business.DTO.Response;
using System.Threading.Tasks;

namespace Kanbersky.Product.Business.Abstract
{
    public interface IProductService
    {
        Task<Pagination<ProductListResponseModel>> GetAllProducts(ProductListRequestModel requestModel);
    }
}
