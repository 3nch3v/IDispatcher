namespace Dispatcher.Web.Tests
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Web.ViewModels.AdModels;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Dispatcher.Web.ViewModels.JobModels;
    using Dispatcher.Web.ViewModels.ProjectModels;

    public static class Data
    {
        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

        public static ApplicationUser GetUser()
        {
            return new ApplicationUser
            {
                Id = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                UserName = "Ivan_Dev",
                Email = "ivan@fake.bg",
                PasswordHash = "sdasd324olkk34dff",
            };
        }

        public static ApplicationUser GetUserNotOwner()
        {
            return new ApplicationUser
            {
                Id = "TestId",
                UserName = "Ivan",
                Email = "ivan@fake.bg",
                PasswordHash = "sdasd324olkk34dff",
            };
        }

        public static CustomerReview GetReview()
        {
            return new CustomerReview
            {
                Id = 1,
                AppraiserId = "testId",
                Comment = "Passssttt",
                StarsCount = 3,
                UserId = UserId,
            };
        }

        public static AdvertisementType GetAdType()
        {
            return new AdvertisementType { Id = 1, Type = "TestType" };
        }

        public static Advertisement GetAd()
        {
            return new Advertisement
            {
                Id = 1,
                AdvertisementTypeId = 1,
                Title = "Looking for Developers",
                Description = "Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years",
                Compensation = "6000 EUR",
                UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
            };
        }

        public static AdvertisementInputModel GetAdValidInputModel()
        {
            return new AdvertisementInputModel
            {
                AdvertisementTypeId = 1,
                Title = "My fake Ad",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Compensation = "100 marki",
            };
        }

        public static BlogInputModel GetValidBlogInputModel()
        {
            return new BlogInputModel { Title = "Test Blog", Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " };
        }

        public static EditBlogPostInputmodel GetEditBlogInputmodel()
        {
            return new EditBlogPostInputmodel { Id = 1, Title = "Test Blog", Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " };
        }

        public static Blog GetBlog()
        {
            return new Blog
            {
                Id = 1,
                Title = "Looking for Developers",
                Body = "Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years",
                UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
            };
        }

        public static IEnumerable<CustomerReview> GetComments()
        {
            return new List<CustomerReview>
            {
                new CustomerReview
                {
                    Id = 1,
                    AppraiserId = "fakeId",
                    UserId = UserId,
                    StarsCount = 5,
                    Comment = "ok",
                },
                new CustomerReview
                {
                    Id = 2,
                    AppraiserId = "fakeId",
                    UserId = UserId,
                    StarsCount = 3,
                    Comment = "super",
                },
                new CustomerReview
                {
                    Id = 3,
                    AppraiserId = "fakeId",
                    UserId = UserId,
                    StarsCount = 1,
                    Comment = "top",
                },
            };
        }

        public static IEnumerable<Category> GetForumCategory()
        {
            return new Category[]
            {
                new Category { Id = 1, Name = "Test" },
                new Category { Id = 2, Name = "Test2" },
                new Category { Id = 3, Name = "Test3" },
            };
        }

        public static DiscussionInputModel GetValidDiscussionInput()
        {
            return new DiscussionInputModel()
            {
                Title = "Bla bla post",
                CategoryId = 1,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries",
            };
        }

        public static Discussion GetDiscussion()
        {
            return new Discussion
            {
                Id = 1,
                CategoryId = 1,
                Title = "Looking for Developers",
                Description = "Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years",
                UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                IsSolved = true,
            };
        }

        public static Comment GetComment()
        {
            return new Comment
            {
                Id = 1,
                Content = "Bla bla comment",
                DiscussionId = 1,
                UserId = UserId,
            };
        }

        public static JobInputModel GetValidJobInputModel()
        {
            return new JobInputModel
            {
                Title = "Test",
                JobBody = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CompanyName = "Hacker GmbH",
                Location = "Paris",
                Contact = "0121490458342",
            };
        }

        public static EditJobInputModel GetJobEditInputModel()
        {
            return new EditJobInputModel
            {
                Id = 1,
                Title = "Test",
                JobBody = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CompanyName = "Hacker GmbH",
                Location = "Paris",
                Contact = "0121490458342",
            };
        }

        public static Job GetJob()
        {
            return new Job
            {
                Id = 1,
                Title = "Test",
                JobBody = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CompanyName = "Hacker GmbH",
                Location = "Paris",
                Contact = "0121490458342",
                UserId = UserId,
            };
        }

        public static ProjectInputmodel GetValidProjectInputModel()
        {
            return new ProjectInputmodel
            {
                Name = "Test Prject",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                UserRole = "Boss",
            };
        }

        public static Project GetProject()
        {
            return new Project
            {
                Id = 1,
                Name = "Test Prject",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                UserRole = "Boss",
                UserId = UserId,
            };
        }

        public static ProjectInputmodel GetProjectInput()
        {
            return new ProjectInputmodel
            {
                Name = "Test Prject",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                UserRole = "Boss",
            };
        }
    }
}
