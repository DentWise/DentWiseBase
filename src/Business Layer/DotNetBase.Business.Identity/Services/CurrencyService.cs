using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Currency> CreateCurrencyAsync(CreateCurrency createCurrency)
        {
            if (createCurrency.CurrencyCode == null)
                throw new Exception("CurrencyCode can not null!");

            var currency = new Currency
            {
                CurrencyCode = createCurrency.CurrencyCode,
                CreatedAt = DateTime.UtcNow,
                CurrencyName = createCurrency.CurrencyName,
                CurrencySymbol = createCurrency.CurrencySymbol,
                IsDefault = createCurrency.IsDefault
            };

            await _unitOfWork.CurrencyRepository.AddAsync(currency);
            await _unitOfWork.CompleteAsync();
            return currency;
        }

        public async Task DeleteCurrencyAsync(int id)
        {
            var currency = await _unitOfWork.CurrencyRepository.GetByIdAsync(id);
            if (currency == null)
                throw new Exception("Currency not found!");

            currency.IsDeleted = true;
            currency.DeletedAt = DateTime.UtcNow;

            _unitOfWork.CurrencyRepository.Update(currency);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Currency>> GetAllCurrencyAsync()
        {
            var currency = await _unitOfWork.CurrencyRepository.FindManyAsync(u => !u.IsDeleted);
            if (currency == null)
                throw new Exception("Currency does not have any object!");

            return currency;
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            var currency = await _unitOfWork.CurrencyRepository.GetByIdAsync(id);
            if (currency == null || currency.IsDeleted)
                throw new Exception("Object not found!!");

            return currency;
        }

        public async Task UpdateCurrencyAsync(int id, UpdateCurrency updateCurrency)
        {
            var currency = await _unitOfWork.CurrencyRepository.GetByIdAsync(id);
            if (currency == null || currency.IsDeleted)
                throw new Exception("Object not found!!");

            currency.UpdatedAt = DateTime.UtcNow;
            currency.IsDefault = updateCurrency.IsDefault;

            _unitOfWork.CurrencyRepository.Update(currency);
            await _unitOfWork.CompleteAsync();
        }
    }
}
