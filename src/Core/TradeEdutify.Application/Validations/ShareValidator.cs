using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Dtos;

namespace TradeEdutify.Application.Validations
{
    public class ShareValidator : AbstractValidator<ShareDto> 
    {
        public ShareValidator()
        {
            RuleFor(item => item.Symbol)
            .NotEmpty().WithMessage("Symbol is required.")
            .Length(3).WithMessage("Symbol must be exactly 3 characters long.")
            .Must(symbol => symbol.All(char.IsUpper)).WithMessage("Symbol must be in capital letters.");
        }
    }

    public class ShareListValidator : AbstractValidator<List<ShareDto>>
    {
        public ShareListValidator()
        {
            RuleForEach(item => item).SetValidator(new ShareValidator());
        }
    }
}
