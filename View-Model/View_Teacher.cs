using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using sampleOneHsb.Models;

namespace sampleOneHsb.View_Model
{
    class View_Teacher
    {

        private string path = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\Teachers\";
        public void documentIndex(List<Teacher> _listTeacher)
        {
            foreach (string f in Directory.GetFiles(this.path))
            {
                string teacher = this.path + Path.GetFileName(f);
                using (StreamReader jsonStream = File.OpenText(teacher))
                {
                    var json = jsonStream.ReadToEnd();
                    Teacher product = JsonConvert.DeserializeObject<Teacher>(json);
                    _listTeacher.Add(product);
                }

            }
        }


        public object addTeachers(Guid id,string fullName, DateTime dateBirth, string adress, bool validation, string mail, string subject)
        {
            Teacher teachers = new Teacher(id,fullName, dateBirth, adress, validation, mail, subject);
            this.creatJson(teachers);
            return teachers;
        }



        public void creatJson(Teacher newTeacher)
        {
            string json = JsonConvert.SerializeObject(newTeacher);

            string idDocument = newTeacher.id.ToString();


            string path = this.path + idDocument + ".json";
            System.IO.File.WriteAllText(path, json);

        }

        public bool editJson(Guid id, string fullName, DateTime dateBirth, string adress, bool validation, string mail, string subject)
        {

            string path = this.path + id + ".json";
            System.IO.File.Delete(path);

            this.addTeachers(id, fullName, dateBirth, adress, validation, mail, subject);


            return true;


        }

        public void deletJson(Guid id)
        {
            string path = this.path + id + ".json";
            System.IO.File.Delete(path);
        }





    }
}
