using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Game1
{
    public partial class Form1 : Form
    {
        string file = "Options.txt";
        List<int> optionvalues = new List<int>();
        int song=1;
        int background=1;
        int debug=2;
        int colorchanger=2;
        int volume=1;
        int platform1;
        int platform2;
        int platform3;
        int platform4;
          Game1 game = new Game1();


        public Form1()
        {
         
            InitializeComponent();
            Activate();
            Show();
            Save();
            using ( game )
                game.Run();
        }
        public void writeto()
        {
            optionvalues.Add(song);
            optionvalues.Add(background);
            optionvalues.Add(debug);
            optionvalues.Add(colorchanger);
            optionvalues.Add(volume);
            optionvalues.Add(platform1);
            optionvalues.Add(platform2);
            optionvalues.Add(platform3);
            optionvalues.Add(platform4);

        }
        public void Save()
        {

            StreamWriter output = null;
            try
            { 
                writeto();
                 output = new StreamWriter(file);
                for(int a = 0; a < optionvalues.Count(); a++)
                {
                    
                        output.WriteLine(optionvalues.ElementAt(a));
                

                }
            

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR,ERROR" + e.Message);
            }
            finally
            {
                if (output != null)
                {
                    output.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            game.platform1.Y += 10;
            game.platform1.platform.Y += 10;
            platform1 = 1;
            Save();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            game.platform4.Y += 10;
            game.platform4.platform.Y += 10;
            platform4 = 1;
            Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            game.platform3.Y -= 10;
            game.platform3.platform.Y -= 10;
            platform3 = 2;
            Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            game.platform3.Y += 10;
            game.platform3.platform.Y += 10;
            platform3 = 1;
            Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.platform2.platform.Y -= 10;
            game.platform2.Y -= 10;
            platform2 = 2;
            Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.platform2.Y += 10;
            game.platform2.platform.Y += 10;
            platform2 = 1;
            Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.platform1.platform.Y -= 10;
            game.platform1.Y -= 10;
            platform1 = 2;
            Save();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            game.platform4.platform.Y -= 10;
            game.platform4.Y -= 10;
            platform4 = 2;
            Save();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            game.background = 1;
            background = 1;
            Save();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            game.background = 2;
              background = 2;
            Save();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            game.background = 3;
              background = 3;
            Save();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            game.debug = 1;
            debug = 1;
            Save();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            game.debug = 2;
            debug = 2;
            Save();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            game.colorchanger = 1;
            colorchanger = 1;
            Save();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            game.colorchanger = 2;
            colorchanger = 2;
            Save();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            game.song = 1;
            song = 1;
            textBox1.Text = "Song Playing: BRAIN POWER- N.O.M.A.";
            Save();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game.song = 2;
            song = 2;
            textBox1.Text = "Song Playing: Monty Python Intermission song";
            Save();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            game.song = 3;
            song = 3;
            textBox1.Text = "Song Playing: DJ Hixxy- Like A Shooting Star";
            Save();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            game.volume = 1;
            volume = 1;
            Save();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            game.volume = 2;
            volume = 2;
            Save();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            game.volume = 3;
            volume = 3;
            Save();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            game.volume = 4;
            volume = 4;
            Save();
        }
    }
}
