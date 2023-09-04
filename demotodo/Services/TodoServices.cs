using demotodo.Data;
using demotodo.Model;
using Microsoft.EntityFrameworkCore;

namespace demotodo.Services
{
    public class TodoServices : ITodoService
    {
        private readonly DataContext _dataContext;
        public TodoServices(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            try
            {
                var items = await _dataContext.Todo.ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Todo> SaveAsync(Todo newTodo)
        {
            try
            {
                if (newTodo == null)
                {
                    throw new Exception("Invalid entry");
                }

                newTodo.Id = Guid.NewGuid();
                _dataContext.Todo.Add(newTodo);
                await _dataContext.SaveChangesAsync();
                return newTodo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
