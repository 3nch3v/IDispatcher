namespace Dispatcher.Web.Areas.Administration.Controllers
{
    using Dispatcher.Common;
    using Dispatcher.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
