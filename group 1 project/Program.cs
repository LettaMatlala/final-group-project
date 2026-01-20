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
            string studentnumber = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your Password");
            string password = Convert.ToString(Console.ReadLine());

            // create a student instance 
            //call the student class so you can work with the methods
            Student student = new Student(name, age, studentnumber, password, string.Empty);

            const int MaxAttempts = 3;
            int attempts = 0;
            bool isValid = false;

            //create a while  looop that allows multiple attempts 
            while (attempts < MaxAttempts && !isValid) 
            {
                Console.WriteLine("Enterv your password. attempt" + attempts + 1 + "of" + MaxAttempts );
                string passwordAttempt = Convert.ToString(Console.ReadLine());

                switch (isValid) 
                {
                    case true:
                        Console.WriteLine("Welcome!");
                        student.DisplayInfo();
                        break;

                        case false: 
                        
                        attempts++;
                        if (attempts == MaxAttempts)
                        {
                            Console.WriteLine("You have entered an icorrect possword! please try again");
                        }
                        else
                        {
                            Console.WriteLine("try again");
                            // call the methods that handle failed log in 
                            //and display student summary / additional log in

                            student.DisplayInfo();

                        }
                        break;
                }
                
               

                



            }

          /*  // METHOD TO DISPLAY INFO
            student.DisplayInfo();
            
            //VALIDATE PASSWORD
            Console.WriteLine( "Please enter your password again to validate:");
            string inputPassword = Convert.ToString(Console.ReadLine());

            // LOOP UNTIL CORRECT PASSWORD IS ENTERED
            while (!student.ValidatePassword(inputPassword))
            {
                Console.WriteLine("Incorrect password. Please try again:");
                inputPassword = Convert.ToString(Console.ReadLine());

            }*/



        }



    }
}
