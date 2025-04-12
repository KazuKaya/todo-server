using System.ComponentModel.DataAnnotations;
namespace MyToDo.API.Models.DTO

{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        public string Priority { get; set; } = "Medium";

        public DateTime? DueDate { get; set; }
        
        public Guid? CategoryId { get; set; }
    }
}
