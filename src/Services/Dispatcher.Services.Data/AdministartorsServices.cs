namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Enums;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Microsoft.Extensions.Caching.Memory;

    public class AdministartorsServices : IAdministartorsServices
    {
        private readonly IDeletableEntityRepository<Advertisement> advertisementsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Job> jobRepository;
        private readonly IDeletableEntityRepository<Blog> blogRepository;
        private readonly IDeletableEntityRepository<Discussion> discussionsRepository;
        private readonly IDeletableEntityRepository<Comment> commentsRepository;
        private readonly IDeletableEntityRepository<CustomerReview> customersReviesRepository;
        private readonly IDeletableEntityRepository<ProfilePicture> profilePicturesRepository;
        private readonly IDeletableEntityRepository<Project> projectsRepository;
        private readonly IMemoryCache memoryCache;

        public AdministartorsServices(
            IDeletableEntityRepository<Advertisement> advertisementsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Job> jobRepository,
            IDeletableEntityRepository<Blog> blogRepository,
            IDeletableEntityRepository<Discussion> discussionsRepository,
            IDeletableEntityRepository<Comment> commentsRepository,
            IDeletableEntityRepository<CustomerReview> customersReviesRepository,
            IDeletableEntityRepository<ProfilePicture> profilePicturesRepository,
            IDeletableEntityRepository<Project> projectsRepository,
            IMemoryCache memoryCache)
        {
            this.advertisementsRepository = advertisementsRepository;
            this.usersRepository = usersRepository;
            this.jobRepository = jobRepository;
            this.blogRepository = blogRepository;
            this.discussionsRepository = discussionsRepository;
            this.commentsRepository = commentsRepository;
            this.customersReviesRepository = customersReviesRepository;
            this.profilePicturesRepository = profilePicturesRepository;
            this.projectsRepository = projectsRepository;
            this.memoryCache = memoryCache;
        }

        public AdminIndexDto GetStatistic()
        {
            var dashboardData = this.memoryCache
                .GetOrCreate("StatisticCache", entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromSeconds(60);
                    return this.GetData();
                });

            return dashboardData;
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = this.usersRepository.All().FirstOrDefault(u => u.Id == id);

            this.DeleteUsersData(id);

            this.usersRepository.Delete(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = this.customersReviesRepository.All().FirstOrDefault(r => r.Id == id);

            this.customersReviesRepository.Delete(review);
            await this.customersReviesRepository.SaveChangesAsync();
        }

        public AdminRequestDataDto GetData(string searchData, string searchMethod, string searchTerm)
        {
            Enum.TryParse<RepositoriesDataTypes>(searchData, true, out var dataTypeResult);
            Enum.TryParse<SearchMethod>(searchMethod, true, out var methodResult);

            IEnumerable<SearchDataDto> data = null;

            if (dataTypeResult == RepositoriesDataTypes.Advertisement)
            {
                data = this.GetAdvertisement(methodResult, searchTerm);
            }
            else if (dataTypeResult == RepositoriesDataTypes.BlogPost)
            {
                data = this.GetBlog(methodResult, searchTerm);
            }
            else if (dataTypeResult == RepositoriesDataTypes.Job)
            {
                data = this.GetJob(methodResult, searchTerm);
            }
            else if (dataTypeResult == RepositoriesDataTypes.ForumPost)
            {
                data = this.GetForum(methodResult, searchTerm);
            }
            else if (dataTypeResult == RepositoriesDataTypes.ForumComment)
            {
                data = this.GetForumComment(methodResult, searchTerm);
            }
            else if (dataTypeResult == RepositoriesDataTypes.User)
            {
                data = this.GetUser(methodResult, searchTerm);
            }
            else if (dataTypeResult == RepositoriesDataTypes.Review)
            {
                data = this.GetReview(methodResult, searchTerm);
            }

            var dataDto = new AdminRequestDataDto
            {
                Data = data,
                DataType = dataTypeResult.ToString(),
            };

            return dataDto;
        }

        private AdminIndexDto GetData()
        {
            return new AdminIndexDto
            {
                SearchDataTypes = Enum.GetNames(typeof(RepositoriesDataTypes)).ToList(),
                SearchMethodTypes = Enum.GetNames(typeof(SearchMethod)).ToList(),
                UsersCount = this.usersRepository.AllAsNoTracking().Count(),
                AdsCount = this.advertisementsRepository.AllAsNoTracking().Count(),
                JobsCount = this.jobRepository.AllAsNoTracking().Count(),
                BlogsCount = this.blogRepository.AllAsNoTracking().Count(),
                DiscussionsCount = this.discussionsRepository.AllAsNoTracking().Count(),
                CommentsCount = this.commentsRepository.AllAsNoTracking().Count(),
                ReviewsCount = this.customersReviesRepository.AllAsNoTracking().Count(),
            };
        }

        private void DeleteUsersData(string id)
        {
            var ads = this.advertisementsRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var ad in ads)
            {
                this.advertisementsRepository.Delete(ad);
            }

            var jobs = this.jobRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var job in jobs)
            {
                this.jobRepository.Delete(job);
            }

            var blogs = this.blogRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var blog in blogs)
            {
                this.blogRepository.Delete(blog);
            }

            var discussions = this.discussionsRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var discussion in discussions)
            {
                this.discussionsRepository.Delete(discussion);
            }

            var projects = this.projectsRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var project in projects)
            {
                this.projectsRepository.Delete(project);
            }

            var reviews = this.customersReviesRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var review in reviews)
            {
                this.customersReviesRepository.Delete(review);
            }

            var pictures = this.profilePicturesRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var picture in pictures)
            {
                this.profilePicturesRepository.Delete(picture);
            }

            var comments = this.commentsRepository.All()
                .Where(u => u.UserId == id)
                .AsQueryable();

            foreach (var comment in comments)
            {
                this.commentsRepository.Delete(comment);
            }
        }

        private IEnumerable<SearchDataDto> GetReview(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.customersReviesRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    dataQuery = dataQuery
                    .Where(a => a.Id == id)
                    .AsQueryable();
                }
                else
                {
                    return null;
                }
            }
            else if (methodResult == SearchMethod.Username || methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                    .Where(a => a.User.UserName == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                .Select(d => new SearchDataDto
                {
                    Id = d.Id.ToString(),
                    Title = d.Appraiser.UserName,
                    Content = d.Comment,
                    Username = d.User.UserName,
                })
                .ToList();
        }

        private IEnumerable<SearchDataDto> GetUser(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.usersRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                dataQuery = dataQuery
                    .Where(a => a.Id == searchTerm)
                    .AsQueryable();
            }
            else if (methodResult == SearchMethod.Username || methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                    .Where(a => a.UserName == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                .Select(d => new SearchDataDto
                {
                    Id = d.Id,
                    Title = d.Email,
                    Content = $"{d.FirstName} {d.LastName}",
                    Username = d.UserName,
                })
                .ToList();
        }

        private IEnumerable<SearchDataDto> GetForumComment(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.commentsRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    dataQuery = dataQuery
                    .Where(a => a.Id == id)
                    .AsQueryable();
                }
                else
                {
                    return null;
                }
            }
            else if (methodResult == SearchMethod.Username)
            {
                dataQuery = dataQuery
                    .Where(a => a.User.UserName == searchTerm)
                   .AsQueryable();
            }
            else if (methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                   .Where(a => a.Discussion.Title == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                .Select(d => new SearchDataDto
                {
                    Id = d.Id.ToString(),
                    Title = d.Discussion.Title,
                    Content = d.Content,
                    Username = d.User.UserName,
                })
                .ToList();
        }

        private IEnumerable<SearchDataDto> GetForum(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.discussionsRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    dataQuery = dataQuery
                    .Where(a => a.Id == id)
                    .AsQueryable();
                }
                else
                {
                    return null;
                }
            }
            else if (methodResult == SearchMethod.Username)
            {
                dataQuery = dataQuery
                    .Where(a => a.User.UserName == searchTerm)
                   .AsQueryable();
            }
            else if (methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                   .Where(a => a.Title == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                .Select(d => new SearchDataDto
                {
                    Id = d.Id.ToString(),
                    Title = d.Title,
                    Content = d.Description,
                    Username = d.User.UserName,
                })
                .ToList();
        }

        private IEnumerable<SearchDataDto> GetJob(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.jobRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    dataQuery = dataQuery
                    .Where(a => a.Id == id)
                    .AsQueryable();
                }
                else
                {
                    return null;
                }
            }
            else if (methodResult == SearchMethod.Username)
            {
                dataQuery = dataQuery
                    .Where(a => a.User.UserName == searchTerm)
                   .AsQueryable();
            }
            else if (methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                   .Where(a => a.Title == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                .Select(d => new SearchDataDto
                {
                    Id = d.Id.ToString(),
                    Title = d.Title,
                    Content = d.JobBody,
                    Username = d.User.UserName,
                })
                .ToList();
        }

        private IEnumerable<SearchDataDto> GetBlog(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.blogRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    dataQuery = dataQuery
                    .Where(a => a.Id == id)
                    .AsQueryable();
                }
                else
                {
                    return null;
                }
            }
            else if (methodResult == SearchMethod.Username)
            {
                dataQuery = dataQuery
                    .Where(a => a.User.UserName == searchTerm)
                   .AsQueryable();
            }
            else if (methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                   .Where(a => a.Title == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                .Select(d => new SearchDataDto
                {
                    Id = d.Id.ToString(),
                    Title = d.Title,
                    Content = d.Body,
                    Username = d.User.UserName,
                })
                .ToList();
        }

        private IEnumerable<SearchDataDto> GetAdvertisement(SearchMethod methodResult, string searchTerm)
        {
            var dataQuery = this.advertisementsRepository.AllAsNoTracking().AsQueryable();

            if (methodResult == SearchMethod.Id)
            {
                if (int.TryParse(searchTerm, out int id))
                {
                    dataQuery = dataQuery
                    .Where(a => a.Id == id)
                    .AsQueryable();
                }
                else
                {
                    return null;
                }
            }
            else if (methodResult == SearchMethod.Username)
            {
                dataQuery = dataQuery
                    .Where(a => a.User.UserName == searchTerm)
                   .AsQueryable();
            }
            else if (methodResult == SearchMethod.Title)
            {
                dataQuery = dataQuery
                   .Where(a => a.Title == searchTerm)
                   .AsQueryable();
            }

            return dataQuery
                 .Select(d => new SearchDataDto
                 {
                     Id = d.Id.ToString(),
                     Title = d.Title,
                     Content = d.Description,
                     Username = d.User.UserName,
                 })
                 .ToList();
        }
    }
}
