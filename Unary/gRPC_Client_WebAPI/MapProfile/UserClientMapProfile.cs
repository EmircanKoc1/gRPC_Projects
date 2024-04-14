using AutoMapper;
using grpc_entities = gRPC_Server;
using shared_entities = Shared.Entities;

namespace gRPC_Client_WebAPI.MapProfile
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {

            CreateMap<shared_entities.User, grpc_entities.User>()
             .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
             .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
             .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
             .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
             .ReverseMap();

            CreateMap<grpc_entities.User, shared_entities.User>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ReverseMap();


            CreateMap<shared_entities.Task, grpc_entities.Task>().ReverseMap();

            CreateMap<shared_entities.User, grpc_entities.User>()
             .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
             .ReverseMap();

            CreateMap<grpc_entities.User, shared_entities.User>()
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                .ReverseMap();


            CreateMap<shared_entities.Credential, grpc_entities.Credential>().ReverseMap();


            CreateMap<shared_entities.User, grpc_entities.User>()
             .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
             .ReverseMap();

            CreateMap<grpc_entities.User, shared_entities.User>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ReverseMap();

            CreateMap<shared_entities.Address, grpc_entities.Address>().ReverseMap();

            CreateMap<shared_entities.User, grpc_entities.User>()
          .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
          .ReverseMap();

            CreateMap<grpc_entities.User, shared_entities.User>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ReverseMap();

            CreateMap<shared_entities.Contact, grpc_entities.Contact>().ReverseMap();
        }


    }
}
