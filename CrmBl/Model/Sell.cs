using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс описывающий факт продажи
    /// </summary>
    public class Sell
    {
        public int SellId { get; set; }
        public int ChekId { get; set; }
        public int ProductId { get; set; }
        
        public virtual Check Check { get; set; }
        public virtual Product Product { get; set; }

    }
}
