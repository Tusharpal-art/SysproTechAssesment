using FluentValidation;
using SysproAssigment.Application.Request.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Validation.Product
{
    public class AddProductValidation:AbstractValidator<AddProductRequest>
    {
        public AddProductValidation()
        {
            RuleFor<string>(x=>x.Name).NotNull().NotEmpty();
            RuleFor<int>(x => x.Quantity).GreaterThan(0);
            RuleFor<decimal>(x => x.Price).GreaterThan(0);
            RuleFor<string>(x=>x.Description).NotNull().NotEmpty().MinimumLength(5);

        }
    }
}
