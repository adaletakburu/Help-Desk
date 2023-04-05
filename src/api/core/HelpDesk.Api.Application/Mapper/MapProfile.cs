using AutoMapper;
using HelpDesk.Api.Application.Features.Commands.Demand.Create;
using HelpDesk.Api.Application.Features.Commands.Demand.Update;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Create;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Update;
using HelpDesk.Api.Application.Features.Commands.User.Login;
using HelpDesk.Api.Application.Features.Commands.User.Register;
using HelpDesk.Api.Application.Features.Queries.Demand.GetById;
using HelpDesk.Api.Application.Features.Queries.DemandMessage.GetByDemandId;
using HelpDesk.Api.Domain.Models;

namespace HelpDesk.Api.Application.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterCommand, User>().ReverseMap();
            CreateMap<LoginCommand, User>().ReverseMap();
            CreateMap<LoginCommandResponse, User>().ReverseMap();

            CreateMap<CreateDemandCommand, Demand>().ReverseMap();
            CreateMap<UpdateDemandCommand, Demand>().ReverseMap();
            CreateMap<GetByIdDemandQueryResponse, Demand>().ReverseMap();


            CreateMap<CreateDemandMessageCommand, DemandMessage>().ReverseMap();
            CreateMap<UpdateDemandMessageCommand, DemandMessage>().ReverseMap();
            CreateMap<GetByDemandIdDemandMessageQueryResponse, DemandMessage>().ReverseMap();

        }
    }
}
