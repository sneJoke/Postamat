using System;
using System.Collections.Generic;
using System.Text;
using PostaMate.Core.Types;

namespace PostaMate.Core.Domain
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Номер заказа 
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Статус заказа
        /// </summary>
        public StatusOrder StatusOrder { get; set; }
        
        /// <summary>
        /// Состав заказа: массив товаров
        /// </summary>
        public IEnumerable<string> Blocks { get; set; }
        
        /// <summary>
        /// Стоимость заказа
        /// </summary>
        public decimal Cost { get; set; }
        
        /// <summary>
        /// Номер постамата доставки
        /// </summary>
        public int PostamatNumber { get; set; }
        
        /// <summary>
        /// Номер телефона получателя
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// ФИО получателя
        /// </summary>
        public string Recipient { get; set; }

        public Order()
        {
            Blocks = new List<string>();
        }
    }
}
