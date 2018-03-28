using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class ClientApplicationUtil : BaseModel<int>
    {
        public string SpecialValue { get; set; }
        public int ClientApplicationId { get; set; }

        [JsonIgnore]
        public ClientApplication ClientApplication { get; set; }
    }
}
