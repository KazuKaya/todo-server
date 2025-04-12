using System.ComponentModel.DataAnnotations;
namespace MyToDo.API.Models.DTO
{
    public class UpdateTaskDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
