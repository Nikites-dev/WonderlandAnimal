using Microsoft.EntityFrameworkCore;
using WonderlandAnimal.Models;

namespace WonderlandAnimal.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Account> Account { get; set; }
    }
}