namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class AuthorIndexVM
    {
        public string Name { get; set; }
        public bool? IsEnter { get; set; }
        public List<AuthorIndexItem> Authors { get; set; }
    }

    public class AuthorIndexItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
