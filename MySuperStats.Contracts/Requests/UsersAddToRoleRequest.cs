using System.Collections.Generic;

namespace MySuperStats.Contracts.Requests
{
    public class UsersAddToRoleRequest
    {
        public UsersAddToRoleRequest()
        {
            UsersAddToRole = new List<UserAddToRoleRequest>();
        }
        
        public int MatchGroupdId { get; set; }
        public List<UserAddToRoleRequest> UsersAddToRole { get; set; }
    }
}