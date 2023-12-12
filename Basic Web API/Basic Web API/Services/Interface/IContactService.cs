using Basic_Web_API.Models;

namespace Basic_Web_API.Services.Interface
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> FilterContacts(int? countryId, int? companyId);
    }
}
