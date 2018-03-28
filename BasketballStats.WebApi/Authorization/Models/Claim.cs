using System.Collections.Generic;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class Claim : BaseModel<int>
    {
        public CustomClaim CustomClaim { get; set; }

        [JsonIgnore]
        public IList<RoleClaim> RoleClaims { get; set; }

        [JsonIgnore]
        public IList<UserClaim> UserClaims { get; set; }
    }
}