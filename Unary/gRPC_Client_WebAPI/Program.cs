using Grpc.Net.Client;
using gRPC_Server;

namespace gRPC_Client_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddSingleton<UserGRPCService.UserGRPCServiceClient>(x =>
            new UserGRPCService.UserGRPCServiceClient(
                 GrpcChannel.ForAddress(builder.Configuration.GetConnectionString("gRPC")))
            );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
