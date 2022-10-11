using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToRemove = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsToPrint = new List<Student>();
            studentsToPrint = students.Where(x => x.Subject == subject).ToList();
            StringBuilder output = new StringBuilder();

            if (studentsToPrint.Count > 0)
            {
                output.AppendLine($"Subject: {subject}");
                output.AppendLine("Students:");

                foreach (var student in studentsToPrint)
                {
                    output.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }
            else
            {
                output.Append("No students enrolled for the subject");
            }

            return output.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Count;
        }
        
        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
