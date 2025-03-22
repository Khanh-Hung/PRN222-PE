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
    public class MedicineInformationRepository : GenericRepository<MedicineInformation>
    {
        public MedicineInformationRepository()
        {

        }

        public async Task<List<MedicineInformation>> getAll()
        {
            return await _context.MedicineInformations
                .Include(x => x.Manufacturer)
                .ToListAsync();
        }
        public async Task<MedicineInformation?> getMedicineInformationByIdHaveInclude(string id)
        {
            return await _context.MedicineInformations
                   .Include(x => x.Manufacturer)
                   .FirstOrDefaultAsync(x => x.MedicineId == id);
        }

        public async Task<List<MedicineInformation>> Search(string? ActiveIngredients, string ExpirationDate, string WarningsAndPrecautions)
        {
            var medicine = await _context.MedicineInformations
                .Include(x => x.Manufacturer)
                .Where(x =>
                    (string.IsNullOrEmpty(ActiveIngredients) || x.ActiveIngredients.Contains(ActiveIngredients)) &&
                    (string.IsNullOrEmpty(ExpirationDate) || x.ExpirationDate.Contains(ExpirationDate)) &&
                    (string.IsNullOrEmpty(WarningsAndPrecautions) || x.WarningsAndPrecautions.Contains(WarningsAndPrecautions))
                )
                .ToListAsync();

            return medicine;
        }
    }
}
