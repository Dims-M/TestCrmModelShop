using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    /// <summary>
    /// Форма добавления покупателя клиента
    /// </summary>
    public partial class CustomerForm : Form
    {
        
        /// <summary>
        /// Обьект для добавления человека этот обьект нового покупателя в Бд
        /// </summary>
        Customer Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

       
        private void Button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = textBox1.Text //В новь созданный класс. Добавляем имя клиента. И оно уходит в Бд
            };
         //  DialogResult
        }

        /// <summary>
        /// Кнопка выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //при закрузке формы
        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
