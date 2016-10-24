using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace TestTask_Navicon.Models
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            this.Property(c => c.Name).IsRequired().HasMaxLength(100);
            this.Property(c => c.Surname).IsRequired().HasMaxLength(100);
            this.Property(c => c.Patronymic).HasMaxLength(100);
        }
    }
}