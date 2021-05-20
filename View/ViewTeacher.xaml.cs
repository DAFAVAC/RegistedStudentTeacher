using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using sampleOneHsb.Models;
using sampleOneHsb.View_Model;


namespace sampleOneHsb
{
    /// <summary>
    /// Lógica de interacción para ViewTeacher.xaml
    /// </summary>
    public partial class ViewTeacher : Window
    {

        Regex rxAnyLetter = new Regex(@"[^\d]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex rxAnyNumber = new Regex(@"\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);


        View_Course _Course = new View_Course();
        View_Index _Index = new View_Index();
        View_StudentSubject _StudentSubject = new View_StudentSubject();
        List<Teacher> teachersArr = new List<Teacher>();
        List<Student> studentsArr = new List<Student>();
        

        public ViewTeacher()
        {
            InitializeComponent();
            _Course.documentIndex(this.studentsArr, this.teachersArr);
            this._Index.initLists();
            this.inputDataUsers();
            
        }





        public void inputDataUsers() 
        {

            for (int i = 0; i < this.teachersArr.Count; i++)
            {
                teacherComboBox.Items.Add(this.teachersArr[i].fullName);
            }
            for (int i = 0; i < this.studentsArr.Count; i++)
            {
                studentComboBox.Items.Add(this.studentsArr[i].fullName);
            }
            
            for (int i = 0; i < this._Index.subjectArr.Count; i++)
            {
                SubjectComboBox.Items.Add(this._Index.subjectArr[i].name);
            }

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {



            
            string jsonStudentr = Convert.ToString(studentComboBox.SelectedItem);
            string jsonSubject = Convert.ToString(SubjectComboBox.SelectedItem);
            

            MatchCollection matches4 = rxAnyLetter.Matches(gradeText.Text);
            MatchCollection matches5 = rxAnyNumber.Matches(taskText.Text);

            int[] validation = { matches4.Count, matches5.Count };

            bool validBool = validation.Any(num => num != 0);


            if (validBool != true)
            {

                Guid StudentSubjectId = _StudentSubject.StudentSubjectId(jsonStudentr, jsonSubject);
                _StudentSubject.createJsonTask(Guid.NewGuid(), taskText.Text, Convert.ToInt32(gradeText.Text), StudentSubjectId);
                gradeText.Text = "";
                taskText.Text = "";

                MessageBox.Show("Grade registered");

            }
            else { MessageBox.Show("Review your data."); }

        }
    }
}
