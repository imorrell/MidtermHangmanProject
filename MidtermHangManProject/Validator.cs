using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MidtermHangManProject
{
    class Validator
    {
        public static DateTime ValidDate(string message)
        {
            try
            {
                return DateTime.Parse(GetUserInput(message));
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is not a valid date. Try again. \n");
                Console.ResetColor();

                //use recursion to recall the method
                return ValidDate(message);
            }
        }

        public static string LetterInputOnly(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            Console.WriteLine();

            //check to see if input is alphabet only

            if (Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
            {
                return input;
            }
            else
            {
                //input is not all alphabet. Return message and recall method
                Console.WriteLine("Wrong input! must contain letters only. \n");
                return LetterInputOnly(message);
            }
        }

        public static int ValidateRange(string message, int min, int max)
        {
            int number = ParseString(message);

            Console.WriteLine();

            if (number >= min && number < max)
            {
                return number;
            }
            else
            {
                //This student does not exist
                Console.WriteLine("This choice does not exist.\n");
                return ValidateRange(message, min, max);
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad input. We need a number \n");
                return ParseString(message);
            }

        }

        public static string GetUserInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            return input;
        }

        public static bool GetContinue()
        {
            //create variables
            String choice;
            bool ok = true;
            bool result = true;

            //create while loop to determine if user wants to continue
            while (ok)
            {
                Console.WriteLine("Play again? (y/n)\n");

                //retrieve user input
                choice = Console.ReadLine();

                //determine the users input and return corresponding message
                if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    //user wants to continue. exit the while loop and return true
                    ok = false;
                    result = true;
                }
                else if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    //user does not want to continue
                    ok = false;
                    result = false;
                }
                else
                {
                    //user did not enter y or n
                    Console.WriteLine("Error! Please enter Y or N. Please enter correct input");

                }

            }

            return result;
        }


        /*
            * Get double within range method checks to see if the user enters a double
            * and also checks to see if the double is within the given range given by
            * the user
            */
        public static double GetDoubleWithinRange(double min, double max)
        {
            //Create variable that will return the users input if it is true
            double numberValue = 0.0;

            //Use boolean to control while loop
            bool isValid = false;

            //While loop
            while (isValid == false)
            {
                //propmt the user to enter 

                numberValue = double.Parse(Console.ReadLine());

                //use if else loop to check for the number value to see if its in 
                //correct range
                if (numberValue <= min)
                {
                    Console.WriteLine("Error! Number must be greate than " + min + ".");

                }
                else if (numberValue >= max)
                {
                    Console.WriteLine("Error! Number must be less than " + max + ".");
                }
                else
                {
                    isValid = true;
                }
            }
            return numberValue;

        }

        /*
         * Get int within range method checks to see if the user enters a int value
         * and also checks to see if the double is within the given range given by
         * the user
         */

        public static int GetIntWithinRange(int min, int max)
        {
            //Create variable that will return the users input if it is true
            int numberValue = 0;

            //Use boolean to control while loop
            bool isValid = false;

            //While loop
            while (isValid == false)
            {

                //Propmt user to enter a integer
                Console.WriteLine("Please enter a integer");

                numberValue = int.Parse(Console.ReadLine());

                //use if else loop to check for the number value to see if its in 
                //correct range
                if (numberValue <= min)
                {
                    Console.WriteLine("Error! Number must be greate than " + min + ".");

                }
                else if (numberValue >= max)
                {
                    Console.WriteLine("Error! Number must be less than " + max + ".");
                }
                else
                {
                    isValid = true;
                }
            }
            return numberValue;
        }

        public static string GetChoiceString(string s1, string s2, string message)
        {
            //create String variable
            string choice = "";

            //Use boolean to control while loop
            bool isValid = false;

            //While loop
            while (isValid == false)
            {
                //Print out prompt message
                Console.WriteLine(message);

                choice = Console.ReadLine();

                Console.WriteLine();

                if (choice.Equals(""))
                {
                    Console.WriteLine("Error! This entry is required. Try again");
                }
                else if (!choice.Equals(s1, StringComparison.OrdinalIgnoreCase) && !choice.Equals(s2, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Error! Entry must be"
                            + s1 + " or " + s2 + "." + " Try again.");
                }
                else
                {
                    isValid = true;
                }
            }
            return choice;
        }
        public static String GetRequiredString()
        {
            String choiceString = "";

            //Use boolean to control while loop
            bool isValid = false;

            //While loop
            while (isValid == false)
            {
                //Print out prompt message
                Console.WriteLine("Please enter a string");
                choiceString = Console.ReadLine();

                if (choiceString.Equals(""))
                {
                    Console.WriteLine("Not a String!!! Please try again");

                }
                else
                {
                    isValid = true;
                }
            }
            return choiceString;
        }

        public static string GetUserInputTwo(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            Console.WriteLine();

            //check user input for empty or digits only
            if (input == "")
            {
                Console.WriteLine("Entry blank! Please enter a name! \n");
                return GetUserInputTwo(message);
            }
            else if (Regex.IsMatch(input, @"^[0-9]*$"))
            {
                Console.WriteLine("Wrong input! Input characters only \n");
                return GetUserInputTwo(message);
            }
            else
            {
                return input;
            }

        }


    }

}
