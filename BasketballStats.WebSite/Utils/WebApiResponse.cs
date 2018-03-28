using System.Collections.Generic;
using System.Net;

namespace BasketballStats.WebSite.Utils
{
    public class WebApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public int TotalCount { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}