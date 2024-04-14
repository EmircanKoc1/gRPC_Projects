using MongoDB.Driver;
using Shared.Context;
using Shared.Entities;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using stt = System.Threading.Tasks;

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
        public async stt.Task<bool> DeleteAsync(Guid id)
            => (await _collection.DeleteOneAsync(x => x.Id == id.ToString())).DeletedCount > 0;
        public async stt.Task<bool> UpdateAsync(Expression<Func<User, bool>> filter, UpdateDefinition<User> update)
            => (await _collection.UpdateOneAsync(filter, update)).ModifiedCount > 0;
        public async stt.Task<User> GetByIdAsync(Guid id)
            => await (await _collection.FindAsync(x => x.Id == id.ToString())).FirstOrDefaultAsync();

        public async stt.Task<IEnumerable<User>> GetAllAsync()
            => await (await _collection.FindAsync(FilterDefinition<User>.Empty)).ToListAsync();
    }



}
