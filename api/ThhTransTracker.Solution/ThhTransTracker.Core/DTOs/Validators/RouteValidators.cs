namespace ThhTransTracker.Core.DTOs.Validators
{
    public class CreateRouteDtoValidator : AbstractValidator<CreateRouteDto>
    {
        public CreateRouteDtoValidator()
        {
            RuleFor(x => x.OriginState)
                .NotEmpty().WithMessage("Origin state is required")
                .MaximumLength(100).WithMessage("Origin state must not exceed 100 characters");
            RuleFor(x => x.OriginCity)
                .NotEmpty().WithMessage("Origin city is required")
                .MaximumLength(100).WithMessage("Origin city must not exceed 100 characters");
            RuleFor(x => x.DestinationState)
                .NotEmpty().WithMessage("Destination state is required")
                .MaximumLength(100).WithMessage("Destination state must not exceed 100 characters");
            RuleFor(x => x.DestinationCity)
                .NotEmpty().WithMessage("Destination city is required")
                .MaximumLength(100).WithMessage("Destination city must not exceed 100 characters");
        }
    }
}
