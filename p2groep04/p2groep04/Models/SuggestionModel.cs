using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p2groep04.Models
{
    public class SuggestionModel
    {
        [Required]
        [Display(Name = "Titel")]
        public string Titel { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "ResearchDomains")]
        public string ResearchDomains { get; set; }

        [Required]
        [Display(Name = "ResearchQuestion")]
        public string ResearchQuestion { get; set; }

        [Required]
        [Display(Name = "Motivation")]
        public string Motivation { get; set; }

        [Required]
        [Display(Name = "Goal")]
        public string Goal { get; set; }

        [Required]
        [Display(Name = "Keywords")]
        public string Keywords { get; set; }

        [Required]
        [Display(Name = "References")]
        public string References { get; set; }
    }
}