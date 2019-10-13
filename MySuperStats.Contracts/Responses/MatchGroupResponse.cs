using MySuperStats.Contracts.Enums;

namespace MySuperStats.Contracts.Responses
{
    public class MatchGroupResponse
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public MatchGroupType MatchGroupType { get; set;}
    }
}