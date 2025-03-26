using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ShipmentTrackingController(ShipmentTrackingService shipmentTrackingService) : Controller
    {
        [HttpPost("CreateShipmentTracking")]
        public async Task<IActionResult> CreateShipmentTrackingAsync([FromBody] CreateShipmentTracking createShipmentTracking)
        {
            try
            {
                var result = await shipmentTrackingService.CreateShipmentTrackingAsync(createShipmentTracking);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllShipmentTracking")]
        public async Task<IActionResult> GetAllShipmentTrackingAsync()
        {
            try
            {
                var result = await shipmentTrackingService.GetAllShipmentTrackingAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetShipmentTrackingById")]
        public async Task<IActionResult> GetShipmentTrackingByIdAsync(int id)
        {
            try
            {
                var result = await shipmentTrackingService.GetShipmentTrackingByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
