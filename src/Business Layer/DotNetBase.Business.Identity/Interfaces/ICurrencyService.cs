using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAllCurrencyAsync();
        Task<Currency> GetCurrencyByIdAsync(int id);
        Task<Currency> CreateCurrencyAsync(CreateCurrency createCurrency);
        Task UpdateCurrencyAsync(int id, UpdateCurrency updateCurrency);
        Task DeleteCurrencyAsync(int id);
    }
}
