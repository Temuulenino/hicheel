using System.ComponentModel.DataAnnotations;

namespace week2.Models
{
    public class Worker
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Нэр оруулна уу")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2-50 тэмдэгт байна")]
        [Display(Name = "Ажилтны нэр")]
        public string? wname { get; set; }

        [Required(ErrorMessage = "Цалин оруулна уу")]
        [Range(100000, 10000000, ErrorMessage = "100,000 - 10,000,000 хооронд байна")]
        [Display(Name = "Цалин")]
        public decimal salary { get; set; }

        [Required]
        [Display(Name = "Салбар")]
        public int branchID { get; set; }

        public virtual Branch? branch { get; set; }
    }
}