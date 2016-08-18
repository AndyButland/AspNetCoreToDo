namespace AspNetCoreToDo.Web.ViewModels.Tasks
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class TasksEditViewModel : AddOrEditSingleEntityViewModelBase
    {
        [Required(ErrorMessage = "Please provide a description")]
        [StringLength(500, ErrorMessage = "The description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public SelectList CategoryOptions { get; set; }
    }
}
