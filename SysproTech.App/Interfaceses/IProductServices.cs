using SysproTech.App.Requestses;
using SysproTech.App.Requestses.Product;
using SysproTech.App.Res;
using SysproTech.App.Responses;

namespace SysproTech.App.Interfaceses
{
    public interface IProductServices
    {
        public Task<Result<AllRecord<ProductResponse>>> GetProductList(GetProductListModel model);
        public Task<Result<ProductResponse>> AddProduct(AddProductModel model);
        public Task<Result<ProductResponse>> UpdateProduct(UpdateProductRequest model);
    }
}
