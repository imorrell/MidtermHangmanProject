using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermHangManProject
{
	class UserPlayer
	{
		public string Name { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }

		public UserPlayer() { }

		public UserPlayer(string name, int wins, int losses)
		{
			Name = name;
			Wins = wins;
			Losses = losses;
		}

        public double WinLossPercentage()
        {
            try
            {
                return Wins / (Wins + Losses);
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
		
	}
}
