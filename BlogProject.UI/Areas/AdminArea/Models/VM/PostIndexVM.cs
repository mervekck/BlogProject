using BlogProject.Domain.Entities.Concrete;
namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class PostIndexVM
    {
        public string Title { get; set; }
        public bool? IsEnter { get; set; }
        public List<PostIndexItem> PostIndexItems { get; set; }
    }
    public class PostIndexItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public string AuthorName { get; set; }
        public byte[]? Picture { get; set; }
        public int? ViewCount { get; set; }
        public Guid? AuthorId { get; set; }

    }
}
