using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDtest2.Data;
using CRUDtest2.Models;

namespace CRUDtest2.Pages.Cabinets
{
    public class EditModel : PageModel
    {
        private readonly CRUDtest2.Data.CRUDtest2Context _context;

        public EditModel(CRUDtest2.Data.CRUDtest2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Cabinet Cabinet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabinet =  await _context.Cabinet.FirstOrDefaultAsync(m => m.Id == id);
            if (cabinet == null)
            {
                return NotFound();
            }
            Cabinet = cabinet;
           ViewData["FloorId"] = new SelectList(_context.Floor, "Id", "Name");
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

            _context.Attach(Cabinet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinetExists(Cabinet.Id))
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

        private bool CabinetExists(int id)
        {
            return _context.Cabinet.Any(e => e.Id == id);
        }
    }
}
