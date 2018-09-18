
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCRUD.Models
{
    public class Collectible
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
            