using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Circle : Point2D
    {
        public float R1 { get; set; }

        public Circle(float x, float y, ColorFig color, float r, bool hide)
            : base(x, y, color, hide)
        {
            R1 = r;
        }

        // Copy constructor
        public Circle(Circle sourse):this(sourse.X, sourse.Y, sourse.Color, sourse.R1, sourse.Hide)
        {
        }

        public override Point[] BuildFigure()
        {
            Point[] result = new Point[(int)(2*((X + R1) - (X - R1) + 1))];
            int index = 0;
            for (int i = (int)(X - R1); i <= (int)(X + R1); i++)
            {
                float y0 = (int)Math.Sqrt(Math.Pow(Math.Ceiling(R1), 2) - Math.Pow(X - i, 2));
                result[index++] = new Point(i, (int)(Y + y0));
                result[index++] = new Point(i, (int)(Y - y0));
            }


            return result;
        }

        public override Figure2D Copy()
        {          
            return new Circle(X, Y, Color, R1, Hide);
        }

        public override void Reduce()
        {
            R1--;
        }
        public override void Increase()
        {
            R1++;
        }


        public override void Resize(int k)
        {
            R1 = k*R1;
        }

        public override void Rotate()
        {
        }

        public override float GetArea()
        {
            return (float)(Math.PI*R1*R1);
        }

        public override float GetPerimeter()
        {
            return (float)(2*Math.PI*R1);
        }
    }
}
