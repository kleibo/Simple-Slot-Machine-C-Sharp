using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Analysis : SlotMachine
    {
        public int TotalWinnings { get; set; }
        public int TotalBets { get; set; }
        public int TotalPlays { get; set; }
        public int[,] Reels { get; set; }

        public Analysis()
        {
            TotalWinnings = 0;
            TotalBets = 0;
            TotalPlays = 100000;
            Reels = new int[3, 3];
        }

        public void MonteCarloSimulation(int bet)
        {
            
            for (int i = 0; i < TotalPlays; i++)
            {
                // Spin the reels
                SpinReels(Reels);
                TotalBets += bet;
                // Check for winning combinations
                int winnings = CheckWin(Reels, bet);
                TotalWinnings+= winnings;
            }
        }

        public void PrintResults()
        {
            // Print the results of the simulation
            Console.WriteLine("Total winnings: " + TotalWinnings);
            Console.WriteLine("Total bets: " + TotalBets);
            Console.WriteLine("Average winnings per play: " + (double)TotalWinnings/ TotalPlays);
            Console.WriteLine("Probability of winning: " + (double)TotalWinnings / TotalBets);
        }
    }
}
