using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetBufferSize(80, 25);

			Walls walls = new Walls(80, 25);//отписовка ограждений, в конструкторе принимает габариты карты
			walls.Draw();

			// Отрисовка точек	змейки		
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');//генерация точек еды(в конструкторе габариты экрана и символ еды)
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())//проверки - столкнулась ли змейка об стену, столкнулась ли с собственным хвостом
				{
					break;//игра окончена
				}
				if (snake.Eat(food))//встретится ли на этом ходу змейка с едой или нет
				{
					food = foodCreator.CreateFood();
					food.Draw();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);//скорость

				if (Console.KeyAvailable)//при нажатии кнопок меняет направление
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HadleKey(key.Key);
				}
			}
			WriteGameOver();
			Console.ReadLine();
		}


		//Game Over
		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("===================", xOffset, yOffset++);
			WriteText("G A M E   O V E R", xOffset + 1, yOffset++);
			WriteText("===================", xOffset, yOffset++);
		}
		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}