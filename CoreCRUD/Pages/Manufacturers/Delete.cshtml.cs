using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCRUD.Models;

namespace CoreCRUD.Pages.Manufacturers
{
    public class DeleteModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;

        public DeleteModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.ID == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FindAsync(id);

            if (Manufacturer != null)
            {
                _context.Manufacturer.Remove(Manufacturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
