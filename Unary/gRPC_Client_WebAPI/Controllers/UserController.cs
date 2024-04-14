using AutoMapper;
using gRPC_Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using grpc_entties = gRPC_Server;
using shared_entities = Shared.Entities;
using stt = System.Threading.Tasks;

namespace gRPC_Client_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserGRPCService.UserGRPCServiceClient _client;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(UserGRPCService.UserGRPCServiceClient client, IMapper mapper, ILogger<UserController> logger)
        {
            _client = client;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async stt.Task<IActionResult> GetAll()
        {
            var response = await _client.GetUsersAsync(new() { });

            var users = response.Users_.Select(x => x);
            var mappedUsers = _mapper.Map<IEnumerable<shared_entities.User>>(users);

            return Ok(mappedUsers);
        }


        [HttpPost]
        public async stt.Task<IActionResult> AddAsync(shared_entities.User user)
        {

            var mappedUser = _mapper.Map<shared_entities.User, grpc_entties.User>(user);

            var response = await _client.CreateUserAsync(new UserCreateRequest
            {
                User = mappedUser
            });

            return Ok(response.IsCreated);
        }

        [HttpPut]
        public async stt.Task<IActionResult> Update(shared_entities.User user)
        {
            var mappedUser = _mapper.Map<grpc_entties.User>(user);

            var response = await _client.UpdateUserAsync(new UserUpdateRequest
            {
                User = mappedUser
            });

            return Ok(response.IsUpdated);
        }

        [HttpDelete]
        public async stt.Task<IActionResult> Delete(Guid id)
        {


            var response = await _client.DeleteUserAsync(new UserDeleteRequest
            {
                Id = id.ToString()
            });

            return Ok(response.IsDeleted);
        }
    }
}
