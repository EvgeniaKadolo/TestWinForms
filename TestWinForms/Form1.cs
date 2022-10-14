using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics graphics;
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rectangle> rectanglesToRemove = new List<Rectangle>();
        int count = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics = CreateGraphics();

            Rectangle rectangle = Rectangle.GetRandomRectangle();
            
            graphics.FillRectangle(new SolidBrush(rectangle.Color), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

            foreach (Rectangle r in rectangles)
            {
                if (rectangle.Intersects(r))
                {
                    rectanglesToRemove.Add(r);
                }
            }

            rectangles.Add(rectangle);

            if (count % 5 == 0 && rectanglesToRemove.Count != 0)
            {
                foreach (Rectangle r in rectanglesToRemove)
                {
                    rectangles.Remove(r);
                }

                graphics.Clear(BackColor);
                rectanglesToRemove.Clear();

                foreach (Rectangle r in rectangles)
                {
                    graphics.FillRectangle(new SolidBrush(r.Color), r.X, r.Y, r.Width, r.Height);
                }
            }
            count++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button1.Text = "Start";
                timer1.Enabled = false;
            }
            else
            {
                button1.Text = "Stop";
                timer1.Enabled = true;
            }
        }
    }
}
