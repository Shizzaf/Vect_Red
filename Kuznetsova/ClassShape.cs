using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kuznetsova
{
    public abstract class Shapes
    {
        public abstract void DrawWith(Graphics g, Pen p);
    }
    public class Cross : Shapes
    {
        int X, Y;
        public Cross(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, X - 3, Y - 3, X + 3, Y + 3);
            g.DrawLine(p, X + 3, Y - 3, X - 3, Y + 3);
        }
    }
}
