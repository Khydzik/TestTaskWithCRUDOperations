using System.ComponentModel.DataAnnotations;

namespace TestTask.Data.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }      
    }
}
