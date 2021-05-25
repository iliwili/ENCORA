using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace les8
{
    public class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Ellipse Ellps { get; set; }
        private Canvas Cnvs { get; set; }

        // TODO
        public bool IsEnemy { get; set; }
        public int SpawnTime { get; set; }

        bool isMovingUp = true;
        bool isMovingDown = false;
        bool isMovingLeft = true;
        bool isMovingRight = false;


        public Ball(double x, double y, int width, int height, int spawnTime, bool isEnemy)
        {
            Ellps = new Ellipse();
            Width = width;
            Height = height;
            Ellps.Width = Width;
            Ellps.Height = Height;
            X = x;
            Y = y;
            // TODO
            SpawnTime = spawnTime;
            IsEnemy = isEnemy;  

            Ellps.Fill = new ImageBrush((ImageSource) new ImageSourceConverter().ConvertFromInvariantString($"{(IsEnemy ? "images/red_ball.png" : "images/ball.png")}"));
        }

        public void Move()
        {
            if (X == 0 || X > (Cnvs.ActualWidth - Width + 5))
            {
                if (isMovingLeft)
                {
                    isMovingLeft = false;
                    isMovingRight = true;
                } else if (isMovingRight) 
                {
                    isMovingRight = false;
                    isMovingLeft = true;
                }
            }

            if (Y == 0 || Y > (Cnvs.ActualHeight - Height))
            {
                if (isMovingDown)
                {
                    isMovingDown = false;
                    isMovingUp = true;
                }
                else if (isMovingUp)
                {
                    isMovingUp = false;
                    isMovingDown = true;
                }
            }

            if (isMovingDown)
            {
                Y += 1;
            } else if (isMovingUp)
            {
                Y -= 1;
            }
            if (isMovingLeft)
            {
                X += 1;
            } else if (isMovingRight)
            {
                X -= 1;
            }


            Canvas.SetLeft(Ellps, X);
            Canvas.SetBottom(Ellps, Y);
        }

        

        public void AddToCanvas(Canvas c)
        {
            c.Children.Add(Ellps);
            Cnvs = c;
        }


    }
}
