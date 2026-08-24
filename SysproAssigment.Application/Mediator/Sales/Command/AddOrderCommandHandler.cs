using AutoMapper;
using MediatR;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Sales;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Mediator.Sales.Command
{
    public class AddOrderCommandHandler(IUnitOfWork unitOfWork,IAuthServices authServices,IMapper mapper) : IRequestHandler<AddOrderRequest, Result<bool>>
    {
        public async Task<Result<bool>> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await authServices.GetCurrentUser();
            if (currentUser.Data == null)
            {
                return Result<bool>.Failure("Current user Not exits");
            }

            var IsProductExists = await unitOfWork.GetRepository<Products>().GetByIdAsync(request.ProductId);

            if (IsProductExists == null) return Result<bool>.Failure("Selected product Does Not Exists Try to buy another product");
            if (IsProductExists.Quantity < request.ProductQuantity) return Result<bool>.Failure("Select amoount of quatity of this procuct does not present please remove few quantity");

            Domain.Entities.Sales order = new();

            order.Product = IsProductExists;
            order.ProductId = request.ProductId;
            order.OrderBy = currentUser.Data;
            order.OrderbyId = currentUser.Data.Id;
            order.OrderDate = DateTime.Now;
            order.ProductCount = request.ProductQuantity;
            order.TotalPrice = request.ProductQuantity * IsProductExists.Price;
            order.UnitPrice = IsProductExists.Price;



            IsProductExists.Quantity -= request.ProductQuantity;


            await unitOfWork.GetRepository<Products>().UpdateAsync(IsProductExists);
            await unitOfWork.GetRepository<Domain.Entities.Sales>().CreateAsync(order);

            await unitOfWork.SaveAsync();

            return Result<bool>.Successs(true);
        }
    }
}
