using AutoMapper;
using MediatR;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Sales;
using SysproAssigment.Application.Response.Sales;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Mediator.Sales.Queries
{
    public class GetAllOrderListQueryHandler(IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<GetAllOderRequest, Result<AllRecord<SalesReponse>>>
    {
        public async Task<Result<AllRecord<SalesReponse>>> Handle(GetAllOderRequest request, CancellationToken cancellationToken)
        {
            var response = await unitOfWork.SalesServices.GetAllSalesList(request);

            List<SalesReponse> salesList = mapper.Map<List<SalesReponse>>(response.Records);

            return Result<AllRecord<SalesReponse>>.Successs(new AllRecord<SalesReponse>(salesList, response.TotalCount));
        }
    }
}
