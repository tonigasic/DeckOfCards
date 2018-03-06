using System;
using System.Collections;
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
        ArrayList usedCards = new ArrayList();
        
        public Boolean isDrawnAlready(int card) {
     
            return usedCards.Contains(card); 
        }
        public void removeArray(ArrayList array)
        {
            array.Clear();
        }
        public void drawnAllCards()
        {
            string message = "You have already drawn all cards. Do you want to try again? ";
            string caption = "Wow, you have seen them all!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                usedCards.Clear();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }
        public void notEnoughtCards()
        {
            string message = "51 cards already drawn. Lets do it again? ";
            string caption = "Not enought cards left!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                usedCards.Clear();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int card = 0;

            while (true){
                if (usedCards.Count >= 52)
                    drawnAllCards();
                card = rnd.Next(52)+1;
                //MessageBox.Show("" + usedCards.Count);
                if (!isDrawnAlready(card)) {
                    usedCards.Add(card);
                    break;
                } 
            } 
            string path= "C:\\Users\\tonig\\Documents\\C#\\DeckOfCards\\DeckOfCards\\CardImages\\"+card+".png";
            pictureBox2.Image = new Bitmap(path);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = null;
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int card1 = 0;
            int card2 = 0;
            while (true)
            {
                if (usedCards.Count >= 52)
                    drawnAllCards();
                card1 = rnd.Next(52) + 1;
                //MessageBox.Show("" + usedCards.Count);
                if (!isDrawnAlready(card1))
                {
                    usedCards.Add(card1);
                    if (usedCards.Count >= 52)
                        notEnoughtCards();
                    while (true) { 
                        card2 = rnd.Next(52) + 1;
                        if (!isDrawnAlready(card2))
                        {
                            break;
                        }
                    }
                    usedCards.Add(card2);
                    break;
                }
            }
            
            string path1 = "C:\\Users\\tonig\\Documents\\C#\\DeckOfCards\\DeckOfCards\\CardImages\\" + card1 + ".png";
            string path2 = "C:\\Users\\tonig\\Documents\\C#\\DeckOfCards\\DeckOfCards\\CardImages\\" + card2 + ".png";
            pictureBox2.Image = new Bitmap(path1);
            pictureBox2.SizeMode= PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = new Bitmap(path2);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;



        }
    }
}
