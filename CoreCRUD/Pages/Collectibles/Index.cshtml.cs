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
    public class IndexModel : PageModel
    {
        private readonly CoreCRUD.Models.AppDbContext _context;

        public IndexModel(CoreCRUD.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Collectible> Collectible { get;set; }

        public async Task OnGetAsync()
        {
            Collectible = await _context.Collectible.ToListAsync();
        }
    }
}
