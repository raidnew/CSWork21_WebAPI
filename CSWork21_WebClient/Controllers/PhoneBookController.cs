using CSWork21.Enities;
using CSWork21.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSWork21_WebClient.Controllers
{
    public class PhoneBookController : Controller
    {
        
        private IPhoneBookEntries _phoneBookContext;

        public PhoneBookController(IPhoneBookEntries phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        public IActionResult ContactsList()
        {
            ViewBag.contacts = _phoneBookContext.GetContacts();
            return View();
        }

        public IActionResult ContactInfo(int id)
        {
            ViewBag.contact = _phoneBookContext.GetContactByID(id);
            return View();
        }

        [HttpGet]
        public IActionResult ContactEdit(int id)
        {
            ViewBag.contact = _phoneBookContext.GetContactByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult ContactEdit(int id, string firstName, string lastName, string thirdName, string phone, string address, string desc)
        {
            Contact contact = new Contact();
            contact.Id = id;
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.ThirdName = thirdName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Desc = desc;
            _phoneBookContext.EditContact(contact);
            return Redirect("/PhoneBook/ContactsList");
        }

        public IActionResult ContactAdd(string firstName, string lastName, string thirdName, string phone, string address, string desc)
        {
            Contact contact = new Contact();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.ThirdName = thirdName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Desc = desc;
            _phoneBookContext.AddContact(contact);
            return Redirect("/PhoneBook/ContactsList");
        }

        public IActionResult ContactAdding()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult ContactRemove(int id)
        {
            _phoneBookContext.RemoveContact(id);
            return Redirect("/PhoneBook/ContactsList");
        }
    }
}
