using MongoDB.Driver;
using Shared.Context;
using Shared.Entities;
using stt = System.Threading.Tasks;
using shared_entities = Shared.Entities;

namespace Shared.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly MongoDbContext _context;
        private readonly IMongoCollection<User> _collection;

        public UserRepository(MongoDbContext context)
        {
            _context = context;
            _collection = _context.GetCollection<User>();
        }

        public async stt.Task AddAsync(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            await _collection.InsertOneAsync(user);
        }
        public virtual async stt.Task<bool> DeleteAsync(Guid id)
            => (await _collection.DeleteOneAsync(x => x.Id == id.ToString())).DeletedCount > 0;
        public virtual async stt.Task<bool> UpdateAsync(User user)
            //=> (await _collection.UpdateOneAsync(filter, update)).ModifiedCount > 0;
            => (await _collection.ReplaceOneAsync(x => x.Id == user.Id.ToString(), user)).ModifiedCount > 0;
        public virtual async stt.Task<User> GetByIdAsync(Guid id)
            => await (await _collection.FindAsync(x => x.Id == id.ToString())).FirstOrDefaultAsync();
        public virtual async stt.Task<IEnumerable<User>> GetAllAsync()
            => await (await _collection.FindAsync(FilterDefinition<User>.Empty)).ToListAsync();

        public async Task<User> AddTaskToUserByIdAsync(Guid id, shared_entities.Task task)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id.ToString());

            var updateDefination = Builders<User>.Update.Push("Tasks", value: task);

            var user = await _collection.FindOneAndUpdateAsync(filter, updateDefination);
            
            return user;
        }

        public async Task<User> RemoveTaskToUserByIdAsync(Guid id, shared_entities.Task task)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id.ToString());

            var updateDefination = Builders<User>.Update.Pull("Tasks", value: task);

            var user = await _collection.FindOneAndUpdateAsync(filter, updateDefination);

            return user;
        }
    }



}
