﻿using Hakims_Livs.Models;

namespace Hakims_Livs.Data
{
    public class DatabaseActions
    {
        public static async Task LoadExampleData(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var cat = new Category
                {
                    Name = "Frukt"
                };
                var testprodukt = new Product
                {
                    Name = "Apple",
                    CategoryName = cat,
                    ProductCode = "F01",
                    Description = "Juicy, sweet and delicious apple",
                    Image = "IMG_URL_HÄR",
                    Price = 5
                };
                context.Products.Add(testprodukt);
                context.SaveChanges();
            }
        }
    }
}
