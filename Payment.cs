using System.ComponentModel.DataAnnotations.Schema; // ✅ Add this
using Microsoft.EntityFrameworkCore; // ✅ For [Precision] attribute

namespace ShowSphere.Models
{
    public class Payment
    {
        public string? Fullname { get; set; }

        public int CardNumber { get; set; }

        public int CVV { get; set; }

        public DateOnly ExpiryDate { get; set; }
    }
}
