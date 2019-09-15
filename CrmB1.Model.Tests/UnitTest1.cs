using System;
using System.Collections.Generic;
using CrmBl.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrmB1.Model.Tests
{
    /// <summary>
    /// Модульные тесты
    /// </summary>
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            //Патерн шаблон

            //arrange //ЭТО бьявления. Где мы создаем входные и итоговые данные
            var customer = new Customer()
            {
                CustomerId = 1,
                Name = "testuser",
            };

            var product1 = new Product()
            {
                ProductId =1,
                Name ="pr1",
                Price = 100,
                Count =10
            };

            var product2 = new Product()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };

            var cart = new Cart(customer);
             
            var expectedResult = new List<Product>()
            {
                product1, product1, product2
            };

            //act //Это выполнение действия
            cart.Add(product1);
            cart.Add(product1); // добавление
            cart.Add(product2);

            var cartResult = cart.GetAll(); // получение данных из метода для сравнения

            //assert //Сравнение результотов ожидаемого кода и  полученного в момент работы
            // сравниваем количество.
            Assert.AreEqual(expectedResult.Count, cartResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]); //сравнение
            }
        }
    }
}
