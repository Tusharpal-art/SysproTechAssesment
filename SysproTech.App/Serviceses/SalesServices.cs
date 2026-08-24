using SysproTech.App.Interfaceses;
using SysproTech.App.Requestses.Sales;
using SysproTech.App.Res;
using SysproTech.App.Responses;

namespace SysproTech.App.Serviceses
{
    public class SalesServices(IApiServices apiServices) : ISalesServices
    {
        public async Task<Result<bool>> AddOrder(AddOrderMModel model)
        {
            var res = await apiServices.PostAsync<bool>("Sales/AddOrder", model);
            return res;
        }

        public async Task<Result<AllRecord<SalesResponse>>> GetAllOrderList(GetAllSalesListRequest dto)
        {
            string query = $"IsDeleted={dto.IsDeleted}&Search={dto.Search}&PageNumber={dto.PageNumber}&PageSize={dto.PageSize}&SortBy={dto.SortBy}&IsAscending={dto.IsAscending}";
            var res = await apiServices.GetAsync<AllRecord<SalesResponse>>($"Sales/GetAllOrderList?{query}");
            return res;
        }
    }
}
