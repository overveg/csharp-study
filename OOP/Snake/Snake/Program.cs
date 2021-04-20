using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 3, '#');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            HorizontalLine line = new HorizontalLine(5, 10, 8, 'x');
            line.Drow();

            VerticalLine vLine = new VerticalLine(10, 2, 7, 'o');
            vLine.Drow();


            //
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            snake.direction = Direction.LEFT;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.direction = Direction.RIGHT;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.direction = Direction.DOWN;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.direction = Direction.UP;
                            break;

                    }
                }
                Thread.Sleep(100);
                snake.Move();

            }

            //Console.ReadLine();
        }


    }
}
