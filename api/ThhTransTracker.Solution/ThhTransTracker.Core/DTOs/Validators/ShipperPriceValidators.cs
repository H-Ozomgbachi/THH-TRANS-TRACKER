namespace ThhTransTracker.Core.DTOs.Validators
{
    public class CreateShipperPriceDtoValidator : AbstractValidator<CreateShipperPriceDto>
    {
        public CreateShipperPriceDtoValidator()
        {
            RuleFor(x => x.Origin).NotEmpty();
            RuleFor(x => x.DestinationCity).NotEmpty();
        }
    }

    public class UpdateShipperPriceDtoValidator : AbstractValidator<UpdateShipperPriceDto>
    {
        public UpdateShipperPriceDtoValidator()
        {
            RuleFor(x => x.Origin).NotEmpty();
            RuleFor(x => x.DestinationCity).NotEmpty();
        }
    }
}
