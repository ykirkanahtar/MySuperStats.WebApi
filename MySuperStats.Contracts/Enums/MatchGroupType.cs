using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Enums
{
    public enum MatchGroupType
    {
        [Display(Name =nameof(Football))]
        Football = 1,

        [Display(Name =nameof(Basketball))]
        Basketball = 2,
    }
}