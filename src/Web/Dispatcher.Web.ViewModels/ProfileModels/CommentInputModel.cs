namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.User;

    public class CommentInputModel : IMapTo<CustomerReview>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(MinStars, MaxStars)]
        public int StarsCount { get; set; }

        [Required]
        [StringLength(CommentMaxLenght, MinimumLength = CommentMinLenght)]
        public string Comment { get; set; }
    }
}
