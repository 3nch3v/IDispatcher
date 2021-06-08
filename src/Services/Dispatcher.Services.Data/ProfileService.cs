namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Data.Dtos;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ProfileModels;

    public class ProfileService : IProfileService
    {
        private const string DefaultAvatarPath = "/img/3_avatar-512.png";
        private const string ProfilePictureFolder = "/img/profile-pictures";

        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<CustomerReview> commentsRepository;
        private readonly IDeletableEntityRepository<ProfilePicture> profilePicturesRepository;

        public ProfileService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<CustomerReview> commentsRepository,
            IDeletableEntityRepository<ProfilePicture> profilePicturesRepository)
        {
            this.usersRepository = usersRepository;
            this.commentsRepository = commentsRepository;
            this.profilePicturesRepository = profilePicturesRepository;
        }

        public T GetUserById<T>(string id)
        {
            var user = this.usersRepository.AllAsNoTracking()
                .Where(u => u.Id == id)
                .To<T>()
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<T> GetComments<T>(string id)
        {
            var comments = this.commentsRepository.All()
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

        public DataManagerDto GetUserData(string id)
        {
            var userData = this.usersRepository.AllAsNoTracking()
                .Where(u => u.Id == id)
                .Select(x => new DataManagerDto
                {
                    Id = x.Id,
                    Projects = x.Projects,
                    Advertisements = x.Advertisements,
                    Discussions = x.Discussions,
                    Jobs = x.Jobs,
                    Blogs = x.Blogs,
                })
                .FirstOrDefault();

            return userData;
        }

        public async Task SavePictureAsync(ProfilePictureInputModel input, string pictureDirectory)
        {
            string fileExtension = Path.GetExtension(input.Picture.FileName);

            ProfilePicture profilePicture = new ProfilePicture
            {
                UserId = input.UserId,
                Extension = fileExtension,
            };

            string filePath = $"{ProfilePictureFolder}/{profilePicture.Id}{fileExtension}";
            string physicalFilePath = $"{pictureDirectory}/{profilePicture.Id}{fileExtension}";

            profilePicture.FilePath = filePath;
            profilePicture.PhysicalFilePath = physicalFilePath;

            using var fileStream = new FileStream(physicalFilePath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);

            await this.profilePicturesRepository.AddAsync(profilePicture);
            await this.profilePicturesRepository.SaveChangesAsync();
        }

        public string GetProfilePicturePath(string id)
        {
            var picture = this.profilePicturesRepository.All()
                .Where(x => x.UserId == id)
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault();

            if (picture == null)
            {
                return DefaultAvatarPath;
            }

            return picture.FilePath;
        }
    }
}
