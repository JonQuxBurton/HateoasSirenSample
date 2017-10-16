using System;
using System.Collections.Generic;
using HateoasSample.Representations;

namespace HateoasSample.Data
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