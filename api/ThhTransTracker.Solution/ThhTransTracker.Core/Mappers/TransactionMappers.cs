namespace ThhTransTracker.Core.Mappers
{
    public class TransactionMappers : Profile
    {
        public TransactionMappers()
        {
            CreateMap<RequestTruckDto, Transaction>().ReverseMap();
            CreateMap<TransactionDto, Transaction>().ReverseMap();
            CreateMap<FulfillRequestDto, Transaction>().ReverseMap();
            CreateMap<CancelRequestDto, Transaction>().ReverseMap();
        }
    }
}
