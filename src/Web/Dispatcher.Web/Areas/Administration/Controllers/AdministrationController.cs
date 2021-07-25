namespace Dispatcher.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
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

        public AdministrationController(IAdministartorsServices administartorsServices)
        {
            this.administartorsServices = administartorsServices;
        }

        [HttpPost]
        public IActionResult GetData(SearchInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Dashboard");
            }

            var dataDto = this.administartorsServices.GetData(input.SearchData, input.SearchMethod, input.SearchTerm);
            var data = AutoMapperConfig.MapperInstance.Map<SearchDataViewmodel>(dataDto);

            return this.View(data);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await this.administartorsServices.DeleteUserAsync(id);
            return this.RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> DeleteReview(int id)
        {
            await this.administartorsServices.DeleteReviewAsync(id);
            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}
