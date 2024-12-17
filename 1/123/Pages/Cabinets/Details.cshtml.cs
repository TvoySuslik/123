using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDtest2.Data;
using CRUDtest2.Models;

namespace CRUDtest2.Pages.Cabinets
{
    public class DetailsModel : PageModel
    {
        private readonly CRUDtest2.Data.CRUDtest2Context _context;

        public DetailsModel(CRUDtest2.Data.CRUDtest2Context context)
        {
            _context = context;
        }

        public Cabinet Cabinet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet.FirstOrDefaultAsync(m => m.Id == id);
            if (cabinet == null)
            {
                return NotFound();
            }
            else
            {
                Cabinet = cabinet;
            }
            return Page();
        }
    }
}
