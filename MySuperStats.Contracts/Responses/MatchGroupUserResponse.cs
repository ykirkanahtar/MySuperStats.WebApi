namespace MySuperStats.Contracts.Responses
{
    public class MatchGroupUserResponse
    {
        public int Id { get; set; }
        public int MatchGroupId { get; set; }
        public int UserId { get; set; }
        public int PlayerId { get; set; }
        public int RoleId { get; set; }

        public MatchGroupResponse MatchGroup { get; set; }
        public UserResponse User { get; set; }
        public PlayerResponse Player { get; set; }
        public RoleResponse Role { get; set; }
    }
}