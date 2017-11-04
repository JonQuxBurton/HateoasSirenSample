using HateoasSirenSample.Representations;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Migrap.AspNetCore.Hateoas;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using System.Threading.Tasks;

namespace HateoasSirenSample.Converters
{
    public class RootStateConverter : IStateConverter
    {
        public Task<object> ConvertAsync(StateConverterContext context)
        {
            var urlHelper = context.HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
            var root= context.Object as Root;
            var path = context.HttpContext.Request.GetDisplayUrl();

            var document = new Document
            {
                Class = new Class { "root" },
                Properties = root,
                Href = path,
                Links = new Links() {
                    new Link() { Rel = new Rel() { "self" }, Href = path },
                    new Link() { Rel = new Rel() { "customers" }, Href = urlHelper.AbsoluteRouteUrl("GetCustomers", new RouteValueDictionary()) },
                }
            };

            return Task.FromResult<object>(document);
        }
    }
}
