using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
      
     //  public int Id { get; set; } //*
      
        public int SellerId { get; set; }

        public string Name { get; set; }

     //  public int ProductId { get; set; } //*

      //  public virtual Check Chek { get; set; } //*
      //  public virtual Product Product { get; set; } //*

        public virtual ICollection<Check> Cheks { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
