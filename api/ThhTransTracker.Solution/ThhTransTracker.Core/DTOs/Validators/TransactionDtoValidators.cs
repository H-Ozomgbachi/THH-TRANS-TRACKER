namespace ThhTransTracker.Core.DTOs.Validators
{
    public class RequestTruckDtoValidator : AbstractValidator<RequestTruckDto>
    {
        public RequestTruckDtoValidator()
        {
            RuleFor(x => x.ShipperName).NotEmpty();
            RuleFor(x => x.OriginCity).NotEmpty();
            RuleFor(x => x.DestinationCity).NotEmpty();
        }
    }

    public class FulfillRequestDtoValidator : AbstractValidator<FulfillRequestDto>
    {
        public FulfillRequestDtoValidator()
        {

        }
    }
}
