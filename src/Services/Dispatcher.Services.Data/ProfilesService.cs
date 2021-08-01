namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ProfileModels;

    using static Dispatcher.Common.GlobalConstants.User;

    public class ProfilesService : IProfilesService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<CustomerReview> commentsRepository;
        private readonly IDeletableEntityRepository<ProfilePicture> profilePicturesRepository;
        private readonly IFilesService filesService;

        public ProfilesService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<CustomerReview> commentsRepository,
            IDeletableEntityRepository<ProfilePicture> profilePicturesRepository,
            IFilesService filesService)
        {
            this.usersRepository = usersRepository;
            this.commentsRepository = commentsRepository;
            this.profilePicturesRepository = profilePicturesRepository;
            this.filesService = filesService;
        }

        public ProfileDataDto GetUserById(string userId)
        {
            var userData = this.usersRepository.AllAsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => new ProfileDataDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Education = u.Education,
                    CompanyName = u.CompanyName,
                    Interest = u.Interest,
                    Contact = u.Contact,
                    WebsiteUrl = u.WebsiteUrl,
                    GithubUrl = u.GithubUrl,
                    FacebookUrl = u.FacebookUrl,
                    InstagramUrl = u.InstagramUrl,
                    CumstomerReviews = u.CumstomerReviews
                        .Select(x => new ProfileCustomersReviewsDto
                        {
                            StarsCount = x.StarsCount,
                        }).ToArray(),
                    ProfilePicture = u.ProfilePicture == null ? null : $"{ProfilePicturePath}/{u.ProfilePicture.Id}{u.ProfilePicture.Extension}",
                    Advertisements = u.Advertisements
                        .Select(x => new ProfileAdvertisementsDto
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Compensation = x.Compensation,
                        }).ToArray(),
                    Projects = u.Projects
                        .Select(x => new ProfileProjectsDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            UserRole = x.UserRole,
                            Url = x.Url,
                        }).ToArray(),
                    Discussions = u.Discussions
                        .Select(x => new ProfileForumDiscussionsDto
                        {
                            Id = x.Id,
                            Title = x.Title,
                        }).ToArray(),
                    Blogs = u.Blogs
                        .Select(x => new ProfileBlogDtos
                        {
                            Id = x.Id,
                            Title = x.Title,
                        }).ToArray(),
                    Jobs = u.Jobs
                        .Select(x => new ProfileJobsDto
                        {
                            Id = x.Id,
                            Title = x.Title,
                        }).ToArray(),
                })
                .FirstOrDefault();

            return userData;
        }

        public DataManagerDto GetUserData(string id)
        {
            var userData = this.usersRepository.AllAsNoTracking()
                .Where(u => u.Id == id)
                .Select(x => new DataManagerDto
                {
                    Id = x.Id,
                    Projects = x.Projects
                        .Select(p => new DataManagerCollectionsDto
                        {
                            Id = p.Id,
                            Title = p.Name,
                        }).ToArray(),
                    Advertisements = x.Advertisements
                        .Select(p => new DataManagerCollectionsDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                        }).ToArray(),
                    Discussions = x.Discussions
                        .Select(p => new DataManagerCollectionsDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                        }).ToArray(),
                    Jobs = x.Jobs
                        .Select(p => new DataManagerCollectionsDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                        }).ToArray(),
                    Blogs = x.Blogs
                        .Select(p => new DataManagerCollectionsDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                        }).ToArray(),
                })
                .FirstOrDefault();

            return userData;
        }

        public string GetProfilePicturePath(string id)
        {
            var picture = this.profilePicturesRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == id)
                .FirstOrDefault();

            if (picture == null)
            {
                return DefaultAvatarPath;
            }

            return $"{ProfilePicturePath}/{picture.Id}{picture.Extension}";
        }

        public IEnumerable<T> GetComments<T>(string id)
        {
            var comments = this.commentsRepository.AllAsNoTracking()
                .Where(x => x.UserId == id)
                .OrderBy(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return comments;
        }

        public async Task CommentAsync<T>(string appraiserId, T input)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<CustomerReview>(input);

            comment.AppraiserId = appraiserId;

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task SetProfilePictureAsync(ProfilePictureInputModel input, string pictureDirectory)
        {
            bool isInitialInstance = false;

            var picture = this.profilePicturesRepository.All().FirstOrDefault(u => u.UserId == input.UserId);

            string pictureExtension = Path.GetExtension(input.Picture.FileName);

            if (picture != null)
            {
                this.filesService.DeleteFile(pictureDirectory, picture.Id, picture.Extension);
            }
            else if (picture == null)
            {
                picture = new ProfilePicture
                {
                    UserId = input.UserId,
                };

                isInitialInstance = true;
            }

            picture.Extension = pictureExtension;

            await this.filesService.SaveFileAsync(input.Picture, pictureDirectory, picture.Id, pictureExtension);

            if (isInitialInstance)
            {
                await this.profilePicturesRepository.AddAsync(picture);
            }

            await this.profilePicturesRepository.SaveChangesAsync();
        }
    }
}
