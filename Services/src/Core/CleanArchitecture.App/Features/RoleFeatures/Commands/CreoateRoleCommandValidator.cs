using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.RoleFeatures.Commands
{
    public sealed class CreoateRoleCommandValidator:AbstractValidator<CreoateRoleCommand>
    {
        public CreoateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role Ado Boş Olamaz");
            RuleFor(x => x.Name).NotNull().WithMessage("Role Ado Boş Olamaz");
                
        }
    }
}
