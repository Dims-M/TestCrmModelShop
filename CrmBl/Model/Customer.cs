using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс описывает покупателя
    /// </summary>
   public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        //Колекция для коректной связи между 2 сущностями. 
        public virtual ICollection<Check> Cheks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
