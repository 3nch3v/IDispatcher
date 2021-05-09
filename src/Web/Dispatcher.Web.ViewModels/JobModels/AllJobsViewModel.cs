namespace Dispatcher.Web.ViewModels.JobModels
{
    using System.Collections.Generic;

    public class AllJobsViewModel
    {
        public IEnumerable<SigleJobViewModel> Jobs { get; set; }
    }
}
