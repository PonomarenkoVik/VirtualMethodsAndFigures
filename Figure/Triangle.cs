using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Triangle:Figure2D
    {

        public Point2D A2 { get; set; }
        public Point2D A3 { get; set; }


        public Triangle(float x, float y, ColorFig color, Point2D a2, Point2D a3, bool hide) : base(x, y, color, hide)
        {
            A2 = new Point2D(a2);
            A3 = new Point2D(a3);
        }

        // Copy constructor
        public Triangle(Triangle sourse)
            : this(sourse.X, sourse.Y, sourse.Color, sourse.A2, sourse.A3, sourse.Hide)
        {
        }

        public override Figure2D Copy()
        {
            return new Triangle(X, Y, Color, A2, A3, Hide);
        }

        public override Point[] BuildFigure()
        {
            int size = (int) ((A2.X - X) + (X - A3.X) + (A2.X - A3.X) + 3);
            Point [] result = new Point[size];
            int index = 0;
            for (int i = 0; i <= (int)(A2.X - X); i++)
            {
                result[index++] = new Point((int)(X + i), (int)(Y + (i * ((A2.Y - Y) / (A2.X - X)))));             
            }

            for (int i = 0; i <= (int)(X - A3.X); i++)
            {
                result[index++] = new Point((int)(X - i), (int)(Y - (i * ((A3.Y - Y) / (A3.X - X)))));               
            }

            for (int i = 0; i <= (int)(A2.X - A3.X); i++)
            {
                result[index++] = new Point((int)(A2.X - i), (int)(A2.Y + (i * ((A3.Y - A2.Y) / (A3.X - A2.X)))));
            }          
            return result;
        }

        public override void Move(int dx, int dy)
        {
            base.Move(dx, dy);
            A2.X += dx;
            A2.Y += dy;
            A3.X += dx;
            A3.Y += dy;
        }

        public override void Reduce()
        {
            throw new NotImplementedException();
        }

        public override void Increase()
        {
            throw new NotImplementedException();
        }

        public override void Resize(int k)
        {
            throw new NotImplementedException();
        }

        public override void Rotate()
        {
            throw new NotImplementedException();
        }

        public override float GetArea()
        {
            throw new NotImplementedException();
        }

        public override float GetPerimeter()
        {
            throw new NotImplementedException();
        }

    }
}
