using HateoasSample.Representations;
using HateoasSirenSample;
using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas;
using System;
using System.Collections.Generic;
using System.Reflection;

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

            if (typeof(Root).IsAssignableFrom(context.ObjectType))
            {
                return new RootStateConverter();
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
