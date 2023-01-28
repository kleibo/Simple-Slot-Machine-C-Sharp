﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        static void Main(string[] args)
        {

            Game start = new();
            start.StartGame();

            Console.WriteLine("Would you like to perform a Monte Carlo analysis? y/n");
            String Answer = Console.ReadLine();

            if (Answer == "y") {
                Analysis MonteCarlo = new();
                MonteCarlo.MonteCarloSimulation(100);
                MonteCarlo.PrintResults();
            }

        }

        // Method to spin the reels
        public static void SpinReels(int[,] reels)
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    reels[i, j] = rand.Next(1, 15);
                }
            }
        }

        // Method to check for winning combinations and calculate winnings
        public static int CheckWin(int[,] reels, int bet)
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