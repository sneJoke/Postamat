namespace PostaMate.Core.Types
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum StatusOrder
    {
        /// <summary>
        /// Зарегистрирован
        /// </summary>
        Registered = 1,
        
        /// <summary>
        /// Принят на складе
        /// </summary>
        AcceptedInStock = 2,
        /// <summary>
        /// Выдан курьеру
        /// </summary>
        IssuedToCourier = 3,
        
        /// <summary>
        /// Доставлен в постамат
        /// </summary>
        DeliveredToCheckpoint = 4,
        
        /// <summary>
        /// Доставлен получателю
        /// </summary>
        DeliveredToRecipient = 5,
        
        /// <summary>
        /// Отменен
        /// </summary>
        Canceled = 6,
    }
}