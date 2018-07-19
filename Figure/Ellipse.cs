using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Ellipse:Circle
    {

        public float R2 { get; set; }


        public Ellipse(float x, float y, ColorFig color, float r1, float r2, bool hide) : base(x, y, color, r1, hide)
        {
            R2 = r2;
        }

        // Copy constructor
        public Ellipse(Ellipse sourse):this(sourse.X, sourse.Y, sourse.Color, sourse.R1, sourse.R2, sourse.Hide)
        {
        }
        public override Point[] BuildFigure()
        {
            Point[] result = new Point[(int)(4*R1 + 2)];
            int index = 0;
            for (int i = (int)-R1; i <= (int)R1; i++)
            {
                float y0 = (float)Math.Sqrt(Math.Pow(R2, 2) * (1 - Math.Pow(i, 2) / Math.Pow(R1, 2)));
                result[index++] = new Point((int)(X + i), (int)(Y + y0));
                result[index++] = new Point((int)(X + i), (int)(Y - y0));
            }
            return result;
        }

        public override Figure2D Copy()
        {
            return new Ellipse(X, Y, Color, R1, R2, Hide);
        }
         public override void Reduce()
        {
            float temp = R1;
            R1--;
            R2 = R2 * (R1 / temp);
        }

         public override void Increase()
         {
             float temp = R1;
             R1++;
             R2 = R2 * (R1 / temp);
         }


         public override void Resize(int k)
         {
             R1 = k*R1;
             R2 = k*R2;
         }

         public override void Rotate()
         {
             float temp = R2;
             R2 = R1;
             R1 = temp;
         }

         public override float GetArea()
         {
             return (float)(Math.PI*R2*R1) ;
         }

         public override float GetPerimeter()
         {
             return (float)(4*((Math.PI*R2*R1 - (R2-R1)*(R2-R1))/(R2 + R1)));
         }
    }
}
