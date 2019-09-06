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
    // https://www.youtube.com/watch?v=XHuUN1u8ZPE
  //  https://www.youtube.com/watch?v=XHuUN1u8ZPE&t=5184s
    public partial class Main : Form
    {
        //Cоединение с базой данных
        CrmContext db;  

        public Main()
        {
            InitializeComponent();
            db = new CrmContext(); // иницализация бд
        }

        //При нажатии на кнопку товар 
        private   void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cataloProduct = new Catalog<Product>(db.Products);
            cataloProduct.Show();
        }

        //Клин или нажатие на кнопку продавец
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cataloSeller = new Catalog<Seller>(db.Sellers); //Создание подключения к бд
            cataloSeller.Show();
        }

        //Кнопка покупатель
        private void CastomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers); //Создание подключения к бд
            catalogCustomer.Show();
        }

        //кнопка чек
        private void Check_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks); //Создание подключения к бд
            catalogCheck.Show();
        }

        //Кнопка добавления Товаров
        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //кнопка добавления покупателей
        private void CustomerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(); // Создаем форму.
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(customerForm.Customer); // Заполненый обьект(имя) полученный из формы  CustomerForm. Записываем в БД
                db.SaveChanges(); //сохраняем в бд
            }
           // customerForm.Show();
        }
    }
}
