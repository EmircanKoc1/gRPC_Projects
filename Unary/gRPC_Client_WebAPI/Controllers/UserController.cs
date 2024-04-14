using Grpc.Net.Client;
using gRPC_Server;
using Microsoft.AspNetCore.Mvc;
using shared_entities = Shared.Entities;

namespace gRPC_Client_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {



        [HttpPost]
        public async Task<IActionResult> AddAsync(shared_entities.User user)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7268");
            var client = new UserGRPCService.UserGRPCServiceClient(channel);

            var response = await client.CreateUserAsync(new()
            {
                User = new User() { Age = user.Age, Name = user.Name },
            });

          
            return Ok(response.IsUpdated);
        }
    }
}
