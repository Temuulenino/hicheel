using System.ComponentModel.DataAnnotations;

namespace week2.Models
{
    public class Branch
    {
        public int branchID { get; set; }

        [Required(ErrorMessage = "Салбарын нэр оруулна уу")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2-100 тэмдэгт байна")]
        [Display(Name = "Салбарын нэр")]
        public string? bname { get; set; }

        [Required(ErrorMessage = "Хаяг оруулна уу")]
        [StringLength(200, ErrorMessage = "200-аас богино байна")]
        [Display(Name = "Хаяг")]
        public string? address { get; set; }

        public virtual ICollection<Worker>? Workers { get; set; }
    }
}