using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCRUD.Models;

namespace CoreCRUD.Pages.Collectibles
{
    public class DeleteModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;

        public DeleteModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Collectible Collectible { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collectible = await _context.Collectible.FirstOrDefaultAsync(m => m.Id == id);

            if (Collectible == null)
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

            Collectible = await _context.Collectible.FindAsync(id);

            if (Collectible != null)
            {
                _context.Collectible.Remove(Collectible);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
