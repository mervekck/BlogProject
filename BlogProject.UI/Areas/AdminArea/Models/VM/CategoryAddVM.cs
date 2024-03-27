using System.ComponentModel.DataAnnotations;

namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class CategoryAddVM
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı girilmek zorunda")]
        [MaxLength(250, ErrorMessage = "Kategori Adı 250 karateri geçemez.")]
        public string Name { get; set; }

        [Display(Name = "Aciklama")]
        [MaxLength(550, ErrorMessage = "Kategori Adı 550 karateri geçemez.")]
        public string? Description { get; set; }
    }
}
