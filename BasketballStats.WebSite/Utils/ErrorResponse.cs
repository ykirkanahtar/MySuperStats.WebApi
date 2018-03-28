namespace BasketballStats.WebSite.Utils
{
    public class ErrorResponse
    {
        public string ExceptionType { get; set; }
        public string ErrorDetails { get; set; }
        public string StackTrace { get; set; }
    }
}