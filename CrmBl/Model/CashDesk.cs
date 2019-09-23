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
  public  class CashDesk
    {
        //Обьект для работв с бд
        CrmContext db = new CrmContext();
         
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
        public bool IsModel { get; set; } //режим выбора работы. Если тру. То не сохраняется в БД

        /// <summary>
        /// Очередь покупателей. В качестве параметров использем корзины покупок. Так как там указан контретный покупатель!!!
        /// </summary>
        public Queue<Cart> Queue { set; get; }

        //конструктор
        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            IsModel = true;
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
                //для статистики
                ExitCustomer++; // добавляем в интовый "список" не попавших в очередь
            }

        }

        /// <summary>
        /// Извлекаем покупателя из очереди
        /// </summary>
        public decimal Dequeue()
        {
            //Сумма продажи
            decimal summ = 0;
            var card = Queue.Dequeue();

            if (card != null)
            {
                var check = new Check() // создаем экземпляр чека.
                {
                    CheckId = Seller.SellerId, //приваеваем id 
                    Seller = Seller, // присваеыаем текущего продавца
                    Customer = card.Customer, // присваеваем текущего покупателя
                    CustomerId = card.Customer.CustomerId,
                    Created = DateTime.Now //дата создание чека
                };

                //проверка на запись в бд
                if (!IsModel)
                {
                    db.Checks.Add(check); // добавляем новую запись в бд
                    db.SaveChanges(); // cохраняем в бд
                }

                else
                {
                    check.CheckId = 0;
                }

                //вспомогательный список продаж
                var sells = new List<Sell>();


                //перебор записи продаж
                foreach (Product product in card)
                {
                    //Прооверка на наличие на складк
                    if (product.Count > 0)
                    {


                        //создаем обьект продажи
                        var sell = new Sell()
                        {
                            ChekId = check.CheckId, // Примваевам переменым данные. 
                            Check = check, // чеки продаж
                            ProductId = product.ProductId, // id продуктов
                            Product = product
                        };

                        //уменьшать количество товара
                        product.Count--;
                        summ = product.Price; // запысываем сумму продажи
                        sells.Add(sell); //записывакм текущую продажу в лист 

                        //Проверка на текущий статус 
                        if (!IsModel)
                        {
                            db.Sells.Add(sell); // добавляем в базу данных
                        }

                    }
                    else
                    {
                        //Товара нет в наличии
                    }
                } //конец цикла

                if (!IsModel)
                {
                    db.SaveChanges(); // сохранение в бд
                }
            }

            return summ;
        }

    }
}
