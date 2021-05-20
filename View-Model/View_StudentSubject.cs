using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using sampleOneHsb.Models;

namespace sampleOneHsb.View_Model
{
    class View_StudentSubject
    {

        private string path = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\Tasks\";

        private string dir = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\StudentSubject\";
        public Guid StudentSubjectId(string idStudent, string idSubject) 
        {
            StudentSubject studentSubject = new StudentSubject(Guid.NewGuid(), idSubject , idStudent);

            string json = JsonConvert.SerializeObject(studentSubject);

            string path = this.dir + studentSubject.id + ".json";
            System.IO.File.WriteAllText(path, json);

            return studentSubject.id;
        }


        public void createJsonTask(Guid id, string name, int grade, Guid id_StudentSubject) 
        {

            Task taskObject = new Task( id, name, grade,  id_StudentSubject);




            string json = JsonConvert.SerializeObject(taskObject);

            string idDocument = taskObject.id.ToString();


            string path = this.path + idDocument + ".json";
            System.IO.File.WriteAllText(path, json);
        }




        private string dirSubjectStudent = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\StudentSubject\";
        private string dirTask = @"C:\Users\DANIEL\source\repos\sampleOneHsb\sampleOneHsb\DATA\Tasks\";



        public bool documentsTaskStudenSubject(List<StudentTaskDocument> tasksStudent)
        {
            foreach (string f in Directory.GetFiles(this.dirTask))
            {
                string task = this.dirTask + Path.GetFileName(f);
                using (StreamReader jsonStream = File.OpenText(task))
                {
                    var json = jsonStream.ReadToEnd();

                    Task taskClass = JsonConvert.DeserializeObject<Task>(json);

                    string idForeign = Convert.ToString(taskClass.id_StudentSubject);

                    string jsonBusjectStudent = this.dirSubjectStudent + idForeign + ".json";

                    StudentSubject subjectStudentClass;

                        using (StreamReader json1Stream = File.OpenText(jsonBusjectStudent))
                        {
                            var json1 = json1Stream.ReadToEnd();
                            subjectStudentClass = JsonConvert.DeserializeObject<StudentSubject>(json1);

                        }


                    StudentTaskDocument studentDocumentStruct = new StudentTaskDocument(subjectStudentClass.id_Student, subjectStudentClass.id_Subject, taskClass.name, taskClass.grade);


                    tasksStudent.Add(studentDocumentStruct);
                }

            }
            return true;
        }
    }
}
