using CURD.Data;
using CURD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CURD.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Login));

        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(User u)
        {

            var checkUser = _context.Users.Where(User => User.UserName == u.UserName && User.Password == u.Password);
            if (checkUser.Any())
            {
                return RedirectToAction(nameof(Result));
            }
            ViewBag.Error = "invalid userName / Password";
            return View(u);
        }

        public IActionResult Result()
        {
            var InActiveUsers = _context.Users.Where(u => !u.IsActive).ToList();
            return View(InActiveUsers);
        }


        public IActionResult RemoveNotActive(Guid userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.IsActive = true;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Result));
        }


    }
}
