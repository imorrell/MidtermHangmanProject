﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidtermHangManProject
{
    class PlayGame
    {
        static FileIO file;
        static List<string> unguessedLetters;
        //The PlayHangMan method controls all the gameplay for hangman
        public static void PlayHangMan()
        {
            file = new FileIO();
            bool ok = true;
            string userName;
            string word;
            //char [] word = new char[];
            List<string> userEntries = new List<string>();
            int incorrectGuesses = 7;
            string enterLetter;
            int wins = 0;
            int losses = 0;
            bool letterFound = false;
            Random rnd = new Random();
            int randomWord;

            //welcome the user to the program
            Console.WriteLine("Welcome to Hangman! Get ready to take this L!\n");
            bool playing = true;
            bool inMenu;
            while (playing)
            {
                //Ask the user to enter their name
                userName = Validator.GetUserInputTwo("Please enter a memorable username\n");

                PlayerRecognition(userName);

                inMenu = true;
                while (inMenu)
                {
                    Console.WriteLine("What do you want to do?\n \n 1. Play a Game\n 2. See High Scores\n 3. New User\n 4. Quit\n");
                    switch (Console.ReadLine())
                    {
                        case ("1"):
                            #region
                            //use while loop to process user input                        
                            ok = true;
                            while (ok)
                            {
                                Console.WriteLine();
                                List<string> hangManWords = WordDifficultySelector();
                                Console.WriteLine();
                                List<string> guessedLettersList = new List<string>();
                                PopulateGuessList();
                                //create a random int variable that will be used to draw words from hangManWords list
                                randomWord = rnd.Next(0, hangManWords.Count);

                                //set the word that the user will guess
                                word = hangManWords[randomWord];                             

                                //generate dashes
                                userEntries = UserInput(word);

                                Console.WriteLine();

                                while (incorrectGuesses != 0 && ConvertStringList(userEntries) != word.ToLower())
                                {
                                    ShowInput(userEntries);
                                    Console.Write("Letters Entered: ");
                                    DisplayListLetters(guessedLettersList);
                                    Console.WriteLine();

                                    //ask the user for an entry
                                    enterLetter = Validator.LetterInputOnly("Enter a letter\n").ToLower();

                                    //check to see if the letter has already been guessed
                                    for (int x = 0; x < unguessedLetters.Count; x++)
                                    {
                                        //check to see if the letter has already been guessed
                                        if (unguessedLetters[x] == enterLetter)
                                        {
                                            unguessedLetters.RemoveAt(x);
                                            guessedLettersList.Add(enterLetter);
                                            for (int i = 0; i < word.Length; i++)
                                            {
                                                if (enterLetter == word[i].ToString().ToLower())
                                                {
                                                    //populate underscore from user entries with letter
                                                    letterFound = true;
                                                    userEntries.RemoveAt(i);
                                                    userEntries.Insert(i, enterLetter);
                                                }
                                            }
                                            break;
                                        }

                                        if (x == unguessedLetters.Count - 1)
                                        {

                                            letterFound = true;
                                            //this letter has already been guessed, tell the user. 
                                            Console.WriteLine("This letter has already been guessed. Please enter different letter. \n");

                                            incorrectGuesses--;
                                            CharacterArtCountdown(incorrectGuesses);
                                        }
                                    }

                                    //if the letter is not found, decrement the number of guesses
                                    if (letterFound == false)
                                    {
                                        Console.WriteLine("Letter not found. You suck.\n");
                                        incorrectGuesses--;
                                        CharacterArtCountdown(incorrectGuesses);
                                    }
                                    //reset the letter found bool for next loop interation
                                    letterFound = false;
                                }
                                if (incorrectGuesses == 0)
                                {
                                    InsultGenerator(word);
                                    losses++;
                                }
                                else if (ConvertStringList(userEntries) == word.ToLower())
                                {
                                    Console.WriteLine($"Congratulations! You won! Your word was {word}. Yay! You're awesome! =)");
                                    wins++;
                                }
                                incorrectGuesses = 7;
                                word = "";
                                UserPlayer CurrentPlayer = new UserPlayer(userName, wins, losses);
                                file.CheckUser(CurrentPlayer);
                                file.WriteUsers();

                                ok = Validator.GetContinue();
                                Console.WriteLine();

                            }
                            #endregion
                            break;
                        case ("2"):
                            Console.WriteLine();
                            DisplayHighScores();
                            Console.WriteLine();
                            break;
                        case ("3"):
                            inMenu = false;
                            break;
                        case ("4"):
                            Environment.Exit(0);
                            break; //<----THIS SHOULDN'T BE NEEEDED!!!! RAAAAAAAAAAAAAAGE!!!!!!!!!\
                        case ("14"):
                            file.Words.Add(Validator.LetterInputOnly("What word do you want to add?"));
                            foreach(string testword in file.Words)
                            {
                                Console.WriteLine(testword);
                            }
                            file.WriteWords();
                            break;
                        default:
                            Console.WriteLine("You done fucked it all up. You broke it! It's ruined!");
                            break;


                    }
                }
            }
        }
            //creating a method to print out a specific sets of CW's based on the number of guesses they have left.
            public static void CharacterArtCountdown(int X)
            {
                if (X == 6)
                {
                    Console.WriteLine("   ____    ");
                    Console.WriteLine("   |  0    ");
                    Console.WriteLine("   |       ");
                    Console.WriteLine("   |       ");
                    Console.WriteLine("___|_______");
                }
                else if (X == 5)
                {
                Console.WriteLine("   ____    ");
                Console.WriteLine("   |  0    ");
                Console.WriteLine("   |  |    ");
                Console.WriteLine("   |       ");
                Console.WriteLine("___|_______");
            }
                else if (X == 4)
                {
                Console.WriteLine("   ____    ");
                Console.WriteLine("   |  0    ");
                Console.WriteLine("   |  |/   ");
                Console.WriteLine("   |       ");
                Console.WriteLine("___|_______");
            }
                else if (X == 3)
                {
                Console.WriteLine("   ____    ");
                Console.WriteLine("   |  0    ");
                Console.WriteLine("   | \\|/   ");
                Console.WriteLine("   |       ");
                Console.WriteLine("___|_______");
            }
                else if (X == 2)
                {
                Console.WriteLine("   ____    ");
                Console.WriteLine("   |  0    ");
                Console.WriteLine("   | \\|/   ");
                Console.WriteLine("   | /     ");
                Console.WriteLine("___|_______");
            }
                else if (X == 1)
                {
                Console.WriteLine("   ____     ");
                Console.WriteLine("   |  0     ");
                Console.WriteLine("   | \\|/    ");
                Console.WriteLine("   | / \\   ");
                Console.WriteLine("___|_______ ");
            }
                else if (X == 0)
                {
                Console.WriteLine("   ____     ");
                Console.WriteLine("   |        ");
                Console.WriteLine("   |        ");
                Console.WriteLine("   | \\|/    ");
                Console.WriteLine("   | / \\   ");
                Console.WriteLine("___|______0_");
            }
            Console.WriteLine($"Number of Guesses Left - {X}\n");
        }

        public static List<string> UserInput(string word)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    words.Add("/");
                    continue;
                }
                words.Add("_ ");

            }
            return words;
        }

        public static void ShowInput(List<string> words)
        {
            foreach (string letter in words)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
        }
        public static List<string> WordDifficultySelector()
        {
           string wordDifficulty = Validator.GetChoiceString("Common", "Other", "Places", "Things", "Person", "Info", "Would you prefer a Common word, a Person, Places, Things or Other?\nEnter \"info\" for information on each Category.");
            if (wordDifficulty.Equals("Common",StringComparison.OrdinalIgnoreCase))
            {
               return file.EasyWords;
            }
            else if (wordDifficulty.Equals("Other", StringComparison.OrdinalIgnoreCase))
            {
                return file.Words;
            }
            else if (wordDifficulty.Equals("Places", StringComparison.OrdinalIgnoreCase))
            {
                return file.PlaceWords;
            }
            else if (wordDifficulty.Equals("Things", StringComparison.OrdinalIgnoreCase))
            {
                return file.ThingWords;
            }
            else if (wordDifficulty.Equals("Person", StringComparison.OrdinalIgnoreCase))
            {
                return file.PeopleWords;
            }
            else if (wordDifficulty.Equals("Info", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Common: Common, everyday words.\nOther: Who knows what you'll get?\nPlaces: Actual places (cities, continents, nations, etc.).\nThings: Everyday objects you see around life.\nPerson: People, real, maybe real, not real.\n");
                return WordDifficultySelector();
            }
            else 
            {
                return WordDifficultySelector();
            }
        }
        public static string ConvertStringList(List<string> list)
        {
            string convertList = "";

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "/")
                {
                    convertList = convertList + " ";
                    continue;
                }
                convertList += list[i];
            }
            return convertList;
        }
        public static void PopulateGuessList()
        {
            unguessedLetters = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        }

        public static void PlayerRecognition(string userName)
        {
            foreach (UserPlayer player in file.Users)
            {
                if (userName.Equals(player.Name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Welcome back, {player.Name}!!\n");
                    Console.WriteLine($"Your record is {player.Wins} wins and {player.Losses} losses!\n");
                    return;
                }
            }
        }

        public static void InsultGenerator(string word)
        {
            //intialize random object
            Random rnd = new Random();

            //create and intialize variables
            List<string> lostStatements = new List<string>
            {
                "Sorry, your just a loser!",
                "Garbage!!!!!!!",
                "Daaaammnnn you suck!!",
                "LOL U SUCK!",
                "That was a really good try...... SIKE!",
                "Gimme my money!",
                "Your mother should of thrown you away and kept the stork lol!",
                "Don't feel bad, there are many people who have no talent!",
                "Brains are not everything. In fact, in your case they're nothing!",
                "Did your parents ever ask you to run away from home?",
                "Don't think, it might sprain your brain!"
            };

            string feedBack = lostStatements[rnd.Next(0, lostStatements.Count)] + $" Your word was \"{word}\".";

            Console.WriteLine(feedBack);

        }

        public static void DisplayHighScores()
        {

            List<UserPlayer> temp = file.Users.OrderBy(x => x.Wins).ToList();
            for (int x = temp.Count - 1; x >= 0; x--)
            {
                Console.WriteLine($"{temp[x].Name}  {temp[x].Wins}");
            }

        }

        public static void DisplayListLetters(List<string> list)
        {
            foreach (string letter in list)
            {
                Console.Write($"{letter} ");
            }
        }
    }
}