using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask_Navicon.Models;
using TestTask_Navicon.Infrastructure;
using PagedList;

namespace TestTask_Navicon.Controllers
{
    public class ContactController : Controller
    {
        private ContactList contactList;

        public ContactController(IContactRepository rep)
        {
            contactList = new ContactList(rep);
        }
        
        public ActionResult ListAjax(int? page, string selectedField)
        {
            ViewBag.selectedField = selectedField;
            ViewBag.page = page;
            if (Request.IsAjaxRequest())
                return PartialView("ContactGrid", contactList.GetContactList(page, selectedField));
            else
                return View(contactList.GetContactList(page, selectedField));
        }

        [HttpPost]
        public ActionResult ListAjax(int[] selectedContacts)
        {
            int count = 0;
            if (selectedContacts != null)
            {
                count = selectedContacts.Count();
                contactList.Repository.Delete(selectedContacts);
            }
            TempData["Message"] = string.Format("{0} Items deleted", count);
            return RedirectToAction("ListAjax");
        }

        public ViewResult EditContact(int? contactID)
        {
            Contact editContact = contactList.GetContact((int)contactID);
            return View(editContact);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactList.Repository.Save(contact);
                TempData["Message"] = string.Format("Contact {0} {1} has been saved", contact.Name, contact.Surname);
                return RedirectToAction("ListAjax");
            }
            else
                return View(contact);
        }

        public ViewResult CreateContact()
        {
            return View("EditContact", new Contact());
        }
    }
}