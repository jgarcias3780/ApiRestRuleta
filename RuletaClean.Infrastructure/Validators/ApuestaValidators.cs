using FluentValidation;
using RuletaClean.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Infrastructure.Validators
{
    public class ApuestaValidators : AbstractValidator<ApuestaDto>
    {
        public ApuestaValidators()
        {
            RuleFor(apuesta => apuesta.id_ruleta)
                .NotNull();
            RuleFor(apuesta => apuesta.id_usuario)
                .NotNull();
            RuleFor(apuesta => apuesta.dinero)
                .NotNull().InclusiveBetween(1,10000);

        }
    }
}
