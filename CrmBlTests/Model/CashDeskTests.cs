using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
         

        // assert
        [TestMethod()]
        public void CashDeskTest()
        {
            //arrange
            //описываем покупателя 
            Customer customer1 = new Customer()
            {
                Name = "testuser",
                CustomerId = 1
            };

            Customer customer2 = new Customer()
            {
                Name = "Cufdsdff2",
                CustomerId = 2
            };

            //продавец
            Seller seller = new Seller()
            {
                Name = "тест Продован",
                SellerId = 1
            };

            Product product1 = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };

            Product product2 = new Product()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };

            Cart cart1 = new Cart(customer1);
            
            cart1.Add(product1);
            cart1.Add(product1); // добавление
            cart1.Add(product2);

            Cart cart2 = new Cart(customer2);
            
            cart2.Add(product1);
            cart2.Add(product1); // добавление
            cart2.Add(product2);

            var cashdesk = new CashDesk(1, seller);
            cashdesk.MaxQueueLenght = 10;
            cashdesk.Enqueue(cart1); // в очередь ставим корзину
            cashdesk.Enqueue(cart2); // в очередь ставим корзину

            var cart1ExpectedResul = 200;
            var cart2ExpectedResul = 200;

            //act //Это выполнение действия
            var cart1ActualResul = cashdesk.Dequeue();
            var cart2ActualResul = cashdesk.Dequeue();

            //assert
            Assert.AreEqual(cart1ExpectedResul, cart1ActualResul);
            Assert.AreEqual(cart2ExpectedResul, cart2ActualResul);
            Assert.AreEqual(6, product1.Count);
            Assert.AreEqual(18, product2.Count);

            // Assert.Fail();
        }

        //[TestMethod()]
        //public void EnqueueTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DequeueTest()
        //{
        //    Assert.Fail();
        //}
    }
}