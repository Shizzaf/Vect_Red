using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Kuznetsova
{
    public abstract class Shapes
    {
        public abstract void DrawWith(Graphics g, Pen p);
        public abstract void SaveTo(StreamWriter sw);
        public abstract string info {get;}
    }
    public class Cross : Shapes
    {
        Point S;
        public Cross(Point _S)
        {
            S = _S;
        }
        public Cross(StreamReader sr)
        {
            String CrossSt = sr.ReadLine();
            string[] foo = CrossSt.Split(' ');
            S.X = Convert.ToInt16(foo[0]);
            S.Y = Convert.ToInt16(foo[1]);
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, S.X - 3, S.Y - 3, S.X + 3, S.Y + 3);
            g.DrawLine(p, S.X + 3, S.Y - 3, S.X - 3, S.Y + 3);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Cross");
            sw.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
        }
        public override string info
        {
            get
            {
                string info = "Cross " + Convert.ToString(S) + ";";
                return info;
            }
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
        public Line(StreamReader sr)
        {
            String LineSt = sr.ReadLine();
            string[] foo = LineSt.Split(' ');
            S.X = Convert.ToInt16(foo[0]);
            S.Y = Convert.ToInt16(foo[1]);
            String LineSt2 = sr.ReadLine();
            string[] foo2 = LineSt2.Split(' ');
            F.X = Convert.ToInt16(foo2[0]);
            F.Y = Convert.ToInt16(foo2[1]);
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, S.X, S.Y, F.X, F.Y);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Line");
            sw.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            sw.WriteLine(Convert.ToString(F.X) + " " + Convert.ToString(F.Y));
        }
        public override string info
        {
            get
            {
                string info = "Line first: " + Convert.ToString(S) + ", second: " + Convert.ToString(F) + ";";
                return info;
            }
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
        public Circle(StreamReader sr)
        {
            String LineSt = sr.ReadLine();
            string[] foo = LineSt.Split(' ');
            this.S.X = Convert.ToInt16(foo[0]);
            this.S.Y = Convert.ToInt16(foo[1]);
            String LineSt2 = sr.ReadLine();
            string[] foo2 = LineSt2.Split(' ');
            this.F.X = Convert.ToInt16(foo2[0]);
            this.F.Y = Convert.ToInt16(foo2[1]);
        }
        private float Radius
        {
            get
            {
                double Radius = Math.Sqrt(Math.Pow(F.X - S.X, 2) + Math.Pow(F.Y - S.Y, 2));
                return (float)Radius;
            }
        }
        public override string info
        {
            get
            {
                string info = "Circle R=" + Convert.ToString(Radius)+", center: "+Convert.ToString(S)+";";
                return info;
            }
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawEllipse(p, S.X - Radius, S.Y - Radius, Radius * 2, Radius * 2);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Circle");
            sw.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            sw.WriteLine(Convert.ToString(F.X) + " " + Convert.ToString(F.Y));
        }
    }
}
