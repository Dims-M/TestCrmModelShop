using System;
using System.Collections.Generic;
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
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// виртуальное свойство для связи между таблицами
        /// </summary>
        public virtual ICollection<Seller> Sells { get; set; }

        /// <summary>
        /// Переопределенный тустринг. Возразает имя товара.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
