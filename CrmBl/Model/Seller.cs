using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс описывающий продавца
    /// </summary>
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Chek> Cheks { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
