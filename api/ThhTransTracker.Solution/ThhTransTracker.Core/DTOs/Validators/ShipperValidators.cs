namespace ThhTransTracker.Core.DTOs.Validators
{
    public class CreateShipperDtoValidator : AbstractValidator<CreateShipperDto>
    {
        public CreateShipperDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.ContactPhone).NotEmpty();
        }
    }

    public class UpdateShipperDtoValidator : AbstractValidator<UpdateShipperDto>
    {
        public UpdateShipperDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.ContactPhone).NotEmpty();
        }
    }
}
