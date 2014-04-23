using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;
using p2groep04.ViewModels.UserViewModels;

namespace p2groep04.ViewModels.SuggestionViewModels
{
    public class CreateViewModel
    {
        public SuggestionViewModel Suggestion { get; set; }
        public StudentViewModel Student { get; set; }
        public PromotorViewModel CoPromotor { get; set; }
    }

    public class EditViewModel
    {
        public SuggestionViewModel Suggestion { get; set; }
        public StudentViewModel Student { get; set; }
        public PromotorViewModel CoPromotor { get; set; }
    }

    public class SuggestionViewModel
    {
        [Display(Name = "Titel")]
        public String Title { get; set; }

        [Display(Name = "Keywords")]
        public String[] Keywords { get; set; }

        [Display(Name = "Context")]
        public String Context { get; set; }

        [Display(Name = "Probleemstelling")]
        public String Subject { get; set; }

        [Display(Name = "Doelstelling")]
        public String Goal { get; set; }

        [Display(Name = "Onderzoeksvraag")]
        public String ResearchQuestion { get; set; }

        [Display(Name = "Plan van aanpak")]
        public String Motivation { get; set; }

        [Display(Name = "Referenties")]
        public String[] References { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }
    }
}