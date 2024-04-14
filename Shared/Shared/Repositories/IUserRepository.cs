using MongoDB.Driver;
using Shared.Entities;
using System.Linq.Expressions;
using stt = System.Threading.Tasks;

namespace Shared.Repositories
{
    public interface IUserRepository
    {
        public stt.Task AddAsync(User user);
        public stt.Task<bool> DeleteAsync(Guid id);
        public stt.Task<bool> UpdateAsync(Expression<Func<User, bool>> filter, UpdateDefinition<User> update);
        public stt.Task<User> GetByIdAsync(Guid id);
        public stt.Task<IEnumerable<User>> GetAllAsync();

    }
}
