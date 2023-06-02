namespace ThhTransTracker.Core.DTOs.Validators
{
    public class CreateTruckSizeDtoValidator : AbstractValidator<CreateTruckSizeDto>
    {
        public CreateTruckSizeDtoValidator()
        {
            RuleFor(x => x.Size).NotEmpty();
        }
    }

    public class UpdateTruckSizeDtoValidator : AbstractValidator<UpdateTruckSizeDto>
    {
        public UpdateTruckSizeDtoValidator()
        {
            RuleFor(x => x.Size).NotEmpty();
        }
    }
}
