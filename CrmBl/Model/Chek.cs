using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        public int Id { get; set; }
        public int CustomerID { get; set; }

        /// <summary>
        /// Виртуальное Свойство для с внешним ключом. для связи между таблицами
        /// </summary>
        public virtual Customer Customer { get; set; }

        public int SellergId { set; get; }

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
            return $"№{CustomerID} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }

    }
}
