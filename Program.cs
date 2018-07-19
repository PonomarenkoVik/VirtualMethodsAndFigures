using System;
using System.ComponentModel;
using System.Drawing;
using _20180131_InheritanceDemo.Figure;


namespace _20180131_InheritanceDemo
{
    class MyKeyEventArgs : HandledEventArgs
    {
        // нажатая кнопка
        public ConsoleKeyInfo Key;

        public MyKeyEventArgs(ConsoleKeyInfo key)
        {
            Key = key;
        }
    }


    class KeyEvent
    {
        // событие нажатия
        public event EventHandler<MyKeyEventArgs> KeyPress;

        // метод запуска события
        public void OnKeyPress(ConsoleKeyInfo key)
        {
            if (KeyPress != null) KeyPress(this, new MyKeyEventArgs(key));
        }
    }

    class Program
    {
        static Random randCol = new Random();
        
        static void Main(string[] args)
        {
            FigureContainer container = new FigureContainer();
            const int xStart = 20;
            const int yStart = 20;
            int indexCurrentFigure = 0;
            UI.StartShow();      
            UI.Kevt.KeyPress += (sender, e) =>
            {
                UI.ShowIndex(indexCurrentFigure);              
                Figure2D tempFig;
                
                switch (e.Key.Key)
                {
                    case ConsoleKey.D1:
                            ColorFig col = GetColor();                      
                            tempFig = new Triangle(xStart, yStart, col, new Point2D(25, 25, col, false), new Point2D(15, 25, col, false), false);
                            indexCurrentFigure = container.Add(tempFig) ;
                            UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
                        break;
                    case ConsoleKey.D2:                        
                            tempFig = new Square(xStart, yStart, GetColor(), 6, false);
                            indexCurrentFigure = container.Add(tempFig) ;
                            UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));                   
                        break;
                    case ConsoleKey.D3:                       
                            tempFig = new Rectangle(xStart, yStart, GetColor(), 12, 4, false);
                            indexCurrentFigure = container.Add(tempFig) ;
                            UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2)); 
                        break;
                    case ConsoleKey.D4:                      
                            tempFig = new Circle(xStart, yStart, GetColor(), 3, false);
                            indexCurrentFigure = container.Add(tempFig) ;
                            UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));  
                        break;
                    case ConsoleKey.D5:                        
                            tempFig = new Ellipse(xStart, yStart, GetColor(), 8, 2, false);
                            indexCurrentFigure = container.Add(tempFig) ;
                            UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
                        break;
                    case ConsoleKey.D6:
                        container.Delete(indexCurrentFigure);
                        indexCurrentFigure = ChooseAnotherFigure(container, indexCurrentFigure);
                        UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
                        break;

                    case ConsoleKey.D7:
                        if (container[indexCurrentFigure])
                        {
                         container.Hide(indexCurrentFigure, false);   
                        }
                        else
                        {
                            container.Hide(indexCurrentFigure, true);
                        }
                     
                        UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
                        break;
                    case ConsoleKey.D8:
                        container.Rotate(indexCurrentFigure);
                        UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
                        break;
                    case ConsoleKey.D9:
                        tempFig = new CircleInSquare(xStart, yStart, GetColor(), 6, false);
                        indexCurrentFigure = container.Add(tempFig);
                        UI.Show(container.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
                        break;
                    case ConsoleKey.LeftArrow:                        
                        Move(container, indexCurrentFigure, -1, 0);
                        break;   

                    case ConsoleKey.RightArrow:
                        Move(container, indexCurrentFigure, 1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        Move(container, indexCurrentFigure, 0, 1);
                        break;

                    case ConsoleKey.UpArrow:
                        Move(container, indexCurrentFigure, 0, -1);
                        break;

                    case ConsoleKey.Add:
                        IncreaseFigure(container, indexCurrentFigure);
                        break;

                    case ConsoleKey.Subtract:
                        ReduceFigure(container, indexCurrentFigure);
                        break;

                    case ConsoleKey.PageUp:
                        for (int i = indexCurrentFigure; i < container.Length - 1; i++)
                        {
                            if (container.GetExistFigure(indexCurrentFigure + 1) != false)
                            {
                                indexCurrentFigure++;
                                break;
                            }   
                        }
                        break;

                    case ConsoleKey.PageDown:
                        for (int i = indexCurrentFigure; i > 0; i--)
                        {
                            if (container.GetExistFigure(indexCurrentFigure - 1) != false)
                            {
                                indexCurrentFigure--;
                                break;
                            }
                        }
                        break;
                }              
            };

            UI.GetPush();
        }

        private static void Move(FigureContainer source, int index, int dx, int dy)
        {
            source.Move(index, dx, dy);
            UI.Show(source.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
        }

        private static byte ChooseAnotherFigure(FigureContainer source, int indexCurrentFigure)
        {
            for (int i = indexCurrentFigure; i < source.Length - 1; i++)
            {
                if (source.GetExistFigure(indexCurrentFigure + 1) != null)
                {
                    indexCurrentFigure++;
                    break;
                }   
            }
            if (source.GetExistFigure(indexCurrentFigure) == null)
            {
                for (int i = indexCurrentFigure; i > 0; i--)
                {
                    if (source.GetExistFigure(indexCurrentFigure - 1) != null)
                    {
                        indexCurrentFigure--;
                        break;
                    }
                }  
            }
            return (byte)indexCurrentFigure;
        }

        private static void IncreaseFigure(FigureContainer source, int index)
        {
            if (source != null)
            {
                source.Increase(index);
                UI.Show(source.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2));
            }           
        }

        private static void ReduceFigure(FigureContainer source, int index)
        {
            if (source != null)
            {             
                source.Reduce(index);
                UI.Show(source.BuildScreen(UI.WindowWidth, UI.WindowHeight - 2)); 
            }           
        }

        private static ColorFig GetColor()
        {
            return (ColorFig)randCol.Next(2, 7);
        }    
    }
}
