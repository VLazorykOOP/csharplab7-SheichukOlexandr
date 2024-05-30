using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Task3
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

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Bitmap rotatedImage = RotateImage(originalImage, currentAngle, 700, 700);
                    rotatedImage.Save(saveFileDialog1.FileName);
                }
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

        private Bitmap RotateImage(Bitmap bitmap, float angle, int width, int height)
        {
            Bitmap rotatedBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                g.TranslateTransform((float)width / 2, (float)height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }
            return rotatedBitmap;
        }
    }
}
