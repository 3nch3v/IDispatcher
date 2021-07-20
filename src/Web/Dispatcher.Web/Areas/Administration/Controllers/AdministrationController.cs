namespace Dispatcher.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using AutoMapper;
    using Dispatcher.Common;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.Administration;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AdministrationController : Controller
    {
        private readonly IAdministartorsServices administartorsServices;
        private readonly IMapper mapper;

        public AdministrationController(
            IAdministartorsServices administartorsServices,
            IMapper mapper)
        {
            this.administartorsServices = administartorsServices;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult GetData(SearchInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Dashboard");
            }

            var dataDto = this.administartorsServices.GetData(input.SearchData, input.SearchMethod, input.SearchTerm);

            if (dataDto == null)
            {
                return this.RedirectToAction("Index", "Dashboard");
            }

            var data = dataDto
                .Select(d => this.mapper.Map<DataViewModel>(d))
                .ToList();

            var dataResult = new SearchDataViewmodel { Data = data };

            return this.View(dataResult);
        }
    }
}
