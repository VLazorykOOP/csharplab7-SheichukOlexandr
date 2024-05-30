using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Color currentColor = Color.Black;
        private bool isDrawing = false;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Налаштування форми
            this.Text = "Drawing Application";

            // Панель для малювання
            Panel panel = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(900, 460),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            panel.MouseUp += new MouseEventHandler(Panel_MouseUp);
            this.Controls.Add(panel);

            // Кнопки для вибору кольору
            Button btnColorRed = new Button
            {
                Text = "Red",
                Location = new Point(1000, 10)
            };
            btnColorRed.Click += new EventHandler(BtnColorRed_Click);
            this.Controls.Add(btnColorRed);

            Button btnColorBlue = new Button
            {
                Text = "Blue",
                Location = new Point(1000, 50)
            };
            btnColorBlue.Click += new EventHandler(BtnColorBlue_Click);
            this.Controls.Add(btnColorBlue);

            Button btnColorGreen = new Button
            {
                Text = "Green",
                Location = new Point(1000, 90)
            };
            btnColorGreen.Click += new EventHandler(BtnColorGreen_Click);
            this.Controls.Add(btnColorGreen);

            Button btnColorBlack = new Button
            {
                Text = "Black",
                Location = new Point(1000, 130)
            };
            btnColorBlack.Click += new EventHandler(BtnColorBlack_Click);
            this.Controls.Add(btnColorBlack);

            // Кнопка для нової картинки
            Button btnNewPicture = new Button
            {
                Text = "New Picture",
                Location = new Point(1000, 170)
            };
            btnNewPicture.Click += new EventHandler(BtnNewPicture_Click);
            this.Controls.Add(btnNewPicture);
        }

        private void BtnColorRed_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void BtnColorBlue_Click(object sender, EventArgs e)
        {
            currentColor = Color.Blue;
        }

        private void BtnColorGreen_Click(object sender, EventArgs e)
        {
            currentColor = Color.Green;
        }

        private void BtnColorBlack_Click(object sender, EventArgs e)
        {
            currentColor = Color.Black;
        }

        private void BtnNewPicture_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)this.Controls[0];
            panel.Invalidate(); // Очищення панелі
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Panel panel = (Panel)sender;
                using (Graphics g = panel.CreateGraphics())
                {
                    g.FillEllipse(new SolidBrush(currentColor), e.X, e.Y, 5, 5);
                }
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }
    }
}
