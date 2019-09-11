using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс описывает корзину
    /// </summary>
   public class Cart : IEnumerable
    {
        //Товар в корзине 1:33:30
        public Customer Customer { get; set; }
        /// <summary>
        /// Словарь в каестве ключ идет сам продукт. В качестве значения идет количество товара
        /// </summary>
        Dictionary<Product, int> Products { get; set; }

        /// <summary>
        /// Конструктор. Который в качестве параметра получает покупателя
        /// </summary>
        /// <param name="customer"></param>
        public Cart(Customer customer)
        {
            Customer = customer; //В текуще свойство присваиваем полученное свойство
        }

        /// <summary>
        /// Метод для добавления покупок к корзину. О параметор сам продукт
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            if (Products.TryGetValue(product, out int count)) // если получаем из словаря товар и количество.
                // то дабовляем.
            {
                Products[product] = ++count; // присваеваем в словарь сам продукт + значение
            }
            else
            {
                Products.Add(product, 1); // просто добавляем в словарь
            }
        }

        /// <summary>
        /// Реализуем интерфейс  IEnumerable длч перебора всех товаров
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var protuct in Products.Keys) // получаем все ключи из словаря.. 
            {
                for (int i=0; i< Products[protuct]; i++) // 
                {
                    yield return protuct; //это ключевое слово, является итератором Оператор yield return используется для возврата каждого элемента по одному. 
                    //https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/yield?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DRU-RU%26k%3Dk(yield_CSharpKeyword)%3Bk(TargetFrameworkMoniker-.NETFramework%2CVersion%3Dv4.6.1)%3Bk(DevLang-csharp)%26rd%3Dtrue
                }
            }
        }
    }
}
