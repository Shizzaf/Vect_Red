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
    public class Line : Shapes
    {
        //S - стартовая координата, F - конечная координата 
        Point S, F;
        Pen p = new Pen(Color.Black);
        public Line(Point _S, Point _F)
        {
            S = _S;
            F = _F;
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, S.X, S.Y, F.X, F.Y);
        }
    }
    public class Circle : Shapes
    {
        //S - стартовая координата, F - конечная координата 
        Point S, F;
        Pen p = new Pen(Color.Black);
        public Circle(Point _S, Point _F)
        {
            S = _S;
            F = _F;
        }
        private float Radius
        {
            get
            {
                double Radius = Math.Sqrt(Math.Pow(F.X - S.X, 2) + Math.Pow(F.Y - S.Y, 2));
                return (float)Radius;
            }
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawEllipse(p, S.X - Radius, S.Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
