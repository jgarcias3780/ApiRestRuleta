using FluentValidation;
using RuletaClean.Core.DTOs;

namespace RuletaClean.Infrastructure.Validators
{
    public class RuletaValidator : AbstractValidator<RuletaDto>
    {
        public RuletaValidator()
        {
            RuleFor(ruleta => ruleta.nombre_ruleta)
                .NotNull()
                .Length(1, 50);

            RuleFor(ruleta => ruleta.estado)
                .NotNull()
                .Length(1, 50);
        }
    }
}
