using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс отвечающий за подлючеие у БД
    /// </summary>
  public  class CrmContext : DbContext
    {
        //переопределенный конструктор
        public CrmContext(): base("CrmConntection") { }

        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sell> Sells { get; set; }


    }
}
