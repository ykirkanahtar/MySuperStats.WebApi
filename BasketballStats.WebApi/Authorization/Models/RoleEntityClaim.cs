using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class RoleEntityClaim : BaseModel<int>
    {
        public int RoleId { get; set; }
        public Entity Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }
}