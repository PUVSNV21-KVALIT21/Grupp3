namespace Hakims_Livs.Models
{
    public class Quantity
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
