using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private bool czy_gra_aktywna;
        private Waz snake;
        private owoc owoc;

        public Form1()
        {
            InitializeComponent();
            czy_gra_aktywna = false;
            timer1.Enabled = true;
        }

        private void start()
        {
            FontFamily fontFamily1 = new FontFamily("Comic Sans MS");
            Font f = new Font(fontFamily1, 15);
            Brush b = new SolidBrush(Color.BlueViolet);
            pole_gry.CreateGraphics().DrawString("Naciśnij Start", f, b, 55, 125);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (czy_gra_aktywna)
            {
                pole_gry.CreateGraphics().Clear(Color.Black);
                snake.move();
                snake.rysuj(pole_gry.CreateGraphics(), new SolidBrush(Color.Aqua));
                owoc.rysuj_owoc(pole_gry.CreateGraphics(), new SolidBrush(Color.Orange));
                if (owoc.czy_nowy_owoc(snake.x[0], snake.y[0]))
                {
                    snake.dodaj();
                }
                if (snake.czy_waz_zyje() == false)
                {
                    czy_gra_aktywna = false;
                }
            }
            else if (pauzaToolStripMenuItem.Text == "Wznów")
            {
                pole_gry.CreateGraphics().Clear(Color.Black);
            }
            else
            {
                start();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            czy_gra_aktywna = true;
            snake = new Waz(pole_gry.Width, pole_gry.Height);
            owoc = new owoc(snake.segment);
            pauzaToolStripMenuItem.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                snake.ruch = "gora";
            }

            if (e.KeyCode == Keys.Down)
            {
                snake.ruch = "dol";
            }

            if (e.KeyCode == Keys.Right)
            {
                snake.ruch = "prawo";
            }

            if (e.KeyCode == Keys.Left)
            {
                snake.ruch = "lewo";
            }
        }

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (czy_gra_aktywna)
            {
                czy_gra_aktywna = false;
                pauzaToolStripMenuItem.Text = "Wznów";
                pole_gry.CreateGraphics().Clear(Color.Black);
            }
            else
            {
                czy_gra_aktywna = true;
                pauzaToolStripMenuItem.Text = "Pauza";
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (czy_gra_aktywna)
            {
                snake = new Waz(pole_gry.Width, pole_gry.Height);
                owoc = new owoc(snake.segment);
            }
        }

        private void wolniejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval += 10;
        }

        private void szybciejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Interval > 10) { timer1.Interval -= 10; }
        }
    }
}
