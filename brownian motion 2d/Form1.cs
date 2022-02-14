using System;
using System.Drawing;
using System.Windows.Forms;


namespace brownian_motion_2d
{
    public partial class Form1 : Form
    {
        Point[] points;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {


            Pen myPen = new Pen(Color.Black, 1f);

            Random rnd = new Random();

            int Seed = rnd.Next(1, 15790);

            string textboxValue = textBox1.Text;

            int valueInt = Int32.Parse(textboxValue);

            int N = valueInt;

            int dxs = rnd.Next(0, this.pictureBox1.Width);
            int dys = rnd.Next(0, this.pictureBox1.Height);

            int[] dx = new int[N];
            dx[0] = dxs;
            int rnd_tmp=0;
            for (int i = 1; i < N; i++)
            {
                rnd_tmp = rnd.Next(-20, 20);
                if (((dxs + rnd_tmp) < this.pictureBox1.Width) && ((dxs + rnd_tmp))>0)
                {
                    
                    dx[i] = dxs + rnd_tmp;
                    dxs = dx[i];
                }
                else
                {
                    dx[i] = (dxs + rnd_tmp * (-1));
                    dxs = dx[i];
                }
            }

            int[] dy = new int[N];
            dy[0] = dys;
            for (int b = 1; b < N; b++)
            {
                rnd_tmp = rnd.Next(-20, 20);
                if (((dys + rnd_tmp) < this.pictureBox1.Height)&& (dys + rnd_tmp) >0)
                {
                    dy[b] = dys + rnd_tmp;
                    dys = dy[b];
                }
                else
                {
                    dy[b] = (dys + rnd_tmp*(-1));
                    dys = dy[b];
                }

            }



            points = new Point[N];

            for (int v = 0; v < N; v++)
            {
                points[v] = new Point(dx[v], dy[v]);
                //label1.Text = points[v].ToString();
            }
            pictureBox1.CreateGraphics().DrawLines(myPen, points);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(Color.White);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (points != null)
                pictureBox1.CreateGraphics().DrawLines(new Pen(Color.Black, 1f), points);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
