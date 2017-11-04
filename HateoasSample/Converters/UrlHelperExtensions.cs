using Microsoft.AspNetCore.Mvc;

namespace HateoasSirenSample.Converters
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteRouteUrl(
            this IUrlHelper url,
            string routeName,
            object routeValues = null)
        {
            var routeUrl = url.RouteUrl(routeName, routeValues, url.ActionContext.HttpContext.Request.Scheme);

            if (routeUrl.StartsWith("http:///"))
            {
                return routeUrl.Replace("http:///", "http://");
            }

            return routeUrl;
        }

    }
}
