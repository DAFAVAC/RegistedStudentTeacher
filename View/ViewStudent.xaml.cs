using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using sampleOneHsb.View_Model;
using sampleOneHsb.Models;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace sampleOneHsb
{
    /// <summary>
    /// Lógica de interacción para ViewStudent.xaml
    /// </summary>
    /// 
    public partial class ViewStudent : Window
    {
        List<StudentTaskDocument> tasksStudent { get; set; } = new List<StudentTaskDocument>();

        View_StudentSubject _StudentSubject = new View_StudentSubject();
        public ViewStudent()
        {
            InitializeComponent();
            this._StudentSubject.documentsTaskStudenSubject(this.tasksStudent);
            listStudentTask.ItemsSource = this.tasksStudent;
            
        }




        private void ToExcelMicrosot()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excel = new ExcelPackage())
            {
                ExcelWorksheet pageOne = excel.Workbook.Worksheets.Add("NombreHoja");

                pageOne.Cells[1, 1].Value = "Student";
                pageOne.Cells[1, 2].Value = "Subject";
                pageOne.Cells[1, 3].Value = "Task";
                pageOne.Cells[1, 4].Value = "Garde";

                for (int i = 0; i < this.tasksStudent.Count; i++)
                {
                    pageOne.Cells[i+2, 1].Value = this.tasksStudent[i].nameStudent;
                    pageOne.Cells[i+2, 2].Value = this.tasksStudent[i].nameSubject;
                    pageOne.Cells[i+2, 3].Value = this.tasksStudent[i].nameTask;
                    pageOne.Cells[i+2, 4].Value = this.tasksStudent[i].grade;
                }
                excel.SaveAs(new FileInfo(@"C:\Users\DANIEL\Documents\DAniTest.xlsx"));
            }


        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list = listStudentTask.ItemsSource;
            this.ToExcelMicrosot();
            MessageBox.Show("Document exported successfully ");
        }
    }
}
