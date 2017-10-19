using HateoasSirenSample.Representations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HateoasSirenSample.Data
{
    public class CustomersDataStore : ICustomersDataStore
    {
        private List<Customer> customers;
        private int phoneLineCounter = 0;
        private Random random  = new Random();

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

        public Customer Add(CreateCustomer createCustomer)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = createCustomer.Name
            };

            this.customers.Add(customer);

            return customer;
        }

        public void Delete(Guid id)
        {
            this.customers.Remove(this.Get(id));
        }

        public PhoneLine AddPhoneLine(Guid id)
        {
            var phoneLine = new PhoneLine()
            {
                Id = Guid.NewGuid(),
                PhoneNumber = $"0114{(phoneLineCounter++).ToString("D7")}"
            };

            this.Get(id).PhoneLine = phoneLine;

            return phoneLine;
        }

        public void DeletePhoneLine(Guid customerId, Guid phoneLineId)
        {
            this.Get(customerId).PhoneLine = null;
        }

        public Broadband AddBroadband(Guid id)
        {
            var broadband = new Broadband()
            {
                Id = Guid.NewGuid(),
                Speed = random.Next(1, 20)
            };

            this.Get(id).Broadband = broadband;

            return broadband;
        }

        public void DeleteBroadband(Guid customerId, Guid broadbandId)
        {
            this.Get(customerId).Broadband = null;
        }

        public StaticIp AddStaticIp(Guid id)
        {
            var newStaticIp = new StaticIp()
            {
                Id = Guid.NewGuid(),
                Value = $"{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}"
            };

            this.Get(id).StaticIp = newStaticIp;

            return newStaticIp;
        }

        public void DeleteStaticIp(Guid customerId, Guid staticIpId)
        {
            this.Get(customerId).StaticIp = null;
        }
    }
}
