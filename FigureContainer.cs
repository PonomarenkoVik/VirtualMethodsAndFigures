using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class FigureContainer
    {
        private const int Size = 20;

        public int Length
        {
            get
            {
                return _figures.Length;
            }
        }

        public bool this[int index ]
        {
            get
            {
                return _figures[index].Hide;
            }
        }
        public FigureContainer() 
        {
          _figures = new Figure2D[Size];  
        }

        public FigureContainer(int size)
        {
            _figures = new Figure2D[size];
        }

        public FigureContainer Copy()
        {
            FigureContainer result = new FigureContainer(_figures.Length);
            for (int i = 0; i < _figures.Length; i++)
            {
                result._figures[i] = _figures[i].Copy();
            }
            return result;
        }

        public short Add(Figure2D source)
        {
            short result = -1;
            if (source != null)
            {
                int initialSize = _figures.Length;
                for (int i = 0; i < initialSize; i++)
                {
                    if (_figures[i] == null)
                    {
                        _figures[i] = source.Copy();
                        result = (short)i;
                        break;
                    }
                }

                if (result < 0)
                {
                    Figure2D[] tempArray = new Figure2D[2*initialSize];
                    for (int i = 0; i < initialSize; i++)
                    {
                        tempArray[i] = _figures[i];
                    }
                    _figures = tempArray;
                    _figures[initialSize] = source.Copy();
                    result = (short)initialSize;
                }
            }
            return result;
        }

        public void Delete(int index)
        {
            _figures[index] = null;
        }

        public void Rotate(int index)
        {
            _figures[index].Rotate();
        }

        public void Hide(int index, bool hide)
        {
            _figures[index].Hide = hide;
        }
        public void Move(int index, int dx, int dy)
        {
            _figures[index].Move(dx, dy);
        }

        public void Reduce(int index)
        {
            _figures[index].Reduce();
        }

        public void Increase(int index)
        {
            _figures[index].Increase();
        }

        public bool? GetExistFigure(int index)
        {
            bool? result = null;
            if (index < _figures.Length)
            {
                result = _figures[index] != null;
            }
            return result;
        }

        public Cell[,] BuildScreen(int width, int height)
        {
            Cell[,] result = new Cell[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                  result[j, i] = new Cell();  
                }
            }

            foreach (Figure2D figure in _figures)
            {
                if (figure != null)
                {
                    Point[] points = figure.BuildFigure();
                    ColorFig col = figure.Color;
                    bool hide = figure.Hide;
                    foreach (Point point in points)
                    {
                        result[point.X, point.Y].Exist = true;
                        result[point.X, point.Y].Color = col;
                        result[point.X, point.Y].Hide = hide;
                    }
                }
            }
            return result;
        }

        private Figure2D[] _figures;
    }
}
