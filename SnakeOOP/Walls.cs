using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizantalLine top = new HorizantalLine(0, 80, 0, '#');
            VerticalLine left = new VerticalLine(0, 25, 0, '#');
            HorizantalLine bottom = new HorizantalLine(0, 80, 25, '#');
            VerticalLine right = new VerticalLine(0, 25, 80, '#');

            VerticalLine obstacle = new VerticalLine(10, 13, 50, '%');

            wallList.Add(top);
            wallList.Add(bottom);
            wallList.Add(right);
            wallList.Add(left);
            wallList.Add(obstacle);

        }
        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }
        public bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
