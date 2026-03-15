using System.ComponentModel.DataAnnotations;

namespace CompanyMVC.Models
{
    public class Ajiltan
    {
        public int AjiltanId { get; set; }

        [Required(ErrorMessage = "Овог оруулна уу")]
        [Display(Name = "Овог")]
        public string Ovog { get; set; } = string.Empty;

        [Required(ErrorMessage = "Нэр оруулна уу")]
        [Display(Name = "Нэр")]
        public string Ner { get; set; } = string.Empty;

        [Display(Name = "Сурагч код")]
        public string? Aimag_kod { get; set; }

        [Display(Name = "Төрөл")]
        public string? Turul { get; set; }

        [Display(Name = "Цалин")]
        public decimal Tsalin { get; set; }

        [Required(ErrorMessage = "Салбар сонгоно уу")]
        [Display(Name = "Салбар")]
        public int SalbarId { get; set; }

        public Salbar? Salbar { get; set; }
    }
}