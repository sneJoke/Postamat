using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostaMate.Core.Domain;

namespace PostaMate.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для постамата
    /// </summary>
    public class InMemoryPostamatRepository
    {
        protected List<Postamat> Data { get; set; }

        public InMemoryPostamatRepository(List<Postamat> data)
        {
            Data = data;
        }

        /// <summary>
        /// Получает постамат по номеру
        /// </summary>
        /// <param name="number">Номер постамата</param>
        /// <returns>Постамат</returns>
        public Task<Postamat> GetByIdAsync(string number)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Number == number));
        }
    }
}