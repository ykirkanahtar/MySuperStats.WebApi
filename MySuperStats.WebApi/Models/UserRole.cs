using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace MySuperStats.WebApi.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
        public int MatchGroupId { get; set; }
    }
}