using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Showsphere;
using Showsphere.Models;
using System.Linq;

namespace Showsphere.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext? _context;
        

        [HttpPost]

        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => u.username == model.Username && u.password == model.Password);
                if (user != null)
                {
                    ViewBag.Message = "Login Successful";
                }
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Signup(User model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Sign up successful";
                ModelState.Clear();
            }
            return View(model);
        }
    }
}
