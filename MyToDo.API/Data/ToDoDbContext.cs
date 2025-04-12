using Microsoft.EntityFrameworkCore;
using MyToDo.API.Models.Domain;

namespace MyToDo.API.Data
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
