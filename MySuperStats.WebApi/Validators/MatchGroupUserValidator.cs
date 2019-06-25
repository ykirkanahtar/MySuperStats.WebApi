using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;

namespace MySuperStats.WebApi.Validators
{
    public class MatchGroupUserValidator : AbstractValidator<MatchGroupUserRequest>
    {
        public MatchGroupUserValidator()
        {
            RuleFor(x => x.MatchGroupId).GreaterThan(0).WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.MatchGroup}");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.User}");
        }

    }
}