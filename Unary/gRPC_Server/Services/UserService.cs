using AutoMapper;
using Grpc.Core;

using Shared.Repositories;
using System.Text.Json;
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
            _logger.LogInformation(JsonSerializer.Serialize(request.User));

            var user = _mapper.Map<shared_entities.User>(request.User);
            await _userRepository.AddAsync(user);

            return new UserCreateResponse
            {
                IsCreated = true,
            };
        }

        public override async Task<UserDeleteResponse> DeleteUser(UserDeleteRequest request, ServerCallContext context)
        {

            _logger.LogInformation((request.Id));

            var isDeleted = await _userRepository.DeleteAsync(Guid.Parse(request.Id));

            return new UserDeleteResponse
            {
                IsDeleted = isDeleted,
            };
        }

        public override async Task<Users> GetUsers(EmptyRequest request, ServerCallContext context)
        {
            _logger.LogInformation("GetUsers");

            var users = await _userRepository.GetAllAsync();
            var list = _mapper.Map<IEnumerable<User>>(users);
            var usersResponse = new Users();
            usersResponse.Users_.AddRange(list);

            return usersResponse;
        }

        public override async Task<UserReadResponse> ReadUser(UserReadRequest request, ServerCallContext context)
        {
            _logger.LogInformation(request.Id);

            var user = await _userRepository.GetByIdAsync(Guid.Parse(request.Id));
            var userReadResponse = new UserReadResponse();
            userReadResponse.User = _mapper.Map<User>(user);

            return userReadResponse;


        }


        public async override Task<UserUpdateResponse> UpdateUser(UserUpdateRequest request, ServerCallContext context)
        {
            _logger.LogInformation(JsonSerializer.Serialize(request.User));

            var id = request.User.Id;
            var user = _mapper.Map<shared_entities.User>(request.User);

            var isUpdated = await _userRepository.UpdateAsync(user);

            return new UserUpdateResponse
            {
                IsUpdated = isUpdated
            };
        }

    }
}
