using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class owoc
    {
        public int x;
        public int y;
        public int segment;

        public void nowy_owoc()
        {
            Random r = new Random();
            x = r.Next(0, 20) * segment;
            y = r.Next(0, 20) * segment;
        }

        public owoc(int segment)
        {
            this.segment = segment;
            nowy_owoc();
        }

        public bool czy_nowy_owoc(int glowa_x, int glowa_y)
        {
            if (x == glowa_x && y == glowa_y)
            {
                nowy_owoc();
                return true;
            }
            return false;
        }

        public void rysuj_owoc(Graphics g, Brush b)
        {
            g.FillRectangle(b, x, y, segment, segment);
        }
    }
}
