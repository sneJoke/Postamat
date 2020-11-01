namespace PostaMate.Core.Domain
{
    /// <summary>
    /// Постамат
    /// </summary>
    public class Postamat
    {
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Адрес постамата
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Статус постамата (bool, Рабочий = true, иначе закрыт)
        /// </summary>
        public bool Status { get; set; }
    }
}