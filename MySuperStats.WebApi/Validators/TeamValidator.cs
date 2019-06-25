using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace MySuperStats.WebApi.Validators
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
