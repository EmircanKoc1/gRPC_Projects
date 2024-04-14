using MongoDB.Driver;
using Shared.Entities;
using System.Linq.Expressions;
using shared_entities= Shared.Entities;
using stt = System.Threading.Tasks;
namespace Shared.Repositories
{
    public interface IUserRepository
    {
        public stt.Task AddAsync(User user);
        public stt.Task<bool> DeleteAsync(Guid id);
        public stt.Task<bool> UpdateAsync(User user);
        public stt.Task<User> GetByIdAsync(Guid id);
        public stt.Task<User> AddTaskToUserByIdAsync(Guid id,shared_entities.Task task);
        public stt.Task<User> RemoveTaskToUserByIdAsync(Guid id,shared_entities.Task task);
        public stt.Task<IEnumerable<User>> GetAllAsync();



    }
}
