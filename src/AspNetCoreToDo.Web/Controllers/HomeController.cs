namespace AspNetCoreToDo.Web.Controllers
{
    using AspNetCoreToDo.Web.ViewModels.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index(TasksIndexViewModelQuery query)
        {
            return RedirectToAction("Index", "Tasks");
        }
   }
}