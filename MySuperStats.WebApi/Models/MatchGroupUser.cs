using CustomFramework.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class MatchGroupUser : BaseModel<int>
    {
        public int MatchGroupId { get; set; }
        public int UserId { get; set; }

        public virtual MatchGroup MatchGroup { get; set; }
        public virtual User User { get; set; }
    }
}