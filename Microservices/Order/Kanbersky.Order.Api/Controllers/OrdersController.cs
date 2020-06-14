using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Order.Business.Abstract;
using Kanbersky.Order.Business.DTO.Request;
using Kanbersky.Order.Business.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.Order.Api.Controllers
{
    /// <summary>
    /// Orders Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="orderService"></param>
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Get Pageble Order
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Pagination<OrderListResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery]OrderListRequestModel requestModel)
        {
            var order = _orderService.GetAll(requestModel);
            return Ok(order);
        }
    }
}