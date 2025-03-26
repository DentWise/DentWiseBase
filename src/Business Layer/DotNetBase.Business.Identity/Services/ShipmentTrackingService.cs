using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;

namespace DotNetBase.Business.Identity.Services
{
    public class ShipmentTrackingService : IShipmentTrackingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShipmentTrackingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShipmentTracking> CreateShipmentTrackingAsync(CreateShipmentTracking createShipmentTracking)
        {
            if (createShipmentTracking.PurchaseOrderId == null)
                throw new Exception("PurchaseOrderId can not be null!");

            var shipmentTracking = new ShipmentTracking
            {
                PurchaseOrderId = createShipmentTracking.PurchaseOrderId,
                CarrierCompanyId = createShipmentTracking.CarrierCompanyId,
                EstimatedDeliveryDate = createShipmentTracking.EstimatedDeliveryDate,
                CreatedAt = DateTime.UtcNow,
                Notes = createShipmentTracking.Notes,
                ShipmentDate = createShipmentTracking.ShipmentDate,
                TrackingNumber = createShipmentTracking.TrackingNumber,
                TrackingUrl = createShipmentTracking.TrackingUrl
            };

            await _unitOfWork.ShipmentTrackingRepository.AddAsync(shipmentTracking);
            await _unitOfWork.CompleteAsync();
            return shipmentTracking;
        }

        public async Task<IEnumerable<ShipmentTracking>> GetAllShipmentTrackingAsync()
        {
            var shipmentTracking = await _unitOfWork.ShipmentTrackingRepository.GetAllAsync();
            if (shipmentTracking == null)
                throw new Exception("ShipmentTracking does not have any object!");

            return shipmentTracking;
        }

        public async Task<ShipmentTracking> GetShipmentTrackingByIdAsync(int id)
        {
            var shipmentTracking = await _unitOfWork.ShipmentTrackingRepository.GetByIdAsync(id);
            if (shipmentTracking == null)
                throw new Exception("Object not found!");

            return shipmentTracking;
        }
    }
}
