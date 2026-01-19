using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace group_1_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // USER NAME
            Console.WriteLine("Enter your Name");
            string name = Convert.ToString(Console.ReadLine());

            // USER AGE
            Console.WriteLine("Enter your Age");
            int age = Convert.ToInt32(Console.ReadLine());

            // USER STUDENT NUMBER
            Console.WriteLine("Enter your Student Number");
            int studentnumber = Convert.ToInt32(Console.ReadLine());

            // USER PASSWORD
            Console.WriteLine("Enter your Password");
            string password = Convert.ToString(Console.ReadLine());

            // USER COURSE
            Console.WriteLine("Enter your Course");
            string course = Convert.ToString(Console.ReadLine());

            // Create Student Object
            Student student = new Student(name, age, studentnumber.ToString(), password, course);
            student.DisplayInfo();
            Console.WriteLine( "Please enter your password again to validate:");
            string inputPassword = Convert.ToString(Console.ReadLine());

            // loop until correct password is entered
            while (!student.ValidatePassword(inputPassword))
            {
                Console.WriteLine("Incorrect password. Please try again:");
                inputPassword = Convert.ToString(Console.ReadLine());
            }











        }



    }
}
