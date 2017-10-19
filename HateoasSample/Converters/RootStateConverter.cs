using HateoasSirenSample.Representations;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Migrap.AspNetCore.Hateoas;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using System.Collections.Generic;
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

            var actions = new List<Action>();
            actions.Add(new Action
            {
                Name = "getCustomers",
                Title = "Get Customers",
                Method = "GET",
                Href = urlHelper.RouteUrl("GetCustomers", new RouteValueDictionary(), "http"),
            });

            var document = new Document
            {
                Class = new Class { "root" },
                Properties = root,
                Href = path,
                Links = new Links() { new Link() { Href = path, Rel = new Rel() { "self" } } },
                Actions = new Actions(actions)
            };

            return Task.FromResult<object>(document);
        }
    }
}
