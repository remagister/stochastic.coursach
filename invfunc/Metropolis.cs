using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invfunc
{
	/// <summary>
	/// Предоставляет функционал для генерации случайных чисел с заданным распределением методом Метрополиса.
	/// </summary>
	public class Metropolis
	{
		double A, B, xFmax;
		double xi1, xi;
		RealFunction F;		// PDF

		/// <summary>
		/// Создает новый экземпляр генератора случайных чисел с заданным распределением.
		/// </summary>
		/// <param name="a">Начальная точка промежутка генерации.</param>
		/// <param name="b">Конечная точка промежутка генерации.</param>
		/// <param name="xfmax">Точка x0 на координате Х такая, что f(x0) = max fx</param>
		/// <param name="fx">Функция распределения плотности вероятности.</param>
		public Metropolis(double a, double b, double xfmax, RealFunction fx)
		{
			Random rand = new Random(DateTime.Now.Millisecond);
			A = a;
			B = b;
			xFmax = xfmax;
			F = fx;
			xi = xFmax;
		}

		/// <summary>
		/// Генерирует новое случайное число с заданным распределением, основываясь на стандартном ГСЧ.
		/// </summary>
		/// <param name="rand">Настроенный экземпляр стандартного генератора случайных чисел.</param>
		/// <returns></returns>
		public double Generate(Random rand)
		{
			double rel, delta = (B-A);
			while(true)
			{
				xi1 = xi - delta * (1 - rand.NextDouble() * 2.0);
				if (xi1 <= A || xi1 >= B) continue;

				rel = F(xi1) / F(xi);

				if (rel >= 1.0)
					return xi1;
				else
					if (rand.NextDouble() < rel)
						return xi1;
			}
		}
	}
}
