using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyContacts.Models;
using System; // Added for DateTime

namespace MyContacts.Controllers
{
    public class ContactController : Controller
    {
        ContactContext _ctx; // Declare ContactContext field

        // Constructor to inject ContactContext
        public ContactController(ContactContext ctx)
        {
            _ctx = ctx; // Assign injected context to _ctx field
        }

        // Action method for displaying the contact list
        public IActionResult Index()
        {
            return View();
        }

        // GET action method for adding a new contact
        [HttpGet]
        public IActionResult Add()
        {
            // Pass list of categories to the view bag
            ViewBag.Categories = _ctx.Categories.ToList();
            ViewBag.Action = "Add"; // Indicate the action as "Add"
            return View("AddEdit", new Contact()); // Pass an empty contact object to the view
        }

        // GET action method for editing an existing contact
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the contact by id
            var contact = _ctx.Contacts.Find(id);
            // Pass list of categories to the view bag
            ViewBag.Categories = _ctx.Categories.ToList();
            ViewBag.Action = "Edit"; // Indicate the action as "Edit"
            return View("AddEdit", contact); // Pass the contact object to the view for editing
        }

        // POST action method for adding/editing a contact
        [HttpPost]
        public IActionResult AddEdit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0) // If it's a new contact
                {
                    contact.DateAdded = DateTime.Now; // Set the date added to current date and time
                    _ctx.Contacts.Add(contact); // Add the contact to the context
                }
                else // If it's an existing contact
                {
                    _ctx.Contacts.Update(contact); // Update the contact
                }
                _ctx.SaveChanges(); // Save changes to the database
                return RedirectToAction("Index", "Home"); // Redirect to home page after adding/editing
            }
            ViewBag.Categories = _ctx.Categories.ToList(); // Pass list of categories to the view bag
            return View(contact); // Return the view with the contact object
        }

        // GET action method for displaying delete confirmation
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _ctx.Contacts.Find(id); // Find the contact by id
            return View(contact); // Return the view with the contact object
        }

        // POST action method for deleting a contact
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            _ctx.Contacts.Remove(contact); // Remove the contact from the context
            _ctx.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index", "Home"); // Redirect to home page after deletion
        }

        // GET action method for displaying contact details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _ctx.Contacts.Include(contact => contact.Category).FirstOrDefault(c => c.ContactId == id);
            // Include category information for the contact
            return View(contact); // Return the view with the contact object
        }
    }
}
