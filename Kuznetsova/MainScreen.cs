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
        
        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + ' ' + Convert.ToString(e.Y);
            Shapes.Add(new Cross(e.X, e.Y));
            this.Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shapes p in this.Shapes)
            {
                p.DrawWith(e.Graphics, pM);
            }
        }
    }
}
