using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows;
using System.Windows.Forms;


namespace lab2
{
    
    public class Ball
    {
        public double Pos_X;
        public double Pos_Y;
        public double Diametr;
        public double Mass;
        public Vector2 Velocity;
        public Vector2 Direction;
        public Pen Color;

        public Ball(double x, double y, double diam, double mas, Vector2 v, Vector2 dir, Pen Color)
        {
            this.Pos_X = x;
            this.Pos_Y = y;
            this.Diametr = diam;
            this.Mass = mas;
            this.Velocity = v;
            this.Direction = Vector2.Normalize(dir);
            this.Color = Color;
        }
        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF elipse = new RectangleF(Convert.ToSingle(this.Pos_X - (this.Diametr / 2)), Convert.ToSingle(this.Pos_Y - (this.Diametr / 2)), Convert.ToSingle(this.Diametr), Convert.ToSingle(this.Diametr));
            graphics.FillEllipse(pen.Brush, elipse);
            graphics.DrawEllipse(pen, elipse);
        }
        public void Move()
        {
            //float v = this.Velocity.Length();
            this.Pos_X += this.Direction.X * this.Velocity.X *this.Mass;
            this.Pos_Y += this.Direction.Y * this.Velocity.Y * this.Mass;

        }

        public void CollideWall(PictureBox pictureBox )
        {
            
            
            for (double p = 0.0; p <= pictureBox.Width; p += 1)
            {
                if ((pictureBox.Height - this.Pos_Y) <= (this.Diametr / 2.0)||
                      (this.Pos_Y <= this.Diametr / 2.0))  //Math.Pow((p - this.Pos_X), 2) + Math.Pow(pictureBox.Height - this.Pos_Y, 2) <= Math.Pow(this.Diametr / 2.0, 2))
                {
                    this.Direction.Y = this.Direction.Y * (-1);
                    break;
                }
            }
            
            for (double p = 0.0; p <= pictureBox.Height; p += 1)
            {
                if (this.Pos_X <= (this.Diametr / 2.0)||
                    pictureBox.Width - this.Pos_X <= this.Diametr / 2.0)//Math.Pow((this.Pos_X), 2.0) + Math.Pow((p - this.Pos_Y), 2.0) <= Math.Pow((this.Diametr / 2.0), 2.0))
                {
                    this.Direction.X = this.Direction.X * (-1);
                    
                    break;
                }
            }
          
        }
        
        public void CollideBall(List<Ball> ballslist)
        {
            foreach (Ball x in ballslist)
            {
                if (x != this)
                {
                    if(Math.Abs(this.Pos_X - x.Pos_X)<=(this.Diametr/2+x.Diametr/2) &&
                        Math.Abs(this.Pos_Y - x.Pos_Y) <= (this.Diametr / 2 + x.Diametr / 2))
                    {
                        this.Direction = Vector2.Negate(this.Direction);
                        x.Direction = Vector2.Negate(x.Direction);

                        break;
                    }
                }
            }
        }
    }
    
    
}
