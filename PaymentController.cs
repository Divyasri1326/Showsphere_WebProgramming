using Microsoft.AspNetCore.Mvc;
using ShowSphere.Data;
using ShowSphere.Models;



namespace Showsphere.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ShowSphereContext _context;

        public PaymentController(ShowSphereContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                // Simulate payment processing
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(payment);
        }

        public IActionResult Success()
        {
            return View();
        }
    }

}
