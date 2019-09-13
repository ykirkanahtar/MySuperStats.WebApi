using System.ComponentModel.DataAnnotations;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.Contracts.Requests
{
    public class BasketballStatRequestForUI1 : BaseBasketballStatRequest
    {
        public BasketballStatRequestForUI1()
        {

        }
        
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public virtual TeamResponse Team { get; set; }
        public virtual UserResponse User { get; set; }
    }
}
