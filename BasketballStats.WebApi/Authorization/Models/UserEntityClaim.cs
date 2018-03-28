using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class UserEntityClaim : BaseModel<int>
    {
        public int UserId { get; set; }
        public Entity Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}