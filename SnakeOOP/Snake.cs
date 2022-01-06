using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class Snake : Figure
    {
        Random rnd = new Random();
        int score = 16;
        Direction direction;
        public Snake(Point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            pointList = new List<Point>();
            for(int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pointList.Add(p);
            }
        }
        public void Move()
        {
            Point tail = pointList.First();
            pointList.Remove(tail);
            tail.Clear();

            Point head = GetNextPoint();
            pointList.Add(head);
            if (score >= 5 && score < 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                head.Draw();
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (score >= 10 && score < 16)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                head.Draw();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (score >= 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                head.Draw();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                head.Draw();
            }
        }
        public Point GetNextPoint()
        {
            Point head = pointList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void HandleKeys(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
        }
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.symb = head.symb;
                pointList.Add(food);
                score++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EatBad(Point foodBad)
        {
            Point head = GetNextPoint();
            if (head.IsHit(foodBad))
            {
                foodBad.symb = head.symb;
                score--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsHitTail()
        {
            Point head = pointList.Last();
            for(int i = 0; i < pointList.Count - 2; i++)
            {
                if (head.IsHit(pointList[i]))
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
