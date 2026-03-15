using System.ComponentModel.DataAnnotations;

namespace CompanyMVC.Models
{
    public class Salbar
    {
        public int SalbarId { get; set; }

        [Required(ErrorMessage = "Нэр оруулна уу")]
        [Display(Name = "Салбарын нэр")]
        public string Ner { get; set; } = string.Empty;

        [Display(Name = "Хаяг")]
        public string? Hayg { get; set; }

        [Display(Name = "Утасны дугаар")]
        public string? Utasny_dugaar { get; set; }

        [Display(Name = "Бүртгэсэн огноо")]
        public DateTime Burtgesen_ognoo { get; set; }
    }
}