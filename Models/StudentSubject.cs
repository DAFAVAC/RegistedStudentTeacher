using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class StudentSubject
    {
        public  Guid id { get; set; }
        public string id_Subject { get; set; } 
        public string id_Student { get; set; }

        public StudentSubject(Guid id, string id_Subject, string id_Student) 
        {

            this.id = id;
            this.id_Subject = id_Subject;
            this.id_Student = id_Student;

        }
    }
}
