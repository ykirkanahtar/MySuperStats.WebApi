using System.Collections.Generic;

namespace MySuperStats.Contracts.Responses
{
    public class UsersAddToRoleResponse
    {
        public UsersAddToRoleResponse()
        {
            UsersAddToRole = new List<UserAddToRoleResponse>();
        }
        public int MatchGroupdId { get; set; }
        public List<UserAddToRoleResponse> UsersAddToRole { get; set; }

    }
}
