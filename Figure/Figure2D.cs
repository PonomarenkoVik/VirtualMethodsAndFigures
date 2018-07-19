using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    abstract class Figure2D
    {
        public bool Hide { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public ColorFig Color { get; set; }

        protected Figure2D(float x, float y, ColorFig color, bool hide)
        {
            X = x;
            Y = y;
            Color = color;
            Hide = hide;
        }

        public abstract Figure2D Copy();

        public abstract Point[] BuildFigure();
              
        public virtual void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }       

        public abstract void Reduce();

        public abstract void Increase();

        public abstract void Resize(int k);

        public abstract void Rotate();

        public abstract float GetArea();

        public abstract float GetPerimeter();
    }
}
