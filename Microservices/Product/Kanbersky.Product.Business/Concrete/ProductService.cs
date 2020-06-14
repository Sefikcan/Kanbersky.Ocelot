using Dapper;
using Kanbersky.Ocelot.Core.Helpers.Pagination;
using Kanbersky.Product.Business.Abstract;
using Kanbersky.Product.Business.DTO.Request;
using Kanbersky.Product.Business.DTO.Response;
using Kanbersky.Product.Business.Helpers;
using Kanbersky.Product.DAL.Concrete.Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanbersky.Product.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDbConnection _dbConnection;

        public ProductService(IProductDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Pagination<ProductListResponseModel>> GetAllProducts(ProductListRequestModel requestModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageSize", requestModel.PageSize);
            parameters.Add("@Offset",requestModel.Page);

            await using var connection = _dbConnection.CreateDbConnection();            
            var products = await connection.QueryMultipleAsync(ProductQuery(requestModel),parameters);

            var productListResponseModel = new ProductListResponseModel();

            var productResult = products.Read<ProductServiceResponseModel, CategoryServiceResponseModel, ProductListResponseModel>
                ((product, category) => {
                    product.CategoryServiceResponseModel = category;
                    productListResponseModel.ProductServiceResponseModel = product;

                    return productListResponseModel;
                }
                , splitOn:"CategoryId");

            var totalItemCount = products.Read<int>().FirstOrDefault();

            var productResponse = PaginationService.GetPagination(
                productResult.AsQueryable(), 
                requestModel.Page.Value,
                string.Empty ,
                true,
                requestModel.PageSize.Value);

            return productResponse;
        }

        private static string ProductQuery(ProductListRequestModel requestModel)
        {
            var sortingString = new StringBuilder();

            var sortType = ProductConstants.Asc;
            if (requestModel.IsOrderByDesc)
            {
                sortType = ProductConstants.Desc;
            };

            if (!string.IsNullOrEmpty(requestModel.OrderByField))
            {
                sortingString = new StringBuilder($" ORDER BY A.{requestModel.OrderByField} {sortType}");
            }

            var query = new StringBuilder();
            query.Append($@"
                 SELECT * FROM
                   (select
                    P.Id AS ProductId,
                    p.ProductName,
                    p.StockQuantity,
                    C.Id as CategoryId,
                    C.CategoryName
                    from Product (nolock) as P 
                    inner join Category (NOLOCK) as C 
                    on P.CategoryId = C.Id
                    ORDER BY P.Id
                    OFFSET (@Offset - 1) ROWS
                    FETCH NEXT @PageSize ROWS ONLY
                    ) A
                    {sortingString}
                    ;
                ");

            query.Append(@" SELECT COUNT(ProductId) AS [TotalItemCount]
                            FROM
                            (
                                SELECT P.Id AS ProductId
                                FROM   Product (NOLOCK) P
                                INNER JOIN Category (NOLOCK) C ON C.Id = P.CategoryId
				            ) A; 
                        ");

            return query.ToString();
        }
    }
}
