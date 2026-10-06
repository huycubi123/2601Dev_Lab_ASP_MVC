using Microsoft.AspNetCore.Mvc;

namespace Lab08_Layout.Areas.Admins.Views.Dashboard
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
