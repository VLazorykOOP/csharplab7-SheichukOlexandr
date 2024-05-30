using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            Shape[] shapes = new Shape[]
            {
                new RectangleShape(),
                new PentagonShape(),
                new TriangleShape()
            };

            Random rand = new Random();
            foreach (Shape shape in shapes)
            {
                int x = rand.Next(pictureBox1.Width / 2);
                int y = rand.Next(pictureBox1.Height / 2);
                shape.Draw(g, x, y);
            }
        }
    }

    public abstract class Shape
    {
        public abstract void Draw(Graphics g, int x, int y);
    }

    public class RectangleShape : Shape
    {
        public override void Draw(Graphics g, int x, int y)
        {
            int radius = 50;
            g.DrawEllipse(Pens.Black, x, y, 2 * radius, 2 * radius);
            g.DrawRectangle(Pens.Black, x + radius / 2, y + radius / 2, radius, radius / 2);
        }
    }

    public class PentagonShape : Shape
    {
        public override void Draw(Graphics g, int x, int y)
        {
            int radius = 50;
            g.DrawEllipse(Pens.Black, x, y, 2 * radius, 2 * radius);

            PointF[] points = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                points[i] = new PointF(
                    x + radius + radius * (float)Math.Cos(i * 2 * Math.PI / 5 - Math.PI / 2),
                    y + radius + radius * (float)Math.Sin(i * 2 * Math.PI / 5 - Math.PI / 2));
            }
            g.DrawPolygon(Pens.Black, points);
        }
    }

    public class TriangleShape : Shape
    {
        public override void Draw(Graphics g, int x, int y)
        {
            int radius = 50;
            g.DrawEllipse(Pens.Black, x, y, 2 * radius, 2 * radius);

            PointF[] points = new PointF[3];
            for (int i = 0; i < 3; i++)
            {
                points[i] = new PointF(
                    x + radius + radius * (float)Math.Cos(i * 2 * Math.PI / 3 - Math.PI / 2),
                    y + radius + radius * (float)Math.Sin(i * 2 * Math.PI / 3 - Math.PI / 2));
            }
            g.DrawPolygon(Pens.Black, points);
        }
    }
}
