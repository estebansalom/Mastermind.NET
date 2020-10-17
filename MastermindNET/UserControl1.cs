using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MastermindNET
{
    public partial class UserControl1: UserControl
    {

        public char[] availableColors = { 'A', 'R', 'V', 'M', 'N', 'B' };

        public char[] colorList = new char[4];

        public char[] colorListAlt = new char[4];

        public char[] attempt = new char[4];

        public int parciales = 0;

        public int totales = 0;

        public int intentos = 0;

        public string[][] repeats = new string[2][];

        public UserControl1()
        {
            InitializeComponent();
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            generateNewColorList();
            intentos = 0;
            parciales = 0;
            totales = 0;
            textBox1.Text = "";
            button2.Visible = true;
            label12.Text = "";
            button1.Text = "Reiniciar Juego";
            refreshResults();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0; i<4; i++)
            {
                colorListAlt[i] = colorList[i];
            }
            attempt = textBox1.Text.ToCharArray();
            print(charArrToString(colorListAlt));
            tryInput();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void generateNewColorList()
        {
            colorList = new char[4];
            Random rnd = new Random();
            for (int i=0; i<4; i++)
            {
                int colorIndex = rnd.Next(0, 5);
                colorList[i] = availableColors[colorIndex];
            }
            print(charArrToString(colorList));
        }

        public void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        public string charArrToString(char[] arr)
        {
            string res = "";
            for(int i=0; i<arr.Length; i++)
            {
                res += arr[i];
            }
            return res;
        }

        public void tryInput()
        {
            if(attempt.Length != 4)
            {
                label12.Text = "Intento no valido.";
                label12.ForeColor = Color.Red;
            }
            else
            {
                label12.Text = "";
                intentos++;
                parciales = 0;
                totales = 0;
                buscarTotales();
                buscarParciales();
                refreshResults();
                if (intentos == 8)
                {
                    label12.Text = "GitGud :(";
                    label12.ForeColor = Color.Red;
                    button2.Visible = false;
                    button1.Text = "Reiniciar Juego";
                }
                if (totales == 4)
                {
                    label12.Text = "GGWP :)";
                    label12.ForeColor = Color.Green;
                    button2.Visible = false;
                    button1.Text = "Reiniciar Juego";
                }
            }
        }

        public void buscarTotales()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (i == k && attempt[k] == colorListAlt[i])
                    {
                        totales++;
                        attempt[k] = 'X';
                        colorListAlt[k] = 'X';
                        break;
                    }
                    
                }
            }
        }

        public void buscarParciales()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (i != k && attempt[i] == colorListAlt[k] && attempt[i] != 'X' && colorListAlt[k] != 'X')
                    {
                        parciales++;
                        attempt[i] = 'X';
                        colorListAlt[k] = 'X';
                    }
                }
            }
        }

        public void refreshResults()
        {
            label6.Text = parciales.ToString();
            label7.Text = totales.ToString();
            label11.Text = (8 - intentos).ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void print(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
