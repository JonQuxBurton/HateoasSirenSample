using HateoasSample.Representations;
using Migrap.AspNetCore.Hateoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HateoasSample
{
    public class CustomerStateConverterProvider : IStateConverterProvider
    {
        public IStateConverter CreateConverter(StateConverterProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (typeof(IEnumerable<Customer>).IsAssignableFrom(context.ObjectType))
            {
                return new CustomerCollectionStateConverter();
            }

            if (typeof(Customer).IsAssignableFrom(context.ObjectType))
            {
                return new CustomerStateConverter();
            }

            return null;
        }
    }
}
