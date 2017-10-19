using System.Threading.Tasks;
using Migrap.AspNetCore.Hateoas;
using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas.Siren.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace HateoasSirenSample.Converters
{
    public class PhoneLineStateConverter : IStateConverter
    {
        public Task<object> ConvertAsync(StateConverterContext context)
        {
            var urlHelper = context.HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
            var customer = context.Object as PhoneLine;

            var document = new Document
            {
                Class = new Class { "phoneline" },
                Properties = customer
            };

            return Task.FromResult<object>(document);

        }
    }
}
