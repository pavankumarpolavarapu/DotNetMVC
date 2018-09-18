using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCRUD.Pages {
    public class IndexModel : PageModel {
        private readonly CoreCRUD.Models.AppDbContext _context;
        public int ManufacturerCount { get; set; }
        public int CollectibleCount { get; set; }

        public Collectible MostPreciousItem { get; set; }

        public Collectible OldestItem { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public IndexModel (CoreCRUD.Models.AppDbContext context) {
            _context = context;
        }
        public void OnGet () {
            ManufacturerCount = _context.Manufacturer.Count ();
            CollectibleCount = _context.Collectible.Count ();
            MostPreciousItem = _context.Collectible
                .OrderByDescending (col => Math.Round (col.Price))
                .First ();
            OldestItem = _context.Collectible
                .OrderBy (col => col.DateOfPurchase)
                .First ();

            // MostPreciousItem = Collectibles.OrderBy(x => x.Price).Reverse().Last();
        }
    }
}