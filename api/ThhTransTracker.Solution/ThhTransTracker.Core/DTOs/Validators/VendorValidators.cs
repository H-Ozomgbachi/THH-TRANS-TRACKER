namespace ThhTransTracker.Core.DTOs.Validators
{
    public class CreateVendorDtoValidator : AbstractValidator<CreateVendorDto>
    {
        public CreateVendorDtoValidator()
        {
            RuleFor(x => x.VendorName)
                .NotEmpty().WithMessage("Vendor name required");
            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("Account name is required");
            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("Account number is required")
                .Length(10).WithMessage("Account number should be ten digits");
            RuleFor(x => x.BankName)
                .NotEmpty().WithMessage("Bank name is required");
        }
    }

    public class UpdateVendorDtoValidator : AbstractValidator<UpdateVendorDto>
    {
        public UpdateVendorDtoValidator()
        {
            RuleFor(x => x.VendorName)
                .NotEmpty().WithMessage("Vendor name required");
            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("Account name is required");
            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("Account number is required")
                .Length(10).WithMessage("Account number should be ten digits");
            RuleFor(x => x.BankName)
                .NotEmpty().WithMessage("Bank name is required");
        }
    }
}