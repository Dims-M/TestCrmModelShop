using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс описавает чек продажи
    /// </summary>
    public class Check
    {

        public int CustomerId { get; set; }

        /// <summary>
        /// Виртуальное Свойство для с внешним ключом. для связи между таблицами
        /// </summary>
        public virtual Customer Customer { get; set; }

        public int SellerId { set; get; }

        /// <summary>
        /// Связь с таблицой тродавца. Для создания всего обьекта со всеми свойствами
        /// </summary>
        public virtual Seller Seller { set; get; }

        /// <summary>
        /// время создания
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// виртуальное свойство для связи между таблицами
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return $"№{CustomerId} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }

    }
}
