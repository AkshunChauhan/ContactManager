using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyContacts.Models
{
    public class Contact
    {
        //PK for the Contact table
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; } = null!;

        //FK for the Category table
        [Required(ErrorMessage ="Please select a category")]
        public int? CategoryId { get; set; }

        //Navigation property
        [ValidateNever]
        public Category Category { get; set; } = null!;

        public DateTime DateAdded { get; set; }

        //Read only property that returns the full name of the contact
        public string Slug => FirstName?.Replace(' ','-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}
