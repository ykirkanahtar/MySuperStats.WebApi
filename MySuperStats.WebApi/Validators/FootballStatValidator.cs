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
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Match}");

            RuleFor(x => x.TeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Team}");

            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.User}");

            RuleFor(x => x.Goal).GreaterThanOrEqualTo(0)
                .WithMessage($"{ValidatorConstants.CannotBeNullError} or {ValidatorConstants.CannotBeNegative} : {AppConstants.Goal}");
        }
    }
}