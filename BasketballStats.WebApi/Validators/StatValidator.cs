using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace BasketballStats.WebApi.Validators
{
    public class StatValidator : AbstractValidator<StatRequest>
    {
        public StatValidator()
        {
            RuleFor(x => x.MatchId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Match}");

            RuleFor(x => x.TeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Team}");

            RuleFor(x => x.PlayerId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Player}");

            RuleFor(x => x.OnePoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.OnePoint}");

            RuleFor(x => x.TwoPoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.TwoPoint}");

            RuleFor(x => x.MissingOnePoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.MissingOnePoint}");

            RuleFor(x => x.MissingTwoPoint).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.MissingTwoPoint}");

            RuleFor(x => x.Rebound).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Rebound}");

            RuleFor(x => x.StealBall).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.StealBall}");

            RuleFor(x => x.LooseBall).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.LooseBall}");

            RuleFor(x => x.Assist).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Assist}");

            RuleFor(x => x.Interrupt).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Interrupt}");








        }
    }
}
