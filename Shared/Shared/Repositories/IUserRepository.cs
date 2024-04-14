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
        public stt.Task<bool> UpdateAsync(User user);
        public stt.Task<User> GetByIdAsync(Guid id);
        public stt.Task<User> AddTaskToUserByIdAsync(Guid id,stt.Task task);
        public stt.Task<User> RemoveTaskToUserByIdAsync(Guid id,stt.Task task);
        public stt.Task<IEnumerable<User>> GetAllAsync();



    }
}
