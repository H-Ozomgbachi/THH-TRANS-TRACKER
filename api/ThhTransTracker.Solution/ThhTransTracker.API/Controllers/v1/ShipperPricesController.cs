namespace ThhTransTracker.API.Controllers.v1
{
    [Authorize]
    public class ShipperPricesController : BaseControllerV1
    {
        private readonly IShipperPriceService _shipperPriceService;

        public ShipperPricesController(IShipperPriceService shipperPriceService)
        {
            _shipperPriceService = shipperPriceService;
        }

        [HttpGet("{shipperId}/GetShipperPrices/")]
        public async Task<ActionResult> GetShipperPrices([FromQuery]ShipperPriceParam shipperPriceParam, Guid shipperId)
        {
            var response = await _shipperPriceService.GetShipperPrices(shipperPriceParam, shipperId);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpPost("{shipperId}/CreateShipperPrices/")]
        public async Task<ActionResult> CreateShipperPrices([FromBody]IEnumerable<CreateShipperPriceDto> createShipperPriceDtos)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            var response = await _shipperPriceService.CreateShipperPrices(createShipperPriceDtos, userId);
            return Ok(response);
        }

        [HttpPut("{shipperId}/UpdateShipperPrice/")]
        public async Task<ActionResult> UpdateShipperPrice([FromBody]UpdateShipperPriceDto updateShipperPriceDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            var response = await _shipperPriceService.UpdateShipperPrice(updateShipperPriceDto, userId);
            return Ok(response);
        }

        [HttpDelete("{shipperId}/DeleteShipperPrice")]
        public async Task<ActionResult> DeleteShipperPrice(Guid shipperId)
        {
            var response = await _shipperPriceService.DeleteShipperPrice(shipperId);
            return Ok(response);
        }
    }
}
