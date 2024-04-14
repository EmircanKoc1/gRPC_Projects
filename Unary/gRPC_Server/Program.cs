using gRPC_Server.Services;
using Shared.Context;
using Shared.Repositories;
namespace gRPC_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddSingleton<MongoDbContext>(x => new MongoDbContext(null));

            builder.Services.AddAutoMapper(typeof(Program));

            //builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

            builder.Services.AddGrpc();

            var app = builder.Build();

            //var context = new MongoDbContext(app.Services.GetService(typeof(MongoDBSettings)) as IOptions<MongoDBSettings>);
            //context.GetCollection<sh.User>()
            //    .InsertOne(new sh.User() { Id = Guid.NewGuid().ToString(), Addresses = new List<sh.Address> { new() { City = "lamlkda" } } });


            app.MapGrpcService<UserService>();

            app.Run();
        }
    }
}