using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement.Repositories;
using PharmaceuticalManagement.Repositories.Models;

namespace PharmaceuticalManagement.Services
{
    public interface IMedicineInformationService
    {
        Task<List<MedicineInformation>> getAll();
        Task<MedicineInformation> getMedicineInformationByIdHaveInclude(string id);
        Task<int> Create(MedicineInformation booking);
        Task<int> Update(MedicineInformation booking);
        Task<bool> Delete(string id);
        Task<List<MedicineInformation>> Search(string? ActiveIngredients, string ExpirationDate, string WarningsAndPrecautions);
    }
    public class MedicineInformationService : IMedicineInformationService
    {
        private readonly MedicineInformationRepository _repository;

        public MedicineInformationService(MedicineInformationRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(MedicineInformation booking)
        {
            return await _repository.CreateAsync(booking);
        }
        public async Task<bool> Delete(string id)
        {
            var deleteId = await _repository.GetByIdAsync(id);
            if (deleteId != null)
            {
                return await _repository.RemoveAsync(deleteId);
            }
            return false;
        }
        public async Task<List<MedicineInformation>> getAll()
        {
            return await _repository.getAll();
        }
        public async Task<MedicineInformation> getMedicineInformationByIdHaveInclude(string id)
        {
            return await _repository.getMedicineInformationByIdHaveInclude(id);
        }
        public async Task<List<MedicineInformation>> Search(string? ActiveIngredients, string ExpirationDate, string WarningsAndPrecautions)
        {
            return await _repository.Search(ActiveIngredients, ExpirationDate, WarningsAndPrecautions);
        }
        public async Task<int> Update(MedicineInformation booking)
        {
            return await _repository.UpdateAsync(booking);
        }
    }
}
