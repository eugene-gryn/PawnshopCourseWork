using AutoMapper;
using DataAccessLayer.Models;
using UIWeb.Shared.DTOs;

namespace BusinessLogic.Mapper;

public class PawnshopMapper : Profile {
    public PawnshopMapper() {
        CreateMap<City, CityDto>();
        CreateMap<CityDto, City>();

        CreateMap<Pawnshop, PawnshopDto>();
        CreateMap<PawnshopDto, Pawnshop>();


        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();


        CreateMap<Make, MakeDto>();
        CreateMap<MakeDto, Make>();


        CreateMap<Operation, OperationDto>();
        CreateMap<OperationDto, Operation>();

        CreateMap<OperationType, OperationTypeDto>();
        CreateMap<OperationTypeDto, OperationType>();


        CreateMap<Worker, WorkerDto>();
        CreateMap<WorkerDto, Worker>();

        CreateMap<WorkerPosition, WorkerPositionDto>();
        CreateMap<WorkerPositionDto, WorkerPosition>();
    }
}