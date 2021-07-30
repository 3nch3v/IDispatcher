namespace Dispatcher.Web.Controllers
{
    using System.Diagnostics;

    using Dispatcher.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code)
        {
            switch (code)
            {
                case 400: this.ViewBag.ErrorMessage = ErrorMessage.BadRequest; break;
                case 401: this.ViewBag.ErrorMessage = ErrorMessage.Unauthorised; break;
                case 403: this.ViewBag.ErrorMessage = ErrorMessage.Forbidden; break;
                case 404: this.ViewBag.ErrorMessage = ErrorMessage.NotFound; break;
                case 500: this.ViewBag.ErrorMessage = ErrorMessage.ServerError; break;
                case 502: this.ViewBag.ErrorMessage = ErrorMessage.BadGateway; break;
                case 505: this.ViewBag.ErrorMessage = ErrorMessage.HttpNotSupported; break;
                default:
                    this.ViewBag.ErrorMessage = ErrorMessage.NotFound;
                    break;
            }

            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
