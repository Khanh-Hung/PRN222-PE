using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement.Repositories.DBContext;
using PharmaceuticalManagement.Repositories.Models;

namespace PharmaceuticalManagement_StudentName.Pages.MedicineInformations
{
    public class DetailsModel : PageModel
    {
        private readonly PharmaceuticalManagement.Repositories.DBContext.Sp25PharmaceuticalDBContext _context;

        public DetailsModel(PharmaceuticalManagement.Repositories.DBContext.Sp25PharmaceuticalDBContext context)
        {
            _context = context;
        }

        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation = await _context.MedicineInformations.FirstOrDefaultAsync(m => m.MedicineId == id);
            if (medicineinformation == null)
            {
                return NotFound();
            }
            else
            {
                MedicineInformation = medicineinformation;
            }
            return Page();
        }
    }
}
