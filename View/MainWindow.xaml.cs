using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sampleOneHsb.Models;
using sampleOneHsb.View_Model;

namespace sampleOneHsb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*
        public List<object> teachersArr { get; set; } = new List<object>() { };
        public List<object> studentsArr { get; set; } = new List<object>() { };
        public List<object> noteTaskArr { get; set; } = new List<object>() { };
        */


        public MainWindow()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterStudent registerStudentWindow = new RegisterStudent();
            //registerStudentWindow.listStudenView.ItemsSource = this.studentsArr;
  
            registerStudentWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterTeacher registerTeacherWindow = new RegisterTeacher();
            
            registerTeacherWindow.ShowDialog();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewTeacher viewTeacherWindow = new ViewTeacher();

            viewTeacherWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewStudent viewStudentWindow = new ViewStudent();

            viewStudentWindow.ShowDialog();
        }
        ///////////////////////////////////////////


    }
}
