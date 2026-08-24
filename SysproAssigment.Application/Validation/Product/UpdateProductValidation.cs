using FluentValidation;
using SysproAssigment.Application.Request.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Validation.Product
{
    public class UpdateProductValidation:AbstractValidator<UpdateProductRqquest>
    {
        public UpdateProductValidation()
        {
            RuleFor<Guid>(x => x.Id).NotNull();
            RuleFor<string>(x => x.Name).NotNull().NotEmpty();
            RuleFor<int?>(x => x.MinimumQuantity).GreaterThan(0).WithMessage("Minimum quantity Must be grater the 0");
            RuleFor<int>(x => x.Quantity).GreaterThan(x => x.MinimumQuantity).WithMessage("Quantity should be grater the Minimum Quanity");
            RuleFor<string?>(x => x.Category).NotEmpty();
            RuleFor<decimal>(x => x.Price).GreaterThan(0).WithMessage("Price Value should be grater than $0.00");
            RuleFor<string>(x => x.Description).NotNull().NotEmpty().MinimumLength(5);
        }
    }
}
