using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Game : SlotMachine
    {
        public int Balance { get; set; }
        public int Bet { get; set; }
        public int Winnings { get; set; }
        public int[,] Reels { get; set; }
        public string PlayAgain { get; set; }

        public Game()
        {
            // Initialize variables
            Balance = 0;
            Bet = 0;
            Winnings = 0;
            Reels = new int[3, 3];
            PlayAgain = "y";

        }


        public void StartGame()
        {
            // Welcome message
            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine("Your current balance is: " + Balance);
            
            // Main game loop
            while (PlayAgain == "y")
            {
                
                if (Balance == 0) {
                    Console.WriteLine("Please insert credits");
                    // Have user insert money
                    Console.WriteLine("Type amount to play with: ");
                    Balance = int.Parse(Console.ReadLine());
                }
                

                // Get bet amount from user
                Console.WriteLine("Enter bet amount: ");
                Bet = int.Parse(Console.ReadLine());

                // Check if bet amount is valid
                if (Bet > Balance)
                {
                    Console.WriteLine("Invalid bet amount. Please enter a valid amount.");
                }
                else
                {
                    // Spin the reels
                    SpinReels(Reels);

                    // Check for winning combinations
                    Winnings = CheckWin(Reels, Bet);

                    // Update balance
                    Balance -= Bet;
                    Balance += Winnings;


                    // Print results
                    Console.WriteLine("Spin results: ");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(Reels[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Winnings: " + Winnings);
                    Console.WriteLine("New balance: " + Balance);

                }

                // Ask if player wants to play again
                Console.WriteLine("Do you want to play again? (y/n)");
                PlayAgain = Console.ReadLine();
            }

            // Goodbye message
            Console.WriteLine("Thanks for playing! Goodbye!");
        }
    }
}
