using Basic_Web_API.Data;
using Basic_Web_API.Models;
using Basic_Web_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Basic_Web_API.Services
{
    public class AppService: ICompanyService, IContactService, ICountryService
    {
        private readonly DataContext _dbContext;

        public AppService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Contact methods
        public List<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public Contact GetContactById(int contactId)
        {
            return _dbContext.Contacts.Find(contactId);
        }

        public void CreateContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            _dbContext.Entry(contact).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteContact(int contactId)
        {
            var contact = _dbContext.Contacts.Find(contactId);
            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
            }
        }
        public List<Contact> FilterContacts(int? countryId, int? companyId)
        {
            IQueryable<Contact> query = _dbContext.Contacts.Include(c => c.Company).Include(c => c.Country);

            if (countryId.HasValue)
            {
                query = query.Where(c => c.CountryId == countryId);
            }

            if (companyId.HasValue)
            {
                query = query.Where(c => c.CompanyId == companyId);
            }

            return query.ToList();
        }

        //Country methods
        public List<Country> GetAllCountries()
        {
            return _dbContext.Countries.ToList();
        }

        public Country GetCountryById(int countryId)
        {
            return _dbContext.Countries.Find(countryId);
        }

        public void CreateCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _dbContext.Entry(country).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCountry(int countryId)
        {
            var country = _dbContext.Countries.Find(countryId);
            if (country != null)
            {
                _dbContext.Countries.Remove(country);
                _dbContext.SaveChanges();
            }
        }


        //Company
        public List<Company> GetAllCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public Company GetCompanyById(int companyId)
        {
            return _dbContext.Companies.Find(companyId);
        }

        public void CreateCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            _dbContext.Entry(company).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCompany(int companyId)
        {
            var company = _dbContext.Companies.Find(companyId);
            if (company != null)
            {
                _dbContext.Companies.Remove(company);
                _dbContext.SaveChanges();
            }
        }

    }
}
