namespace AspNetCoreToDo.Web.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
