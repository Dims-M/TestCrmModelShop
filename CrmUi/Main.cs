using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUi
{
    public partial class Main : Form
    {
        //Cоединение с базой данных
        CrmContext db;  
        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        //При нажатии на кнопку товар 
      
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cataloProduct = new Catalog<Product>(db.Products);
            cataloProduct.Show();
        }

        //Клин или нажатие на кнопку продавец
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
