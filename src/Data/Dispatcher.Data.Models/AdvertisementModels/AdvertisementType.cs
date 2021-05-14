namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class AdvertisementType : BaseDeletableModel<int>
    {
        public AdvertisementType()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        public IEnumerable<Advertisement> Advertisements { get; set; }
    }
}
