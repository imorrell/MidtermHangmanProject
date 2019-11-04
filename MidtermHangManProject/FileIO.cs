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
        private static string EasyWordFile = "../../../EasyWords.txt";
        //private static string HardWordFile = "../../../HardWords.txt";
        private static string PeopleFile = "../../../PeopleCharacters.txt";
        private static string PlacesFile = "../../../Places.txt";
        public List<string> Words { get; set; }
        public List<UserPlayer> Users { get; set; }
        public List<string> EasyWords {get;set;}
        //public List<string> HardWords {get;set;}
        public List<string> PeopleWords { get; set; }
        public List<string> PlaceWords { get; set; }


        public FileIO()
        {
            Words = new List<string>();
            Users = new List<UserPlayer>();
            EasyWords = new List<string>();
            PeopleWords = new List<string>();
            PlaceWords = new List<string>();
            ReadUsers();
            ReadWords();
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
        private void ReadUsers()
        {
            StreamReader reader = new StreamReader(UsersFile);
            string line = reader.ReadLine();
            string[] formattedLine = new string[3];
            while (line != null)
            {
                formattedLine = line.Split('|');
                CheckUser(new UserPlayer(formattedLine[0], int.Parse(formattedLine[1]), int.Parse(formattedLine[2])));
                line = reader.ReadLine();
            }
            reader.Close();
        }
        private void ReadWords()
        {
            StreamReader reader = new StreamReader(WordFile);
            string line = reader.ReadLine();
            while (line != null)
            {
                Words.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
            
            line = "";
            reader = new StreamReader(EasyWordFile);
            line = reader.ReadLine();
            while (line != null)
            {
                EasyWords.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
            
            line = "";
            reader = new StreamReader(PeopleFile);
            line = reader.ReadLine();
            while (line != null)
            {
                PeopleWords.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();

            line = "";
            reader = new StreamReader(PlacesFile);
            line = reader.ReadLine();
            while (line != null)
            {
                PlaceWords.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
        }
        public void WriteWords()
        {
            StreamWriter writer = new StreamWriter(WordFile);
            foreach (string word in Words)
            {
                writer.WriteLine($"{word}");
            }
            writer.Close();
        }
        public void CheckUser(UserPlayer newPlayer)
        {
            foreach(UserPlayer existing in Users)
            {
                if(existing.Name == newPlayer.Name)
                {
                    existing.Wins = existing.Wins + newPlayer.Wins;
                    existing.Losses = existing.Losses + newPlayer.Losses;
                    return;
                }
            }
            Users.Add(newPlayer);
        }
    }
}