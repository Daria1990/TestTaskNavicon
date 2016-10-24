using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TestTask_Navicon.Infrastructure;

namespace TestTask_Navicon.Models
{
    public enum Sex { Male, Female };

    [MatchAgeByDateBirthAndAge]
    public class Contact
    {
        [HiddenInput(DisplayValue = false)]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length of Name is 100")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length of Surname is 100")]
        public string Surname { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length of Patronymic is 100")]
        public string Patronymic { get; set; }
        
        [DataType(DataType.Date, ErrorMessage = "Please enter Date")]
        [DataOfBirthRange(ErrorMessage = "DataOfBirth beyond the permissible values")]
        public DateTime? DateOfBirth { get; set; }

        [Range(0, Validation.MaxAge, ErrorMessage = "Age beyond the permissible values")]
        public int? Age { get; set; }

        [EnumDataType(typeof(Sex))]
        public Sex? Sex { get; set; }
        
    }
}