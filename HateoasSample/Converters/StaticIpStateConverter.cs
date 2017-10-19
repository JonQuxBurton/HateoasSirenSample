using System.Threading.Tasks;
using Migrap.AspNetCore.Hateoas;
using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace HateoasSirenSample.Converters
{
    public class StaticIpStateConverter : IStateConverter
    {
        public Task<object> ConvertAsync(StateConverterContext context)
        {
            var urlHelper = context.HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
            var staticIp = context.Object as StaticIp;

            var document = new Document
            {
                Class = new Class { "staticIp" },
                Properties = staticIp
            };

            return Task.FromResult<object>(document);

        }
    }
}
