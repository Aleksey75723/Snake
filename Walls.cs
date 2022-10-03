using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();//список фигур

            // Отрисовка рамки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            wallList.Add(upLine);
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            wallList.Add(downLine);
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            wallList.Add(leftLine);
            VerticalLine rightLine = new VerticalLine(0, mapHeight , mapWidth - 2, '+');
            wallList.Add(rightLine);

            ////отрисовка рамки
            //HorizontaLine lineUp = new HorizontaLine(1, 79, 0, '*');
            //lineUp.Drow();
            //HorizontaLine lineDown = new HorizontaLine(1, 79, 24, '*');
            //lineDown.Drow();
            //VerticalLine lineLeft = new VerticalLine(1, 24, 0, '*');
            //lineLeft.Drow();
            //VerticalLine lineRight = new VerticalLine(1, 24, 79, '*');
            //lineRight.Drow();
        }

        internal bool IsHit(Figure figure)//столкнулась ли змейка со стеной
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()//поочередно пробегает по всем фигурам и вызывает метод Draw
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }


    }
}