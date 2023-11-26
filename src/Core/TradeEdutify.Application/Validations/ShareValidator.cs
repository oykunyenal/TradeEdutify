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
        }
    }
}
