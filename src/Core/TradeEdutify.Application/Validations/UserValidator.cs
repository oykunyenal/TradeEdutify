using FluentValidation;
using TradeEdutify.Application.Dtos;

namespace TradeEdutify.Application.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(obj => obj.Username)
                .NotEmpty()
                .NotNull();
        }
    }
}