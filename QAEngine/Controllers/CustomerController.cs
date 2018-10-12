using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QAEngine.Web.Infrastructure;
using QAEngine.Application.Customers.Command;
using QAEngine.Application.Customers.Models;
using QAEngine.Application.Customers.Query;
using Microsoft.AspNetCore.Authorization;
using MediatR;


namespace QAEngine.Web.Controllers
{
    [Route("[controller]/[action]")]

    public class CustomerController : BaseController
    {
        
        [Authorize]
        public IActionResult CustomerIndex()
        {
            return View();
        }

        [HttpGet()]
        public Task<List<CustomerListModel>> ViewCustomers()
        {
            return Mediator.Send(new GetCustomerListQuery());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindACustomer(string id)
        {
            return Ok(await Mediator.Send(new GetCustomerModelQuery { Id = id }));
        }

        // I don't know if the below action result actually does anything of significance. Find out if you can return a view whilst sending a STATUS OK 200 CODE!!
        // Below is an example of "NewCustomer" action with a view and a task. 
        [Authorize]
        public IActionResult NewCustomer()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        //noteToSelf = FromForm means from the bloody form not [FromBody]
        public async Task<IActionResult> NewCustomer([FromForm]CreateCustomerCommand command)
        {

            
            return Ok(await Mediator.Send(command));
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerDetails(string id, [FromBody]UpdateCustomerCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest();
            }
            

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });
            return NoContent();
        }

    }
}
