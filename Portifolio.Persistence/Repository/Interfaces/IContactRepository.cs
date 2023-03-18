using Portifolio.Domain.Models;

namespace Portifolio.Persistence.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> AddContact(Contact contact);
        Task<List<Contact>> GetAllContacts();
    }
}
