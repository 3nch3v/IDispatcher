namespace Dispatcher.Services.Data
{
    using AutoMapper;
    using Dispatcher.Services.Data.Dtos;
    using Dispatcher.Web.ViewModels.Administration;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Dispatcher.Web.ViewModels.ProfileModels;

    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            this.CreateMap<BlogInputModel, BlogPostDto>();
            this.CreateMap<EditBlogPostInputmodel, BlogPostDto>();

            this.CreateMap<DataManagerDto, DataManagerViewModel>();
            this.CreateMap<DataManagerCollectionsDto, DataManagerCollectionsViewModel>();

            this.CreateMap<ProfileDataDto, ProfileViewModel>();
            this.CreateMap<ProfileCustomersReviewsDto, ProfileCustomersReviewsViewModel>();
            this.CreateMap<ProfilePicturesDto, ProfilePicturesCollectionViewModel>();
            this.CreateMap<ProfileAdvertisementsDto, ProfileAdvertisementsViewModel>();
            this.CreateMap<ProfileProjectsDto, ProfileProjectsViewModel>();
            this.CreateMap<ProfileForumDiscussionsDto, ProfileForumDiscussionsViewModel>();
            this.CreateMap<ProfileBlogDtos, ProfileBlogsViewModel>();
            this.CreateMap<ProfileJobsDto, ProfileJobsViewModel>();
            this.CreateMap<AdminIndexDto, IndexViewModel>();
            this.CreateMap<AdminRequestDataDto, SearchDataViewmodel>();
            this.CreateMap<SearchDataDto, DataViewModel>();
        }
    }
}
