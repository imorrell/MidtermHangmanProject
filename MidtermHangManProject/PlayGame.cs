using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MidtermHangManProject
{
    class PlayGame
    {
        //The PlayHangMan method controls all the gameplay for hangman
        public static void PlayHangMan()
        {
            //create and intialize variables
            bool ok = true;
            string userName;
            //char [] word = new char[];
            List<String> userEntries = new List<string>();
            int numberOfGuesses = 7;
            string enterLetter;
            int wins = 0;
            int loses = 0;
            
            UserPlayer user = new UserPlayer();

            //welcome the user to the program
            Console.WriteLine("Welcome to Hangman! Get ready to take this L!\n");

            //Ask the user to enter their name
            userName = Validator.GetUserInputTwo("Please enter user name\n");

            //add the username to the user object
            user.Name = userName;

            //use while loop to process user input
            while (ok && numberOfGuesses != 0)
            {
                //set the name of the word from the file

                







            }

            

        }

        //The DisplayUnderScore met method

    }
}
