using BasketballStats.WebApi.Authorization.Enums;

namespace BasketballStats.WebApi.Authorization.Request
{
    public class RoleEntityClaimRequest
    {
        public int RoleId { get; set; }
        public Entity Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}