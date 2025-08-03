using System.ComponentModel.DataAnnotations.Schema;
namespace ShowSphere.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal PricePerTicket { get; set; }
        public int Quantity { get; set; }
        public decimal Total => PricePerTicket * Quantity;

        public string? Category { get; set; }
        
    }


}


    

