using HateoasSirenSample.Data;
using HateoasSirenSample.Representations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HateoasSirenSample.Controllers
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
            var newCustomer = this.customersDataStore.AddPhoneLine(id);

            return new OkObjectResult(newCustomer);
        }

        [HttpDelete("{id}/phonelines/{phoneLineId}", Name = "DeletePhoneLine")]
        public IActionResult DeletePhoneLine(Guid id, Guid phoneLineId)
        {
            this.customersDataStore.DeletePhoneLine(id, phoneLineId);

            return new NoContentResult();
        }

        [HttpPost("{id}/broadbands", Name = "AddBroadband")]
        public IActionResult AddBroadband(Guid id)
        {
            var broadband = this.customersDataStore.AddBroadband(id);

            return new OkObjectResult(broadband);
        }

        [HttpDelete("{id}/broadbands/{broadbandId}", Name = "DeleteBroadband")]
        public IActionResult DeleteBroadband(Guid id, Guid broadbandId)
        {
            this.customersDataStore.DeleteBroadband(id, broadbandId);

            return new NoContentResult();
        }

        [HttpPost("{id}/staticips", Name = "AddStaticIp")]
        public IActionResult AddStaticIp(Guid id)
        {
            var staticIp = this.customersDataStore.AddStaticIp(id);

            return new OkObjectResult(staticIp);
        }

        [HttpDelete("{id}/staticips", Name = "DeleteStaticIp")]
        public IActionResult DeleteStaticIp(Guid id, Guid staticIpId)
        {
            this.customersDataStore.DeleteStaticIp(id, staticIpId);

            return Ok();
        }
    }
}
