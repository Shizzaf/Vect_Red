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
    public partial class MainScreen : Form
    {
        public List<Shapes> Shapes = new List<Shapes>();
        public bool isShapeStart = true;
        public Point ShapeStart = new Point();
        public Shapes tempShape;
        Pen pM = new Pen(Color.Black);
        Pen pTemp = new Pen(Color.Gray);
        Pen pCh = new Pen(Color.Red, 2);
        public MainScreen()
        {
            InitializeComponent();
        }
        private void AddShape(Shapes shape)
        {
            Shapes.Add(shape);
        }
        private void MainScreen_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            //
            if (e.Button == MouseButtons.Left)
            {
                this.Text = Convert.ToString(e.X) + ' ' + Convert.ToString(e.Y);
                int TempX, TempY;
                TempX = e.X;
                TempY = e.Y;
                Point TempPoint = new Point();
                if (RCross.Checked)
                {
                    AddShape(tempShape);
                    isShapeStart = true;
                    ShapesList.Items.Add("Cross " + Convert.ToString(e.Location));
                }
                else if (RLine.Checked)
                {
                    if (isShapeStart == true)
                    {
                        isShapeStart = false;
                        ShapeStart.X = TempX;
                        ShapeStart.Y = TempY;
                    }
                    else
                    {
                        TempPoint.X = e.X;
                        TempPoint.Y = e.Y;
                        AddShape(tempShape);
                        ShapesList.Items.Add("Line " + Convert.ToString(ShapeStart) + Convert.ToString(e.Location));
                        isShapeStart = true;
                    }
                }
                else if (RCircle.Checked)
                {
                    if (isShapeStart == true)
                    {
                        isShapeStart = false;
                        ShapeStart.X = TempX;
                        ShapeStart.Y = TempY;
                    }
                    else
                    {
                        TempPoint.X = e.X;
                        TempPoint.Y = e.Y;
                        AddShape(tempShape);
                        ShapesList.Items.Add("Circle " + Convert.ToString(ShapeStart) + Convert.ToString(e.Location));
                        isShapeStart = true;
                    }
                }
                this.Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                foreach (Shapes p in this.Shapes)
                {
                    if (p.Near_point(e.Location) == true)
                    {
                        ShapesList.SetSelected(Shapes.IndexOf(p), true);//выделяет ближайшую фигуру
                    }
                }

            }
        }
        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            if (tempShape != null)
            {
                tempShape.DrawWith(e.Graphics, pTemp);
            }
            foreach (int i in ShapesList.SelectedIndices)
            {
                Shapes[i].DrawWith(e.Graphics, pCh);
            }
            foreach (Shapes p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pM);
            }

        }
        private void ClearButt_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            isShapeStart = true;
            ShapesList.Items.Clear();
            tempShape = null;
            this.Refresh();
        }
        private void R_CheckedChanged(object sender, EventArgs e)
        {
            isShapeStart = true;
        }
        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String curFile = "test.txt";
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                curFile = SaveDialog.FileName;
                StreamWriter sw = new StreamWriter(curFile);
                foreach (Shapes p in this.Shapes)
                {
                    p.SaveTo(sw);
                }
                sw.Close();
            }
            isShapeStart = true;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String curFile = "test.txt";
            Shapes.Clear();
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                curFile = OpenDialog.FileName;
                StreamReader sr = new StreamReader(curFile);
                while (!sr.EndOfStream)
                {
                    string type = sr.ReadLine();
                    switch (type)
                    {
                        case "Cross":
                            {
                                Shapes.Add(new Cross(sr));
                                break;
                            }
                        case "Line":
                            {
                                Shapes.Add(new My_line(sr));
                                break;
                            }
                        case "Circle":
                            {
                                Shapes.Add(new My_circle(sr));
                                break;
                            }
                        case "":
                            {
                                break;
                            }
                    }
                    this.Refresh();
                }
                sr.Close();
            }
        }
        private void MainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + ' ' + Convert.ToString(e.Y);
            Point TempPoint = e.Location;
            if (RCross.Checked)
            {
                tempShape = new Cross(e.X, e.Y);
                this.Refresh();
            }
            else if (RLine.Checked)
            {
                if (isShapeStart == false)
                {
                    tempShape = new My_line(ShapeStart, TempPoint);
                    this.Refresh();
                }
            }
            else if (RCircle.Checked)
            {
                if (isShapeStart == false)
                {
                    tempShape = new My_circle(ShapeStart, TempPoint);
                    this.Refresh();
                }
            }

        }
        private void D_Unit_Click(object sender, EventArgs e)
        {
            while (ShapesList.SelectedIndices.Count > 0)
            {
                Shapes.RemoveAt(ShapesList.SelectedIndices[0]);
                ShapesList.Items.RemoveAt(ShapesList.SelectedIndices[0]);
            }
            tempShape = null;
            Refresh();
        }
        private void ShapesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            isShapeStart = true;
            tempShape = null;
            this.Refresh();
        }
    }
}
