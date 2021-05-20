using System;
using System.Collections.Generic;
using System.Text;

namespace sampleOneHsb.Models
{
    class User
    {
#nullable enable
        internal Guid id { get; set; }
        public string fullName { get; set; } = "";
        public DateTime dateBirth { get; set; } =new DateTime();
        public string adress { get; set; } = "";
        public string mail { get; set; } = "";
        protected bool validation { get; set; } = true;

        public User(Guid id, string fullName, DateTime dateBirth, string adress, bool validation, string mail)
        {

        }
    }
}
