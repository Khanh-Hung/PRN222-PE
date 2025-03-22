using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement.Repositories.DBContext;
using PharmaceuticalManagement.Repositories.Models;

namespace PharmaceuticalManagement_StudentName.Pages.MedicineInformations
{
    public class EditModel : PageModel
    {
        private readonly PharmaceuticalManagement.Repositories.DBContext.Sp25PharmaceuticalDBContext _context;

        public EditModel(PharmaceuticalManagement.Repositories.DBContext.Sp25PharmaceuticalDBContext context)
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

            var medicineinformation =  await _context.MedicineInformations.FirstOrDefaultAsync(m => m.MedicineId == id);
            if (medicineinformation == null)
            {
                return NotFound();
            }
            MedicineInformation = medicineinformation;
           ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MedicineInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineInformationExists(MedicineInformation.MedicineId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicineInformationExists(string id)
        {
            return _context.MedicineInformations.Any(e => e.MedicineId == id);
        }
    }
}
