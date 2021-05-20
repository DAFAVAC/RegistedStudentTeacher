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
    /// Lógica de interacción para RegisterTeacher.xaml
    /// </summary>
    public partial class RegisterTeacher : Window
    {
        Regex rxAnyLetter = new Regex(@"[^\d]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex rxAnyNumber = new Regex(@"\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        View_Teacher _Teacher = new View_Teacher();

        public Guid idUserEdited_Delete { get; set; }
        private List<Teacher> teachersArr = new List<Teacher>();

        public RegisterTeacher()
        {
            InitializeComponent();
            _Teacher.documentIndex(this.teachersArr);

            if (this.teachersArr.Count != 0)
            {
                listTeacherView.ItemsSource = this.teachersArr;
            }
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {

            MatchCollection matches = rxAnyLetter.Matches(dateYearText.Text);
            MatchCollection matches1 = rxAnyLetter.Matches(dateMounthText.Text);
            MatchCollection matches2 = rxAnyLetter.Matches(dateDayText.Text);

            MatchCollection matches3 = rxAnyNumber.Matches(nameText.Text);
            MatchCollection matches4 = rxAnyNumber.Matches(adressText.Text);
            MatchCollection matches5 = rxAnyNumber.Matches(mailText.Text);
            MatchCollection matches6 = rxAnyNumber.Matches(specialtyText.Text);

            int[] validation = { matches.Count, matches1.Count, matches2.Count, matches3.Count, matches4.Count, matches5.Count, matches6.Count };

            bool validBool = validation.Any(num => num!=0);


            if (validBool==false)
            {

                string year = dateYearText.Text;
                string mouth = dateMounthText.Text;
                string day = dateDayText.Text;

                var birdTeacher = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mouth), Convert.ToInt32(day), 7, 0, 0);
                var newTeacher = this._Teacher.addTeachers(Guid.NewGuid(), nameText.Text, birdTeacher, adressText.Text, true, mailText.Text, specialtyText.Text);
                


                if (newTeacher != null)
                {
                    nameText.Text = "";
                    dateYearText.Text = "";
                    dateMounthText.Text = "";
                    dateDayText.Text = "";
                    adressText.Text = "";
                    mailText.Text = "";
                    specialtyText.Text = "";


                }

                MessageBox.Show("Registered");

            }
            else
            {
                MessageBox.Show("Data incorrect, verify your data");
            }
            
        }

        private void listTeacherView_MouseDoubleClick(object sender, System.EventArgs e)
        {
            string jsonString = JsonConvert.SerializeObject(listTeacherView.SelectedItem);
            Teacher product = JsonConvert.DeserializeObject<Teacher>(jsonString);

            nameText.Text = product.fullName;
            dateYearText.Text = product.dateBirth.Year.ToString();
            dateMounthText.Text = product.dateBirth.Month.ToString();
            dateDayText.Text = product.dateBirth.Day.ToString();
            adressText.Text = product.adress;
            mailText.Text = product.mail;
            specialtyText.Text = product.specialty;

            this.idUserEdited_Delete = product.id;
            MessageBox.Show("You will be edit to user:  " + product.fullName);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            MatchCollection matches = rxAnyLetter.Matches(dateYearText.Text);
            MatchCollection matches1 = rxAnyLetter.Matches(dateMounthText.Text);
            MatchCollection matches2 = rxAnyLetter.Matches(dateDayText.Text);

            MatchCollection matches3 = rxAnyNumber.Matches(nameText.Text);
            MatchCollection matches4 = rxAnyNumber.Matches(adressText.Text);
            MatchCollection matches5 = rxAnyNumber.Matches(mailText.Text);
            MatchCollection matches6 = rxAnyNumber.Matches(specialtyText.Text);

            int[] validation = { matches.Count, matches1.Count, matches2.Count, matches3.Count, matches4.Count, matches5.Count, matches6.Count };

            bool validBool = validation.Any(num => num != 0);


            if (validBool == false)
            {

                string year = dateYearText.Text;
                string mouth = dateMounthText.Text;
                string day = dateDayText.Text;

                var birdTeacher = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mouth), Convert.ToInt32(day), 7, 0, 0);
                var newTeacher = this._Teacher.editJson(this.idUserEdited_Delete, nameText.Text, birdTeacher, adressText.Text, true, mailText.Text, specialtyText.Text);



                if (newTeacher != null)
                {
                    nameText.Text = "";
                    dateYearText.Text = "";
                    dateMounthText.Text = "";
                    dateDayText.Text = "";
                    adressText.Text = "";
                    mailText.Text = "";
                    specialtyText.Text = "";


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
            string jsonString = JsonConvert.SerializeObject(listTeacherView.SelectedItem);
            Teacher product = JsonConvert.DeserializeObject<Teacher>(jsonString);
            this.idUserEdited_Delete = product.id;
            if (this.idUserEdited_Delete == null)
            {
                MessageBox.Show("Select any user by delet!");
            }
            if (this.idUserEdited_Delete != null)
            {
                var resul = MessageBox.Show("Do you want DELET to user selected?", "Delet User", MessageBoxButton.YesNo);

                if ( resul == MessageBoxResult.Yes) { this._Teacher.deletJson(product.id); }
            }
        }
    }
}
