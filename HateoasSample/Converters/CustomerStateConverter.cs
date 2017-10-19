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
                Href = urlHelper.RouteUrl("DeleteCustomer", new RouteValueDictionary() { { "id", customer.Id } }),
            });

            if (customer.PhoneLine == null)
            {
                actions.Add(new Action
                {
                    Name = "add phoneline",
                    Title = "Add PhoneLine",
                    Method = "POST",
                    Href = urlHelper.RouteUrl("AddPhoneLine", new RouteValueDictionary() { { "id", customer.Id } }, "http")
                });
            }
            else 
            {
                actions.Add(new Action
                {
                    Name = "delete phoneline",
                    Title = "Delete PhoneLine",
                    Method = "DELETE",
                    Href = urlHelper.RouteUrl("DeletePhoneLine", new RouteValueDictionary() { { "id", customer.Id }, { "phoneLineId", customer.PhoneLine.Id } }, "http"),
                });

                if (customer.Broadband == null)
                {
                    actions.Add(new Action
                    {
                        Name = "add broadband",
                        Title = "Add Broadband",
                        Method = "POST",
                        Href = urlHelper.RouteUrl("AddBroadband", new RouteValueDictionary() { { "phoneLineId", customer.PhoneLine.Id } }, "http"),
                    });
                }
                else
                {
                    actions.Add(new Action
                    {
                        Name = "delete broadband",
                        Title = "Delete broadband",
                        Method = "DELETE",
                        Href = urlHelper.RouteUrl("DeleteBroadband", new RouteValueDictionary() { { "id", customer.Id }, { "broadbandId", customer.Broadband.Id } }, "http"),
                    });

                    if (customer.StaticIp == null)
                    {
                        actions.Add(new Action
                        {
                            Name = "add static ip",
                            Title = "Add Static IP",
                            Method = "POST",
                            Href = urlHelper.RouteUrl("AddStaticIp", new RouteValueDictionary() { { "id", customer.Id } }, "http"),
                        });
                    }
                    else
                    {
                        actions.Add(new Action
                        {
                            Name = "delete static ip",
                            Title = "Delete Static IP",
                            Method = "DELETE",
                            Href = urlHelper.RouteUrl("DeleteStaticIp", new RouteValueDictionary() { { "id", customer.Id }, { "staticIpId", customer.StaticIp.Id } }, "http"),
                        });
                    }
                }
            }

            var document = new Document
            {
                Class = new Class { "customer" },
                Properties = customer,
                Href = urlHelper.RouteUrl("GetCustomer", new RouteValueDictionary() { { "id", customer.Id } }, "http"),
                Actions = new Actions(actions)
            };

            return Task.FromResult<object>(document);
        }
    }
}
