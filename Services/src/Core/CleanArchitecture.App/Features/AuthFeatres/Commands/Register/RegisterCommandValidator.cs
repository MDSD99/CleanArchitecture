using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.AuthFeatres.Commands.Register
{
    public sealed  class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail bilgisi boş olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail bilgisi boş olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail Geçerli değil");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı bilgisi boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı bilgisi boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı bilgisi Girin");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password bilgisi boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password bilgisi boş olamaz");
            RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Password en az bir adet Büyük harf içermelidir");
            RuleFor(x => x.Password).Matches("[a-z]").WithMessage("Password en az bir adet küçük rakam içermelidir");
            RuleFor(x => x.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password en az bir özek Karakter içermelidir");
        }
    }
}
