namespace ThhTransTracker.Core.DTOs
{
    public class VendorDto
    {
        public Guid Id { get; set; }
        public string VendorName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
    }

    public class CreateVendorDto
    {
        public string VendorName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
    }

    public class UpdateVendorDto
    {
        public Guid Id { get; set; }
        public string VendorName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
    }
}
