using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.Business.DTO.Request;
using Kanbersky.Order.Business.DTO.Response;

namespace Kanbersky.Order.Business.Abstract
{
    public interface IOrderService
    {
        PagedResult<OrderListResponseModel> GetAll(OrderListRequestModel requestModel);
    }
}
