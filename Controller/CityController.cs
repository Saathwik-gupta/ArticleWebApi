using Microsoft.AspNetCore.Mvc;
using ArticleWebApi.Models;
using ArticleWebApi.Services;
using System.Collections.Generic;

namespace ArticleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        // Injecting the interface instead of the concrete service
        private readonly ICityServiceBL _cityService;

        // Constructor updated to use ICityServiceBL
        public CitiesController(ICityServiceBL cityService)
        {
            _cityService = cityService;
        }

        // GET: api/cities
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _cityService.GetAllCities(); // This will return the list of cities including ArticleId
            return Ok(cities);
        }

        // GET: api/cities/{id}
        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityService.GetCityById(id);
            if (city == null)
            {
                return NotFound(); // Return 404 if the city is not found
            }
            return Ok(city);
        }

        // POST: api/cities
        [HttpPost]
        public IActionResult AddCity([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest(); // Return 400 if the city is null
            }
            _cityService.AddCity(city);
            return CreatedAtAction(nameof(GetCityById), new { id = city.CityId }, city); // Return 201 Created
        }

        // PUT: api/cities/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] City city)
        {
            if (id != city.CityId)
            {
                return BadRequest(); // Return 400 if the ID in the URL does not match the city object
            }

            var existingCity = _cityService.GetCityById(id);
            if (existingCity == null)
            {
                return NotFound(); // Return 404 if the city is not found
            }

            _cityService.UpdateCity(city);
            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/cities/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var existingCity = _cityService.GetCityById(id);
            if (existingCity == null)
            {
                return NotFound(); // Return 404 if the city is not found
            }

            _cityService.DeleteCity(id);
            return NoContent(); // Return 204 No Content
        }
    }
}
