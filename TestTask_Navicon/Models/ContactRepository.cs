using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_Navicon.Models
{
    public class ContactRepository : IContactRepository
    {
        private DbEntityContext context = new DbEntityContext();

        public IEnumerable<Contact> Contacts
        {
            get { return context.Contacts; }
        }

        public void Delete(int[] selectedContacts)
        {
            if (selectedContacts == null) return;

            foreach (int sc in selectedContacts)
            {
                Contact contact = context.Contacts.Find(sc);
                if (contact != null)
                    context.Contacts.Remove(contact);
            }
            context.SaveChanges();
        }

        public void Save(Contact contact)
        {
            if (contact.ContactId == 0)
                context.Contacts.Add(contact);
            else
            {
                Contact editContact = context.Contacts.Find(contact.ContactId);
                if (editContact != null)
                {
                    editContact.Age = contact.Age;
                    editContact.DateOfBirth = contact.DateOfBirth;
                    editContact.Name = contact.Name;
                    editContact.Patronymic = contact.Patronymic;
                    editContact.Sex = contact.Sex;
                    editContact.Surname = contact.Surname;
                }
            }
            context.SaveChanges();
        }
    }
}