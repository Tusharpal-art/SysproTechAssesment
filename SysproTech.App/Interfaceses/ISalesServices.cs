using SysproTech.App.Requestses.Sales;
using SysproTech.App.Res;
using SysproTech.App.Responses;

namespace SysproTech.App.Interfaceses
{
    public interface ISalesServices
    {
        public Task<Result<AllRecord<SalesResponse>>> GetAllOrderList(GetAllSalesListRequest request);
        public Task<Result<bool>> AddOrder(AddOrderMModel model);
    }
}
