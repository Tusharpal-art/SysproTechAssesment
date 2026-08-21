using AutoMapper;
using MediatR;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Product;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;

namespace SysproAssigment.Application.Mediator.Product.Command
{
    public class UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAuthServices auth) : IRequestHandler<UpdateProductRqquest, Result<ProductResponse>>
    {
        public async Task<Result<ProductResponse>> Handle(UpdateProductRqquest request, CancellationToken cancellationToken)
        {
            var currentUser = await auth.GetCurrentUser();
            if (currentUser.Data == null)
            {
                return Result<ProductResponse>.Failure("Current user Not exits");
            }

            var productExist = await unitOfWork.GetRepository<Products>().GetByIdAsync(request.Id);

            if(productExist == null)
            {
                return Result<ProductResponse>.Failure("Given product not exist..");
            }

            productExist.Quantity = request.Quantity;
            productExist.Price = request.Price;
            productExist.Name =  request.Name; ;
            productExist.Description = request.Description;

            var result = await unitOfWork.GetRepository<Products>().UpdateAsync(productExist);
            await unitOfWork.SaveAsync();

            return Result<ProductResponse>.Successs(mapper.Map<ProductResponse>(result));
        }
    }
}
