using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{
    public class BasketballStatRequestForMultiEntry : BaseBasketballStatRequest
    {

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Player")]
        public int PlayerId { get; set; }
    }
}
