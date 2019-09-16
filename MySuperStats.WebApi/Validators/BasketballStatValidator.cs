using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace MySuperStats.WebApi.Validators
{
    public class BasketballStatValidator : AbstractValidator<BasketballStatRequest>
    {
        public BasketballStatValidator()
        {
            RuleFor(x => x.MatchId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Match}");

            RuleFor(x => x.TeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Team}");

            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.User}");

            RuleFor(x => x.OnePoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.OnePoint}");

            RuleFor(x => x.TwoPoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.TwoPoint}");

            RuleFor(x => x.MissingOnePoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.MissingOnePoint}");

            RuleFor(x => x.MissingTwoPoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.MissingTwoPoint}");

            RuleFor(x => x.Rebound).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Rebound}");

            RuleFor(x => x.StealBall).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.StealBall}");

            RuleFor(x => x.LooseBall).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.LooseBall}");

            RuleFor(x => x.Assist).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Assist}");

            RuleFor(x => x.Interrupt).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AppConstants.Interrupt}");
        }
    }
}
