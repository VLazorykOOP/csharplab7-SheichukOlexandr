using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private float currentAngle = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Invalidate();
            }
        }

        private void BtnRotateImage_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                currentAngle += 45;
                if (currentAngle >= 360) currentAngle = 0;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (originalImage != null)
            {
                Graphics g = e.Graphics;
                g.Clear(pictureBox1.BackColor);

                // Перетворення для центрування зображення
                g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
                g.RotateTransform(currentAngle);
                g.TranslateTransform(-originalImage.Width / 2, -originalImage.Height / 2);

                // Малювання зображення
                g.DrawImage(originalImage, new Point(0, 0));
            }
        }
    }
}
