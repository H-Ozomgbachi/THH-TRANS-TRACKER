﻿namespace ThhTransTracker.Core.Mappers
{
    public class TransactionMappers : Profile
    {
        public TransactionMappers()
        {
            CreateMap<RequestTruckDto, Transaction>().ReverseMap();
            CreateMap<TransactionDto, Transaction>().ReverseMap();
            CreateMap<FulfillRequestDto, Transaction>().ReverseMap();
            CreateMap<CancelRequestDto, Transaction>().ReverseMap();
            CreateMap<ConfirmLoadingDto, Transaction>().ReverseMap();
            CreateMap<CreateWaybillDetailDto, WaybillDetail>().ReverseMap();
            CreateMap<WaybillDetailDto, WaybillDetail>().ReverseMap();
        }
    }
}
