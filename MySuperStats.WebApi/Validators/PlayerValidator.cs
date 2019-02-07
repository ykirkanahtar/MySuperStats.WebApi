using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace MySuperStats.WebApi.Validators
{
    public class PlayerValidator : AbstractValidator<PlayerRequest>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}");

            RuleFor(x => x.Surname).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Surname}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Surname}");

            RuleFor(x => x.BirthDate).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.BirthDate}");

        }
    }
}
