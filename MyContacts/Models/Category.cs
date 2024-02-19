using System.ComponentModel.DataAnnotations;

namespace MyContacts.Models
{
    // Represents a category for contacts
    public class Category
    {
        // The unique identifier for the category
        public int CategoryId { get; set; }

        // The name of the category
        [Required(ErrorMessage = "The Name field is required.")] // Specifies that the Name property is required
        public string Name { get; set; } = null!; // Allows the Name property to be null and initializes it to null by default
    }
}
