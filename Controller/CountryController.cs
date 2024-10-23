using Microsoft.AspNetCore.Mvc;
using ArticleWebApi.Models;
using ArticleWebApi.Services;

namespace ArticleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        // Use the interface ICountryServiceBL instead of the concrete class
        private readonly ICountryServiceBL _countryService;

        // Inject the service using the interface
        public CountriesController(ICountryServiceBL countryService)
        {
            _countryService = countryService;
        }

        // GET: api/countries
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _countryService.GetAllCountries();
            return Ok(countries);
        }

        // GET: api/countries/5
        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {
            var country = _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST: api/countries
        [HttpPost]
        public IActionResult PostCountry([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            _countryService.AddCountry(country);
            return CreatedAtAction(nameof(GetCountry), new { id = country.CountryId }, country);
        }

        // PUT: api/countries/5
        [HttpPut("{id}")]
        public IActionResult PutCountry(int id, [FromBody] Country country)
        {
            if (id != country.CountryId || country == null)
            {
                return BadRequest();
            }

            _countryService.UpdateCountry(country);
            return NoContent();
        }

        // DELETE: api/countries/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var existingCountry = _countryService.GetCountryById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            _countryService.DeleteCountry(id);
            return NoContent();
        }
    }
}
