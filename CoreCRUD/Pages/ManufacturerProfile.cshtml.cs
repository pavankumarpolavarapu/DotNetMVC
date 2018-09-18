using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCRUD
{
    public class ManufacturerProfileModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;
 
        public Manufacturer Manufacturer { get; set;}

        public ManufacturerProfileModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int? id)
        {
            Manufacturer = _context.Manufacturer
                                    .Include(col => col.Collectibles)
                                    .FirstOrDefault(man => man.ID == id);


            if (Manufacturer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}