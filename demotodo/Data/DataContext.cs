using demotodo.Model;
using Microsoft.EntityFrameworkCore;

namespace demotodo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todo { get; set; }
    }
}
