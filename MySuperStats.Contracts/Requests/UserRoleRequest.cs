using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{

    public class UserRoleRequest
    {
        public int MatchGroupId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
        
        public string RoleName { get; set; }
    }
}