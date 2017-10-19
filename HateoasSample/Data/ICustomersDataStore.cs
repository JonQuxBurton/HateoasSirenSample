using System;
using System.Collections.Generic;
using HateoasSirenSample.Representations;

namespace HateoasSirenSample.Data
{
    public interface ICustomersDataStore
    {
        IEnumerable<Customer> GetAll();
        Customer Add(CreateCustomer createCustomer);
        Customer Get(Guid id);
        void Delete(Guid id);
        PhoneLine AddPhoneLine(Guid id);
        void DeletePhoneLine(Guid customerId, Guid phoneLineId);
        Broadband AddBroadband(Guid id);
        void DeleteBroadband(Guid customerId, Guid broadbandId);
        StaticIp AddStaticIp(Guid id);
        void DeleteStaticIp(Guid customerId, Guid staticIpId);
    }
}