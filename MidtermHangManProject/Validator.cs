using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MidtermHangManProject
{
    class Validator
    {

        public static string LetterInputOnly(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            Console.WriteLine();

            //check to see if input is alphabet only
            if (input.Length > 1)
            {
                Console.WriteLine("Can only enter one letter at a time! Try again");
                return LetterInputOnly(message);
            }

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
