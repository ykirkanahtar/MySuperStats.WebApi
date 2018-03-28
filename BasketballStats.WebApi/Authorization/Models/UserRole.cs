using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class UserRole : BaseModel<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }
}