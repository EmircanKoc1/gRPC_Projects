using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Settings;

namespace Shared.Context
{
    public class MongoDbContext
    {
        protected IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDBSettings> options)
        {
            IMongoClient client;

            if (options is null)
            {
                client = new MongoClient("mongodb://localhost:27017");
                _database = client.GetDatabase("GRPC_Mongo_DB");
                return;
            }
            client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public virtual IMongoDatabase GetDatabase()
            => _database;

        public virtual IMongoCollection<T> GetCollection<T>()
            => _database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());

    }
}
