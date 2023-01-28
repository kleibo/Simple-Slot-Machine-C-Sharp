using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Game : SlotMachine
    {
        public int balance { get; set; }
        public int bet { get; set; }
        public int winnings { get; set; }
        public int[,] reels { get; set; }
        public string playAgain { get; set; }

        public Game()
        {
            // Initialize variables
            balance = 100;
            bet = 0;
            winnings = 0;
            reels = new int[3, 3];
            playAgain = "y";

        }


        public void StartGame()
        {
            // Welcome message
            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine("Your current balance is: " + bet);

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
    }
}
