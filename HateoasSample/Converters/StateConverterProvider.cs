using HateoasSirenSample.Representations;
using Migrap.AspNetCore.Hateoas;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HateoasSirenSample.Converters
{
    public class StateConverterProvider : IStateConverterProvider
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

            if (typeof(PhoneLine).IsAssignableFrom(context.ObjectType))
            {
                return new PhoneLineStateConverter();
            }

            if (typeof(Broadband).IsAssignableFrom(context.ObjectType))
            {
                return new BroadbandStateConverter();
            }

            if (typeof(StaticIp).IsAssignableFrom(context.ObjectType))
            {
                return new StaticIpStateConverter();
            }

            return null;
        }
    }
}
