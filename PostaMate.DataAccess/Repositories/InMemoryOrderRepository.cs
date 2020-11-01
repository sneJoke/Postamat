using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostaMate.Core.Domain;

namespace PostaMate.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для заказов
    /// </summary>
    public class InMemoryOrderRepository
    {
        protected List<Order> Data { get; set; }

        public InMemoryOrderRepository(List<Order> data)
        {
            Data = data;
        }
        
        /// <summary>
        /// Получает заказ по номеру
        /// </summary>
        /// <param name="number">Номер заказа</param>
        /// <returns>Заказ</returns>
        public Task<Order> GetByIdAsync(int number)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Number == number));
        }

        /// <summary>
        /// Создает заказ
        /// </summary>
        /// <param name="item">Заказ</param>
        /// <returns></returns>
        public Task CreateAsync(Order item)
        {
            return Task.Run(() => Data.Add(item));
        }

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="item">Заказ</param>
        /// <returns></returns>
        public Task UpdateAsync(Order item)
        {
            return Task.Run(() =>
            {
                var oldValue = Data.FirstOrDefault(x => x.Number == item.Number);
                if (oldValue != null) Data.Remove(oldValue);
                Data.Add(item);
            });
        }

        /// <summary>
        /// Отменяет заказ
        /// </summary>
        /// <param name="number">Номер заказа</param>
        /// <returns></returns>
        public Task CancelAsync(int number)
        {
            return Task.Run(() =>
            {
                var value = Data.FirstOrDefault(x => x.Number == number);
                if (value != null) Data.Remove(value);
                value.StatusOrder = Core.Types.StatusOrder.Canceled;
                Data.Add(value);
            });
        }
    }
}