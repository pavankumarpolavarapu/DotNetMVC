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
    public class DetailsModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;

        public DetailsModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }

        public Collectible Collectible { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collectible = await _context.Collectible
            .Include(e => e.Manufacturer)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Collectible == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
