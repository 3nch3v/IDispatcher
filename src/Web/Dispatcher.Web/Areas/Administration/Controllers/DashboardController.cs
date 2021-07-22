namespace Dispatcher.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants.User;

    [Area("Administration")]
    [Authorize(Roles = AdministratorRole)]
    public class DashboardController : Controller
    {
        private readonly IAdministartorsServices administartorsServices;
        private readonly IMapper mapper;

        public DashboardController(
            IAdministartorsServices administartorsServices,
            IMapper mapper)
        {
            this.administartorsServices = administartorsServices;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var data = this.administartorsServices.GetIndexData();
            var indexData = this.mapper.Map<IndexViewModel>(data);

            return this.View(indexData);
        }
    }
}
