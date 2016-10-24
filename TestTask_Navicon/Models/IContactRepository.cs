using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Navicon.Models
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Contacts { get; }

        void Delete(int[] selectedContacts);

        void Save(Contact contact);
    }
}
