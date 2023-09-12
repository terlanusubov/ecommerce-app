namespace EcommerceApp.MVC.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }

    }
}
