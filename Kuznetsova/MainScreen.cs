using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kuznetsova
{
    public partial class MainScreen : Form
    {
        public List<Shapes> Shapes = new List<Shapes>();
        Pen pM = new Pen(Color.Black);
        public bool isShapeStart = true;
        public Point ShapeStart = new Point();
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + ' ' + Convert.ToString(e.Y);
            if (RdBxCross.Checked)
            {
                Shapes.Add(new Cross(e.X, e.Y));
            }
            else if (RdBxLine.Checked)
            {
                if (isShapeStart == true)
                {
                    isShapeStart = false;
                    ShapeStart = e.Location;
                }
                else
                {
                    Shapes.Add(new Line(ShapeStart,e.Location));
                    isShapeStart = true;
                }
            }
            else if (RdBxCircle.Checked)
            {
                if (isShapeStart == true)
                {
                    isShapeStart = false;
                    ShapeStart = e.Location;
                }
                else
                {
                    Shapes.Add(new Circle(ShapeStart, e.Location));
                    isShapeStart = true;
                }
            }
            this.Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shapes p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pM);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            isShapeStart = true;
            this.Refresh();
        }
        private void R_CheckedChanged(object sender, EventArgs e)
        {
            isShapeStart = true;
        }
    }
}
