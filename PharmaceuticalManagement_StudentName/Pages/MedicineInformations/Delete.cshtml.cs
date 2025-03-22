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
    public class DeleteModel : PageModel
    {
        private readonly PharmaceuticalManagement.Repositories.DBContext.Sp25PharmaceuticalDBContext _context;

        public DeleteModel(PharmaceuticalManagement.Repositories.DBContext.Sp25PharmaceuticalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation = await _context.MedicineInformations.FindAsync(id);
            if (medicineinformation != null)
            {
                MedicineInformation = medicineinformation;
                _context.MedicineInformations.Remove(MedicineInformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
