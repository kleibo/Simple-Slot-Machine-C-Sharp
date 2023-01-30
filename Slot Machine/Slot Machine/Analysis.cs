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
            int maxSingleSpinAward = 0;
            int maxSingleSpinCount = 0;
            int totalWinningsSquared = 0;

            for (int i = 0; i < TotalPlays; i++)
            {
                // Spin the reels
                SpinReels(Reels);
                TotalBets += bet;
                
                // Check for winning combinations
                int winnings = CheckWin(Reels, bet);
                TotalWinnings+= winnings;
                totalWinningsSquared += winnings * winnings;
                if (winnings > maxSingleSpinAward)
                {
                    maxSingleSpinAward = winnings;
                    maxSingleSpinCount++;
                }
                else if (winnings == maxSingleSpinCount)
                {
                    maxSingleSpinCount++;
                }
            }

            double volatilityIndex = Math.Sqrt((TotalPlays * totalWinningsSquared) - (TotalWinnings * TotalWinnings)) / TotalPlays;
            
            // Print the results of the simulation
            Console.WriteLine("Total winnings: " + TotalWinnings);
            Console.WriteLine("Total bets: " + TotalBets);
            Console.WriteLine("Average winnings per play: " + (double)TotalWinnings / TotalPlays);
            Console.WriteLine("Probability of winning: " + (double)TotalWinnings / TotalBets);
            Console.WriteLine("Max single spin award: " + maxSingleSpinAward);
            Console.WriteLine("Max single spin award odds: 1 in " + (double)TotalPlays / maxSingleSpinCount);
            Console.WriteLine("Hit frequency %: " + (double)TotalWinnings / TotalBets * 100);
            Console.WriteLine("Total Hit Rate: " + (double)TotalWinnings / TotalBets * 100);
            Console.WriteLine("Volatility (VI): " + volatilityIndex);
        }


    }
}
