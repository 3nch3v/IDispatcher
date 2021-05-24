namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    public class AllCommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
