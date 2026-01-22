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

            // --- CHANGES START HERE (line 31 onward) ---
            // Validate age (up to 3 attempts) — don't change the top inputs, validate here
            int validatedAge = age;
            int ageAttempts = 0;
            const int MaxFieldAttempts = 3;
            while ((validatedAge <= 0 || validatedAge > 120) && ageAttempts < MaxFieldAttempts)
            {
                ageAttempts++;
                Console.ForegroundColor = (ageAttempts == MaxFieldAttempts) ? ConsoleColor.Red : (ageAttempts == MaxFieldAttempts - 1 ? ConsoleColor.Yellow : ConsoleColor.Red);
                Console.WriteLine(ageAttempts == MaxFieldAttempts
                    ? "Invalid age entered too many times. Exiting."
                    : (ageAttempts == MaxFieldAttempts - 1 ? "Warning: One attempt left for Age." : "Invalid age. Enter a number between 1 and 120."));
                Console.ResetColor();

                if (ageAttempts >= MaxFieldAttempts)
                {
                    return;
                }

                Console.WriteLine("Re-enter your Age:");
                string ageInput = Convert.ToString(Console.ReadLine());
                int parsed;
                if (int.TryParse(ageInput, out parsed))
                {
                    validatedAge = parsed;
                }
            }

            // Validate student number (last 4 characters must be digits) — up to 3 attempts
            string validatedStudentNumber = studentnumber ?? string.Empty;
            int idAttempts = 0;
            while ((validatedStudentNumber.Length < 4 || !validatedStudentNumber.Substring(validatedStudentNumber.Length - 4).All(char.IsDigit)) && idAttempts < MaxFieldAttempts)
            {
                idAttempts++;
                Console.ForegroundColor = (idAttempts == MaxFieldAttempts) ? ConsoleColor.Red : (idAttempts == MaxFieldAttempts - 1 ? ConsoleColor.Yellow : ConsoleColor.Red);
                Console.WriteLine(idAttempts == MaxFieldAttempts
                    ? "Invalid student number entered too many times. Exiting."
                    : (idAttempts == MaxFieldAttempts - 1 ? "Warning: One attempt left for Student Number. Last 4 characters must be digits." : "Invalid student number. Ensure the last 4 characters are digits."));
                Console.ResetColor();

                if (idAttempts >= MaxFieldAttempts)
                {
                    return;
                }

                Console.WriteLine("Re-enter your Student Number:");
                validatedStudentNumber = Convert.ToString(Console.ReadLine()) ?? string.Empty;
            }

            // Create the student instance only after validating age and student number
            Student student = new Student(name, validatedAge, validatedStudentNumber, password ?? string.Empty, email ?? string.Empty);

            // PASSWORD attempts — must match generated password (Name + last 4 digits of student number)
            const int MaxAttempts = 3;
            int attempts = 0;
            bool isValid = false;

            // Precompute expected password parts to give clearer feedback when incorrect
            string expectedLast4 = validatedStudentNumber.Length >= 4 ? validatedStudentNumber.Substring(validatedStudentNumber.Length - 4) : string.Empty;
            string expectedPassword = name + expectedLast4;

            while (attempts < MaxAttempts && !isValid)
            {
                Console.WriteLine("Enter your password. attempt " + (attempts + 1) + " of " + MaxAttempts);
                string passwordAttempt = Convert.ToString(Console.ReadLine());

                if (student.ValidatePassword(passwordAttempt))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Welcome! Access granted.");
                    student.DisplayInfo();
                    Console.ResetColor();
                    isValid = true;
                    break;
                }

                attempts++;

                // If the typed password matches pattern but not correct (unlikely), still treat as incorrect.
                // Provide specific feedback whether the entered password does not correspond to supplied name/student number
                if (passwordAttempt != expectedPassword)
                {
                    Console.ForegroundColor = (attempts == MaxAttempts) ? ConsoleColor.Red : (attempts == MaxAttempts - 1 ? ConsoleColor.Yellow : ConsoleColor.Red);
                    if (attempts == MaxAttempts)
                    {
                        Console.WriteLine("Password incorrect and does not correspond to given Name/Student Number. Access denied.");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to exit...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ReadKey(true);
                        Console.ResetColor();
                        return;
                    }

                    if (attempts == MaxAttempts - 1)
                    {
                        Console.WriteLine("Warning: One attempt left. The password should be your Name followed by the last 4 digits of your Student Number.");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Make sure it corresponds to your Name + last 4 digits of Student Number.");
                    }
                    Console.ResetColor();
                }
                else
                {
                    // entered exactly expected format but still failed(wrong characters); generic feedback
                    Console.ForegroundColor = (attempts == MaxAttempts) ? ConsoleColor.Red : (attempts == MaxAttempts - 1 ? ConsoleColor.Yellow : ConsoleColor.Red);
                    if (attempts == MaxAttempts)
                    {
                        Console.WriteLine("Incorrect password entered too many times. Access denied.");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to exit...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ReadKey(true);
                        Console.ResetColor();
                        return;
                    }

                    if (attempts == MaxAttempts - 1)
                    {
                        Console.WriteLine("Warning: One attempt left :-(");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Please try again.");
                    }
                    Console.ResetColor();
                }

                // a briefnyana to display student summary after incorrect attempts
                student.DisplayInfo();
            }

            
        }



    }
}
