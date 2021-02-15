using FluentValidation;
using RuletaClean.Core.DTOs;

namespace RuletaClean.Infrastructure.Validators
{
    public class RouletteValidator : AbstractValidator<RouletteDto>
    {
        public RouletteValidator()
        {
            RuleFor(roulette => roulette.roulette_name)
                .NotNull()
                .Length(1, 50);

            RuleFor(roulette => roulette.state)
                .NotNull()
                .Length(1, 50);
        }
    }
}
