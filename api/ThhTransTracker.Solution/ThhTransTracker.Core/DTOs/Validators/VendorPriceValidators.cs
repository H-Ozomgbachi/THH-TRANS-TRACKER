namespace ThhTransTracker.Core.DTOs.Validators
{
    public class CreateVendorPriceDtoValidator : AbstractValidator<CreateVendorPriceDto>
    {
        public CreateVendorPriceDtoValidator()
        {
            RuleFor(x => x.Origin)
                .NotEmpty().WithMessage("Origin is required");
        }
    }
}
