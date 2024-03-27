using System.ComponentModel.DataAnnotations;

namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class CategoryEditVM
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }


        [MaxLength(550)]
        public string? Description { get; set; }
    }
}
