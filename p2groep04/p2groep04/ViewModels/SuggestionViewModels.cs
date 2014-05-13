using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using p2groep04.Models.Domain;
using p2groep04.ViewModels.UserViewModels;

namespace p2groep04.ViewModels
{
    public class CreateViewModel
    {
        public SuggestionViewModel Suggestion { get; set; }
        public StudentViewModel Student { get; set; }
        public PromotorViewModel Promotor { get; set; }
        public CoPromotorViewModel CoPromotor { get; set; }
    }

    public class EditViewModel
    {
        public SuggestionViewModel Suggestion { get; set; }
        public StudentViewModel Student { get; set; }
        public PromotorViewModel Promotor { get; set; }
        public CoPromotorViewModel CoPromotor { get; set; }
    }

    public class AdviceViewModel
    {
        public SuggestionViewModel Suggestion { get; set; }
        public StudentViewModel Student { get; set; }
        public PromotorViewModel Promotor { get; set; }
    }

    public class SuggestionViewModel
    {
        [Required]
        [Display(Name = "Titel")]
        public String Title { get; set; }

        [Display(Name = "Keywords")]
        public String[] Keywords { get; set; }

        [Required]
        [Display(Name = "Context")]
        public String Context { get; set; }

        [Required]
        [Display(Name = "Probleemstelling")]
        public String Subject { get; set; }

        [Required]
        [Display(Name = "Doelstelling")]
        public String Goal { get; set; }

        [Required]
        [Display(Name = "Onderzoeksvraag")]
        public String ResearchQuestion { get; set; }

        [Required]
        [Display(Name = "Plan van aanpak")]
        public String Motivation { get; set; }

        [Required]
        [Display(Name = "Referenties")]
        public String[] References { get; set; }
        
        [Display(Name = "Onderzoeksdomein")]
        public IEnumerable<ResearchDomain> ResearchDomains { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Advies")]
        public String Advice { get; set; }
    }
}