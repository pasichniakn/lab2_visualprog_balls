using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows;
using System.Drawing.Drawing2D;

namespace lab2
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        List<Ball> ballslist = new List<Ball>();

       // List<List<float>> size = new List<List<float>>();

        public Form1()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            Load += Form1_Load_1;
            //List<float> currentsize = new List<float>();
            //currentsize.Add(pictureBox1.Height);
            //currentsize.Add(pictureBox1.Width);
            //size.Add(currentsize);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
           
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
        }
        
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.PeachPuff);
            
            foreach (Ball x in ballslist)
            {
                x.Move();
                x.Draw(graphics, x.Color);
                x.CollideWall(pictureBox1);
                x.CollideBall(ballslist);
               
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            ballslist.Clear();

            ballslist.Add(new Ball(218, 100, 17, 23, new Vector2(0.1f, 0.6f), new Vector2(5f, 2f), new Pen(Brushes.Blue)));
            ballslist.Add(new Ball(pictureBox1.Width - pictureBox1.Width / 6, 20, 20, 3, new Vector2(0.8f, 0.4f), new Vector2(-2f, 0.8f), new Pen(Brushes.Red)));
            ballslist.Add(new Ball(pictureBox1.Width /12, 278, 23, 7, new Vector2(0.9f, 0.3f), new Vector2(-0.2f, -0.8f), new Pen(Brushes.Lime)));
            ballslist.Add(new Ball(146, 30, 25 , 5, new Vector2(0.5f, 0.8f), new Vector2(0.3f, -2f), new Pen(Brushes.Yellow)));
            ballslist.Add(new Ball(315, 260, 15 , 13, new Vector2(0.2f, 0.5f), new Vector2(1.5f, -4f), new Pen(Brushes.RosyBrown)));
            
            foreach (Ball x in ballslist)
            {
                x.Draw(graphics, x.Color);
            }

            timer1.Interval = 30;
            
            timer1.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ballslist.Clear();
        }

       
    }

}
