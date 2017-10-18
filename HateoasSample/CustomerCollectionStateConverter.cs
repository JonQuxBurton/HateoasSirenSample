using System.Collections.Generic;
using System.Threading.Tasks;
using Migrap.AspNetCore.Hateoas;
using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;

namespace HateoasSirenSample
{
    public class CustomerCollectionStateConverter : IStateConverter
    {
        public Task<object> ConvertAsync(StateConverterContext context)
        {
            var customers = (context.Object as IEnumerable<Customer>);
            var path = context.HttpContext.Request.GetDisplayUrl();

            var properties = new
            {
                count = customers.Count()
            };

            var document = new Document
            {
                Class = new Class { "customer", "collection" },
                Properties = properties,
                Href = path,
            };

            var entities = customers.Select(x => new Entity
            {
                Class = new Class { "customer" },
                Properties = x,
                Href = $"{path}/{x.Id}"
            });

            document.Entities.Add(entities);

            return Task.FromResult<object>(document);
        }
    }
}
