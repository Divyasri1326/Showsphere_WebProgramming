using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowSphere.Data;
using ShowSphere.Models;

namespace Showsphere.Controllers
{
    public class BookingController : Controller
    {


        private readonly ShowSphereContext _context;

        public BookingController(ShowSphereContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(booking);
        }

        public IActionResult Success()
        {
            return View(); // show a success message
        }


    }
}
