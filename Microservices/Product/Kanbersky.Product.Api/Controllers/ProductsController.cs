using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Product.Business.Abstract;
using Kanbersky.Product.Business.DTO.Request;
using Kanbersky.Product.Business.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kanbersky.Product.Api.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get Pageable Products
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Pagination<ProductListResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery]ProductListRequestModel requestModel)
        {
            var order = await _productService.GetAllProducts(requestModel);
            return Ok(order);
        }
    }
}