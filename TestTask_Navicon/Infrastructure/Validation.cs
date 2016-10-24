using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TestTask_Navicon.Models;

namespace TestTask_Navicon.Infrastructure
{
    public class Validation
    {
        public const int MaxAge = 130;
    }


    public class MatchAgeByDateBirthAndAge : ValidationAttribute
    {
        public MatchAgeByDateBirthAndAge()
        {
            this.ErrorMessage = "Age doesn't match by date of birth and age";
        }

        public override bool IsValid(object value)
        {
            Contact contact = value as Contact;

            if (contact == null || contact.Age == null || contact.DateOfBirth == null)
                return true;

            int age = (int)contact.Age;
            DateTime dateOfBirth = (DateTime)contact.DateOfBirth;
            int yearDif = DateTime.Now.Year - dateOfBirth.Year;

            return yearDif - age == 0 || yearDif - age == 1;
        }
    }


    public class DataOfBirthRange : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            DateTime date = (DateTime)value;
            return date <= DateTime.Now && DateTime.Now <= date.AddYears(Validation.MaxAge);
        }
    }
}