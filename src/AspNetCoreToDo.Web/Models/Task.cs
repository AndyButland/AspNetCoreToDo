namespace AspNetCoreToDo.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        private Task()
        {
        }

        public Task(string description, Category category)
        {
            SetDetails(description, category);
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; private set; }

        public bool IsComplete { get; private set; }

        [Required]
        public Category Category { get; private set; }

        public void SetDetails(string description, Category category)
        {
            Description = description;
            Category = category;
        }

        public void MarkComplete()
        {
            IsComplete = true;
        }

        public void MarkIncomplete()
        {
            IsComplete = false;
        }
    }
}
