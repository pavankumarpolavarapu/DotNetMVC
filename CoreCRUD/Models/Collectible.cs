using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CoreCRUD.Models {
    public class Collectible {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength (10)]
        [RegularExpression (@"[a-z]+")]
        public string Name { get; set; }

        [CustomValidation (typeof (Collectible), "DateValidator")]
        [Display (Name = "Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        [CustomValidation (typeof (Collectible), "CategoryValidator")]
        public string Category { get; set; }

        [Range (10, 2000)]
        public decimal Price { get; set; }
        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public static ValidationResult DateValidator (DateTime? pDate, ValidationContext context) {
            if (pDate == null) {
                return ValidationResult.Success;
            }

            if (pDate < DateTime.Today) {
                return ValidationResult.Success;
            }

            return new ValidationResult ("Purchase date must be in the past");
        }
        public static ValidationResult CategoryValidator (string category, ValidationContext context) {
            if (category == null) {
                return ValidationResult.Success;
            }

            if (category != "Pavan") {
                return ValidationResult.Success;
            }

            return new ValidationResult (" Category cannot be Pavan");
        }

    }
}