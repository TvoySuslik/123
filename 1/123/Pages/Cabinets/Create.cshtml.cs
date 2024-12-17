using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDtest2.Data;
using CRUDtest2.Models;

namespace CRUDtest2.Pages.Cabinets
{
    public class CreateModel : PageModel
    {
        private readonly CRUDtest2.Data.CRUDtest2Context _context;

        public CreateModel(CRUDtest2.Data.CRUDtest2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FloorId"] = new SelectList(_context.Floor, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Cabinet Cabinet { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cabinet.Add(Cabinet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
