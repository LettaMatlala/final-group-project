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
            // ASK USER FOR INPUT
            Console.WriteLine("Enter your Name");
            string name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your Age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Email");
            string email = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your Student Number");
            int studentnumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Password");
            string password = Convert.ToString(Console.ReadLine());


            //INTANCE OF STUDENT CLASS
            Student student = new Student(name, age, studentnumber.ToString(), password, email);

            // METHOD TO DISPLAY INFO
            student.DisplayInfo();
            
            // VALIDATE PASSWORD
            Console.WriteLine( "Please enter your password again to validate:");
            string inputPassword = Convert.ToString(Console.ReadLine());

            // LOOP UNTIL CORRECT PASSWORD IS ENTERED
            while (!student.ValidatePassword(inputPassword))
            {
                Console.WriteLine("Incorrect password. Please try again:");
                inputPassword = Convert.ToString(Console.ReadLine());

            }

           









        }



    }
}
