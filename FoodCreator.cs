using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Snake
{
    internal class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)//габариты карты, символ еды
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()//где будет создаваться еда
        {
            int x = random.Next(3, mapWidth - 2);
            int y = random.Next(3, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}