namespace Dispatcher.Web.ViewModels.ForumModels
{
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
