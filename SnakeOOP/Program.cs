using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int speed = 200;
            Walls walls = new Walls(80, 25);
            walls.Draw();
            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 3, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '@');
            FoodGenerator foodGenerator2 = new FoodGenerator(80, 25, '@');
            Point food = foodGenerator.GeneratorFood();
            Point foodBad = foodGenerator2.GeneratorFoodBad();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foodBad.Draw();
            Console.ForegroundColor = ConsoleColor.White;
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodGenerator.GeneratorFood();
                    food.Draw();
                    score++;
                    speed = speed - 7;
                    WriteScore(score);
                }
                else
                {
                    snake.Move();
                }
                if (snake.EatBad(foodBad))
                {
                    foodBad = foodGenerator2.GeneratorFoodBad();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foodBad.Draw();
                    Console.ForegroundColor = ConsoleColor.White;
                    score--;
                    speed = speed + 7;
                    WriteScore(score);
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(speed);

            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);

            Console.ReadLine();
        }
        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("======================", xOffset, yOffset++);
            WriteText("===== GAME  OVER =====", xOffset, yOffset++);
            WriteText("======================", xOffset, yOffset++);
            WriteText($"=== YOUR SCORE : {score} ===", xOffset, yOffset++);
            WriteText("======================", xOffset, yOffset++);
        }
        public static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        public static void WriteScore(int score)
        {
            Console.SetCursorPosition(100, 13);
            Console.WriteLine($"SCORE : {score}");
        }
    }
}
