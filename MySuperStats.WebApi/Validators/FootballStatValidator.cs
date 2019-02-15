using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;

namespace MySuperStats.WebApi.Validators
{
    public class FootballStatValidator : AbstractValidator<FootballStatRequest>
    {
        public FootballStatValidator()
        {
            RuleFor(x => x.MatchId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Match}");

            RuleFor(x => x.TeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Team}");

            RuleFor(x => x.PlayerId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Player}");

            RuleFor(x => x.Goal).GreaterThanOrEqualTo(0)
                .WithMessage($"{ValidatorConstants.CannotBeNullError} or {ValidatorConstants.CannotBeNegative} : {WebApiResourceConstants.Goal}");
        }
    }
}