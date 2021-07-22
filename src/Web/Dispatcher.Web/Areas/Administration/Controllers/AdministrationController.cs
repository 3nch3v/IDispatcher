namespace Dispatcher.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.Administration;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants.User;

    [Area("Administration")]
    [Authorize(Roles = AdministratorRole)]
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
            var data = this.mapper.Map<SearchDataViewmodel>(dataDto);

            return this.View(data);
        }

        public IActionResult DeleteUser(string id)
        {
            this.administartorsServices.DeleteUserAsync(id);
            return this.RedirectToAction("Index", "Dashboard");
        }

        public IActionResult DeleteReview(int id)
        {
            this.administartorsServices.DeleteReviewAsync(id);
            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}
