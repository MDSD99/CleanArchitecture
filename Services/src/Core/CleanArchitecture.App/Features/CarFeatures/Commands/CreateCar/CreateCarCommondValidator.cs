﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.CarFeatures.Commands.CreateCar
{
    public sealed class CreateCarCommondValidator:AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommondValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Araç adı boş olamaz!");
            RuleFor(p => p.Name).NotNull().WithMessage("Araç adı boş olamaz!");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Araç adı en az 3 karakter olmalıdır!");
          
            RuleFor(p => p.Model).NotEmpty().WithMessage("Araç modeli boş olamaz!");
            RuleFor(p => p.Model).NotNull().WithMessage("Araç modeli boş olamaz!");
            RuleFor(p => p.Model).MinimumLength(3).WithMessage("Araç modeli en az 3 karakter olmalıdır!");
        
            RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Araç motor gücü boş olamaz!");
            RuleFor(p => p.EnginePower).NotNull().WithMessage("Araç motor gücü boş olamaz!");
            RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Araç motor gücü 0'dan büyük olmalıdır!");

        }

    }
}
