using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class Catalog<T> : Form
         where T : class
    {
        CrmContext db; //для свзи с БД
        DbSet<T> set;  // контекст для работы и подключение к бд 

        ///
        public Catalog(DbSet<T> set, CrmContext db) // в качестве параметра указываем подключение к дазе данных
        {
            InitializeComponent();
            this.db = db; // в теущую переменую присваиваем входящую экземпляр db
            this.set = set; // работа с БДЫ
            set.Load(); // закрузка данных из бд. Ленивая подгузка
            dataGridView.DataSource = set.Local.ToBindingList(); // Соединение с БД и получам закешированые данные из БД
        }

         
        //дествия при загрузке формы
        private void Catalog_Load(object sender, EventArgs e)
        {
            dataGridView.Refresh(); // перерисовка всех элементов 
        }

        //поле дата грид
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Кнопка Выход с формы
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Кнопка добавить на форме коталого
        private void Button1_Click(object sender, EventArgs e)
        {
            //Проверка на входной тип
            if (typeof(T) == typeof(Product))
            {

            }
            else if (typeof(T) == typeof(Seller))
            {

            }

            else if (typeof(T) == typeof(Customer))
            {
            }
        }

        //кнопка изменить, редактирование
        private void Button3_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value; // получам выбранный в таблице id строки

            if (typeof(T) == typeof(Product)) // если открывеется форма для работы с товарами(Product)
            {
               var product =  set.Find(id) as Product; //  Находит сущность с заданными значениями первичного ключа. Пприводим к нужному классу c

                if (product != null)
                {
                    var form = new ProductForm(product); //cоздаем форму

                    if (form.ShowDialog() == DialogResult.OK) // если на форме нажата кнопка ОК
                    {
                        //db.Products.Add(item.Product); //не добавить а обновить!!
                        product = form.Product;
                        db.SaveChanges();
                    }
                   // item.Show(); // показываем форму
                }

            }

            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller; //  Находит сущность с заданными значениями первичного ключа. Пприводим к нужному классу c

                if (seller != null)
                {
                    var form = new SellerForm(seller); //cоздаем форму

                    if (form.ShowDialog() == DialogResult.OK) // если на форме нажата кнопка ОК
                    {
                        //db.Products.Add(item.Product); //не добавить а обновить!!
                        seller = form.Seller;
                        db.SaveChanges();
                    }
                   
                }
            }

            else if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product; //  Находит сущность с заданными значениями первичного ключа. Пприводим к нужному классу c

                if (product != null)
                {
                    var form = new ProductForm(product); //cоздаем форму

                    if (form.ShowDialog() == DialogResult.OK) // если на форме нажата кнопка ОК
                    {
                        //db.Products.Add(item.Product); //не добавить а обновить!!
                        product = form.Product;
                        db.SaveChanges();
                    }

                }
            }
        }

        //Кнопка удалить
        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Update(int id, Form form)
        {
                    //var form = new ProductForm(item ); //cоздаем форму
                    //if (form.ShowDialog() == DialogResult.OK) // если на форме нажата кнопка ОК
                    //{
                 
                    //     item = form.Product;
                    //     db.SaveChanges();
                    //     dataGridView.Update();
                    //}
                   
                }
        
    }
}
