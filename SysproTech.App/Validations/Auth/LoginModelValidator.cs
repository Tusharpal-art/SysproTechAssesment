using FluentValidation;
using SysproTech.App.Requestses.Auth;

namespace SysproTech.App.Validations.Auth
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .Matches(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$").WithMessage("Please enter a valid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,20}$")
                .WithMessage("Password must be 6-20 characters with at least one uppercase, one lowercase, one number, and one special character.");
        }
    }
}
