using CadastroAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CadastroAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
