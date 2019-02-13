using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;

namespace MySuperStats.WebApi.Validators
{
    public class MatchGroupPlayerValidator : AbstractValidator<MatchGroupPlayerRequest>
    {
        public MatchGroupPlayerValidator()
        {
            RuleFor(x => x.MatchGroupId).GreaterThan(0).WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.MatchGroup}");
            RuleFor(x => x.PlayerId).GreaterThan(0).WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Player}");
        }

    }
}