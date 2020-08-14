using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Waz
    {
        public int segmenty;
        public int segment;
        public int[] x = new int[900];
        public int[] y = new int[900];
        public string ruch;

        public Waz(int szerokosc, int wysokosc)
        {
            segment = szerokosc / 20;
            segmenty = 3;
            ruch = "prawo";
            int xg = 9 * segment;
            int yg = 9 * segment;
            for (int i = 0; i < segmenty; i++)
            {
                x[i] = xg - (i * segment);
                y[i] = yg;
            }
        }

        public void move()
        {
            for (int i = segmenty; i > 0; i--)
            {
                x[i] = x[(i - 1)];
                y[i] = y[(i - 1)];
            }
            if (ruch == "lewo")
            {
                x[0] = x[0] - segment;
            }
            if (ruch == "prawo")
            {
                x[0] = x[0] + segment;
            }
            if (ruch == "gora")
            {
                y[0] = y[0] - segment;
            }
            if (ruch == "dol")
            {
                y[0] = y[0] + segment;
            }
            if (x[0] < 0) { x[0] = segment * 19; }
            if (x[0] > segment * 20) { x[0] = 0; }
            if (y[0] < 0) { y[0] = segment * 19; }
            if (y[0] > segment * 20) { y[0] = 0; }
        }

        public void rysuj(Graphics g, Brush b)
        {
            g.FillRectangle(new SolidBrush(Color.Green), x[0], y[0], segment, segment);
            for (int i = 1; i < segmenty; i++)
            {
                g.FillRectangle(b, x[i], y[i], segment, segment);
            }
        }

        public void dodaj()
        {
            x[segmenty] = x[segmenty - 1];
            y[segmenty] = y[segmenty - 1];
            segmenty = segmenty + 1;
        }

        public bool czy_waz_zyje()
        {
            for (int i = 1; i < segmenty; i++)
            {
                if (x[0] == x[i] && y[0] == y[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
