using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invfunc
{
	/// <summary>
	/// Предоставляет функционал для генерации случайных чисел с заданным распределением методом Неймана.
	/// </summary>
	public class Neyman
	{
		double A, B, Max;
		RealFunction f;		// PDF

		/// <summary>
		/// Создает новый экземпляр генератора случайных чисел с заданным распределением.
		/// </summary>
		/// <param name="a">Начальная точка промежутка генерации.</param>
		/// <param name="b">Конечная точка промежутка генерации.</param>
		/// <param name="max">Максимальное значение функции плотности вероятности.</param>
		/// <param name="function">Функция плотности вероятности.</param>
		public Neyman(double a, double b, double max, RealFunction function)
		{
			A = a;
			B = b;
			Max = max;
			f = function;
		}

		/// <summary>
		/// Генерирует новое случайное число с заданным распределением, основываясь на стандартном ГСЧ.
		/// </summary>
		/// <param name="rand">Стандартный настроенный экземпляр генератора случайных System.Random.</param>
		/// <returns></returns>
		public double Generate(Random rand)
		{
			double x, y;
			do
			{
				x = A + (B - A) * rand.NextDouble();
				y = Max * rand.NextDouble();

			} while (f(x) < y);
			return x;
		}
	}
}
