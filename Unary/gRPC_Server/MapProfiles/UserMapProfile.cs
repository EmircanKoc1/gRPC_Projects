using AutoMapper;
using grpc_entities = gRPC_Server;
using shared_entities = Shared.Entities;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.MapProfiles
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<shared_entities.User, grpc_entities.User>().ReverseMap();
        }

    }
}
