namespace Dispatcher.Web.ViewModels.ForumModels
{
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class SingleCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public int DiscussionsCount { get; set; }
    }
}
