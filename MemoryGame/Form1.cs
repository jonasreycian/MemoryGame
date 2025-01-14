﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Media;

namespace MemoryGame
{
    public partial class Login : Form
    {
        
        // Object of "Regex" class
        Regex letters_numbers;

        // Object of "SoundPlayer" class        
        SoundPlayer player;

        public Login()
        {
            InitializeComponent();

            // sound that plays when user makes something wrong
            player = new SoundPlayer("error_sound.wav");

            // regular expression that accepts only letters and numbers
            letters_numbers = new Regex(@"^[a-zA-Z0-9]+$");
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            // Check user's input is correct according to Regexes
            if (letters_numbers.IsMatch(txtPlayerName.Text))
            {
                // Proceed to the Home Page area
                HomePage homePage = new HomePage(txtPlayerName.Text);
                this.Hide(); // Hides the current form
                homePage.ShowDialog(); // Shows the next form
                this.Close(); // Closes the current form
            }

            else // If user's input is not valid

            {
                player.Play(); // Play an "error" sound

                MessageBox.Show("Please your enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);

                // Erase the text from the textboxes
                txtPlayerName.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
