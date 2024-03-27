namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class PostEditVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public IFormFile Picture_ { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
