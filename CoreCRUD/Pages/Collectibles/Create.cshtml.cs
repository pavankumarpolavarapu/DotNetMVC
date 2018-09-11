using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCRUD.Models;

namespace CoreCRUD.Pages.Collectibles
{
    public class CreateModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;

        public CreateModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Collectible Collectible { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collectible.Add(Collectible);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}