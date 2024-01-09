using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicDataBase.Controllers
{
    public class MonsterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
