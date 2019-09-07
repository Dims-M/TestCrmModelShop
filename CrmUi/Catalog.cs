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
        
        ///
        public Catalog(DbSet<T> set)
        {
            InitializeComponent();
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
    }
}
