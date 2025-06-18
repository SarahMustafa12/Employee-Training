using InternalTraining.Models;
using InternalTraining.Unit_of_Work;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InternalTraining.Areas.AdminCompany.Controllers
{
    [Area("AdminCompany")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCourse()
        {
            var currentUser = userManager.GetUserId(User);
            var myCourses = unitOfWork.BookingCourses.Get(e=>e.CompanyUserId == currentUser,includes: [e=>e.Course, e=>e.Course.Chapters]).ToList();
            return View(myCourses);   
        }

        public IActionResult CourseDetails(int id)
        {
            var currentUser = userManager.GetUserId(User);
            var myCourse = unitOfWork.BookingCourses.Get(e => e.CompanyUserId == currentUser && e.CourseId == id, includes: [e => e.Course, e => e.Course.Chapters]).ToList();
            return View(myCourse);
        }
    }
}
