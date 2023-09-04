using demotodo.Model;

namespace demotodo.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        public Task<Todo> SaveAsync(Todo newTodo);
    }
}
