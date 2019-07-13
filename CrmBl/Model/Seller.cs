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
    public class Sell
    {
        public int SellId { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }

        public virtual Chek Chek { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<Chek> Cheks { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
