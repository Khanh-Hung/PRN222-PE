using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement.Repositories.Models;
using PharmaceuticalManagement.Repositories;

namespace PharmaceuticalManagement.Services
{
    public interface IStoreAccountService
    {
        Task<List<StoreAccount>> getAll();
        Task<StoreAccount> GetUserAccount(string email, string password);
    }
    public class StoreAccountService : IStoreAccountService
    {
        private readonly StoreAccountRepository _repository;

        public StoreAccountService(StoreAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<StoreAccount>> getAll()
        {
            return await _repository.GetAll();
        }

        public async Task<StoreAccount> GetUserAccount(string email, string password)
        {
            return await _repository.GetUserAccount(email, password);
        }


    }
}
