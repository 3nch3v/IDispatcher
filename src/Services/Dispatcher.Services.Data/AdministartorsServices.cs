namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Enums;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Data.Dtos;

    public class AdministartorsServices : IAdministartorsServices
    {
        private readonly IDeletableEntityRepository<Advertisement> advertisementsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Job> jobRepository;
        private readonly IDeletableEntityRepository<Blog> blogRepository;
        private readonly IDeletableEntityRepository<Discussion> discussionsRepository;
        private readonly IDeletableEntityRepository<Comment> commentsRepository;
        private readonly IDeletableEntityRepository<CustomerReview> customersReviesRepository;

        public AdministartorsServices(
            IDeletableEntityRepository<Advertisement> advertisementsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Job> jobRepository,
            IDeletableEntityRepository<Blog> blogRepository,
            IDeletableEntityRepository<Discussion> discussionsRepository,
            IDeletableEntityRepository<Comment> commentsRepository,
            IDeletableEntityRepository<CustomerReview> customersReviesRepository)
        {
            this.advertisementsRepository = advertisementsRepository;
            this.usersRepository = usersRepository;
            this.jobRepository = jobRepository;
            this.blogRepository = blogRepository;
            this.discussionsRepository = discussionsRepository;
            this.commentsRepository = commentsRepository;
            this.customersReviesRepository = customersReviesRepository;
        }

        public AdminIndexDto GetIndexData()
        {
            var data = new AdminIndexDto
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

            return data;
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = this.usersRepository.All().FirstOrDefault(u => u.Id == id);
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

               data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id.ToString(),
                        Title = d.Title,
                        Content = d.Description,
                        Username = d.User.UserName,
                    })
                    .ToList();
            }
            else if (dataTypeResult == RepositoriesDataTypes.BlogPost)
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

                data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id.ToString(),
                        Title = d.Title,
                        Content = d.Body,
                        Username = d.User.UserName,
                    })
                    .ToList();
            }
            else if (dataTypeResult == RepositoriesDataTypes.Job)
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

                data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id.ToString(),
                        Title = d.Title,
                        Content = d.JobBody,
                        Username = d.User.UserName,
                    })
                    .ToList();
            }
            else if (dataTypeResult == RepositoriesDataTypes.ForumPost)
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

                data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id.ToString(),
                        Title = d.Title,
                        Content = d.Description,
                        Username = d.User.UserName,
                    })
                    .ToList();
            }
            else if (dataTypeResult == RepositoriesDataTypes.ForumComment)
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

                data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id.ToString(),
                        Title = d.Discussion.Title,
                        Content = d.Content,
                        Username = d.User.UserName,
                    })
                    .ToList();
            }
            else if (dataTypeResult == RepositoriesDataTypes.User)
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

                data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id,
                        Title = d.Email,
                        Content = $"{d.FirstName} {d.LastName}",
                        Username = d.UserName,
                    })
                    .ToList();
            }
            else if (dataTypeResult == RepositoriesDataTypes.Review)
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

                data = dataQuery
                    .Select(d => new SearchDataDto
                    {
                        Id = d.Id.ToString(),
                        Title = d.Appraiser.UserName,
                        Content = d.Comment,
                        Username = d.User.UserName,
                    })
                    .ToList();
            }

            var dataDto = new AdminRequestDataDto
            {
                Data = data,
                DataType = dataTypeResult.ToString(),
            };

            return dataDto;
        }
    }
}
