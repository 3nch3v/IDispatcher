namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class CommentViewModel : IMapFrom<CustomerReview>
    {
        public string UserId { get; set; }

        public int StarsCount { get; set; }

        public string Comment { get; set; }

        public string AppraiserUsername { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
