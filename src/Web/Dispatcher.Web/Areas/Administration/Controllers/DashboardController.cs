namespace Dispatcher.Web.Areas.Administration.Controllers
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants.User;

    [Area("Administration")]
    [Authorize(Roles = AdministratorRole)]
    public class DashboardController : Controller
    {
        private readonly IAdministartorsServices administartorsServices;

        public DashboardController(IAdministartorsServices administartorsServices)
        {
            this.administartorsServices = administartorsServices;
        }

        public IActionResult Index()
        {
            var data = this.administartorsServices.GetIndexData();
            var indexData = AutoMapperConfig.MapperInstance.Map<IndexViewModel>(data);

            return this.View(indexData);
        }
    }
}
