using AutoMapper;
using MediatR;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Product;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Mediator.Product.Queries
{
    public class GetAllProductQueryHandler(IUnitOfWork unitOfWork ,IMapper mapper) : IRequestHandler<GetAllProductListRequest, Result<AllRecord<ProductResponse>>>
    {
        public async Task<Result<AllRecord<ProductResponse>>> Handle(GetAllProductListRequest request, CancellationToken cancellationToken)
        {
            var response = await unitOfWork.productServices.GetAllProductsAsync(request);

            List<ProductResponse> result = mapper.Map<List<ProductResponse>>(response.Records);

            return Result<AllRecord<ProductResponse>>.Successs(new AllRecord<ProductResponse>(result, response.TotalCount));


        }
    }
}
