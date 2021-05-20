using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using sampleOneHsb.Models;


namespace sampleOneHsb.View_Model
{
    class View_Student
    {
        
        private string path = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\Students\";

        public void documentIndex(List<Student> _listStudent )
        {
            foreach (string f in Directory.GetFiles(this.path))
            {
                string student = this.path+Path.GetFileName(f);
                using (StreamReader jsonStream = File.OpenText(student))
                {
                    var json = jsonStream.ReadToEnd();
                    Student product = JsonConvert.DeserializeObject<Student>(json);
                    _listStudent.Add(product);
                }

            }

        }



        public object addStudents(Guid id,string fullName, DateTime dateBirth, string adress, bool validation, string mail)
        {
            Student students = new Student(id,fullName, dateBirth, adress, validation, mail);
            this.creatJson(students);
            return students;
        }





        public void creatJson(Student newStudent)
        {
            string json = JsonConvert.SerializeObject(newStudent);

            string idDocument = newStudent.id.ToString();


            string path = this.path + idDocument + ".json";
            System.IO.File.WriteAllText(path, json);

        }

        public bool editJson(Guid id,string fullName, DateTime dateBirth, string adress, bool validation, string mail)
        {
            

            
            string path = this.path + id+".json";
            System.IO.File.Delete(path);

            this.addStudents(id,fullName, dateBirth, adress, validation, mail);


            return true;
        }

        public void deletJson(Guid id)
        {
            string path = this.path + id + ".json";
            System.IO.File.Delete(path);
        }


    }
}
