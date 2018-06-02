using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace BasketballStats.WebApi.Validators
{
    public class MatchValidator : AbstractValidator<MatchRequest>
    {
        public MatchValidator()
        {
            RuleFor(x => x.Order).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Order}");

            RuleFor(x => x.DurationInMinutes).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.DurationInMinutes}");

            RuleFor(x => x.HomeTeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.HomeTeam}");

            RuleFor(x => x.AwayTeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.AwayTeam}");

            RuleFor(x => x.VideoLink).MaximumLength(1000)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.VideoLink}");

        }
    }
}
