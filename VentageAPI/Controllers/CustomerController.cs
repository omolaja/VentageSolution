using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VentageRepositoryModel.Model;
using VentageServices.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VentageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [Route("PostCustomer")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(
           [FromBody] CustomerModel entity)
        {
            try
            {
                var response = await _customerService.PostCustomer(entity);

                if (response != null)
                    return Ok(response);

                return BadRequest("An error occurred while processing your request");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        
        [Route("GetCustomerById/{Id}")]
        [HttpGet]
        public async Task<ActionResult> GetCustomerById([FromRoute] int Id)
        {
            try
            {
                var reponse = await _customerService.GetCustomerById(Id);

                if (reponse != null)
                    return Ok(reponse);

                return BadRequest("An error occurred while processing your request");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Route("GetAllCustomer")]
        [HttpGet]
        public async Task<ActionResult> GetAllCustomer()
        {
            try
            {
                var reponse = await _customerService.GetAllCustomer();

                if (reponse != null)
                    return Ok(reponse);

                return BadRequest("An error occurred while processing your request");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}

