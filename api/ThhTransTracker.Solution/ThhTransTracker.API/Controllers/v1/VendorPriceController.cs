namespace ThhTransTracker.API.Controllers.v1
{
    [Authorize]
    public class VendorPriceController : BaseControllerV1
    {
        private readonly IVendorPriceService _vendorPriceService;

        public VendorPriceController(IVendorPriceService vendorPriceService)
        {
            _vendorPriceService = vendorPriceService;
        }

        [HttpGet("GetVendorPrices/{vendorId}")]
        public async Task<ActionResult> GetVendorPrices([FromQuery]VendorPriceParam vendorPriceParam, Guid vendorId)
        {
            var response = await _vendorPriceService.GetVendorPrices(vendorPriceParam, vendorId);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpPost("CreateVendorPrices/")]
        public async Task<ActionResult> CreateVendorPrices([FromBody]IEnumerable<CreateVendorPriceDto> createVendorPriceDtos)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            var response = await _vendorPriceService.CreateVendorPrices(createVendorPriceDtos, userId);
            return Ok(response);
        }

        [HttpPut("UpdateVendorPrice/")]
        public async Task<ActionResult> UpdateVendorPrice([FromBody]UpdateVendorPriceDto updateVendorPriceDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            var response = await _vendorPriceService.UpdateVendorPrice(updateVendorPriceDto, userId);
            return Ok(response);
        }

        [HttpDelete("DeleteVendorPrice/{vendorPriceId}")]
        public async Task<ActionResult> DeleteVendorPrice(Guid vendorPriceId)
        {
            var response = await _vendorPriceService.DeleteVendorPrice(vendorPriceId);
            return Ok(response);
        }
    }
}
