using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс оописывающий товар
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// виртуальное свойство для связи между таблицами
        /// </summary>
      //  public virtual ICollection<Seller> Selles { get; set; }

        /// <summary>
        /// Переопределенный тустринг. Возразает имя товара.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Переопределенный метод GetHashCode который возращает id продукта
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ProductId;
        }

        public override bool Equals(object obj)
        {
            if(obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }

            return false;
        }
    }
}
