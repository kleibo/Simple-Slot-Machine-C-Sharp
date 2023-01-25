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
            int[,] reels = new int[3,3];
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
                    balance -= bet;
                    balance += winnings;


                    // Print results
                    Console.WriteLine("Spin results: ");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(reels[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
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
        static void SpinReels(int[,] reels)
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    reels[i, j] = rand.Next(1, 7);
                }
            }
        }

        // Method to check for winning combinations and calculate winnings
        static int CheckWin(int[,] reels, int bet)
        {
            int winnings = 0;
            bool colWin = false;
            bool zagWin = false;

            // Check for winning combinations in collinear lines
            for (int i = 0; i < 3; i++)
            {
                if (reels[i, 0] == reels[i, 1] && reels[i, 1] == reels[i, 2])
                {
                    colWin = true;
                    break;
                }
                if (reels[0, i] == reels[1, i] && reels[1, i] == reels[2, i])
                {
                    colWin = true;
                    break;
                }
            }

            // Check for winning combinations in zigzag lines
            if (reels[0, 0] == reels[1, 1] && reels[1, 1] == reels[2, 2])
            {
                zagWin = true;
            }
            if (reels[0, 2] == reels[1, 1] && reels[1, 1] == reels[2, 0])
            {
                zagWin = true;
            }

            // Calculate winnings
            if (colWin)
            {
                winnings = bet * 5;
            }
            if (zagWin)
            {
                winnings = bet * 10;
            }
            if (colWin && zagWin)
            {
                winnings = bet * 20;
            }

            return winnings;
        }
    }
}