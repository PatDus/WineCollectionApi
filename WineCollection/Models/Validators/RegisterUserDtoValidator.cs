using FluentValidation;
using WineCollection.Entities;

namespace WineCollection.Models.Validators
{
    //TODO: Figure out why its not working
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(WineCollectionDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var isEmailUsed = dbContext.Users.Any(u => u.Email == value);
                    if (isEmailUsed)
                    {
                        context.AddFailure("Email", "This email is taken");
                    }
                });


        }
    }
}
