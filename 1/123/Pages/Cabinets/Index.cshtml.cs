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
    public class IndexModel : PageModel
    {
        private readonly CRUDtest2.Data.CRUDtest2Context _context;

        public IndexModel(CRUDtest2.Data.CRUDtest2Context context)
        {
            _context = context;
        }

        public IList<Cabinet> Cabinet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cabinet = await _context.Cabinet
                .Include(c => c.Floor).ToListAsync();
        }
    }
}
