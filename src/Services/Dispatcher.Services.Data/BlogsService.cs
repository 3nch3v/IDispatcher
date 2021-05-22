﻿namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.BlogModels;

    public class BlogsService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogsRepository;

        public BlogsService(IDeletableEntityRepository<Blog> blogsRepository)
        {
            this.blogsRepository = blogsRepository;
        }

        public int BlogPostsCount()
        {
            return this.blogsRepository.All().Count();
        }

        public async Task CreatPostAsync(BlogInputModel inputModel, string userId, string imgPath)
        {
            Blog post = AutoMapperConfig.MapperInstance.Map<Blog>(inputModel);
            post.UserId = userId;
            post.PictureFileName = inputModel.Picture.FileName;

            using var fileStream = new FileStream(imgPath, FileMode.Create);
            await inputModel.Picture.CopyToAsync(fileStream);

            await this.blogsRepository.AddAsync(post);
            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletePost = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);
            this.blogsRepository.Delete(deletePost);
            await this.blogsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount)
        {
            var posts = this.blogsRepository
                .AllAsNoTracking()
                .OrderByDescending(j => j.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return posts;
        }

        public T GetPost<T>(int id)
        {
            var post = this.blogsRepository.AllAsNoTracking()
                .Where(b => b.Id == id)
                .To<T>()
                .FirstOrDefault();

            return post;
        }

        public T RandomBlogPost<T>()
        {
            var blogPost = this.blogsRepository.AllAsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .To<T>()
                .FirstOrDefault();

            return blogPost;
        }

        public async Task UpdatePostAsync(int id, EditBlogPostInputmodel input)
        {
            var post = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);
            post.Title = input.Title;
            post.Body = input.Body;
            post.VideoLink = input.VideoLink;
            post.ModifiedOn = DateTime.UtcNow;

            await this.blogsRepository.SaveChangesAsync();
        }
    }
}
