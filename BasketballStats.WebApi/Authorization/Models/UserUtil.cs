using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class UserUtil : BaseModel<int>
    {
        public string SpecialValue { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
