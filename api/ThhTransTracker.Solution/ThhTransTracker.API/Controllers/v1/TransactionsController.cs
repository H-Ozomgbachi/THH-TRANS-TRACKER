namespace ThhTransTracker.API.Controllers.v1
{
    [Authorize]
    public class TransactionsController : BaseControllerV1
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost("RequestTruck/")]
        public async Task<ActionResult> RequestTruck([FromBody]RequestTruckDto requestTruckDto, string uniqueCode)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            ValidateEmployeeUniqueCode(userId, uniqueCode);

            var response = await _transactionService.RequestTruck(requestTruckDto, userId);
            return Ok(response);
        }

        [HttpGet("GetTransaction/{transactionId}")]
        public async Task<ActionResult> GetTransaction(Guid transactionId)
        {
            var response = await _transactionService.GetTransaction(transactionId);
            return Ok(response);
        }

        [HttpGet("GetTransactions/")]
        public async Task<ActionResult> GetTransactions([FromQuery]TransactionParam transactionParam)
        {
            var response = await _transactionService.GetTransactions(transactionParam);
            Response.Headers.Add("X-Pagination", HelperMethods.GetPaginationInfo(response));
            return Ok(response);
        }

        [HttpPost("FulfillRequest/")]
        public async Task<ActionResult> FulfillRequest([FromBody]FulfillRequestDto fulfillRequestDto, string uniqueCode)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            ValidateEmployeeUniqueCode(userId, uniqueCode);

            var response = await _transactionService.FulfillRequest(fulfillRequestDto, userId);
            return Ok(response);
        }

        [HttpPost("CancelRequest/")]
        public async Task<ActionResult> CancelRequest([FromBody]CancelRequestDto cancelRequestDto, string uniqueCode)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            ValidateEmployeeUniqueCode(userId, uniqueCode);

            var response = await _transactionService.CancelRequest(cancelRequestDto, userId);
            return Ok(response);
        }

        [HttpPost("ConfirmLoading/")]
        public async Task<ActionResult> ConfirmLoading([FromForm]ConfirmLoadingDto confirmLoadingDto, string uniqueCode)
        {
            string userId = User.FindFirstValue(ClaimTypes.UserData);
            ValidateEmployeeUniqueCode(userId, uniqueCode);

            var response = await _transactionService.ConfirmLoading(confirmLoadingDto, userId);
            return Ok(response);
        }
    }
}
