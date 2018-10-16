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
        public async Task<IActionResult> ViewCustomers()
        {

            List<CustomerListModel> CustomerObj = await Mediator.Send(new GetCustomerListQuery());
            return View(CustomerObj);
        }

        public IActionResult FindCustomer()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> FindCustomer([FromForm] GetCustomerModelQuery query)
        {
            if(query.Id == null)
            {
                throw new UnauthorizedAccessException();

            }
            await FindCustomer(query.Id);
            return View();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindCustomer(string id)
        {
            var CustomerObj = await Mediator.Send(new GetCustomerModelQuery { Id = id });
            return View(CustomerObj);
            //return Ok(await Mediator.Send(new GetCustomerModelQuery { Id = findaCustomer }));

        }

        // I don't know if the below action result actually does anything of significance. Find out if you can return a view whilst sending a STATUS OK 200 CODE!!
        // Below is an example of "NewCustomer" action with a view and a task. 

        public IActionResult NewCustomer()
        {

            return View();
        }


        [HttpPost]
        //noteToSelf = FromForm means from the bloody form not [FromBody]
        public async Task<IActionResult> NewCustomer([FromForm]CreateCustomerCommand command)
        {
            //sets the accountCreation before it is populated at database level
            command.AccountCreated = DateTime.Now;
            Ok(await Mediator.Send(command));
            return RedirectToAction("ViewCustomers");
            
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
