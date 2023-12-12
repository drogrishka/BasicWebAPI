using Basic_Web_API.Models;

namespace Basic_Web_API.Services.Interface
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);

    }
}
