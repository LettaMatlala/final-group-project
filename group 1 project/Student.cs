using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace group_1_project
{
    internal class Student
    {
        // Properties of the Student
        public string Name { get; set; }
        public int Age { get; set; }
        public string StudentNumber { get; set; }
        public string Password { get; set; }
        public string course { get; set; }

        // Constructor
        public Student(string name, int age, string studentnumber, string password, string course)
        {
            Name = name;
            Age = age;
            StudentNumber = studentnumber;
            Password = password;
            this.course = course;

        }
        // Method to display student information
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Student Number: {StudentNumber}");
        }

        //Method for student to enter password
        public bool EnterPassword(string inputPassword, string correctPassword)
        {
            return inputPassword == correctPassword;
        }

    }
}
