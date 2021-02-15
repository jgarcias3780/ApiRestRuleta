using FluentValidation;
using RuletaClean.Core.DTOs;

namespace RuletaClean.Infrastructure.Validators
{
    public class BetValidator : AbstractValidator<BetDto>
    {
        public BetValidator()
        {
            RuleFor(bet => bet.id_roulette)
                .NotNull();
            RuleFor(bet => bet.id_user)
                .NotNull();
            RuleFor(bet => bet.money)
                .NotNull().InclusiveBetween(1,10000);

        }
    }
}
