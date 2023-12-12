using Basic_Web_API.Models;
using Basic_Web_API.Services;
using Basic_Web_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Web_API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("getAllCountries")]
        public ActionResult<List<Country>> GetAllCountry()
        {
            var countries = _countryService.GetAllCountries();
            return Ok(countries);
        }

        [HttpGet("getCountryById")]
        public ActionResult<Country> GetCountryById(int countryId)
        {
            var country = _countryService.GetCountryById(countryId);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost("createCountry")]
        public ActionResult CreateCountry([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            _countryService.CreateCountry(country);

            return CreatedAtAction(nameof(GetCountryById), new { companyId = country.CountryId }, country);
        }

        [HttpPut("updateCountry")]
        public ActionResult UpdateCountry(int countryId, [FromBody] Country country)
        {
            if (country == null || countryId != country.CountryId)
            {
                return BadRequest();
            }

            var existingCountry = _countryService.GetCountryById(countryId);

            if (existingCountry == null)
            {
                return NotFound();
            }

            _countryService.UpdateCountry(country);

            return NoContent();
        }

        [HttpDelete("deleteCountry")]
        public ActionResult DeleteCountry(int countryId)
        {
            var country = _countryService.GetCountryById(countryId);

            if (country == null)
            {
                return NotFound();
            }

            _countryService.DeleteCountry(countryId);

            return NoContent();
        }
    }
}
