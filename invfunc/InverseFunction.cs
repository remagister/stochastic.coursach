using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invfunc
{
	public delegate double RealFunction(double x);

	/// <summary>
	/// Класс, реализующий численное вычисление обратной функции, от данной, строго возрастающей. Метод: интерполяция функции.
	/// </summary>
	public class InverseFunction
	{
		RealFunction f;
		int intervals;
		double A = 0.0, B;
		double dx;
		double max = 0.0;
		/// <summary>
		/// Таблица решений функции вида [n,2] , где n - количество пар решений y = f(x). [i,0] - аргумент Xi, [i,1] - значение f(Xi).
		/// </summary>
		public double[,] Solutions = null;

		/// <summary>
		/// Получает количество интервалов разбиения.
		/// </summary>
		public double Intervals { get { return intervals; } }

		/// <summary>
		/// Получает длину указанного при инициализации отрезка.
		/// </summary>
		public double Length { get { return B - A; } }
		/// <summary>
		/// Длина интервала разбиения.
		/// </summary>
		public double Delta { get { return dx; } }

		/// <summary>
		/// Создает новый экземпляр InverseFunction с заданными параметрами.
		/// </summary>
		/// <param name="fromA">Начало предполагаемого отрезка, на котором функция определена.</param>
		/// <param name="toB">Конец отрезка, на котором определена функция.</param>
		/// <param name="n">Количество разбиений функции (соответственно, количество вызовов функции при создании разбиения).</param>
		/// <param name="function">Делегат типа double->double, который реализует требуемую функцию. Функция обязательно должна быть возрастающей.</param>
		public InverseFunction(double fromA, double toB, int n, RealFunction function)
		{
			f = function;
			intervals = n;
			A = fromA;
			B = toB;
			dx = (toB - fromA) / intervals;
			Solutions = new double[n, 2];
			double x = 0.0;
			for (int i = 0; i < n; ++i)
			{
				x = A + dx * i;
				Solutions[i, 0] = x;
				x = f(x);
				Solutions[i, 1] = x;
				if (x > max) max = x;
			}
		}

		/// <summary>
		/// Создает новый экземпляр InverseFunction с заданными параметрами.
		/// </summary>
		/// <param name="toB">Конец предполагаемого отрезка, на котором функция определена. Начало этого отрезка находится в нуле.</param>
		/// <param name="n">Количество разбиений функции (соответственно, количество вызовов функции при создании разбиения).</param>
		/// <param name="function">Делегат типа double->double, который реализует требуемую функцию. Функция обязательно должна быть возрастающей.</param>
		public InverseFunction(double toB, int n, RealFunction function)
		{
			f = function;
			intervals = n;
			A = 0.0;
			B = toB;
			dx = toB / intervals;
			Solutions = new double[n, 2];
			double x = 0.0;
			for (int i = 0; i < n; ++i)
			{
				x = dx * i;
				Solutions[i, 0] = x;
				x = f(x);
				Solutions[i, 1] = x;
				if (x > max) max = x;
			}
		}

		/// <summary>
		/// Численно решает обратную функцию для той, что была задана при инициализации объекта.
		/// </summary>
		/// <param name="y">Значение функции, для которого нужно разрешить обратную функцию.</param>
		/// <example>f(x) = x^2. SolveFor(y) = sqrt(x).</example>
		/// <returns>Решение уравнения вида f(x) = y.</returns>
		public double SolveFor(double y)
		{
			if (Solutions == null) return double.NaN;
			
			// binary search needed f value
			int i = 0;
			int j = intervals - 1;
			while (i + 1 < j)
			{
				int k = i + (j - i) / 2;
				if (y <= Solutions[k, 1])
					j = k;
				else
					i = k;
			}

			// calculating using derivative definition.
			// assuming, that function increment between Fi and F(i+1) has to be the same, as one between (y and Fi)
			double d = (Solutions[j, 1] - Solutions[j - 1, 1]) / dx;
			return (y - Solutions[j - 1, 1]) / d + Solutions[j - 1, 0];
		}

		/// <summary>
		/// Возвращает случайное значение с заданным распределением.
		/// </summary>
		/// <param name="rand">Стандартный экземпляр настроенного ГСЧ.</param>
		/// <returns></returns>
		public double Generate(Random rand)
		{
			return SolveFor(rand.NextDouble());
		}

		/// <summary>
		/// Возвращает глобальный максимум функции на заданном отрезке.
		/// </summary>
		public double GlobalMaximum { get { return max; } }
	}

	public static class Functions
	{
		/// <summary>
		/// Параметр "бета", участвующий в вычислении функции распределения Максвелла.
		/// </summary>
		public static double beta = 1.0;

		/// <summary>
		/// Функция распределения Максвелла по скоростям (интеграл от плотности вероятности).
		/// Имеет вид erf(t) - 2t*exp(-t^2)/sqrt(pi), где t = sqrt(beta)*x. Функция использует статический параметр этого класса, который равен по умолчанию
		/// единице. Таким образом, хоть фукция зависит только от одной переменной, она имеет такой вид: Fm(x|beta) = erf(sqrt(beta)x) - 2sqrt(beta)x*exp(-bx^2)/sqrt(pi).
		/// </summary>
		/// <param name="x">Аргумент фукнции распределения.</param>
		/// <returns></returns>
		public static double FMaxwell(double x)
		{
			double t = Math.Sqrt(beta) * x;
			return Erf(t) -  Math.Exp(-(t * t)) * 2 * t / Math.Sqrt(Math.PI);
		}

		/// <summary>
		/// Приближенная реализация вычисления функции ошибок вещественного аргумента. Быстрый вариант.
		/// </summary>
		/// <param name="x">Аргумент функции erf(x).</param>
		/// <returns></returns>
		public static double Erf(double x)
		{
			if (x == 0.0) return 0.0;
			double y = 1.0 / (1.0 + 0.3275911 * x);
			return 1 - (((((
				+1.061405429 * y
				- 1.453152027) * y
				+ 1.421413741) * y
				- 0.284496736) * y
				+ 0.254829592) * y)
				* Math.Exp(-x * x);
		}

		/// <summary>
		/// Более точная реализация функции ошибок вещественного аргумента. 1 Выполнение занимает около 2 миллисекунд.
		/// </summary>
		/// <param name="x">Аргумент фукнции erf(x).</param>
		/// <returns></returns>
		public static double Erf2(double x)
		{
			double y, z, xnum, xden, del, result;
			int i;
			const double xbreak = 0.46875;
			const double pi = 3.14159265358979;


			y = Math.Abs(x);

			//  evaluate  erf  for  |x| <= 0.46875
			if (y < xbreak)
			{
				double[] a = {3.16112374387056560e00, 1.13864154151050156e02, 3.77485237685302021e02,
                      3.20937758913846947e03, 1.85777706184603153e-1};
				double[] b = {2.36012909523441209e01, 2.44024637934444173e02,  1.28261652607737228e03,
                      2.84423683343917062e03};

				z = y * y;
				xnum = a[4] * z;
				xden = z;
				for (i = 0; i < 3; i++)
				{
					xnum = (xnum + a[i]) * z;
					xden = (xden + b[i]) * z;
				}
				result = x * (xnum + a[3]) / (xden + b[3]);
			}
			//  evaluate  erfc  for 0.46875 <= |x| <= 4.0
			else if ((y > xbreak) && (y <= 4.0))
			{
				double[] c = {5.64188496988670089e-1, 8.88314979438837594e00, 6.61191906371416295e01,
                      2.98635138197400131e02, 8.81952221241769090e02, 1.71204761263407058e03,
                      2.05107837782607147e03, 1.23033935479799725e03, 2.15311535474403846e-8};
				double[] d = {1.57449261107098347e01, 1.17693950891312499e02, 5.37181101862009858e02,
                      1.62138957456669019e03, 3.29079923573345963e03, 4.36261909014324716e03,
                      3.43936767414372164e03, 1.23033935480374942e03};

				xnum = c[8] * y;
				xden = y;
				for (i = 0; i < 7; i++)
				{
					xnum = (xnum + c[i]) * y;
					xden = (xden + d[i]) * y;
				}
				result = (xnum + c[7]) / (xden + d[7]);
				z = ((int)(y * 16)) / 16.0;
				del = (y - z) * (y + z);
				result *= Math.Exp(-z * z - del);
			}
			//   evaluate  erfc  for |x| > 4.0
			else
			{
				double[] p = {3.05326634961232344e-1, 3.60344899949804439e-1, 1.25781726111229246e-1,
                      1.60837851487422766e-2, 6.58749161529837803e-4, 1.63153871373020978e-2};
				double[] q = {2.56852019228982242e00, 1.87295284992346047e00, 5.27905102951428412e-1,
                      6.05183413124413191e-2, 2.33520497626869185e-3};
				z = 1 / (y * y);
				xnum = p[5] * z;
				xden = z;
				for (i = 0; i < 4; i++)
				{
					xnum = (xnum + p[i]) * z;
					xden = (xden + q[i]) * z;
				}
				result = z * (xnum + p[4]) / (xden + q[4]);
				result = (1 / Math.Sqrt(pi) - result) / y;
				z = ((int)(y * 16)) / 16.0;
				del = (y - z) * (y + z);
				result *= Math.Exp(-z * z - del);
			}

			//   fix up for negative argument, erf, etc.
			if (x > xbreak)
				result = 1 - result;
			if (x < -xbreak)
				result = result - 1;

			return result;
		}
	}
}
