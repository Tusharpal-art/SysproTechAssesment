using SysproTech.App.Interfaceses;
using SysproTech.App.Requestses.Product;
using SysproTech.App.Res;
using SysproTech.App.Responses;

namespace SysproTech.App.Serviceses
{
    public class ProductServices(IApiServices apiServices) : IProductServices
    {
        public async Task<Result<ProductResponse>> AddProduct(AddProductModel model)
        {
            var result = await apiServices.PostAsync<ProductResponse>("Product/AddProduct", model);
            return result;
        }

        public async Task<Result<AllRecord<ProductResponse>>> GetProductList(GetProductListModel dto)
        {
            
            string query = $"IsDeleted={dto.IsDeleted}&Search={dto.Search}&PageNumber={dto.PageNumber}&PageSize={dto.PageSize}&SortBy={dto.SortBy}&IsAscending={dto.IsAscending}";
            var result = await apiServices.GetAsync<AllRecord<ProductResponse>>($"Product/GetAllProduct?{query}");
            return result;
        }

        public  async Task<Result<ProductResponse>> UpdateProduct(UpdateProductRequest model)
        {
            var result = await apiServices.PutAsync<ProductResponse>("Product/UpdateProduct", model);
            return result;
        }
    }
}
