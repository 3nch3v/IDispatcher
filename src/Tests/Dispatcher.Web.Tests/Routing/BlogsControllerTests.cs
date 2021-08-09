namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.BlogModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class BlogsControllerTests
    {
        [Fact]
        public void CreateRouteShouldBeMapped()
          => MyRouting
          .Configuration()
          .ShouldMap("/Blogs/Create")
          .To<BlogsController>(c => c
              .Create());

        [Fact]
        public void CreateRouteWithPostMethodShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap(request => request
                .WithPath("/Blogs/Create")
                .WithMethod(HttpMethod.Post))
           .To<BlogsController>(c => c
               .Create(new BlogInputModel()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int id)
           => MyRouting
           .Configuration()
           .ShouldMap($"/Blogs/Edit/{id}")
           .To<BlogsController>(c => c
               .Edit(id));

        [Theory]
        [InlineData(1)]
        public void EditRouteWithPostMethodShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
               .WithPath($"/Blogs/Edit/{id}")
               .WithMethod(HttpMethod.Post))
          .To<BlogsController>(c => c
              .Edit(new EditBlogPostInputmodel() { Id = id }));

        [Theory]
        [InlineData(1)]
        public void DeleteRouteShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap($"/Blogs/Delete/{id}")
          .To<BlogsController>(c => c
              .Delete(id));

        [Theory]
        [InlineData(1)]
        public void PostRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Blogs/Post/{id}")
         .To<BlogsController>(c => c
             .Post(id));

        [Theory]
        [InlineData(1)]
        public void AllRouteShouldBeMapped(int page)
        => MyRouting
        .Configuration()
        .ShouldMap($"/Blogs/All?page={page}")
        .To<BlogsController>(c => c
            .All(page));
    }
}
