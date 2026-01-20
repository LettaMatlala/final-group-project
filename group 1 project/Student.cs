using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace group_1_project
{
    internal class Student
    {
        // Properties of the Student class
        public string Name { get; set; }
        public int Age { get; set; }
        public string StudentNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Constructor
        public Student(string name, int age, string studentnumber, string password, string email)
        {
            Name = name; 
            Age = age;
            StudentNumber = studentnumber;
            Password = password;
            this.Email = email;

        }

        // Generate correct password.
        // password == surname + last four numbers of your student number
        // Generate password based on name and last 4 digits of student number
        private string GeneratePassword()
        {
            string last4 = StudentNumber.Substring(StudentNumber.Length - 4);
            return Name + last4;
        }
        
        // Validate password
        //must not allow incorrect input on the password 
        public bool PasswordInput(string inputPassword)

        // Validate password
        public bool ValidatePassword(string inputPassword)
        {
            string correctPassword = GeneratePassword();

            if (inputPassword == correctPassword)
            {
                Console.WriteLine("Access granted");

                Console.WriteLine("Acess granted!");
                return true;
            }
            else
            {
                Console.WriteLine(" Access denied: Incorrect password");
                Console.WriteLine("access denied! Your password is incorrect");
                return false;
            }
        }

        // Method to display student information
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Student Number: {StudentNumber}, email{Email}");
        }
        
        //Method for student to enter password
        public bool EnterPassword(string inputPassword, string correctPassword)
        {
            return inputPassword == correctPassword;
        }

    }
}
