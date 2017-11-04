using System.Collections.Generic;
using System.Threading.Tasks;
using Migrap.AspNetCore.Hateoas;
using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HateoasSirenSample.Converters
{
    public class CustomerStateConverter : IStateConverter
    {
        public Task<object> ConvertAsync(StateConverterContext context)
        {
            var urlHelper = context.HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
            var customer = context.Object as Customer;

            var actions = new List<Action>();
            actions.Add(new Action
            {
                Name = "delete",
                Title = "Delete Customer",
                Method = "DELETE",
                Href = new Href(urlHelper.AbsoluteRouteUrl("DeleteCustomer", new RouteValueDictionary() { { "id", customer.Id } }), System.UriKind.Absolute),
            });

            if (customer.PhoneLine == null)
            {
                actions.Add(new Action
                {
                    Name = "add phoneline",
                    Title = "Add PhoneLine",
                    Method = "POST",
                    Href = new Href(urlHelper.AbsoluteRouteUrl("AddPhoneLine", new RouteValueDictionary() { { "id", customer.Id } }), System.UriKind.Absolute),
                    Fields = new Fields(new[] { new Field() { Name = "PhoneNumber", Type = "text" } })
                });
            }
            else
            {
                actions.Add(new Action
                {
                    Name = "delete phoneline",
                    Title = "Delete PhoneLine",
                    Method = "DELETE",
                    Href = new Href(urlHelper.AbsoluteRouteUrl("DeletePhoneLine", new RouteValueDictionary() { { "id", customer.Id }, { "phoneLineId", customer.PhoneLine.Id } }), System.UriKind.Absolute),
                });

                if (customer.Broadband == null)
                {
                    actions.Add(new Action
                    {
                        Name = "add broadband",
                        Title = "Add Broadband",
                        Method = "POST",
                        Href = new Href(urlHelper.AbsoluteRouteUrl("AddBroadband", new RouteValueDictionary() { { "id", customer.Id } }), System.UriKind.Absolute),
                    });
                }
                else
                {
                    actions.Add(new Action
                    {
                        Name = "delete broadband",
                        Title = "Delete broadband",
                        Method = "DELETE",
                        Href = new Href(urlHelper.AbsoluteRouteUrl("DeleteBroadband", new RouteValueDictionary() { { "id", customer.Id }, { "broadbandId", customer.Broadband.Id } }), System.UriKind.Absolute),
                    });

                    if (customer.StaticIp == null)
                    {
                        actions.Add(new Action
                        {
                            Name = "add static ip",
                            Title = "Add Static IP",
                            Method = "POST",
                            Href = new Href(urlHelper.AbsoluteRouteUrl("AddStaticIp", new RouteValueDictionary() { { "id", customer.Id } }), System.UriKind.Absolute),
                        });
                    }
                    else
                    {
                        actions.Add(new Action
                        {
                            Name = "delete static ip",
                            Title = "Delete Static IP",
                            Method = "DELETE",
                            Href = new Href(urlHelper.AbsoluteRouteUrl("DeleteStaticIp", new RouteValueDictionary() { { "id", customer.Id }, { "staticIpId", customer.StaticIp.Id } }), System.UriKind.Absolute)
                        });
                    }
                }
            }

            var document = new Document
            {
                Class = new Class { "customer" },
                Properties = customer,
                Href = new Href(urlHelper.AbsoluteRouteUrl("GetCustomer", new RouteValueDictionary() { { "id", customer.Id } }), System.UriKind.Absolute),
                Actions = new Actions(actions)
            };

            return Task.FromResult<object>(document);
        }
    }
}
