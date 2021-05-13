namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdvertisementType
    {
        public AdvertisementType()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        public IEnumerable<Advertisement> Advertisements { get; set; }
    }
}
