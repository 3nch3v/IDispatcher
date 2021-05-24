namespace Dispatcher.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomersReviewsController : Controller
    {
        public CustomersReviewsController()
        {
        }

        public IActionResult AllCustomersReviews(string id)
        {
            return this.View();
        }
    }
}
