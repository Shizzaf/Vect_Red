using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Kuznetsova
{
    public class Cross : Shapes
    {
        int X, Y;
        public Cross(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }
        public Cross(StreamReader sr)
        {
            String CrossSt = sr.ReadLine();
            string[] foo = CrossSt.Split(' ');
            X = Convert.ToInt16(foo[0]);
            Y = Convert.ToInt16(foo[1]);
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, X - 3, Y - 3, X + 3, Y + 3);
            g.DrawLine(p, X + 3, Y - 3, X - 3, Y + 3);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Cross");
            sw.WriteLine(Convert.ToString(X) + " " + Convert.ToString(Y));
        }
        public override double len(Point First, Point Second)
        {
            double r = Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
            return r;
        }
        public override bool Near_point(Point point)
        {
            Point cross = new Point();
            cross.X = X;
            cross.Y = Y;
            double len_cross_point = len(cross, point);
            if (len_cross_point > 2)
                return false;
            else
                return true;
        }
    }
    public abstract class Shapes
    {
        public abstract void DrawWith(Graphics g, Pen p);
        public abstract void SaveTo(StreamWriter sw);
        public abstract bool Near_point(Point point);
        public abstract double len(Point First, Point Second);
    }
    //класс линий с конструктором и отрисовкой
    public class My_line : Shapes
    {
        //S - стартовая координата, F - конечная координата 
        Point S, F;
        Pen p = new Pen(Color.Black);
        public My_line(Point _S, Point _F)
        {
            S = _S;
            F = _F;
        }
        public My_line(StreamReader sr)
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
        public override double len(Point First, Point Second)
        {
            double r = Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
            return r;
        }
        public override bool Near_point(Point point)
        {
            double a = (double)len(point, F);
            double b = (double)len(point, S);
            double c = (double)len(S, F);
            double cos_alpha = (Math.Pow(a, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) / (-2 * b * c);
            double cos_betha = (Math.Pow(b, 2) - Math.Pow(a, 2) - Math.Pow(c, 2)) / (-2 * a * c);
            //float
            double len_point = 0;
            // Double
            if ((cos_alpha > 0) && (cos_betha > 0))
            {
                len_point = cos_alpha * b;
            }
            else if ((cos_alpha < 0) && (cos_betha > 0))
            {
                len_point = b;
            }
            else if ((cos_alpha > 0) && (cos_betha < 0))
            {
                len_point = a;
            }
            else if ((cos_alpha == 0) && (cos_betha > 0))
            {
                len_point = b;
            }
            else if ((cos_alpha > 0) && (cos_betha == 0))
            {
                len_point = a;
            }
            MainScreen.ActiveForm.Text = Convert.ToString(cos_betha);
            if (len_point > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
    public class My_circle : Shapes
    {
        //S - стартовая координата, F - конечная координата 
        Point S, F;
        Pen p = new Pen(Color.Black);
        public My_circle(Point _S, Point _F)
        {
            S = _S;
            F = _F;
        }
        public My_circle(StreamReader sr)
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
        public override double len(Point First, Point Second)
        {
            double r = Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
            return r;
        }
        public override bool Near_point(Point point)
        {
            double len_center_point = len(F, point);
            double len_circle_point = len_center_point - Radius;
            if (len_circle_point > 1)
                return false;
            else
                return true;
        }
    }
}
