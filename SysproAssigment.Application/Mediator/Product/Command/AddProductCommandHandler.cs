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

namespace SysproAssigment.Application.Mediator.Product.Command
{
    public class AddProductCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IAuthServices auth) : IRequestHandler<AddProductRequest, Result<ProductResponse>>
    {
        public async Task<Result<ProductResponse>> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await auth.GetCurrentUser();
            if (currentUser.Data == null)
            {
                return Result<ProductResponse>.Failure("Current user Not exits");
            }


            var prduct = mapper.Map<Products>(request);
            prduct.CreatedBy = currentUser.Data;
            prduct.CreatedById = currentUser.Data.Id;


           var result =  await unitOfWork.GetRepository<Products>().CreateAsync(prduct);
            await unitOfWork.SaveAsync();

            return Result<ProductResponse>.Successs(mapper.Map<ProductResponse>(result));



        }
    }
}
