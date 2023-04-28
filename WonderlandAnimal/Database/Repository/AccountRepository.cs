using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WonderlandAnimal.Models;

namespace WonderlandAnimal.Database.Repository
{
    public class AccountRepository: Repository<Account>
    {
        public AccountRepository(DatabaseContext context) : base(context)
        {
            
        }
    
        public async Task<Account> GetByEmailAsync(String email)
        {
            return await _context.Account.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}