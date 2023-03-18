using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portifolio.Domain.Models;

namespace Portifolio.API.Data
{
    public class PortifolioContext : DbContext
    {
        public PortifolioContext(DbContextOptions<PortifolioContext> options) : base(options) { }

        public DbSet<Contact> Contatcs { get; set; }        
    }
}
