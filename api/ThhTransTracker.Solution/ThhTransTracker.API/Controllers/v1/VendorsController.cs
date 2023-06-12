namespace ThhTransTracker.API.Controllers.v1
{
    public class VendorsController : BaseControllerV1
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet("GetVendors/")]
        public async Task<ActionResult> GetVendors([FromQuery]VendorParam vendorParam)
        {
            var response = await _vendorService.GetVendors(vendorParam);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpGet("GetVendor/{vendorId}")]
        public async Task<ActionResult> GetVendor(Guid vendorId)
        {
            var response = await _vendorService.GetVendor(vendorId);
            return Ok(response);
        }

        [HttpPost("CreateVendors/")]
        public async Task<ActionResult> CreateVendors([FromBody]IEnumerable<CreateVendorDto> createVendorDtos)
        {
            string userId = string.Empty;
            var response = await _vendorService.CreateVendors(createVendorDtos, userId);
            return Ok(response);
        }

        [HttpPut("UpdateVendor/")]
        public async Task<ActionResult> UpdateVendor([FromBody]UpdateVendorDto updateVendorDto)
        {
            string userId = string.Empty;
            var response = await _vendorService.UpdateVendor(updateVendorDto, userId);
            return Ok(response);
        }

        [HttpDelete("DeleteVendor/{vendorId}")]
        public async Task<ActionResult> DeleteVendor(Guid vendorId)
        {
            var vendor = await _vendorService.DeleteVendor(vendorId);
            return Ok(vendor);
        }
    }
}
