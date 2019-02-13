using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;

namespace MySuperStats.WebApi.Validators
{
    public class MatchGroupValidator : AbstractValidator<MatchGroupRequest>

    {
        public MatchGroupValidator()
        {
            RuleFor(x => x.GroupName)
            .NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.GroupName}")
            .MaximumLength(100)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.GroupName}");

        }
    }
}