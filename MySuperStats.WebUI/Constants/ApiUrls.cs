namespace MySuperStats.WebUI.Constants
{
    public static class ApiUrls
    {
        public const string Login = "Account/Login";
        public const string Register = "Account/Register";
        public const string ConfirmEmail = "Account/ConfirmEmail";
        public const string ForgotPassword = "Account/ForgotPassword";
        public const string ResetPassword = "Account/ResetPassword";
        public const string GetAllMacthesForMainScreen = "match/getallformainscreen/matchgroupid/";
        public const string GetMatchDetail = "match/getmatchdetailbasketballstats/id/";
        public const string GetAllUsersByMatchGroupId = "User/getall/matchgroupid/";
        public const string GetUserWithBasketballStats = "user/getwithbasketballstats/id/";
        public const string GetTopBasketballStats = "basketballstat/gettopstats/matchgroupid/";
        public const string GetUserById = "User/get/";
        public const string CreateMultiBasketballStats = "basketballstat/createwithmultistats";
        public const string GetAllMatchGroupsByUserId = "MatchGroupUser/getallmatchgroup/user/";
        public const string CreateMatchGroupUser = "MatchGroupUser/create";
        public const string GetMatchGroupById = "MatchGroup/get/id/";
        public const string CreateMatchGroup = "MatchGroup/create";
        public const string GetUserByEmailAddress = "User/get/email/";
        public const string GetPermissions = "PermissionChecker/haspermission/";

    }
}