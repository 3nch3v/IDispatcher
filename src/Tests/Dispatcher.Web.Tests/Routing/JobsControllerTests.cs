namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.JobModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class JobsControllerTests
    {
        [Fact]
        public void CreateRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Jobs/Create")
            .To<JobsController>(c => c
                .Create());

        [Fact]
        public void CreateRouteWithPostMethodShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap(request => request
                .WithPath("/Jobs/Create")
                .WithMethod(HttpMethod.Post))
           .To<JobsController>(c => c
               .Create(new JobInputModel()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int id)
           => MyRouting
           .Configuration()
           .ShouldMap($"/Jobs/Edit/{id}")
           .To<JobsController>(c => c
               .Edit(id));

        [Theory]
        [InlineData(1)]
        public void EditRouteWithPostMethodShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
               .WithPath($"/Jobs/Edit/{id}")
               .WithMethod(HttpMethod.Post))
          .To<JobsController>(c => c
              .Edit(new EditJobInputModel { Id = id }));

        [Theory]
        [InlineData(1)]
        public void DeleteRouteShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap($"/Jobs/Delete/{id}")
          .To<JobsController>(c => c
              .Delete(id));

        [Theory]
        [InlineData(1)]
        public void JobRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Jobs/Job/{id}")
         .To<JobsController>(c => c
             .Job(id));

        [Theory]
        [InlineData(1)]
        public void AllRouteShouldBeMapped(int page)
        => MyRouting
        .Configuration()
        .ShouldMap($"/Jobs/All?page={page}")
        .To<JobsController>(c => c
            .All(page));

        [Theory]
        [InlineData("it", 1)]
        public void SearchRouteShouldBeMapped(string keywords, int page)
         => MyRouting
             .Configuration()
             .ShouldMap($"/Jobs/Search?page={page}&keyWords={keywords}")
             .To<JobsController>(c => c
                 .Search(keywords, page));
    }
}
