using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using sampleOneHsb.Models;

namespace sampleOneHsb.View_Model
{
    class View_Course
    {
        private string dirStudent = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\Students\";
        private string dirTeacher = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\Teachers\";
        

        public void documentIndex(List<Student> _listStudent, List<Teacher> _listTeacher)
        {
            foreach (string f in Directory.GetFiles(this.dirStudent))
            {
                string student = this.dirStudent + Path.GetFileName(f);
                using (StreamReader jsonStream = File.OpenText(student))
                {
                    var json = jsonStream.ReadToEnd();
                    Student product = JsonConvert.DeserializeObject<Student>(json);
                    _listStudent.Add(product);
                }

            }
            foreach (string f in Directory.GetFiles(this.dirTeacher))
            {
                string student = this.dirTeacher + Path.GetFileName(f);
                using (StreamReader jsonStream = File.OpenText(student))
                {
                    var json = jsonStream.ReadToEnd();
                    Teacher product = JsonConvert.DeserializeObject<Teacher>(json);
                    _listTeacher.Add(product);
                }

            }

        }


        







    }
}
