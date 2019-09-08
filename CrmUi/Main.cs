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
    // 2 урок  1.07 minute
    // миграциия -Verbose
    //get-help NuGet
    //enable-migrations  -Force
    //add-migration "AddCompanyMigration"  -Force
    //update-database -Force или update-database -Verbose

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
            var cataloProduct = new Catalog<Product>(db.Products,db);
            cataloProduct.Show();
        }

        //Клин или нажатие на кнопку продавец
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cataloSeller = new Catalog<Seller>(db.Sellers,db); //Создание подключения к бд
            cataloSeller.Show();
        }

        //Кнопка покупатель
        private void CastomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers,db); //Создание подключения к бд
            catalogCustomer.Show();
        }

        //кнопка чек
        private void Check_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks,db); //Создание подключения к бд
            catalogCheck.Show();
        }

        //Кнопка добавления Товаров
        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerForm = new ProductForm(); // Создаем форму.
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(customerForm.Product); // Заполненый обьект(имя) полученный из формы  CustomerForm. Записываем в БД
                db.SaveChanges(); //сохраняем в бд

            }
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

        //Кнопка добавления продавца.
        private void SellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(form.Seller); // Заполненый обьект(имя) полученный из формы  CustomerForm. Записываем в БД
                db.SaveChanges(); //сохраняем в бд
            }
            //form.Show();

        }

        private void Main_Load(object sender, EventArgs e)
        {
           
        }

        //при закрытии но не доконца
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
          //    db.SaveChanges();
        }
    }
}
