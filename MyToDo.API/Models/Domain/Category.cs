using System.ComponentModel.DataAnnotations;

namespace MyToDo.API.Models.Domain
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<TaskItem> Tasks { get; set; }
    }
}
