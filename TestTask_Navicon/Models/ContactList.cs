using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Reflection;
using PagedList;
using TestTask_Navicon.Infrastructure;
using System.Linq.Expressions;

namespace TestTask_Navicon.Models
{
    public class ContactList
    {
        public IContactRepository Repository { get; private set; }

        public int PageSize
        {
            get { return 10; }
        }
       
        public ContactList(IContactRepository repository)
        {
            this.Repository = repository;
        }

        public IPagedList<Contact> GetContactList(int? pageID, string sortedField)
        {
            if (Repository.Contacts == null || Repository.Contacts.Count() == 0)
                return null;

            if (string.IsNullOrEmpty(sortedField))
                return Repository.Contacts.OrderBy(m=>m.Name).ToPagedList(pageID ?? 1, this.PageSize);

            List<string> availableField = GetAllProperties(typeof(Contact));

            if (!availableField.Contains(sortedField))
                throw new ArgumentException(string.Format("You can't sort by field {0}", sortedField));

            PropertyInfo property = typeof(Contact).GetProperty(sortedField);

            return Repository.Contacts.OrderBy(sortedField).ToPagedList(pageID ?? 1, this.PageSize);
        }

        public Contact GetContact(int? contactID)
        {
            return Repository.Contacts.FirstOrDefault(p => p.ContactId == contactID);
        }

        private static List<string> GetAllProperties(Type type)
        {
            PropertyInfo[] propInfos = type.GetProperties();

            List<string> result = new List<string>();
            foreach (var propInfo in propInfos)
                result.Add(propInfo.Name);

            return result;
        }
    }
}