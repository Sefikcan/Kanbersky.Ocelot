using AutoMapper;
using Kanbersky.Ocelot.Core.Extensions;
using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.Business.Abstract;
using Kanbersky.Order.Business.DTO.Request;
using Kanbersky.Order.Business.DTO.Response;
using Kanbersky.Order.DAL.Concrete.EntityFramework.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Kanbersky.Order.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Entities.Concrete.Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IGenericRepository<Entities.Concrete.Order> orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public PagedResult<OrderListResponseModel> GetAll(OrderListRequestModel requestModel)
        {
            var order = _orderRepository.GetQueryable().Include(x => x.OrderItems).GetPaged(requestModel.Page.Value, requestModel.PageSize.Value);

            var mappedOrder = _mapper.Map<PagedResult<OrderListResponseModel>>(order);

            return mappedOrder;
        }
    }
}
