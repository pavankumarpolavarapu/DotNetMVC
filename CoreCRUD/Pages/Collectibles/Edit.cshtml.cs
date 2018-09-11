using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCRUD.Models;

namespace CoreCRUD.Pages.Collectibles
{
    public class EditModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;

        public EditModel(CoreCRUD.Models.AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Collectible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectibleExists(Collectible.Id))
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

        private bool CollectibleExists(int id)
        {
            return _context.Collectible.Any(e => e.Id == id);
        }
    }
}
