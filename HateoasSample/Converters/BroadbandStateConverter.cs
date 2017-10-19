using System.Threading.Tasks;
using Migrap.AspNetCore.Hateoas;
using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace HateoasSirenSample.Converters
{
    public class BroadbandStateConverter : IStateConverter
    {
        public Task<object> ConvertAsync(StateConverterContext context)
        {
            var urlHelper = context.HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
            var broadband = context.Object as Broadband;

            var document = new Document
            {
                Class = new Class { "broadband" },
                Properties = broadband
            };

            return Task.FromResult<object>(document);

        }
    }
}
