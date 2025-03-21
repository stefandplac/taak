﻿using System.ComponentModel.DataAnnotations;

namespace Taak.Models
{
    public class TaakTaskModel
    {
        public Guid IdTask { get; set; }
        public Guid IdTaskCategory { get; set; }
        public Guid IdCustomer { get; set; }
        public string Title { get; set; } = null!;

        [MinLength(20, ErrorMessage = "The description must be at least 20 characters")]
        public string Description { get; set; } = null!;
        public decimal Buget { get; set; }
        public string? SpecialRequirements { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime TaskDate { get; set; }
        public string? TimeOptions { get; set; }
        public string DateOption { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Building { get; set; } = null!;
        public string? Floor { get; set; }
        public string County { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
