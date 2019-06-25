using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Constants;

namespace MySuperStats.WebApi.Validators
{
    public class MatchGroupTeamValidator : AbstractValidator<MatchGroupTeamRequest>
    {
        public MatchGroupTeamValidator()
        {
            RuleFor(x => x.MatchGroupId).GreaterThan(0).WithMessage($"{ValidatorConstants.CannotBeNullError}:{WebApiResourceConstants.MatchGroup}");
            RuleFor(x => x.TeamId).GreaterThan(0).WithMessage($"{ValidatorConstants.CannotBeNullError}:{WebApiResourceConstants.Team}");
        }
    }
}