using FluentValidation;
using SysproTech.App.Requestses;

namespace SysproTech.App.Validations.Product
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
