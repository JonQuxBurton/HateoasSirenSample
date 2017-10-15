using HateoasSample.Representations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HateoasSample.Data
{
    public class CustomersDataStore : ICustomersDataStore
    {
        private List<Customer> customers;
        private int phoneLineCounter = 0;

        public CustomersDataStore()
        {
            this.customers = new List<Customer>()
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice's Antiques"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob's Books"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Carols's Candles"
                }
            };
        }

        public IEnumerable<Customer> GetAll()
        {
            return customers;
        }

        public Customer Get(Guid id)
        {
            return this.customers.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            this.customers.Remove(this.Get(id));
        }

        public void AddPhoneLine(Guid id)
        {
            this.Get(id).PhoneLine = new PhoneLine()
            {
                Id = Guid.NewGuid(),
                PhoneNumber = $"0114{(phoneLineCounter++).ToString("D7")}"
            };
        }

        public void DeletePhoneLine(Guid customerId, Guid phoneLineId)
        {
            this.Get(customerId).PhoneLine = null;
        }
    }
}
