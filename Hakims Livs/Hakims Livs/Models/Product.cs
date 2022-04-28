namespace Hakims_Livs.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Category CategoryName { get; set; }      
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
 
    }

    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
