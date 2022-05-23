using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hakims_Livs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakims_Livs.Services.Tests
{
    [TestClass()]
    public class CartTests
    {      
        [TestMethod()]
        public async Task UpdateCartPriceTest()
        {
            List<double> test = new List<double>();

            async Task<double> UnitTest(List<double> shoppingList)
            {
                double totalCost = 0;

                foreach (var item in shoppingList)
                {
                    totalCost += item;
                }

                return Math.Round(totalCost, 1);
            }
            double product1 = 5;
            double product2 = 15;
            test.Add(product1);
            test.Add(product2);

            double sum = await (UnitTest(test));

            Assert.AreEqual(20, sum);
        }
        [TestMethod()]
        public async Task FutureDiscountTest()
        {
            List<double> test = new List<double>();

            async Task<double> UnitTest(List<double> shoppingList, double discount)
            {
                double totalCost = 0;
     

                foreach (var item in shoppingList)
                {
                    totalCost += item;
                }
                totalCost = totalCost * ((100 - discount) / 100);
                return Math.Round(totalCost, 1);
            }
            double product1 = 5;
            double product2 = 15;
            double discount = 20;
            test.Add(product1);
            test.Add(product2);
          
            double sum = await (UnitTest(test, discount));

            Assert.AreEqual(16, sum);
        }
    }
}
