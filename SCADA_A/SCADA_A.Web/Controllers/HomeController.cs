using Microsoft.AspNetCore.Mvc;

namespace SCADA_A.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
