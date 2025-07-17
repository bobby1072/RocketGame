using System.Net.Mail;
using FluentValidation;
using PokeGame.Core.Schemas;

namespace PokeGame.Core.Schemas.Validators;

internal sealed class UserValidator: AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email is required");

        RuleFor(user => user.Email).Must(x =>
        {
            try
            {
                var validEmail = new MailAddress(x);
                return true;
            }
            catch
            {
                return false;
            }
        })
        .WithMessage("Invalid email address");
    }
}