namespace Dispatcher.Web.ViewModels.AdModels
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class AdsViewModel : IMapFrom<Advertisement>, IMapTo<Advertisement>
    {
        public int Id { get; set; }

        public string AdvertisementTypeType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ClearDescription => WebUtility.HtmlDecode(Regex.Replace(new HtmlSanitizer().Sanitize(this.Description), "<[^>]+>", string.Empty));

        public string UserUsername { get; set; }

        public string UserId { get; set; }

        public string PictureUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Compensation { get; set; }
    }
}
