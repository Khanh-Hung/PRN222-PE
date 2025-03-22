using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement.Repositories;
using PharmaceuticalManagement.Repositories.Models;

namespace PharmaceuticalManagement.Services
{ 
    public interface IManufacturerService
    {
        Task<List<Manufacturer>> GetAllAsync();
    }
    public class ManufacturerService : IManufacturerService
    {
        private readonly ManufacturerRepository _repository;

        public ManufacturerService(ManufacturerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
