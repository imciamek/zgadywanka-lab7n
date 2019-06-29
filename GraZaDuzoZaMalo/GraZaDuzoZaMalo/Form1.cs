using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraZaDuzoZaMalo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int liczba_prob = 0, losowana = 0,czas=0;  //jebac disa kurwe zwisa
        private int Losuj(int min, int max)
        {
            if (min > max)
            {
                int temp = max;
                max = min;
                min = temp;
            }

            Random generator = new Random();
            return generator.Next(min, max + 1);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CheckIfWin(int num)
        {
            liczba_prob++;
            label7.Text = liczba_prob.ToString();
            if (num == losowana)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                textBox3.Enabled = false;
                button2.Enabled = false;
                label1.Text = "WYGRAŁEŚ";
                timer1.Enabled = false;
            } else if(num > losowana)
            {
                label1.Text = "ZA DUŻO";
            } else if(num < losowana)
            {
                label1.Text = "ZA MAŁO";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas++;
            label8.Text = czas.ToString() + " s";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                losowana = Losuj(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                textBox3.Enabled = true;
                button2.Enabled = true;
                liczba_prob = 0;
                czas = 0;
                label7.Text = liczba_prob.ToString();
                label8.Text = czas.ToString() + " s";
                timer1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Błędne dane");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIfWin(Convert.ToInt32(textBox3.Text));
            }
            catch 
            {
                MessageBox.Show("Błąd ! niepoprawne liczby !");
            }
        }

    }
}
