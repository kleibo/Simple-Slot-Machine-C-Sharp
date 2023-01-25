using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        int balance = 100;
        int bet = 0;
        int winnings = 0;
        int[] reels = new int[3];
        Random rand = new Random();
        
        public Form1()
        {
            InitializeComponent();
            balanceLabel.Texzt
        }
        
        private void spinButton_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(betTextBox.Text, out bet))
            {
                MessageBox.Show("Please enter a valid bet amount.");
                return;
            }

            if(bet > balance)
            {
                MessageBox.Show("Insufficient funds. Please enter a valid bet amount.");
                return;
            }

            SpinReels();
            CheckWin();
            UpdateGUI();

        }

        private void SpinReels()
        {
            reel1Label.Text = rand.Next(1, 7).ToString();
            reel2Label.Text = rand.Next(1, 7).ToString();
            reel3Label.Text = rand.Next(1, 7).ToString();
        }

        private void CheckWin()
        {
            reels[0] = int.Parse(reel1Label.Text);
            reels[1] = int.Parse(reel2Label.Text);
            reels[2] = int.Parse(reel3Label.Text);

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
            else
            {
                winnings = 0;
            }
        }

        private void UpdateGUI()
        {
            balance -= bet;
            balance += winnings;
            balanceLabel.Text = "Balance : $" + balance;
            winningsLabel.Text = "Winnings: $" + winnings;
        }
   
    
    }
}
