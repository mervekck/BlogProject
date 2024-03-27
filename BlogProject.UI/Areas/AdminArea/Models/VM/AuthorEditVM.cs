namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class AuthorEditVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
