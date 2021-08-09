namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ProjectModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProjectsControllerTests
    {
        [Fact]
        public void AddRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Projects/Add")
            .To<ProjectsController>(c => c
                .Add());

        [Fact]
        public void AddRouteWithPostMethodShouldBeMapped()
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
               .WithPath("/Projects/Add")
               .WithMethod(HttpMethod.Post))
          .To<ProjectsController>(c => c
              .Add(new ProjectInputmodel()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Projects/Edit/{id}")
         .To<ProjectsController>(c => c
             .Edit(id));

        [Theory]
        [InlineData(1)]
        public void EditRouteWithPostMethodShouldBeMapped(int id)
       => MyRouting
       .Configuration()
       .ShouldMap(request => request
            .WithPath($"/Projects/Edit/{id}")
            .WithMethod(HttpMethod.Post))
       .To<ProjectsController>(c => c
           .Edit(id, new ProjectInputmodel()));

        [Theory]
        [InlineData(1)]
        public void DeleteRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Projects/Delete/{id}")
         .To<ProjectsController>(c => c
             .Delete(id));

        [Theory]
        [InlineData(1)]
        public void ProjectRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Projects/Project/{id}")
         .To<ProjectsController>(c => c
             .Project(id));
    }
}
