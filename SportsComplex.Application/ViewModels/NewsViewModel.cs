using System;
using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class NewsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "News Content*")]
        [Required]
        public string Content { get; set; }

        public string Image { get; set; }

        public bool Highlight { get; set; }

        public string IsSelected { get; set; }

        [Display(Name = "Posted On*")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime PostedOn { get; set; }

        [Display(Name = "Expires On*")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ExpiresOn { get; set; }
    }
}