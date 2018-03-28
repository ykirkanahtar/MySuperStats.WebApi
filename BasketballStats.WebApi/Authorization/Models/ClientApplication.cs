using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Authorization.Models
{
    public class ClientApplication : BaseModel<int>
    {
        public ClientApplication()
        {
            
        }

        public ClientApplication(string name, string code, string password)
        {
            ClientApplicationName = name;
            ClientApplicationCode = code;
            ClientApplicationPassword = password;
        }

        public string ClientApplicationName { get; set; }
        public string ClientApplicationCode { get; set; }
        public string ClientApplicationPassword { get; set; }

        [JsonIgnore]
        public ClientApplicationUtil ClientApplicationUtil { get; set; }
    }
}
