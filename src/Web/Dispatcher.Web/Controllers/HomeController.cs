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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code)
        {
            this.ViewBag.ErrorMessage = this.GetMessage(code);
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        private string GetMessage(int code)
        {
            return code switch
            {
                400 => ErrorMessage.BadRequest,
                401 => ErrorMessage.Unauthorised,
                403 => ErrorMessage.Forbidden,
                404 => ErrorMessage.NotFound,
                500 => ErrorMessage.ServerError,
                502 => ErrorMessage.BadGateway,
                505 => ErrorMessage.HttpNotSupported,
                _ => this.ViewBag.ErrorMessage = ErrorMessage.NotFound,
            };
        }
    }
}
