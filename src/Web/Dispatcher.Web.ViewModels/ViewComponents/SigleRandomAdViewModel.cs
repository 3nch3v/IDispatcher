namespace Dispatcher.Web.ViewModels.ViewComponents
{
    using System.Net;
    using System.Text.RegularExpressions;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SigleRandomAdViewModel : IMapFrom<Advertisement>
    {
        public int Id { get; set; }

        public string AdvertisementTypeType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string ClearDescription => WebUtility.HtmlDecode(Regex.Replace(this.SanitizedDescription, "<[^>]+>", string.Empty));

        public string Compensation { get; set; }

        public string PictureUrl { get; set; }

        public string UserUsername { get; set; }
    }
}
