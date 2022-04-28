namespace Hakims_Livs.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }      
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public enum ProductCategory
        {
            Frukt,
            Snacks,
            Drycker,
            Mejeri,
            Skafferi
        }
    }
}
