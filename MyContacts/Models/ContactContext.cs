using Microsoft.EntityFrameworkCore;

namespace MyContacts.Models
{
    // Represents the database context for the contacts application
    public class ContactContext : DbContext
    {
        // Constructor to initialize the context with options
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        // Represents the database table for contacts
        public DbSet<Contact> Contacts { get; set; } = null!;

        // Represents the database table for categories
        public DbSet<Category> Categories { get; set; } = null!;

        // Configures the initial data to be seeded into the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data for categories
            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryId = 1, Name = "Family" },
              new Category { CategoryId = 2, Name = "Friend" },
              new Category { CategoryId = 3, Name = "Work" }
            );

            // Seed initial data for contacts
            modelBuilder.Entity<Contact>().HasData(
              new Contact
              {
                  ContactId = 1,
                  FirstName = "Akshun",
                  LastName = "Chauhan",
                  PhoneNumber = "123-456-7890",
                  Email = "akshunchauhan@gmail.com",
                  CategoryId = 1,
              },
              new Contact
              {
                  ContactId = 2,
                  FirstName = "Rohit",
                  LastName = "LNU",
                  PhoneNumber = "123-456-7890",
                  Email = "rohit@gmail.com",
                  CategoryId = 1,
              },
              new Contact
              {
                  ContactId = 3,
                  FirstName = "Sam",
                  LastName = "Singh",
                  PhoneNumber = "123-456-7890",
                  Email = "Singh09@gmail.com",
                  CategoryId = 2,
              }
            );
        }
    }
}
