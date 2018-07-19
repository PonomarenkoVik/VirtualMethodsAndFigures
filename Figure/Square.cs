using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Square:Figure2D
    {
        public float L1 { get; set; }

        public Square(float x, float y, ColorFig color, float l1, bool hide) : base(x, y, color, hide)
        {
            L1 = l1;
        }


        // Copy constructor
       public Square(Square sourse):this(sourse.X, sourse.Y, sourse.Color, sourse.L1, sourse.Hide)
        {
        }


       public override Point[] BuildFigure()
       {
           //SetColor(source.Color, clear);
           Point[] result = new Point[(int)(4 * (L1 + 1))];
           int index = 0;
           for (int i = (int)(-L1/2); i <= L1/2; i++)
           {
               result[index++] = new Point((int)(X + i), (int)(Y - L1 / 2));
               result[index++] = new Point((int)(X + i), (int)(Y + L1 / 2));
               result[index++] = new Point((int)(X - L1/2), (int)(Y  + i));
               result[index++] = new Point((int)(X + L1/2), (int)(Y  + i));           
           }
           return result;
       }
       public override Figure2D Copy()
       {
           return new Square(X, Y, Color, L1, Hide);
       }

       public override void Reduce()
       {        
           L1--;
       }

       public override void Increase()
       {
           L1++;
       }

        public override void Resize(int k)
        {
            L1 = k*L1;
        }

        public override void Rotate()
        {
        }

        public override float GetArea()
        {
            return L1*L1;
        }

        public override float GetPerimeter()
        {
            return 2*(L1 + L1);
        }
    }
}
