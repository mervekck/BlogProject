namespace BlogProject.UI.Areas.AdminArea.Models.VM
{
    public class CategoryIndexVm
    {
        public string Ad { get; set; }
        public bool? IsEnter { get; set; }
        public List<CategoryIndexItem> Categories { get; set; }
    }
    public class CategoryIndexItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }


    }
}
