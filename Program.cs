using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsharpFirstAssignmentWithDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileStudents = System.Configuration.ConfigurationManager.AppSettings["inputFileForStudent"];
            string inputFileStudentResults = System.Configuration.ConfigurationManager.AppSettings["inputFileForStudentResult"];
            List<Student> studentList = new List<Student>();
            List<StudentResult> studentResultList = new List<StudentResult>();
            StudentListHelper.PopulateStudentList(ref studentList, ref inputFileStudents);
            StudentListHelper.PopulateStudentResultList(ref studentResultList, ref inputFileStudentResults);
            Dictionary<string, float> resultDictionay = StudentListHelper.CalculateCGPABuildResultDictionay(ref studentResultList);
            StudentListHelper.AssignCGPAToEachStudent(ref studentList, ref resultDictionay);
            var list = studentList.OrderBy(student => student.CGPA).ThenBy(student => student.Roll).ThenBy(student => student.Name);
            string outputFilePath = System.Configuration.ConfigurationManager.AppSettings["StudentResultOutput"];
            using (StreamWriter sw = File.Exists(outputFilePath) ? new StreamWriter(outputFilePath, true) : File.CreateText(outputFilePath))
            {
                Console.WriteLine("Final Result: ");
                sw.WriteLine("Final Result: ");
                foreach (Student student in list)
                {
                    Console.WriteLine(" Roll: {0} \t\t Name: {1} \t\t CG: {2}", student.Roll, student.Name, student.CGPA.ToString("n2"));
                    sw.WriteLine(" Roll: {0} \t\t Name: {1} \t\t CG: {2}", student.Roll, student.Name, student.CGPA.ToString("n2"));
                }

            }
            
            Console.ReadLine();

        }

    }
}
