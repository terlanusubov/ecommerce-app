using Microsoft.AspNetCore.Http.HttpResults;

namespace EcommerceApp.MVC.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Expired { get; set; }
        public DateTime Created  {get;set;}
        public DateTime Updated  {get;set; }

        public int CartStatusId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<CartDetail>  CartDetails { get; set; }
    }
}
