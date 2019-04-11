using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsharpFirstAssignmentWithDotNetFramework
{
    public static class StudentListHelper
    {
        public static void PopulateStudentList(ref List<Student> studentList, ref string inputFileStudents)
        {
            string studentInfo;
            if (File.Exists(inputFileStudents))
            {
                using (StreamReader sr = File.OpenText(inputFileStudents))
                {
                    while ((studentInfo = sr.ReadLine()) != null)
                    {
                        if (studentInfo.Length > 0)
                        {
                            string[] tmp = studentInfo.Split(',');
                            studentList.Add(new Student(tmp[0], tmp[1]));
                        }
                    }


                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }

        }

        public static void PopulateStudentResultList(ref List<StudentResult> studentResultList, ref string inputFileStudentResults)
        {
            string studentInfo;
            if (File.Exists(inputFileStudentResults))
            {
                using (StreamReader sr = File.OpenText(inputFileStudentResults))
                {
                    while ((studentInfo = sr.ReadLine()) != null)
                    {
                        if (studentInfo.Length > 0)
                        {
                            string[] tmp = studentInfo.Split(',');
                            studentResultList.Add(new StudentResult(tmp[0], tmp[1], float.Parse(tmp[2])));
                        }
                    }


                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }

        }

        public static Dictionary<string, float> CalculateCGPABuildResultDictionay(ref List<StudentResult> studentResultList)
        {
            Dictionary<string, float> resultDictionay =
                (from result in studentResultList
                 group result by result.Roll into resultGroup
                 select new
                 {
                     Roll = resultGroup.Key,
                     CGPA = resultGroup.Average(x => x.GPA),
                 }
                ).ToDictionary(x => x.Roll, x => x.CGPA);
            return resultDictionay;
        }

        public static void AssignCGPAToEachStudent(ref List<Student> studentList, ref Dictionary<string, float> resultDictionay)
        {
            foreach (Student student in studentList)
            {
                if (resultDictionay.ContainsKey(student.Roll))
                {
                    student.CGPA = resultDictionay[student.Roll];
                }
            }
        }
    }
}
