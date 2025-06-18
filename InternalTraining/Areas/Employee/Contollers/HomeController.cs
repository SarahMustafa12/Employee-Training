using InternalTraining.Unit_of_Work;
using Microsoft.AspNetCore.Mvc;

namespace InternalTraining.Areas.Employee.Contollers
{
    [Area("Employee")]

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }

    }
}
