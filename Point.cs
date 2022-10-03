using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        //координаты и символ точки
        public int x;
        public int y;
        public char sym;

        public Point(int x_, int y_, char sym_)//методы для создания точек
        {
            x = x_;
            y = y_;
            sym = sym_;
        }
        public Point()
        {
        }


        public Point(Point p)//задаются точки с помощью другой точки, создается точка точная копия хвоста
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)//сдвигает точку на расстояние offset по направлению Direction
        {
            if (direction == Direction.RIGHT) { x += offset; } 
            else if ( direction == Direction.LEFT ) { x -= offset; }

            if (direction == Direction.UP) { y -= offset; }
            else if (direction == Direction.DOWN) { y += offset; }
        }

        public bool IsHit(Point p)//проврека на равенство координат в текущей точки и точки в аргументе "Point p"
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Clear()//затирается точка которая была хвостовой
        {
            sym = ' ';
            Draw();
        }

        public void Draw()//вывод символа
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public override string ToString()//чтобы в отладчике было удобнее смотреть назначение переменной Point
        {
            return x + "," + y + "," + sym;
        }


    }
}
