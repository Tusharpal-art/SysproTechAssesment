using FluentValidation;
using SysproTech.App.Requestses.Product;

namespace SysproTech.App.Validations.Product
{
    public class AddProductModelValidator : AbstractValidator<AddProductModel>
    {
        public AddProductModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.MinimumQuantity).GreaterThan(0).WithMessage("Minimum Quantity should be greater than 0.");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(x=>x.MinimumQuantity).WithMessage("Quantity Should be greater then minimum quantity");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category cannot be empty");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
