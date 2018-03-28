using System;
using System.Net;

namespace BasketballStats.WebApi.Helper
{
    public class HttpStatusCodeBinderAttribute : Attribute
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public HttpStatusCodeBinderAttribute(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }
        public static HttpStatusCode Get(Type tp, string name)
        {
            var mi = tp.GetMember(name);
            if (mi == null || mi.Length <= 0) return HttpStatusCode.BadRequest;
            if (Attribute.GetCustomAttribute(mi[0],
                typeof(HttpStatusCodeBinderAttribute)) is HttpStatusCodeBinderAttribute attr)
            {
                return attr.HttpStatusCode;
            }
            return HttpStatusCode.BadRequest;
        }
        public static HttpStatusCode Get(object enm)
        {
            var mi = enm?.GetType().GetMember(enm.ToString());
            if (mi == null || mi.Length <= 0) return HttpStatusCode.BadRequest;
            if (Attribute.GetCustomAttribute(mi[0],
                typeof(HttpStatusCodeBinderAttribute)) is HttpStatusCodeBinderAttribute attr)
            {
                return attr.HttpStatusCode;
            }
            return HttpStatusCode.BadRequest;
        }

    }
}