namespace Dispatcher.Web.ViewModels.ProjectModels
{
    using System.Collections.Generic;

    public class AllProjectsViewModel
    {
        public IEnumerable<SingleProjectViewModel> Projects { get; set; }
    }
}
