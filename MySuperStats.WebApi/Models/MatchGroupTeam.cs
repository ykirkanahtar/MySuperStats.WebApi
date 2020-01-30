using CustomFramework.BaseWebApi.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class MatchGroupTeam : BaseModel<int>
    {
        public int MatchGroupId { get; set; }
        public int TeamId { get; set; }

        public virtual MatchGroup MatchGroup { get; set; }
        public virtual Team Team { get; set; }
    }
}