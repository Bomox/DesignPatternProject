using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class WarframeViewModel
    {
        public int ID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Warframe's name must be at least 2 characters")]
        [MaxLength(30, ErrorMessage = "Warframe's name must not be over 30 characters")]
        [Display(Name = "Warframe Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, 2200, ErrorMessage = "Warframe's health can't be under one and over 2200")]
        [Display(Name = "Warframe Health")]
        public int Health { get; set; }

        [Required]
        [Range(0, 300, ErrorMessage = "Warframe's energy can't be below 0 and above 300")]
        [Display(Name = "Warframe Energy")]
        public int Energy { get; set; }

        [Required]
        [Range(15, 700, ErrorMessage = "Warframe's armor can't be below 15 and above 700")]
        [Display(Name = "Warframe Armor")]
        public int Armor { get; set; }
    }
}
