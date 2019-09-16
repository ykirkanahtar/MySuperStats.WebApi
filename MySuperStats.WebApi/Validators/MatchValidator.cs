using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace MySuperStats.WebApi.Validators
{
    public class MatchValidator : AbstractValidator<MatchRequest>
    {
        public MatchValidator()
        {
            RuleFor(x => x.Order).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Order}");

            RuleFor(x => x.DurationInMinutes).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.DurationInMinutes}");

            RuleFor(x => x.HomeTeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.HomeTeam}");

            RuleFor(x => x.AwayTeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.AwayTeam}");

            RuleFor(x => x.VideoLink).MaximumLength(1000)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AppConstants.VideoLink}");

        }
    }
}
