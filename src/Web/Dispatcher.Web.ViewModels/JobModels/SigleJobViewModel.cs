namespace Dispatcher.Web.ViewModels.JobModels
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SigleJobViewModel : IMapFrom<Job>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string JobBody { get; set; }

        public string SanitizedBody => new HtmlSanitizer().Sanitize(this.JobBody);

        public string ClearBody => WebUtility.HtmlDecode(Regex.Replace(new HtmlSanitizer().Sanitize(this.JobBody), "<[^>]+>", string.Empty));

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string Contact { get; set; }

        public string LogoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}
