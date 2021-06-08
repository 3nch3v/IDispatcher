namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfileCustomersReviewsDto : IMapFrom<CustomerReview>
    {
        public int StarsCount { get; set; }
    }
}
