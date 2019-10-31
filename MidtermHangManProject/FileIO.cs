using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MidtermHangManProject
{
    class FileIO
    {
        private static string WordFile = "../../../Words.txt";
        private static string UsersFile = "../../../UserPlayers.txt";
        public List<string> Words { get; set; }
        public List<UserPlayer> Users { get; set; }
        //public List<string> EasyWords {get;set;}
        //public List<string> HardWords {get;set;}


        public FileIO()
        {
            Words = new List<string>();
            Users = new List<UserPlayer>();
        }
        public void WriteUsers()
        {
            StreamWriter writer = new StreamWriter(UsersFile);
            foreach (UserPlayer player in Users)
            {
                writer.WriteLine($"{player.Name}|{player.Wins}|{player.Losses}");
            }
            writer.Close();
        }
        public void ReadUsers()
        {
            StreamReader reader = new StreamReader(UsersFile);
            string line = reader.ReadLine();
            string[] formattedLine = new string[3];
            while (line != null)
            {
                formattedLine = line.Split('|');
                Users.Add(new UserPlayer(formattedLine[0], int.Parse(formattedLine[1]), int.Parse(formattedLine[2])));
                line = reader.ReadLine();
            }
            reader.Close();
        }
        public void ReadWords()
        {
            StreamReader reader = new StreamReader(WordFile);
            string line = reader.ReadLine();
            while (line != null)
            {
                Words.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
        }
        //public void WriteWords()
        //{

        //}
    }
}
