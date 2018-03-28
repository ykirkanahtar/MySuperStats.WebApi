using System.Collections.Generic;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class Role : BaseModel<int>
    {
        public string RoleName { get; set; }

        [JsonIgnore]
        public IList<RoleClaim> RoleClaims { get; set; }

        [JsonIgnore]
        public IList<RoleEntityClaim> RoleEntityClaims { get; set; }

        [JsonIgnore]
        public IList<UserRole> UserRoles { get; set; }
    }
}