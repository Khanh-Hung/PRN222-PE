using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement.Repositories.Basic;
using PharmaceuticalManagement.Repositories.Models;

namespace PharmaceuticalManagement.Repositories
{
    public class StoreAccountRepository : GenericRepository<StoreAccount>
    {
        public StoreAccountRepository()
        {
        }

        public async Task<StoreAccount> GetUserAccount(string email, string password)
        {
            return await _context.StoreAccounts
                .FirstOrDefaultAsync(x => x.EmailAddress == email && x.StoreAccountPassword == password);

        }

        public async Task<List<StoreAccount>> GetAll()
        {
            return await _context.StoreAccounts.ToListAsync();
        }
    }
}
