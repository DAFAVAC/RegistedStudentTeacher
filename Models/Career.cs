using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class Career
    {
        public Guid id { get; set; }
        public string name { get; set; } = "";
        public Career(string name)
        {
            id = Guid.NewGuid();
            this.name = name;
        }
    }
}
