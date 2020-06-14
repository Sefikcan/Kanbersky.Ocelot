using AutoMapper;
using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.Business.DTO.Response;

namespace Kanbersky.Order.Business.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Entities.Concrete.Order, OrderListResponseModel>()
                .ReverseMap();

            CreateMap<PagedResult<Entities.Concrete.Order>, PagedResult<OrderListResponseModel>>()
                .ReverseMap();
        }
    }
}
