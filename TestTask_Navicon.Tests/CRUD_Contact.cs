using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask_Navicon.Models;
using Moq;
using TestTask_Navicon.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;

namespace TestTask_Navicon.Tests
{
    [TestClass]
    public class CRUD_Contact
    {
        [TestMethod]
        public void Contact_EditTest()
        {
            Mock<IContactRepository> mock = new Mock<IContactRepository>();
            mock.Setup(m => m.Contacts).Returns(new List<Contact>()
            {
                new Contact { ContactId = 1, Name = "11", Surname = "11" },
                new Contact { ContactId = 2, Name = "22", Surname = "22" },
                new Contact { ContactId = 3, Name = "33", Surname = "33" }
            });

            ContactController target = new ContactController(mock.Object);

            var result = (ViewResult)target.EditContact(1).ViewData.Model;

            Assert.AreEqual((result as Contact).ContactId, mock.Object.Contacts)
        }
    }
}
