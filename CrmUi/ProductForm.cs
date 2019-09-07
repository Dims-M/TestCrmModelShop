using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    /// <summary>
    /// Форма добавления продавца  
    /// </summary>
    public partial class ProductForm : Form
    {
        
        /// <summary>
        /// Обьект для товара в Бд
        /// </summary>
      public Product Product { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

       
        private void Button1_Click(object sender, EventArgs e)
        {
            //Проверка имени на пустоту
            if (textBox1.Text == "")
            {
                MessageBox.Show("Имя товара нее заполненно0000");
                DialogResult = DialogResult.Cancel; //В диалого присваиваем отмену. И не записывае в Бд
            }

           else
            {
                Product = new Product()
                {
                    Name = textBox1.Text, //В новь созданный класс. Добавляем имя клиента. И оно уходит в Бд
                    Price = numericUpDown1.Value,
                    Count = (int)numericUpDown2.Value
                };

            //  DialogResult
            label2.Visible = true;
            label2.Text = "Новый товар добавлен";
            Update(); //обновление главной формы
            Thread.Sleep(500); // ожидание 0.5 сек 
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //при закрузке формы
        private void CustomerForm_Load(object sender, EventArgs e)
        {
             
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
