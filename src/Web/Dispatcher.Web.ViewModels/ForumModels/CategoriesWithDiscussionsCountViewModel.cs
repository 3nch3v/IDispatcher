namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;

    public class CategoriesWithDiscussionsCountViewModel
    {
        public IEnumerable<SingleCategoryViewModel> Categories { get; set; }

        public int UnsolvedCount { get; set; }
    }
}
