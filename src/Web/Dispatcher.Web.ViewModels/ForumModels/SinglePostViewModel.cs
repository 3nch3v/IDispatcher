namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;
    using System.Linq;

    using AutoMapper;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    using static Dispatcher.Common.GlobalConstants.User;

    public class SinglePostViewModel : IMapFrom<Comment>, IMapTo<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserUsername { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public ProfilePicture UserProfilePicture { get; set; }

        public string ProfilePicture => this.UserProfilePicture == null ? null : $"{ProfilePicturePath}/{this.UserProfilePicture.Id}{this.UserProfilePicture.Extension}";

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, SinglePostViewModel>()
               .ForMember(
                   x => x.Likes,
                   opts => opts.MapFrom(src => src.Votes.Sum(x => x.Like)))
               .ForMember(
                   x => x.Dislikes,
                   opts => opts.MapFrom(src => src.Votes.Sum(x => x.Dislike)));
        }
    }
}
