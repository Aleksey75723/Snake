using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;//направление

        public Snake(Point tail, int lenght, Direction _direction)//змейка(координаты хвоста, длина, направление)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);//в цикле создаются точки, копии хвостовой точки
                p.Move(i,direction);//сдвиг точки по направлению direction
                pList.Add(p);//добавить эту точку в список
            }
        }

        internal void Move()//выполнение движения змейки
        {
            Point tail = pList.First();//возвращает первый элемент списка
            pList.Remove(tail);//стирается после прохождения змейки
            Point head = GetNextPoint();//куда движется голова
            pList.Add(head);//добавляется новое положение головы в список

            tail.Clear();//затирается точка которая была хвостовой
            head.Draw();//новая головная точка выводится на экран
        }
        public Point GetNextPoint()//вычисляет в какой точке окажется змейка в следующий момент
        {
            Point head = pList.Last();//текущая позиция головы змейки
            Point nextPoint = new Point(head);//создаётся точка, копия предыдущего положения головы
            nextPoint.Move(1,direction);//точка сдвигается по направлению direction
            return nextPoint;//новое положение головы(точка)
        }


        internal bool IsHitTail()//вычисляет врезалась ли змейка сама в себя
        {
            var head = pList.Last();//получаем координату головной точки
            for (int i = 0; i < pList.Count-2; i++)
            {
                if (head.IsHit(pList[i]))//есть ли совпадение головной точки с оставшимися
                {
                    return true;
                }
            }
            return false;
        }


        public void HadleKey(ConsoleKey key)//при нажатии кнопок меняет направление
        {
            if ((key == ConsoleKey.RightArrow) & (direction != Direction.LEFT))
                direction = Direction.RIGHT;

            if ((key == ConsoleKey.LeftArrow) & (direction != Direction.RIGHT) & (direction != Direction.LEFT))
                direction = Direction.LEFT;

            if ((key == ConsoleKey.DownArrow) & (direction != Direction.UP))
                direction = Direction.DOWN;

            if ((key == ConsoleKey.UpArrow) & (direction != Direction.DOWN))
                direction = Direction.UP;
        }

        internal bool Eat(Point food)//если змейка встретилась с едой то будет акт питания
        {
            Point head = GetNextPoint();//точка соотв. след. положению головы змейки
            if (head.IsHit(food))//если координата совпадает с едой то будет акт питания
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else return false;
        }

    }
}
