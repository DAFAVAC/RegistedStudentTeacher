using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class Subject
    {
        public Guid id = Guid.NewGuid();
        public string name { get; set; } = "";

        public Subject(string name)
        {
            id = Guid.NewGuid();
            this.name = name;
        }
    }
}
