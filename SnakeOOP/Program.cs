using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 10, '*');
            Point p2 = new Point(11, 10, '*');

            HorizantalLine hLine = new HorizantalLine(10, 14, 5, '#');
            VerticalLine vLine = new VerticalLine(6, 16, 14, '#');
            //hLine.Draw();
            //vLine.Draw();

            HorizantalLine top = new HorizantalLine(0, 80, 0, '#');
            VerticalLine left = new VerticalLine(0, 25, 0, '#');
            HorizantalLine bottom = new HorizantalLine(0, 80, 25, '#');
            VerticalLine right = new VerticalLine(0, 25, 80, '#');
            right.Draw();
            bottom.Draw();
            left.Draw();
            top.Draw();

            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 3, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '@');
            Point food = foodGenerator.GeneratorFood();

            while (true)
            {
                if (snake.Eat(food))
                {

                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(300);
                //snake.Move();

            }

            Console.ReadLine();
        }
    }
}
