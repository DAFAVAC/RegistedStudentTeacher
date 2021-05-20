using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class Teacher:User
    {

        public dynamic id { get; set; } 
        public string specialty { get; set; }
        
        public Teacher(Guid id, string fullName, DateTime dateBirth, string adress, bool validation, string mail, string _specialty )
            : base(id, fullName, dateBirth, adress, validation, mail)
        {
            this.id = id;
            this.fullName = fullName;
            this.dateBirth = dateBirth;
            this.adress = adress;
            this.mail = mail;
            this.validation = validation;
            specialty = _specialty;
            
        }
         


    }
}
