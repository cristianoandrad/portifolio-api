using Microsoft.EntityFrameworkCore;
using Portifolio.API.Data;
using Portifolio.Domain.Models;
using Portifolio.Persistence.Repository.Interfaces;

namespace Portifolio.API.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly PortifolioContext _context;

        public ContactRepository(PortifolioContext context)
        {
            _context = context;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            _context.Contatcs.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contatcs.AsNoTracking().ToListAsync();            
        }
    }
}
