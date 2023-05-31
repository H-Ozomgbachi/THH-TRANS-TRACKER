namespace ThhTransTracker.API.Controllers.v1
{
    public class ShippersController : BaseControllerV1
    {
        private readonly IShipperService _shipperService;

        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet("GetShippers/")]
        public async Task<IActionResult> GetShippers([FromQuery]ShipperParam shipperParam)
        {
            var response = await _shipperService.GetShippers(shipperParam);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpGet("GetShipper/{shipperId:guid}")]
        public async Task<IActionResult> GetShipper(Guid shipperId)
        {
            var response = await _shipperService.GetShipper(shipperId);
            return Ok(response);
        }

        [HttpPost("CreateShipper/")]
        public async Task<IActionResult> CreateShipper([FromBody]CreateShipperDto createShipperDto)
        {
            string userId = string.Empty;
            var response = await _shipperService.CreateShipper(createShipperDto, userId);
            return Ok(response);
        }

        [HttpPut("UpdateShipper/")]
        public async Task<IActionResult> UpdateShipper([FromBody]UpdateShipperDto updateShipperDto)
        {
            string userId = string.Empty;
            var response = await _shipperService.UpdateShipper(updateShipperDto, userId);
            return Ok(response);
        }

        [HttpDelete("DeleteShipper/{shipperId:guid}")]
        public async Task<IActionResult> DeleteShipper(Guid shipperId)
        {
            var response = await _shipperService.DeleteShipper(shipperId);
            return Ok(response);
        }
    }
}
