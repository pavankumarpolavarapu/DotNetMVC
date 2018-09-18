using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCRUD.Pages
{
    public class AuctionModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;
        public List<Collectible> Collectibles { get; set; }
        public AuctionModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            Collectibles = _context.Collectible
                                        .Include(man => man.Manufacturer)
                                        .ToList(); 
            return Page();
        }
    }
}