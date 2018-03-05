using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeckOfCards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> usedCards = new List<int>();
        
        public Boolean isDrawnAlready(int card) {
     
            return usedCards.Contains(card); 
        }
        public void removeArray(List<int> array)
        {
            // remove list
        }
        public void drawnAllCards()
        {
            string message = "You have already drawn all cards. Do you want to try again? ";
            string caption = "WOW";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                removeArray(usedCards);
            }
            else
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int card = 53;
            if (usedCards.Count > 52)
                drawnAllCards();

            while (!isDrawnAlready(card)) { 
             card= rnd.Next(52);
            }
            pictureBox1.Image = Image.FromFile("/CardImages/"+card+".png");



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
