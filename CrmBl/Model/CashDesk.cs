using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    /// <summary>
    /// Класс опысывает кассу.    
    /// </summary>
    class CashDesk
    {
         
        /// <summary>
        /// Продавец. Кто осуществляет текущую продажу
        /// </summary>
        public Seller Seller { set; get; }
        /// <summary>
        /// Номер кассы
        /// </summary>
        public int Number { get; set; }
        public int MaxQueueLenght { get; set; } //Максимальная длина очереди
        public int ExitCustomer { get; set; } //Счетчик длины очереди. Если больше маскималки. Продажа не происходит

        /// <summary>
        /// Очередь покупателей. В качестве параметров использем корзины покупок. Так как там указан контретный покупатель!!!
        /// </summary>
        public Queue<Cart> Queue { set; get; }

        //конструктор
        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>(); // иницализируем очередь
        }

        /// <summary>
        /// Постановка в очередь. Для совершения покупи и провекрка на очередь
        /// </summary>
        /// <param name="cart"></param>
        public void Enqueue(Cart cart)
        {
            // если меньше максимольной размера очереди 
            if (Queue.Count <= MaxQueueLenght)  
            {
                Queue.Enqueue(cart); //Добавляем в конец очереди.
            }

            else
            {
                ExitCustomer++; // добавляем в интовый "список" непопавщик в очередь
            }

        }

        /// <summary>
        /// Извлекаем покупателя из очереди
        /// </summary>
        public void Dequeue()
        {

        }

    }
}
