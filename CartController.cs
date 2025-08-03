using Microsoft.AspNetCore.Mvc;
using ShowSphere.Data; // ✅ Namespace for your DbContext
using ShowSphere.Models;
using System.Linq;

namespace ShowSphere.Controllers
{
    public class CartController : Controller
    {
        private readonly ShowSphereContext _context;

        public CartController(ShowSphereContext context)
        {
            _context = context;
        }

        // ✅ GET: /Cart
        public IActionResult Index()
        {
            var cartItems = _context.CartItems.ToList();
            return View(cartItems);
        }

        // ✅ POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(string title, decimal price, string category)
        {
            
            var existing = _context.CartItems.FirstOrDefault(c => c.Title == title);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                var newItem = new CartItem
                {
                    Title = title,
                    PricePerTicket = price,
                    Quantity = 1,
                    Category = category
                };
                _context.CartItems.Add(newItem);
            }

            _context.SaveChanges(); // ✅ Save to DB
            return RedirectToAction("Index");
        }

        // ✅ POST: /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(int id, string action)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                if (action == "increase") item.Quantity++;
                else if (action == "decrease" && item.Quantity > 1) item.Quantity--;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ✅ POST: /Cart/Remove
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // ✅ POST: /Cart/Clear
        [HttpPost]
        public IActionResult Clear()
        {
            var allItems = _context.CartItems.ToList();
            _context.CartItems.RemoveRange(allItems);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ✅ Proceed to Payment (with placeholder bookingId)
        public IActionResult ProceedToPayment()
        {
            int bookingId = 1; // Replace with actual booking logic
            return RedirectToAction("Create", "Payment", new { bookingId });
        }

        [Route("My Cart")]
        public IActionResult MyCart()
        {
            return RedirectToAction("Index");
        }
    }
}