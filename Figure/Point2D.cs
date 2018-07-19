using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo    
{
    class Point2D : Figure2D
    {
        // конструктор с 3-мя параметрами (наиболее полная версия конструктора)
        public Point2D(float x, float y, ColorFig color, bool hide)
            : base(x, y, color, hide)    // вызов конструктора базового класса с 3-мя параметрами
        {
        }

        // конструктор копирования
        public Point2D(Point2D source)
            : this(source.X, source.Y, source.Color, source.Hide)
        {
        }


        public override Figure2D Copy()
        {
            return new Point2D(X, Y, Color, Hide);
        }

        public override Point[] BuildFigure()
        {
            return  new[]
            {
                new Point((int)X, (int)Y)
            };
        }

        public override void Reduce()
        { 
        }

        public override void Increase()
        {
        }

        public override void Resize(int k)
        {
        }

        public override void Rotate()
        {
        }

        public override float GetArea()
        {
            return 0;
        }

        public override float GetPerimeter()
        {
            return 0;
        }
    }

}
