using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    static class UI
    {
        public const int WindowHeight = 40;
        public const int WindowWidth = 72;
        public static KeyEvent Kevt = new KeyEvent();  
        public static void StartShow()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = WindowHeight;
            Console.WindowWidth = WindowWidth;
            Console.Write("1-triangle, 2-square, 3-rectangle, 4-circle, 5-ellipse, 6-delete figure, 7-hide, 8-rotate, arrows-moving \n+  increase in size, -  reduction in size, PageUp/Down - figure choosing");   
        }
 
        public static void Show(Cell[,] source)
        {
           
            for (int i = 0; i < source.GetLength(1); i++)
            {
                for (int j = 0; j < source.GetLength(0); j++)
                {
                    Console.SetCursorPosition(j, i + 2);
                    Console.ForegroundColor = (source[j, i].Exist) && !source[j, i].Hide ? GetColor(source[j, i].Color) : Console.BackgroundColor;
                    Console.Write("*");
                }
            }          
        }

        public static void GetPush()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                Kevt.OnKeyPress(key);
            }
        }

        private static ConsoleColor GetColor(ColorFig sourse)
        {
            ConsoleColor col = ConsoleColor.Black;
            switch (sourse)
            {
                case ColorFig.Red:
                    col = ConsoleColor.Red;
                    break;
                case ColorFig.Green:
                    col = ConsoleColor.Green;
                    break;
                case ColorFig.Yellow:
                    col = ConsoleColor.Yellow;
                    break;
                case ColorFig.DarkRed:
                    col = ConsoleColor.DarkRed;
                    break;
                case ColorFig.Blue:
                    col = ConsoleColor.Blue;
                    break;
                case ColorFig.White:
                    col = ConsoleColor.White;
                    break;
                case ColorFig.DarkYellow:
                    col = ConsoleColor.DarkYellow;
                    break;
            }
            return col;
        }

        public static void ShowIndex(int index)
        {
            Console.SetCursorPosition(70, 1);
            Console.WriteLine(index); 
        }

    }
}
