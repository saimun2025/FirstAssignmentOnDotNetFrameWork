using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFirstAssignmentWithDotNetFramework
{
    public class Student
    {
        public string Name { get; set; }
        public string Roll { get; set; }
        public float CGPA { get; set; }
        public Student(string name, string roll, float cgpa = 0)
        {
            this.Name = name;
            this.Roll = roll;
            this.CGPA = CGPA;
        }
    }
}
