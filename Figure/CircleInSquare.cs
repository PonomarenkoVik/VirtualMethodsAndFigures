using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo.Figure
{
    class CircleInSquare:Square
    {

        public CircleInSquare(float x, float y, ColorFig color, float l1, bool hide)
            : base(x, y, color, l1, hide)
        {
            _circle = new Circle(x, y, color, l1/2, hide);
            _square = new Square(x, y, color, l1, hide);
        }

        public override Figure2D Copy()
        {
            return new CircleInSquare(X, Y, Color, L1, Hide);
        }

        public CircleInSquare(Square source)
            : base(source)
        {
        }

        public override Point[] BuildFigure()
        {
            Point[] pointsS = _square.BuildFigure();
            Point[] pointsC = _circle.BuildFigure();
            Point[] result = new Point[pointsC.Length + pointsS.Length];
            pointsS.CopyTo(result, 0);
            pointsC.CopyTo(result, pointsS.Length);
            return result;
        }

        public override void Reduce()
        {
            L1 = L1 - 1;
            _circle.R1 = _circle.R1 - 0.5f;
            _square.L1 = _square.L1 - 1;
        }

        public override void Increase()
        {
            L1 = L1 + 1;
            _circle.R1 = _circle.R1 + 0.5f;
            _square.L1 = _square.L1 + 1;
        }

        public override void Move(int dx, int dy)
        {
            _circle.Move(dx, dy);
            _square.Move(dx, dy);
        }

        public override float GetArea()
        {
            return _square.GetArea() - _circle.GetArea();
        }

        private Circle _circle;
        private Square _square;
    }
}
