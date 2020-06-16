using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class WeaponViewModel
    {
        public int  ID { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Weapon's name must be at least 4 characters")]
        [MaxLength(30, ErrorMessage = "Weapon's name must not be over 30 characters")]
        [Display(Name = "Weapon Name")]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required]
        [Range(1, 1550, ErrorMessage = "Weapon's damage can't be under 1, or over 1550")]
        [Display(Name = "Weapon Damage")]
        public int Damage { get; set; }

        [Required]
        [Range(1, 180, ErrorMessage = "Weapon's magazine can't be under 1, or over 180")]
        [Display(Name = "Weapon Magazine")]
        public int Magazine { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Weapon's critical chance can't be under 0, or over 100")]
        [Display(Name = "Weapon Critical Chance")]
        public int Critical { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Weapon's status chance can't be under 0, or over 100")]
        [Display(Name = "Weapon Status Chance")]
        public int Status { get; set; }
    }
}