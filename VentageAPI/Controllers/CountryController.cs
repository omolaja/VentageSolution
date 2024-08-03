using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VentageServices.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VentageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                var reponse = await _countryService.GetAllCountries();
                return Ok(reponse);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult> GetCountyById([FromRoute] int Id)
        {
            try
            {
                var reponse = await _countryService.GetCountryById(Id);
                return Ok(reponse);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}

