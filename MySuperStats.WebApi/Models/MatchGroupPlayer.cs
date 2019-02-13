using CustomFramework.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class MatchGroupPlayer : BaseModel<int>
    {
        public int MatchGroupId { get; set; }
        public int PlayerId { get; set; }

        public virtual MatchGroup MatchGroup { get; set; }
        public virtual Player Player { get; set; }
    }
}