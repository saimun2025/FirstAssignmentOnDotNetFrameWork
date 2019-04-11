using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFirstAssignmentWithDotNetFramework
{
    public class StudentResult
    {
        public string Subject { get; set; }
        public string Roll { get; set; }
        public float GPA { get; set; }

        public StudentResult(string roll, string subject, float gpa = 0)
        {
            this.Subject = subject;
            this.Roll = roll;
            this.GPA = gpa;
        }
    }
}
