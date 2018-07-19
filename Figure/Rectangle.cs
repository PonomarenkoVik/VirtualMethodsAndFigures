using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Rectangle:Square
    {
        public float L2 { get; set; }

        public Rectangle(float x, float y, ColorFig color, float l1, float l2, bool hide) : base(x, y, color,l1, hide)
        {
            L2 = l2;
        }

        // Copy constructor
        public Rectangle(Rectangle sourse):this(sourse.X, sourse.Y, sourse.Color, sourse.L1, sourse.L2, sourse.Hide)
        {
        }

        public override Point[] BuildFigure()
        {
            Point[] result = new Point[(int)(2 * (L1 + 1) + 2 * (L2 + 1))];
            int index = 0;
            for (int i = (int)(-L1/2); i <= L1/2; i++)
            {
                result[index++] = new Point((int)(X + i), (int)(Y - L2/2));
                result[index++] = new Point((int)(X + i), (int)(Y + L2/2));
            }
            for (int i = (int)(-L2 / 2); i <= L2 / 2; i++)
            {
                result[index++] = new Point((int)(X - L1/2), (int)(Y + i));
                result[index++] = new Point((int)(X + L1/2), (int)(Y + i));
            }
            return result;
        }

        public override Figure2D Copy()
        {
            return new Rectangle(X, Y, Color, L1, L2, Hide);
        }

        public override void Reduce()
        {
            float temp = L1;
            L1--;
            L2 = L2 * (L1 / temp);
        }

        public override void Increase()
        {
            float temp = L1;
            L1++;
            L2 = L2 * (L1 / temp);
        }


        public override void Resize(int k)
        {
            L2 = k*L2;
            L1 = k*L1;
        }

        public override void Rotate()
        {
            float temp = L2;
            L2 = L1;
            L1 = temp;
        }

        public override float GetArea()
        {
            return L2*L1;
        }

        public override float GetPerimeter()
        {
            return 2*(L2 + L1);
        }
    }
}
