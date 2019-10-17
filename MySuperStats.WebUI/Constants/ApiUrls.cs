namespace MySuperStats.WebUI.Constants
{
    public static class ApiUrls
    {
        public const string Login = "Account/Login";
        public const string Register = "Account/Register";
        public const string ConfirmEmail = "Account/ConfirmEmail/userId/{0}/code/{1}";
        public const string ForgotPassword = "Account/ForgotPassword";
        public const string ResetPassword = "Account/ResetPassword";
        public const string GetMatchGroupByMatchId = "matchgroup/get/matchId/{0}";
        public const string GetAllMacthesForMainScreen = "match/getallformainscreen/matchgroupid/{0}";
        public const string GetMatchDetailBasketballStats = "match/getmatchdetailbasketballstats/id/{0}";
        public const string GetMatchDetailFootballStats = "match/getmatchdetailfootballstats/id/{0}";
        public const string GetAllPlayersByMatchGroupId = "Player/getall/matchgroupid/{0}";
        public const string GetPlayerWithBasketballStats = "player/getwithbasketballstats/id/{0}/matchGroupId/{1}";
        public const string GetPlayerWithFootballStats = "player/getwithfootballstats/id/{0}/matchGroupId/{1}";
        public const string GetTopBasketballStats = "basketballstat/gettopstats/matchgroupid/{0}";
        public const string GetTopFootballStats = "footballstat/gettopstats/matchgroupid/{0}";
        public const string GetUserById = "User/get/{0}";
        public const string GetPlayerByUserId = "User/getplayer/{0}";
        public const string CreateMultiBasketballStats = "basketballstat/createwithmultistats";
        public const string CreateMultiFootballStats = "footballstat/createwithmultistats";
        public const string GetAllMatchGroupsByUserId = "MatchGroupUser/getallmatchgroup/user/{0}";
        public const string CreateMatchGroupUser = "MatchGroupUser/create";
        public const string GetMatchGroupById = "MatchGroup/get/id/{0}";
        public const string CreateMatchGroup = "MatchGroup/create";
        public const string GetUserByEmailAddress = "User/get/email/{0}";
        public const string GetPermissions = "PermissionChecker/haspermission/userId/{0}/matchGroupId/{1}?{2}";
        public const string GetAllMatchGroupUsersByMatchGroupId = "MatchGroupUser/getallusers/matchgroup/{0}"; //"User/getallwithroles/matchgroupid/";
        public const string MatchGroupUserUpdateRole = "MatchGroupUser/updaterole";
        public const string Logout = "Account/logout";
        public const string CreateGuestPlayer = "Player/createguestplayer";
        public const string UpdatePlayer = "Player/{0}/update";
        public const string UpdateEmailRequest = "user/{0}/update/email/request";

    }
}