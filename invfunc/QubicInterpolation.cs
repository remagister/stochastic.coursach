using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invfunc
{
	/// <summary>
	/// Класс интерполяции функции. Разбивает функцию на отрезки и составляет таблицу решений для данной функции.
	/// </summary>
	public class Interpolation
	{
		/// <summary>
		/// Создаёт новый экземпляр класса с заданными параметрами.
		/// </summary>
		/// <param name="a">Начало отрезка для интерполяции.</param>
		/// <param name="b">Конец отрезка. Должен быть большим по значению, чем начальная точка.</param>
		/// <param name="n">Количество разбиений (и, соответственно, количество вызовов функции).</param>
		/// <param name="f">Делегат вида double->double, реализующий необходимую функцию.</param>
		public Interpolation(double a, double b, int n, RealFunction f)
		{
			if (n < 1) throw new ArgumentException("N partitions has to be > 1", "n");
			partitions = n;
			Solutions = new double[n, 2];
			double dx = (b - a) / n;
			for (int i = 0; i < n; i++)
			{
				Solutions[i, 0] = a + dx * i;
				Solutions[i, 1] = f(a + dx * i);
			}
		}
		/// <summary>
		/// Создаёт новый экземпляр класса с заданными параметрами.
		/// </summary>
		/// <param name="end">Конец отрезка. Должен быть больше 0, где 0 - начальная точка интерполирования.</param>
		/// <param name="n">Количество разбиений (и, соответственно, количество вызовов функции).</param>
		/// <param name="f">Делегат вида double->double, реализующий необходимую функцию.</param>
		public Interpolation(double end, int n, RealFunction f)
		{
			if (n < 1) throw new ArgumentException("N partitions has to be > 1", "n");
			if (end < 0.0) throw new ArgumentException("end has to be greater than 0", "end");
			partitions = n;
			Solutions = new double[n, 2];
			double dx = end / n;
			for (int i = 0; i < n; i++)
			{
				Solutions[i, 0] = dx * i;
				Solutions[i, 1] = f(dx * i);
			}
		}

		int partitions = 0;
		public double[,] Solutions = null;
	}

	/// <summary>
	/// Узел, представляющий собой полином кубического сплайна.
	/// </summary>
	public struct SplineNode
	{
		public double A, B, C, D, x;
	}

	/// <summary>
	/// Класс предоставляющий функции для работы с интерполяцией кубическими сплайнами.
	/// </summary>
	public class QSpline
	{
		/// <summary>
		/// Узлы кубических сплайнов (таблица решений).
		/// </summary>
		public SplineNode[] Nodes = null;

		/// <summary>
		/// Создаёт новый экземпляр, строит таблицу узлов.
		/// </summary>
		/// <param name="solutions">Таблица решений некоторой функции.</param>
		public QSpline(double[,] solutions)
		{
			if (solutions == null) throw new ArgumentNullException("solutions");
			Nodes = new SplineNode[solutions.GetLength(0)];

			for (int i = 0; i < Nodes.Length; ++i)
			{
				Nodes[i].x = solutions[i, 0];
				Nodes[i].A = solutions[i, 1];
			}
			Nodes[0].C = Nodes[Nodes.Length - 1].C = 0.0;

			// matrix LAE solution

			double[] alpha = new double[Nodes.Length - 1];
			double[] beta = new double[Nodes.Length - 1];
			double hi, hi1, A, B, C, F, z;
			alpha[0] = beta[0] = 0.0;

			// forward step
			for (int i = 1; i < Nodes.Length - 1; ++i)
			{
				hi = solutions[i, 0] - solutions[i - 1, 0];
				hi1 = solutions[i + 1, 0] - solutions[i, 0];
				A = hi;
				C = 2.0 * (hi + hi1);
				B = hi1;
				F = 6.0 * ((solutions[i + 1, 1] - solutions[i, 1]) / hi1 - (solutions[i, 1] - solutions[i - 1, 1]) / hi);
				z = (A * alpha[i - 1] + C);
				alpha[i] = -B / z;
				beta[i] = (F - A * beta[i - 1]) / z;
			}

			// backward step
			for (int i = Nodes.Length - 2; i > 0; --i)
				Nodes[i].C = alpha[i] * Nodes[i + 1].C + beta[i];

			// via Ci - find Bi and Di

			for (int i = Nodes.Length - 1; i > 0; --i)
			{
				// using old hi variable
				hi = solutions[i, 0] - solutions[i - 1, 0];
				Nodes[i].D = (Nodes[i].C - Nodes[i - 1].C) / hi;
				Nodes[i].B = hi * (2.0 * Nodes[i].B + Nodes[i - 1].B) / 6.0 + (solutions[i, 1] - solutions[i - 1, 1]) / hi;
			}
		}

	}

	/// <summary>
	/// Класс, реализующий интерполяцию функции и её приблизительное вычисление в точках.
	/// </summary>
	public class QInterpolation
	{
		RealFunction func;
		double[,] solutions = null;
		SplineNode[] nodes = null;

		/// <summary>
		/// Создаёт новый экземпляр интерполяции с заданными параметрами.
		/// </summary>
		/// <param name="estimatedA">Начало отрезка, на котором функция определена.</param>
		/// <param name="estimatedB">Конец отрезка.</param>
		/// <param name="intervals">Количество интервалов разбиения.</param>
		/// <param name="f">Делегат вида double->double, реализующий необходимую функцию.</param>
		public QInterpolation(double estimatedA, double estimatedB, int intervals, RealFunction f)
		{
			if (intervals == 0) throw new ArgumentException("intervals");
			if (estimatedB < estimatedA) throw new ArgumentException("estimatedB < estimatedA", "estimatedB");
			if (f == null) throw new ArgumentNullException("f");
			func = f;
			Interpolation inter;
			if (estimatedA == 0.0)
				inter = new Interpolation(estimatedB, intervals, f);
			else inter = new Interpolation(estimatedA, estimatedB, intervals, f);
			QSpline spline = new QSpline(inter.Solutions);
			solutions = inter.Solutions;
			nodes = spline.Nodes;
		}

		/// <summary>
		/// Создаёт новый экземпляр интерполяции, основываясь на готовой таблице решений.
		/// </summary>
		/// <param name="solutions">Таблица решений некоторой неизвестной функции вида [n,2] где n - количество решений, [i,0] - xi, [i,1] - f(xi).</param>
		public QInterpolation(double[,] solutions)
		{
			if (solutions == null) throw new ArgumentNullException("solutions");
			QSpline spline = new QSpline(solutions);
			nodes = spline.Nodes;
		}

		/// <summary>
		/// Вычисляет приближенное значение функции в заданной точке.
		/// </summary>
		/// <param name="x">Аргумент функции, которую нужно аппроксимировать.</param>
		/// <returns></returns>
		public double this[double x]
		{
			get
			{
				if (nodes == null) return double.NaN;
				int n = nodes.Length;
				SplineNode s;

				if (x <= nodes[0].x) // first elem if x < X0
				{
					s = nodes[0];
				}
				else if (x >= nodes[n - 1].x) // last elem if x > Xn
				{
					s = nodes[n - 1];
				}
				else // binary search
				{
					int i = 0;
					int j = n - 1;
					while (i + 1 < j)
					{
						int k = i + (j - i) / 2;
						if (x <= nodes[k].x)
						{
							j = k;
						}
						else
						{
							i = k;
						}
					}
					s = nodes[j];
				}

				double dx = x - s.x;

				// gorner scheme
				return s.A + (s.B + (s.C / 2.0 + s.D * dx / 6.0) * dx) * dx;
			}
		}
	}
}
