using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class Student:User
    {
#nullable enable
        public Guid id { get; set; }
        public  string disciplin { get; set; }

        public Student(Guid id, string fullName, DateTime dateBirth, string adress, bool validation, string mail)
            : base(id,fullName , dateBirth, adress, validation, mail)
        {
            this.id =id;
            this.fullName = fullName;
            this.dateBirth = dateBirth;
            this.validation = validation;
            this.adress = adress;
            this.mail = mail;
            this.disciplin = "";
        }

        
    }
}
