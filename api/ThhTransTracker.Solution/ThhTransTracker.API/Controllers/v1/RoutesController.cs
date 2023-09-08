namespace ThhTransTracker.API.Controllers.v1
{
    [Authorize]
    public class RoutesController : BaseControllerV1
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("GetRoutes/")]
        public async Task<ActionResult<RouteDto>> GetRoutes([FromQuery]RouteParam routeParam)
        {
            var response = await _routeService.GetRoutes(routeParam);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpGet("GetRoute/{routeId:guid}")]
        public async Task<ActionResult> GetRoute(Guid routeId)
        {
            var response = await _routeService.GetRoute(routeId);
            return Ok(response);
        }

        [HttpPost("CreateRoute/")]
        public async Task<ActionResult> CreateRoute([FromBody]CreateRouteDto createRouteDto)
        {
            string empId = User.FindFirstValue(ClaimTypes.UserData);
            var response = await _routeService.CreateRoute(createRouteDto, empId);
            return Ok(response);
        }

        [HttpPut("UpdateRoute/")]
        public async Task<ActionResult> UpdateRoute([FromBody]UpdateRouteDto updateRouteDto)
        {
            string empId = User.FindFirstValue(ClaimTypes.UserData);
            var response = await _routeService.UpdateRoute(updateRouteDto, empId);
            return Ok(response);
        }

        [HttpDelete("DeleteRoute/{routeId:guid}")]
        public async Task<ActionResult> DeleteRoute(Guid routeId)
        {
            var response = await _routeService.DeleteRoute(routeId);
            return Ok(response);
        }
    }
}
