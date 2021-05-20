using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb
{
    class Task
    {
        public Guid id { get; set; }
        public string name { get; set; } = "";
        public int grade { get; set; } = 0;

        public Guid id_StudentSubject { get; set; }

        public Task(Guid id, string name, int grade, Guid id_StudentSubject)
        {
            this.id = id;
            this.name = name;
            this.grade = grade;
            this.id_StudentSubject = id_StudentSubject;
        }
        

    }
}
