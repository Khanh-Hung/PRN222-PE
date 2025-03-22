using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement.Repositories.DBContext;
using PharmaceuticalManagement.Repositories.Models;
using PharmaceuticalManagement.Services;

namespace PharmaceuticalManagement_StudentName.Pages.MedicineInformations
{
    [Authorize(Roles = "2,3")]
    public class IndexModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;

        public IndexModel(IMedicineInformationService medicineInformationService)
        {
            _medicineInformationService = medicineInformationService;
        }

        public IList<MedicineInformation> MedicineInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MedicineInformation = await _medicineInformationService.getAll();
        }
    }
}
