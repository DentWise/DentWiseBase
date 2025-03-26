using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IShipmentTrackingService
    {
        Task<IEnumerable<ShipmentTracking>> GetAllShipmentTrackingAsync();
        Task<ShipmentTracking> GetShipmentTrackingByIdAsync(int id);
        Task<ShipmentTracking> CreateShipmentTrackingAsync(CreateShipmentTracking createShipmentTracking);
    }
}
