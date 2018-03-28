using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class UserClaim : BaseModel<int>
    {
        public int UserId { get; set; }
        public int ClaimId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Claim Claim { get; set; }
    }
}