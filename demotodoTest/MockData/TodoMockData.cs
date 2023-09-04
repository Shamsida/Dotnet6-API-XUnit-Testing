using demotodo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demotodoTest.MockData
{
    public class TodoMockData
    {
        public static List<Todo> GetTodos()
        {
            return new List<Todo>{
             new Todo{
                 Id = Guid.NewGuid(),
                 ItemName = "Need To Go Shopping",
                 IsCompleted = true
             },
             new Todo{
                 Id = Guid.NewGuid(),
                 ItemName = "Cook Food",
                 IsCompleted = true
             },
             new Todo{
                 Id = Guid.NewGuid(),
                 ItemName = "Play Games",
                 IsCompleted = false
             }
         };
        }

        public static List<Todo> GetEmptyTodos()
        {
            return new List<Todo>();
        }

        public static Todo NewTodo()
        {
            return new Todo
            {
                Id = Guid.NewGuid(),
                ItemName = "wash cloths",
                IsCompleted = false
            };
        }
    }
}
