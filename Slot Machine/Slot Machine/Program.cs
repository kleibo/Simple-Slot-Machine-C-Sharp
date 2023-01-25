using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize variables
            int balance = 100;
            int bet = 0;
            int winnings = 0;
            int[] reels = new int[3];
            string playAgain = "y";

            // Welcome message
            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine("Your current balance is: " + balance);

            // Main game loop
            while (playAgain == "y")
            {
                // Get bet amount from user
                Console.WriteLine("Enter bet amount: ");
                bet = int.Parse(Console.ReadLine());

                // Check if bet amount is valid
                if (bet > balance)
                {
                    Console.WriteLine("Invalid bet amount. Please enter a valid amount.");
                }
                else
                {
                    // Spin the reels
                    SpinReels(reels);

                    // Check for winning combinations
                    winnings = CheckWin(reels, bet);

                    // Update balance
                    balance = balance - bet + winnings;
                    

                    // Print results
                    Console.WriteLine("Spin results: " + reels[0] + " " + reels[1] + " " + reels[2]);
                    Console.WriteLine("Winnings: " + winnings);
                    Console.WriteLine("New balance: " + balance);
                }

                // Ask if player wants to play again
                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine();
            }

            // Goodbye message
            Console.WriteLine("Thanks for playing! Goodbye!");
        }

        // Method to spin the reels
        static void SpinReels(int[] reels)
        {
            Random rand = new Random();
            for (int i = 0; i < reels.Length; i++)
            {
                reels[i] = rand.Next(1, 7);
            }
        }

        // Method to check for winning combinations and calculate winnings
        static int CheckWin(int[] reels, int bet)
        {
            int winnings = 0;

            if (reels[0] == reels[1] && reels[1] == reels[2])
            {
                // Three of a kind
                winnings = bet * 10;
            }
            else if (reels[0] == reels[1] || reels[1] == reels[2] || reels[0] == reels[2])
            {
                // Two of a kind
                winnings = bet * 3;

            }

            return winnings;
        }
    }
}