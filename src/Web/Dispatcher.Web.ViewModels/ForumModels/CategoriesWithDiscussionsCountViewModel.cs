namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;

    public class CategoriesWithDiscussionsCountViewModel
    {
        public int UnsolvedCount { get; set; }

        public IEnumerable<SingleCategoryViewModel> Categories { get; set; }
    }
}
