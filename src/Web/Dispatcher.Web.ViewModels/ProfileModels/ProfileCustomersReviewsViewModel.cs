﻿namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfileCustomersReviewsViewModel : IMapFrom<CustomerReview>
    {
        public int StarsCount { get; set; }
    }
}
