using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para RegisterStudent.xaml
    /// </summary>
    public partial class RegisterStudent : Window
    {
        Regex rxAnyLetter = new Regex(@"[^\d]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex rxAnyNumber = new Regex(@"\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        View_Student _Student = new View_Student();
        public Guid idUserEdited_Delete { get; set; }
        private List<Student> studentsArr = new List<Student>(); 

        public RegisterStudent()
        {
            InitializeComponent();
            
            _Student.documentIndex(this.studentsArr);

            if (this.studentsArr.Count != 0)
            {
                listStudenView.ItemsSource=this.studentsArr;
            }
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MatchCollection matches = rxAnyLetter.Matches(dateYearText.Text);
            MatchCollection matches1 = rxAnyLetter.Matches(dateMounthText.Text);
            MatchCollection matches2 = rxAnyLetter.Matches(dateDayText.Text);

            MatchCollection matches3 = rxAnyNumber.Matches(nameText.Text);
            MatchCollection matches4 = rxAnyNumber.Matches(adressText.Text);
            MatchCollection matches5 = rxAnyNumber.Matches(mailText.Text);

            int[] validation = { matches.Count, matches1.Count, matches2.Count, matches3.Count, matches4.Count, matches5.Count };

            bool validBool = validation.Any(num => num != 0);


            if (validBool == false)
            {
                string year = dateYearText.Text;
                string mouth = dateMounthText.Text;
                string day = dateDayText.Text;

                var birdTeacher = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mouth), Convert.ToInt32(day), 7, 0, 0);
                var newStudent = _Student.addStudents(Guid.NewGuid(),nameText.Text, birdTeacher, adressText.Text, true, mailText.Text);

                if (newStudent != null)
                {
                    nameText.Text = "";
                    dateYearText.Text = "";
                    dateMounthText.Text = "";
                    dateDayText.Text = "";
                    adressText.Text = "";
                    mailText.Text = "";

                }

                MessageBox.Show("Registered");
            }
            else
            {
                MessageBox.Show("Data incorrect, verify your data");
            }
        }

        private void listStudenView_SelectionChanged(object sender, System.EventArgs e)
        {
            string jsonString = JsonConvert.SerializeObject(listStudenView.SelectedItem);
            Student product = JsonConvert.DeserializeObject<Student>(jsonString);

            nameText.Text = product.fullName;
            dateYearText.Text = product.dateBirth.Year.ToString();
            dateMounthText.Text = product.dateBirth.Month.ToString();
            dateDayText.Text = product.dateBirth.Day.ToString();
            adressText.Text = product.adress;
            mailText.Text = product.mail;

            this.idUserEdited_Delete = product.id;
            MessageBox.Show("You will be edit to user:  "+ product.fullName);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MatchCollection matches = rxAnyLetter.Matches(dateYearText.Text);
            MatchCollection matches1 = rxAnyLetter.Matches(dateMounthText.Text);
            MatchCollection matches2 = rxAnyLetter.Matches(dateDayText.Text);

            MatchCollection matches3 = rxAnyNumber.Matches(nameText.Text);
            MatchCollection matches4 = rxAnyNumber.Matches(adressText.Text);
            MatchCollection matches5 = rxAnyNumber.Matches(mailText.Text);

            int[] validation = { matches.Count, matches1.Count, matches2.Count, matches3.Count, matches4.Count, matches5.Count };

            bool validBool = validation.Any(num => num != 0);


            if (validBool == false)
            {
                string year = dateYearText.Text;
                string mouth = dateMounthText.Text;
                string day = dateDayText.Text;

                var birdTeacher = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mouth), Convert.ToInt32(day), 7, 0, 0);
                var newStudent = this._Student.editJson(this.idUserEdited_Delete, nameText.Text, birdTeacher, adressText.Text, true, mailText.Text);




                if (newStudent != null)
                {
                    nameText.Text = "";
                    dateYearText.Text = "";
                    dateMounthText.Text = "";
                    dateDayText.Text = "";
                    adressText.Text = "";
                    mailText.Text = "";

                }

                MessageBox.Show("User updated!");
            }
            else
            {
                MessageBox.Show("Data incorrect, verify your data");
            }


            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string jsonString = JsonConvert.SerializeObject(listStudenView.SelectedItem);
            Student product = JsonConvert.DeserializeObject<Student>(jsonString);
            this.idUserEdited_Delete = product.id;
            if (this.idUserEdited_Delete == null)
            {
                MessageBox.Show("Select any user by delet!");
            }
            if (this.idUserEdited_Delete != null)
            {
                var resul = MessageBox.Show("Do you want DELET to user selected?", "Delet User", MessageBoxButton.YesNo);

                if (resul == MessageBoxResult.Yes) { this._Student.deletJson(product.id); }
            }
        }
    }
}
