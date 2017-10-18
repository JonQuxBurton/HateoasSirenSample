using System;
using System.Collections.Generic;
using HateoasSirenSample.Representations;

namespace HateoasSirenSample.Data
{
    public interface ICustomersDataStore
    {
        Customer Add(CreateCustomer createCustomer);
        void AddPhoneLine(Guid id);
        Customer Get(Guid id);
        void Delete(Guid id);
        IEnumerable<Customer> GetAll();
        void DeletePhoneLine(Guid customerId, Guid phoneLineId);
    }
}