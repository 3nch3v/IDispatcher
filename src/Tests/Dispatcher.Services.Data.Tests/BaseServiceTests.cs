namespace Dispatcher.Services.Data.Tests
{
    using System.Reflection;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.AdModels;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Dispatcher.Web.ViewModels.JobModels;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Dispatcher.Web.ViewModels.ProjectModels;
    using Microsoft.Extensions.Caching.Memory;

    public abstract class BaseServiceTests
    {
        public BaseServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        protected static string UserId => "7699db4d-e91c-4dcd-9672-7b88b8484930";

        protected static EfDeletableEntityRepository<Advertisement> AdsRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<AdvertisementType> AdTypesRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<Blog> BlogsRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<Comment> CommentsServiceRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<Discussion> ForumRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<Category> CategoriesRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<Job> JobsRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<ApplicationUser> UsersRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<CustomerReview> CustomersReviewsRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<ProfilePicture> PicturesRepository => new(PrepareDb().Result);

        protected static EfDeletableEntityRepository<Project> ProjectsRepository => new(PrepareDb().Result);

        protected static EfRepository<DiscussionVote> DiscussionsVotesRepository => new(PrepareDb().Result);

        protected static EfRepository<CommentVote> CommentVotesRepository => new(PrepareDb().Result);

        protected static IVotesService GetVotesService(
            IRepository<DiscussionVote> discussionsVotes = null,
            IRepository<CommentVote> commentsVotes = null)
        {
            var service = new VotesService(discussionsVotes, commentsVotes);

            return service;
        }

        protected static IAdsService GetAdService(
          IDeletableEntityRepository<Advertisement> advertisementRepository = null,
          IDeletableEntityRepository<AdvertisementType> adTypesRepository = null,
          IMemoryCache memoryCache = null)
        {
            var service = new AdsService(advertisementRepository, adTypesRepository, memoryCache);

            return service;
        }

        protected static IBlogsService GetBlogService(
            IDeletableEntityRepository<Blog> blogsRepository = null,
            IDeletableEntityRepository<BlogImage> blogImagesRepository = null,
            IFilesService filesService = null,
            IMemoryCache memoryCache = null)
        {
            var service = new BlogsService(blogsRepository, blogImagesRepository, filesService, memoryCache);

            return service;
        }

        protected static IForumsService GetForumService(
            IDeletableEntityRepository<Discussion> forumRepository = null,
            IDeletableEntityRepository<Category> categoriesRepository = null)
        {
            var service = new ForumsService(forumRepository, categoriesRepository);

            return service;
        }

        protected static IJobsService GetService(
            IDeletableEntityRepository<Job> jobRepository = null,
            IMemoryCache memoryCache = null)
        {
            var service = new JobsService(jobRepository, memoryCache);

            return service;
        }

        protected static IProfilesService GetService(
             IDeletableEntityRepository<ApplicationUser> usersRepository = null,
             IDeletableEntityRepository<CustomerReview> commentsRepository = null,
             IDeletableEntityRepository<ProfilePicture> profilePicturesRepository = null,
             IFilesService filesService = null)
        {
            var service = new ProfilesService(
                usersRepository,
                commentsRepository,
                profilePicturesRepository,
                filesService);

            return service;
        }

        protected static IAdministartorsServices GetService(
            IDeletableEntityRepository<Advertisement> advertisementsRepository = null,
            IDeletableEntityRepository<ApplicationUser> usersRepository = null,
            IDeletableEntityRepository<Job> jobRepository = null,
            IDeletableEntityRepository<Blog> blogRepository = null,
            IDeletableEntityRepository<Discussion> discussionsRepository = null,
            IDeletableEntityRepository<Comment> commentsRepository = null,
            IDeletableEntityRepository<CustomerReview> customersReviesRepository = null,
            IDeletableEntityRepository<ProfilePicture> profilePicturesRepository = null,
            IDeletableEntityRepository<Project> projectsRepository = null,
            IMemoryCache memoryCache = null)
        {
            var service = new AdministartorsServices(
                advertisementsRepository,
                usersRepository,
                jobRepository,
                blogRepository,
                discussionsRepository,
                commentsRepository,
                customersReviesRepository,
                profilePicturesRepository,
                projectsRepository,
                memoryCache);

            return service;
        }

        protected static IProjectsService GetService(IDeletableEntityRepository<Project> projectRepository)
        {
            var service = new ProjectsService(projectRepository);

            return service;
        }

        protected static ICommentsService GetCommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            var service = new CommentsService(commentsRepository);

            return service;
        }

        protected static async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;

            await data.Advertisements.AddRangeAsync(
                new Advertisement
                {
                    Id = 1,
                    AdvertisementTypeId = 1,
                    Title = "Test1",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    Compensation = "200",
                    PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Advertisement
                {
                    Id = 2,
                    AdvertisementTypeId = 2,
                    Title = "Test2",
                    Description = "2 We Work Remotely is a niche job board for remote jobseekers.",
                    Compensation = "100",
                    PictureUrl = "https://www.wpbeginner.com/fake.png",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Advertisement
                {
                    Id = 3,
                    AdvertisementTypeId = 3,
                    Title = "Test3",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    Compensation = "400",
                    PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                },
                new Advertisement
                {
                    Id = 4,
                    AdvertisementTypeId = 1,
                    Title = "Test4",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    Compensation = "300",
                    PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                });

            await data.AdvertisementTypes.AddRangeAsync(
                new AdvertisementType
                {
                    Id = 1,
                    Type = "Ad",
                },
                new AdvertisementType
                {
                    Id = 2,
                    Type = "Free",
                },
                new AdvertisementType
                {
                    Id = 3,
                    Type = "MoneyMaker",
                });

            await data.Blogs.AddRangeAsync(
                new Blog
                {
                    Id = 1,
                    Title = "Test1",
                    Body = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                    UserId = UserId,
                },
                new Blog
                {
                    Id = 2,
                    Title = "Test2",
                    Body = "2 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s2",
                    UserId = UserId,
                },
                new Blog
                {
                    Id = 3,
                    Title = "Test3",
                    Body = "3 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s3",
                    UserId = UserId,
                },
                new Blog
                {
                    Id = 4,
                    Title = "Test4",
                    Body = "4 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s4",
                    UserId = UserId,
                });

            await data.Comments.AddRangeAsync(
               new Comment
               {
                   Id = 1,
                   Content = "The best one",
                   UserId = UserId,
                   DiscussionId = 1,
               },
               new Comment
               {
                   Id = 2,
                   Content = "Super Dev",
                   UserId = UserId,
                   DiscussionId = 2,
               },
               new Comment
               {
                   Id = 3,
                   Content = "Number one! The best one",
                   UserId = UserId,
                   DiscussionId = 2,
               },
               new Comment
               {
                   Id = 4,
                   Content = "Super! The best one",
                   UserId = UserId,
                   DiscussionId = 3,
               });

            await data.Discussions.AddRangeAsync(
                new Discussion
                {
                    Id = 1,
                    Title = "Test1",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    UserId = UserId,
                    CategoryId = 1,
                    IsSolved = false,
                },
                new Discussion
                {
                    Id = 2,
                    Title = "Test2",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    UserId = UserId,
                    CategoryId = 3,
                    IsSolved = false,
                },
                new Discussion
                {
                    Id = 3,
                    Title = "Test3",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    UserId = UserId,
                    CategoryId = 1,
                    IsSolved = false,
                },
                new Discussion
                {
                    Id = 4,
                    Title = "Test4",
                    Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    UserId = UserId,
                    CategoryId = 1,
                    IsSolved = false,
                });

            await data.Categories.AddRangeAsync(
                new Category
                {
                    Id = 1,
                    Name = "News",
                },
                new Category
                {
                    Id = 2,
                    Name = "Education",
                },
                new Category
                {
                    Id = 3,
                    Name = "Software",
                });

            await data.DiscussionVotes.AddRangeAsync(
                new DiscussionVote
                {
                    Id = 1,
                    DiscussionId = 1,
                    Like = 1,
                    UserId = "4" + UserId,
                },
                new DiscussionVote
                {
                    Id = 2,
                    DiscussionId = 1,
                    Like = 1,
                    UserId = "2" + UserId,
                },
                new DiscussionVote
                {
                    Id = 3,
                    DiscussionId = 1,
                    Dislike = 1,
                    UserId = "3" + UserId,
                },
                new DiscussionVote
                {
                    Id = 4,
                    DiscussionId = 2,
                    Dislike = 1,
                    UserId = UserId,
                });

            await data.CommentVotes.AddRangeAsync(
                new CommentVote
                {
                    Id = 1,
                    CommentId = 1,
                    Like = 1,
                    UserId = "3" + UserId,
                },
                new CommentVote
                {
                    Id = 2,
                    CommentId = 1,
                    Like = 1,
                    UserId = "2" + UserId,
                },
                new CommentVote
                {
                    Id = 3,
                    CommentId = 2,
                    Dislike = 1,
                    UserId = UserId,
                },
                new CommentVote
                {
                    Id = 4,
                    CommentId = 2,
                    Dislike = 1,
                    UserId = "2" + UserId,
                });

            await data.Jobs.AddRangeAsync(
                new Job
                {
                    Id = 1,
                    Title = "Test1",
                    JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    CompanyName = "Mercedes",
                    Location = "Stuttgart, DE",
                    LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = UserId,
                },
                new Job
                {
                    Id = 2,
                    Title = "Test2",
                    JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    CompanyName = "Audi",
                    Location = "Ingolstadt, DE",
                    LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = UserId,
                },
                new Job
                {
                    Id = 3,
                    Title = "Test3",
                    JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    CompanyName = "BMW",
                    Location = "Munich, DE",
                    LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = UserId,
                },
                new Job
                {
                    Id = 4,
                    Title = "Test4",
                    JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    CompanyName = "Mercedes",
                    Location = "Stuttgart, DE",
                    LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                    UserId = UserId,
                });

            await data.AddRangeAsync(
                new ApplicationUser
                {
                    Id = UserId,
                    Email = "fake@fake.bg",
                    UserName = "fake",
                    PasswordHash = "123456",
                    ProfilePicture = new ProfilePicture
                    {
                        Id = "mypic",
                        Extension = ".jpg",
                    },
                },
                new ApplicationUser
                {
                    Id = "2" + UserId,
                    Email = "fake2@fake.bg",
                    UserName = "fake2",
                    PasswordHash = "123456",
                },
                new ApplicationUser
                {
                    Id = "3" + UserId,
                    Email = "fake3@fake.bg",
                    UserName = "fake3",
                    PasswordHash = "123456",
                },
                new ApplicationUser
                {
                    Id = "4" + UserId,
                    Email = "fake4@fake.bg",
                    UserName = "fake4",
                    PasswordHash = "123456",
                });

            await data.CustomersReviews.AddRangeAsync(
                new CustomerReview
                {
                    StarsCount = 5,
                    Comment = "The best one!",
                    UserId = UserId,
                    AppraiserId = "2" + UserId,
                },
                new CustomerReview
                {
                    StarsCount = 3,
                    Comment = "Not so good",
                    UserId = UserId,
                    AppraiserId = "2" + UserId,
                });

            await data.Projects.AddRangeAsync(
                new Project
               {
                   Id = 1,
                   Name = "Test1",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "Teacher",
                   UserId = UserId,
               },
                new Project
               {
                   Id = 2,
                   Name = "Test2",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "Boss",
                   UserId = UserId,
               },
                new Project
               {
                   Id = 3,
                   Name = "Test3",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "President",
                   UserId = UserId,
               },
                new Project
               {
                   Id = 4,
                   Name = "Test4",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "Taxi Driver",
                   UserId = UserId,
               });

            await data.SaveChangesAsync();

            return data;
        }

        protected static AdvertisementInputModel GetAdInputModel()
        {
            return new AdvertisementInputModel
            {
                AdvertisementTypeId = 2,
                Title = "Input",
                Description = "New We Work Remotely is a niche job board for remote jobseekers.",
                Compensation = "$400",
                PictureUrl = "https://www.wpbeginner.com/fake.png",
            };
        }

        protected static BlogInputModel GetBlogInputModel()
        {
            return new BlogInputModel
            {
                Title = "Input",
                Body = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                VideoLink = "https://www.youtube.com/watch?v=FMwz-YXAK_E&ab_channel=DeutschlernendurchH%C3%B6ren",
            };
        }

        protected PostInputViewModel GetCommentInputModel()
        {
            return new PostInputViewModel()
            {
                DiscussionId = 1,
                Content = "We Work Remotely.",
            };
        }

        protected DiscussionInputModel GetDiscussionInputModel()
        {
            return new DiscussionInputModel()
            {
                CategoryId = 3,
                Title = "Input",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
            };
        }

        protected JobInputModel GetJobInputModel()
        {
            return new JobInputModel()
            {
                Title = "Input",
                JobBody = "Edit We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "Bla-Bla",
                Location = "Sofia, Razsadnika",
                Contact = "fake@fake.bg",
            };
        }

        protected CommentInputModel GetReviewInputModel()
        {
            return new CommentInputModel
            {
                StarsCount = 5,
                Comment = "No comment!",
                UserId = UserId,
            };
        }

        protected ProjectInputmodel GetProjectInputModel()
        {
            return new ProjectInputmodel()
            {
                Name = "Input",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserRole = "Hamalin",
            };
        }
    }
}
