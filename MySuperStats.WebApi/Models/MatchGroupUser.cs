using CustomFramework.BaseWebApi.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class MatchGroupUser : BaseModel<int>
    {
        public int MatchGroupId { get; set; }
        public int? UserId { get; set; }
        public int RoleId { get; set; }
        public int PlayerId { get; set; }

        public virtual MatchGroup MatchGroup { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public virtual Player Player { get; set; }
    }
}