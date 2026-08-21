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
    public class GetProductQuantityQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductQuantityRequest, Result<ProductCountResponse>>
    {
        public async Task<Result<ProductCountResponse>> Handle(GetProductQuantityRequest request, CancellationToken cancellationToken)
        {
            var res = await unitOfWork.productServices.GetProductQuqntity(request);
            return Result<ProductCountResponse>.Successs(new ProductCountResponse(res));
        }
    }
}
