using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    public class Course
    {
        public  Guid id { get; set; }
        public string name { get; set; }
        public string id_Career { get; set; } = "";

        public Course(string name)
        {
            id = Guid.NewGuid();
            this.name = name;
        }




    }
}
