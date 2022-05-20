namespace Hakims_Livs.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Customer User { get; set; }
        public List<Product> Products { get; set; }
        public bool IsDone { get; set; }
        public DateTime TimePlaced { get; set; }
        public List<Quantity> Quantity { get; set; }
    }
}
