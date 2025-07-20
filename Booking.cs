using System;

namespace ShowSphere.Models
{
    public class Booking
    {
        public string? Fullname { get; set; }
        public int ContactNumber { get; set; }
        public int NoOfTicket { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public decimal Amount { get; set; }
    }
}
