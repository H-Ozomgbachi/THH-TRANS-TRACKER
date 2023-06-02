namespace ThhTransTracker.API.Controllers.v1
{
    public class TruckSizeController : BaseControllerV1
    {
        private readonly ITruckSizeService _truckSizeService;

        public TruckSizeController(ITruckSizeService truckSizeService)
        {
            _truckSizeService = truckSizeService;
        }

        [HttpGet("GetTruckSizes/")]
        public async Task<IActionResult> GetTruckSizes([FromQuery]TruckSizeParam truckSizeParam)
        {
            var response = await _truckSizeService.GetTruckSizes(truckSizeParam);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpPost("CreateTruckSizes/")]
        public async Task<IActionResult> CreateTruckSizes([FromBody]IEnumerable<CreateTruckSizeDto> createTruckSizeDtos)
        {
            string userId = string.Empty;
            var response = await _truckSizeService.CreateTruckSizes(createTruckSizeDtos, userId);
            return Ok(response);
        }

        [HttpPut("UpdateTruckSize/")]
        public async Task<IActionResult> UpdateTruckSize([FromBody]UpdateTruckSizeDto updateTruckSizeDto)
        {
            string userId = string.Empty;
            var response = await _truckSizeService.UpdateTruckSize(updateTruckSizeDto, userId);
            return Ok(response);
        }

        [HttpDelete("DeleteTruckSize/{truckSizeId:guid}")]
        public async Task<IActionResult> DeleteTruckSize(Guid truckSizeId)
        {
            var response = await _truckSizeService.DeleteTruckSize(truckSizeId);
            return Ok(response);
        }
    }
}
