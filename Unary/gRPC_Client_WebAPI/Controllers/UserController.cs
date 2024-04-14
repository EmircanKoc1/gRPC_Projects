using AutoMapper;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using grpc_entties = gRPC_Server;
using shared_entities = Shared.Entities;
using gRPC_Server;

namespace gRPC_Client_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserGRPCService.UserGRPCServiceClient _client;
        private readonly IMapper _mapper;
        public UserController(UserGRPCService.UserGRPCServiceClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(shared_entities.User user)
        {

           var mappedUser = _mapper.Map<shared_entities.User, grpc_entties.User>(user);

            


            var response = await _client.CreateUserAsync(new UserCreateRequest
            {
                User = mappedUser
            });
          
            return Ok(response);
        }
    }
}
