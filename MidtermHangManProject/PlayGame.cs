using System;
using System.Collections.Generic;
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
            string word;
            //char [] word = new char[];
            List<string> userEntries = new List<string>();
            int numberOfGuesses = 7;
            string enterLetter;
            int wins = 0;
            int loses = 0;
            Random rnd = new Random();
            

            //create user player object
            UserPlayer user = new UserPlayer();

            //pull in list of words from FileIO class
            FileIO file = new FileIO();

            //read the word file
            file.ReadWords();

            //initialize array that will hold all of the words read from the file
            List<string> hangManWords = file.Words;

            //create a random int variable that will be used to draw words from hangManWords list
            int randomWord;

            //welcome the user to the program
            Console.WriteLine("Welcome to Hangman! Get ready to take this L!\n");

            //Ask the user to enter their name
            userName = Validator.GetUserInputTwo("Please enter user name\n");

            //add the username to the user object
            user.Name = userName;

            //use while loop to process user input
            while (ok && numberOfGuesses != 0)
            {
                //create a random int variable that will be used to draw words from hangManWords list
                randomWord = rnd.Next(1, hangManWords.Count);

                //set the word that the user will guess
                word = hangManWords[randomWord];

                Console.WriteLine(word);

            }
		//creating a method to print out a specific sets of CW's based on the number of guesses they have left.
		//public static void CharacterArtCountdown()
		//	{ foreach (number X in guesses)
		//		
		//		 if (X is == 7)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("    (XXX)  ");
		//			Console.WriteLine("  Number of Guesses Left - 7  ");
		//			Guesses--;
		//		}
		//		else if (X is == 6)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("    (XXX)  ");
		//			Console.WriteLine("  Number of Guesses Left - 6  ");
		//			Guesses--;
		//		}
		//		else if (X is == 5)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("    (XXX)  ");
		//			Console.WriteLine("  Number of Guesses Left - 5  ");
		//			Guesses--;
		//		}
		//		else if (X is == 4)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     |X|    ");
		//			Console.WriteLine("    (XXX)  ");
		//			Console.WriteLine("  Number of Guesses Left - 4  ");
		//			Guesses--;
		//		}
		//		else if (X is == 3)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("    (XXX)  ");
		//			Console.WriteLine("  Number of Guesses Left - 3  ");
		//			Guesses--;
		//		}
		//		else if (X is == 2)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("    (X X)  ");
		//			Console.WriteLine("  Number of Guesses Left - 2  ");
		//			Guesses--;
		//		}
		//		else if (X is == 1)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("    (X  )  ");
		//			Console.WriteLine("  Number of Guesses Left - 1  ");
		//			Guesses--;
		//		}
		//		else if (X is == 0)
		//		{
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("     | |    ");
		//			Console.WriteLine("    (   )  ");
		//			Console.WriteLine("  Number of Guesses Left - 0  ");
		//			Guesses--;
		//		}
		//		Console.WriteLine("I am afraid you have been hanged");
		//	}


        }
		//public static void 
		//public static void CheckLetter()
		//{
			//foreach (char[i] in FileIO.Words(word))
			//{
				//if([i] == userGuess)
			//}
			//UserPlayer.Guesses--;
		//}

    }
}
