using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QAEngine.Web.Infrastructure;
using QAEngine.Application.Customers.Command;
using QAEngine.Application.Customers.Models;
using QAEngine.Application.Customers.Query;
namespace QAEngine.Web.Controllers
{
    public class CustomerController : BaseController
    {
        [HttpGet()]
        public Task<List<CustomerListModel>> Get()
        {
            return Mediator.Send(new GetCustomerListQuery());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetCustomerModelQuery { Id = id }));
        }

        public async Task<IActionResult> Create([FromBody]CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]UpdateCustomerCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });
            return NoContent();
        }

    }
}