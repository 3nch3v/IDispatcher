namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    using static Dispatcher.Common.GlobalConstants.User;

    public class SingleForumDiscussionsViewModel : IMapFrom<Discussion>, IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public bool IsSolved { get; set; }

        public string CategoryName { get; set; }

        public string UserUsername { get; set; }

        public ProfilePicture UserProfilePicture { get; set; }

        public string ProfilePicture => this.UserProfilePicture == null ? null : $"{ProfilePicturePath}/{this.UserProfilePicture.Id}{this.UserProfilePicture.Extension}";

        public DateTime CreatedOn { get; set; }

        public virtual IEnumerable<SinglePostViewModel> Posts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Discussion, SingleForumDiscussionsViewModel>()
                .ForMember(
                    x => x.Likes,
                    opts => opts.MapFrom(src => src.Votes.Sum(x => x.Like)))
                .ForMember(
                    x => x.Dislikes,
                    opts => opts.MapFrom(src => src.Votes.Sum(x => x.Dislike)));
        }
    }
}
