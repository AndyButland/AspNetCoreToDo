namespace AspNetCoreToDo.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private Category()
        {
        }

        public Category(string name)
        {
            SetName(name);
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
