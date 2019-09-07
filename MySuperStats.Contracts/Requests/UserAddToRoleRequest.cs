namespace MySuperStats.Contracts.Requests
{

    public class UserAddToRoleRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}