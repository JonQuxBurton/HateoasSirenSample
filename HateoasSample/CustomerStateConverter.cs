using System.Collections.Generic;
using System.Threading.Tasks;
using Migrap.AspNetCore.Hateoas;
using HateoasSample.Representations;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HateoasSample
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
                    Href = urlHelper.RouteUrl("AddPhoneLine", new RouteValueDictionary() { { "id", customer.Id } })
                });
            }

            if (customer.PhoneLine != null)
            {
                actions.Add(new Action
                {
                    Name = "delete phoneline",
                    Title = "Delete PhoneLine",
                    Method = "DELETE",
                    Href = urlHelper.RouteUrl("DeletePhoneLine", new RouteValueDictionary() { { "phoneLineId", customer.PhoneLine.Id } }),
                });
            }

            var document = new Document
            {
                Class = new Class { "customer" },
                Properties = customer,
                Href = urlHelper.RouteUrl("GetCustomer", new RouteValueDictionary() { { "id", customer.Id } }),
                Actions = new Actions(actions)
            };

            return Task.FromResult<object>(document);
        }
    }
}
