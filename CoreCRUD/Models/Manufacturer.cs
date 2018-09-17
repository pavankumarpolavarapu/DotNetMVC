
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public int Count {
            get{
                return Collectibles.Count();
            }
        }
    }
}
            