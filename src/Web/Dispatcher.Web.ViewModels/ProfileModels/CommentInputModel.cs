namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class CommentInputModel : IMapTo<CustomerReview>
    {
        public string UserId { get; set; }

        [Range(1, 5)]
        public int StarsCount { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
