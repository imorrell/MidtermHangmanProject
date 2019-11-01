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
            List<string> letterGuessed = new List<string>();
            int incorrectGuesses = 7;
            string enterLetter;
            int wins = 0;
            int loses = 0;
            bool letterFound = false;
            Random rnd = new Random();
            int randomWord;

            //create user player object
            UserPlayer user = new UserPlayer();

            //pull in list of words from FileIO class
            FileIO file = new FileIO();

            //read the word file
            file.ReadWords();

            //initialize array that will hold all of the words read from the file
            List<string> hangManWords = file.Words;

            //welcome the user to the program
            Console.WriteLine("Welcome to Hangman! Get ready to take this L!\n");

            //Ask the user to enter their name
            userName = Validator.GetUserInputTwo("Please enter user name\n");

            //add the username to the user object
            user.Name = userName;

            //use while loop to process user input
            while (ok)
            {
                //create a random int variable that will be used to draw words from hangManWords list
                randomWord = rnd.Next(0, hangManWords.Count);

                //set the word that the user will guess
                word = hangManWords[randomWord];

                Console.WriteLine(word);

                //generate dashes
                userEntries = UserInput(word);
                Console.WriteLine();

                while (incorrectGuesses != 0 && userEntries.ToString() != word)
                {
                    ShowInput(userEntries);

                    //ask the user for an entry
                    enterLetter = Validator.LetterInputOnly("Enter a letter\n");

                    //check to see if the letter has already been guessed
                    foreach (String item in letterGuessed)
                    {
                        //check to see if the letter has already been guessed
                        if (item == enterLetter)
                        {
                            //this letter has already been guessed, tell the user. 
                            Console.WriteLine("This letter has already been guessed. Please enter different letter. \n");
                        }
                        else
                        //letter has not been guessed
                        //check to see if the letter is equivalent to letter or letters in word
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (char.Parse(enterLetter) == word[i])
                            {
                                //populate underscore from user entries with letter
                                letterFound = true;
                                userEntries.RemoveAt(i);
                                userEntries.Insert(i, enterLetter);
                            }

                        }
                    }

                    //if the letter is not found, decrement the number of guesses
                    if (letterFound == false)
                    {
                        incorrectGuesses--;
                    }

                    //reset the letter found bool for next loop interation
                    letterFound = false;
                }


                //populate empty list with underscores
                foreach(char c in word)
                {
                    
                }

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

        public static List<string> UserInput(string word)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                words.Add("_ ");
            }
           

            return words;

        }

        public static void ShowInput(List <string> words)
        {
            foreach (string letter in words)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}
