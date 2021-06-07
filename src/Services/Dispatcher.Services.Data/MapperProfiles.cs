namespace Dispatcher.Services.Data
{
    using AutoMapper;
    using Dispatcher.Services.Data.Dtos;
    using Dispatcher.Web.ViewModels.BlogModels;

    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            this.CreateMap<BlogInputModel, BlogPostDto>();
            this.CreateMap<EditBlogPostInputmodel, BlogPostDto>();
        }
    }
}
