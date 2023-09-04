using demotodo.Data;
using demotodo.Services;
using demotodoTest.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demotodoTest.Systems.Services
{
    public class TestTodoService :IDisposable
    {
        protected readonly DataContext _context;
        public TestTodoService()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new DataContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ReturnTodoCollection()
        {
            /// Arrange
            _context.Todo.AddRange(MockData.TodoMockData.GetTodos());
            _context.SaveChanges();

            var sut = new TodoServices(_context);

            /// Act
            var result = await sut.GetAllAsync();

            /// Assert
            result.Should().HaveCount(TodoMockData.GetTodos().Count);
        }

        [Fact]
        public async Task SaveAsync_AddNewTodo()
        {
            /// Arrange
            var newTodo = TodoMockData.NewTodo();
            _context.Todo.AddRange(TodoMockData.GetTodos());
            _context.SaveChanges();

            var sut = new TodoServices(_context);

            /// Act
            await sut.SaveAsync(newTodo);

            ///Assert
            int expectedRecordCount = (TodoMockData.GetTodos().Count() + 1);
            _context.Todo.Count().Should().Be(expectedRecordCount);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
