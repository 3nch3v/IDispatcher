namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    public class AllCommentsViewModel
    {
        public string UserId { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
