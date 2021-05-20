using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class StudentTaskDocument
    {
        public string nameStudent { get; set; }
        public string nameSubject { get; set; }
        public string nameTask { get; set; }
        public int grade { get; set; }
        public StudentTaskDocument(string nameStudent, string nameSubject, string nameTask, int grade)
        {
            this.nameStudent = nameStudent;
            this.nameSubject = nameSubject;
            this.nameTask = nameTask;
            this.grade = grade;

        }

    }
}
