using BasketballStats.Contracts.Requests;
using BasketballStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace BasketballStats.WebApi.Validators
{
    public class TeamValidator : AbstractValidator<TeamRequest>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}");

            RuleFor(x => x.Color).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Color}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Color}");


        }
    }
}
