namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.ComponentModel.DataAnnotations;

    public class AdvertisementType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }
    }
}
