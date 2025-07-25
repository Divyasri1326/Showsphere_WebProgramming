using System; 
using Microsoft.EntityFrameworkCore; 

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
