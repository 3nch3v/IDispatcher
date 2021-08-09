namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ForumModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ForumControllerTests
    {
        [Fact]
        public void CreateRouteShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap("/Forum/Create")
           .To<ForumController>(c => c
               .Create());

        [Fact]
        public void CreateRouteWithPostMethodShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap(request => request
                .WithPath("/Forum/Create")
                .WithMethod(HttpMethod.Post))
           .To<ForumController>(c => c
               .Create(new DiscussionInputModel()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int id)
           => MyRouting
           .Configuration()
           .ShouldMap($"/Forum/Edit/{id}")
           .To<ForumController>(c => c
               .Edit(id));

        [Theory]
        [InlineData(1)]
        public void EditRouteWithPostMethodShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
               .WithPath($"/Forum/Edit/{id}")
               .WithMethod(HttpMethod.Post))
          .To<ForumController>(c => c
              .Edit(new DiscussionInputModel(), id));

        [Theory]
        [InlineData(1)]
        public void DeleteRouteShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap($"/Forum/Delete/{id}")
          .To<ForumController>(c => c
              .Delete(id));

        [Theory]
        [InlineData(1)]
        public void DiscussionRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Forum/Discussion/{id}")
         .To<ForumController>(c => c
             .Discussion(id));

        [Theory]
        [InlineData("All", 1)]
        public void AllRouteShouldBeMapped(string category, int page)
        => MyRouting
        .Configuration()
        .ShouldMap($"/Forum/All?category={category}&page={page}")
        .To<ForumController>(c => c
            .All(category, page));

        [Theory]
        [InlineData(1)]
        public void SetToSolvedRouteShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap($"/Forum/SetToSolved/{id}")
          .To<ForumController>(c => c
              .SetToSolved(id));

        [Fact]
        public void CommentRouteShouldBeMapped()
         => MyRouting
         .Configuration()
         .ShouldMap($"/Forum/Comment")
         .To<ForumController>(c => c
             .Comment(new PostInputViewModel()));

        [Theory]
        [InlineData(1, 1)]
        public void DeletecommentRouteShouldBeMapped(int id, int discussionId)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Forum/DeleteComment/{id}?discussionId={discussionId}")
         .To<ForumController>(c => c
             .DeleteComment(id, discussionId));
    }
}
