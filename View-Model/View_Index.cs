using System;
using System.Collections.Generic;
using System.Text;
using sampleOneHsb.Models;

namespace sampleOneHsb.View_Model
{
    class View_Index
    {
        public List<Career> careerArr = new List<Career>();

        public List<Course> courseArr = new List<Course>();

        public List<Subject> subjectArr = new List<Subject>();



        public void initLists()
        {
            this.careerArr.Add(new Career("Web Development"));
            this.careerArr.Add(new Career("Communication"));
            this.careerArr.Add(new Career("Nursing"));

            this.courseArr.Add(new Course("A"));
            this.courseArr.Add(new Course("B"));
            this.courseArr.Add(new Course("C"));

            this.subjectArr.Add(new Subject("astronomy"));
            this.subjectArr.Add(new Subject("biology"));
            this.subjectArr.Add(new Subject("engineering"));
            this.subjectArr.Add(new Subject("medicine"));
            this.subjectArr.Add(new Subject("sex education"));
            this.subjectArr.Add(new Subject("physics"));
        }
    }
}
