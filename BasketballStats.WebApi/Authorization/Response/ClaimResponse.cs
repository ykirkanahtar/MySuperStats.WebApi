using BasketballStats.WebApi.Authorization.Enums;

namespace BasketballStats.WebApi.Authorization.Response
{
    public class ClaimResponse
    {
        public int Id { get; set; }
        public CustomClaim CustomCLaim { get; set; }
    }
}
