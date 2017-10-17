using HateoasSample.Data;
using HateoasSample.Representations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HateoasSample.Controllers
{
    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomersDataStore customersDataStore;

        public CustomersController(ICustomersDataStore customersDataStore)
        {
            this.customersDataStore = customersDataStore;
        }

        [HttpGet("", Name = "GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            return customersDataStore.GetAll();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public Customer Get(Guid id)
        {
            return customersDataStore.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCustomer createCustomer)
        {
            var newCustomer = this.customersDataStore.Add(createCustomer);

            return new CreatedAtRouteResult("GetCustomer", new { controller = "customers", id = newCustomer.Id }, newCustomer);
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public IActionResult Delete(Guid id)
        {
            customersDataStore.Delete(id);

            return new NoContentResult();
        }

        [HttpPost("{id}/phonelines", Name = "AddPhoneLine")]
        public IActionResult AddPhoneLine(Guid id)
        {
            this.customersDataStore.AddPhoneLine(id);

            return Ok();
        }

        [HttpDelete("{id}/phonelines/{phoneLineId}", Name = "DeletePhoneLine")]
        public IActionResult DeletePhoneLine(Guid id, Guid phoneLineId)
        {
            this.customersDataStore.DeletePhoneLine(id, phoneLineId);

            return new NoContentResult();
        }

        [HttpPost("{id}/broadbands")]
        public IActionResult AddBroadband()
        {
            return Ok();
        }

        [HttpDelete("{id}/broadbands/{broadbandId}")]
        public IActionResult DeleteBroadband()
        {
            return new NoContentResult();
        }

        [HttpPost("{id}/staticips")]
        public IActionResult AddStaticIp()
        {
            return Ok();
        }

        [HttpPost("{id}/staticips")]
        public IActionResult DeleteStaticIp()
        {
            return Ok();
        }
    }
}
