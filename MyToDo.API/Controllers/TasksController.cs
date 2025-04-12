using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyToDo.API.Data;
using MyToDo.API.Models.Domain;
using MyToDo.API.Models.DTO;

namespace MyToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ToDoDbContext dbContext;

        public TasksController(ToDoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = dbContext.TaskItems
                .Include(t => t.Category)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status.ToString(),
                    Priority = t.Priority.ToString(),
                    DueDate = t.DueDate,
                    CategoryName = t.Category != null ? t.Category.Name : "Uncategorized"
                })
                .ToList();

            return Ok(tasks);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteTask([FromRoute] Guid id)
        {
            var task = dbContext.TaskItems.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            dbContext.Remove(task);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] CreateTaskDto newTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var task = new TaskItem
            {
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                Status = Enum.Parse<Models.Domain.TaskStatus>(newTaskDto.Status, true),
                Priority = Enum.Parse<TaskPriority>(newTaskDto.Priority, true),
                DueDate = newTaskDto.DueDate,
                CategoryId = newTaskDto.CategoryId
            };

            dbContext.TaskItems.Add(task);
            dbContext.SaveChanges();
            

            return Ok();
        }

        [HttpPut("{id:Guid}")]
        public IActionResult UpdateTask(Guid id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = dbContext.TaskItems.FirstOrDefault(t => t.Id == id);
            
            if (task == null)
                return NotFound();

            task.Title = updateTaskDto.Title;
            task.Description = updateTaskDto.Description;
            task.Status = Enum.Parse<Models.Domain.TaskStatus>(updateTaskDto.Status, true);
            task.Priority = Enum.Parse<TaskPriority>(updateTaskDto.Priority, true);
            task.DueDate = updateTaskDto.DueDate;
            
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
