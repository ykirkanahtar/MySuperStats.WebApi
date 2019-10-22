using System.Collections.Generic;

namespace MySuperStats.Contracts.Responses
{
    public class PermissionCheckerResponse
    {
        public PermissionCheckerResponse()
        {
            PermissionDetails = new Dictionary<string, bool>();
        }

        public int UserId { get; set; }
        public int MatchGroupId { get; set; }
        public Dictionary<string, bool> PermissionDetails { get; set; }
    }
}