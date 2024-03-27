using BlogProject.Domain.Entities.Concrete;

namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class PostAddVM
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public byte[]? Picture { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? CategoryId { get; set; }

    }
}
