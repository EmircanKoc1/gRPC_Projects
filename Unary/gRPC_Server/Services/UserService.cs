using AutoMapper;
using Grpc.Core;
using Shared.Repositories;
using shared_entities = Shared.Entities;

namespace gRPC_Server.Services
{
    public class UserService : UserGRPCService.UserGRPCServiceBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(ILogger<UserService> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<UserCreateResponse> CreateUser(UserCreateRequest request, ServerCallContext context)
        {
            var user = _mapper.Map<shared_entities.User>(request.User);
            await _userRepository.AddAsync(user);

            return new UserCreateResponse
            {
                IsUpdated = true,
            };
        }

        public override Task<UserDeleteResponse> DeleteUser(UserDeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUser(request, context);
        }

        public override Task<Users> GetUsers(EmptyRequest request, ServerCallContext context)
        {
            return base.GetUsers(request, context);
        }

        public override Task<UserReadResponse> ReadUser(UserReadRequest request, ServerCallContext context)
        {
            return base.ReadUser(request, context);
        }


        public override Task<UserUpdateResponse> UpdateUser(UserUpdateRequest request, ServerCallContext context)
        {
            return base.UpdateUser(request, context);
        }

    }
}
