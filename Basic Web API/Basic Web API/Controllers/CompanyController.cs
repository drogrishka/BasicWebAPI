using Basic_Web_API.Models;
using Basic_Web_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Web_API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("getAllCompanies")]
        public ActionResult<List<Company>> GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("getCompanyById")]
        public ActionResult<Company> GetCompanyById(int companyId)
        {
            var company = _companyService.GetCompanyById(companyId);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost("createCompany")]
        public ActionResult CreateCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            _companyService.CreateCompany(company);

            return CreatedAtAction(nameof(GetCompanyById), new { companyId = company.CompanyId }, company);
        }

        [HttpPut("updateCompany")]
        public ActionResult UpdateCompany(int companyId, [FromBody] Company company)
        {
            if (company == null || companyId != company.CompanyId)
            {
                return BadRequest();
            }

            var existingCompany = _companyService.GetCompanyById(companyId);

            if (existingCompany == null)
            {
                return NotFound();
            }

            _companyService.UpdateCompany(company);

            return NoContent();
        }

        [HttpDelete("deleteCompany")]
        public ActionResult DeleteCompany(int companyId)
        {
            var company = _companyService.GetCompanyById(companyId);

            if (company == null)
            {
                return NotFound();
            }

            _companyService.DeleteCompany(companyId);

            return NoContent();
        }
    }
}
