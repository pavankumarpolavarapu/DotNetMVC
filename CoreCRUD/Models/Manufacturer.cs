
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCRUD.Models
{
    public class Manufacturer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Model { get; set; }
        public ICollection<Collectible> Collectibles { get; set; }

        //Bool was throwing an error
    }
}
            