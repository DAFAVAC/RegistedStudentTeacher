using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class CourseSubject
    {
        internal Guid id = Guid.NewGuid();
        public string id_Subject { get; set; } = "";
        public string id_Course { get; set; } = "";
    }
}
