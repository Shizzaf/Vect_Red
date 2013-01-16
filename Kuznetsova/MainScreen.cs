using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Kuznetsova
{
    public partial class MainScreen : Form
    {
        public List<Shapes> Shapes = new List<Shapes>();
        Pen pM = new Pen(Color.Black);
        public bool isShapeStart = true;
        public Point ShapeStart = new Point();
        public Shapes tempShape;
        Pen pTemp = new Pen(Color.Gray);
        Pen pCh = new Pen(Color.Red, 2);
        public MainScreen()
        {
            InitializeComponent();
        }
        private void AddShape(Shapes shape)
        {
            Shapes.Add(shape);
            ShapesList.Items.Add(shape.info);
        }
        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + ' ' + Convert.ToString(e.Y);
            if (RdBxCross.Checked)
            {
                AddShape(tempShape);
                isShapeStart = true;
            }
            else 
            {
                if (isShapeStart)
                {
                    isShapeStart = false;
                    ShapeStart = e.Location;
                }
                else
                {
                    AddShape(tempShape);
                    isShapeStart = true;
                }
            }
            this.Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            if (tempShape != null)
            {
                tempShape.DrawWith(e.Graphics, pTemp);
            }
            foreach (Shapes p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pM);
            }
            foreach (int i in ShapesList.SelectedIndices)
            {
                Shapes[i].DrawWith(e.Graphics, pCh);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            isShapeStart = true;
            tempShape = null;
            ShapesList.Items.Clear();
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
                StreamWriter sw = new StreamWriter(curFile+".txt");
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
            String curFile;
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
                                Shapes.Add(new Line(sr));
                                break;
                            }
                        case "Circle":
                            {
                                Shapes.Add(new Circle(sr));
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
            if (RdBxCross.Checked)
            {
                tempShape = new Cross(e.Location);
                this.Refresh();
            }
            else
            {
                if (isShapeStart == false)
                {
                    if (RdBxLine.Checked)
                        tempShape = new Line(ShapeStart, e.Location);
                    if (RdBxCircle.Checked)
                        tempShape = new Circle(ShapeStart, e.Location);
                    this.Refresh();
                }
            }
        }

        private void BtnDelUnit_Click(object sender, EventArgs e)
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
