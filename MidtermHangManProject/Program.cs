using System;

namespace MidtermHangManProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIO test = new FileIO();
            test.ReadWords();
            foreach(string word in test.Words)
            {
                Console.WriteLine(word);
            }
            test.ReadUsers();
            foreach (UserPlayer userplayer in test.Users)
            {
                Console.WriteLine($"{userplayer.Name} { userplayer.Wins} {userplayer.Losses}");
            }
            UserPlayer newUser = new UserPlayer("Gannondorf", 0, 131313);
            test.CheckUser(newUser);
            test.WriteUsers();
        }
    }
}
