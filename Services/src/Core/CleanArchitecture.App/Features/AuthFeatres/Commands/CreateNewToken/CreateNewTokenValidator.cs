using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.AuthFeatres.Commands.CreateNewToken
{
    public sealed class CreateNewTokenValidator: AbstractValidator<CreateNewTokenCommand>
    {
        public CreateNewTokenValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Bilgisi Boş Olmamaz");
            RuleFor(x => x.UserId).NotNull().WithMessage("User Bilgisi Boş Olmamaz");
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken Bilgisi Boş Olmamaz");
        }
    }
}
