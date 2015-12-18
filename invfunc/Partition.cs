using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invfunc
{
	/// <summary>
	/// Класс, представляющий функционал разбиения отрезка A..B на N равномерных отрезков, и позволяющий подсчитывать попадания значения Х
	/// в какой-либо отрезок Х_i.
	/// </summary>
	public class Partition
	{
		/// <summary>
		/// Создаёт пустой экземпляр класса Partition. Для настройки работы воспользуйтесь методом Recalculate.
		/// </summary>
		public Partition() { }

		/// <summary>
		/// Создаёт экземпляр класса Partition с заданными данными концов отрезка и количества разбиений. 
		/// </summary>
		/// <param name="a">Начальная координата отрезка. Должно быть строго меньше, чем B.</param>
		/// <param name="b">Конечная координата отрезка. Должно быть строго больше, чем А.</param>
		/// <param name="intervals">Количество интервалов разбиений. Значение в диапазоне от 1 до бесконечности.</param>
		/// <exception cref="System.ArgumentException"></exception>
		public Partition(double a, double b, int intervals)
		{
			if (intervals < 1) throw new ArgumentException("Intervals has to be between 1 and inf", "intervals");
			if (a >= b) throw new ArgumentException(string.Format("\"{0}\" is not legal. A has to be less than B", a), "a");
			elements = intervals;
			dx = (b - a) / intervals;
			counter = new long[intervals];
			A = a;
			B = b;
		}

		double dx = 0.0;
		int elements = 0;
		long[] counter;
		double A;
		double B;

		/// <summary>
		/// Возвращает количество интервалов разбиений.
		/// </summary>
		public int Count { get { return elements; } }
		/// <summary>
		/// Возвращает длину текущего отрезка АВ.
		/// </summary>
		public double Length { get { return B - A; } }
		/// <summary>
		/// Возвращает значение дельта-х, которое характеризует длину одного интервала разбиения.
		/// </summary>
		public double Delta { get { return dx; } }

		/// <summary>
		/// Возвращает начальную точку отрезка разбиения.
		/// </summary>
		public double Begin { get { return A; } }

		/// <summary>
		/// Возвращает конечную точку отрезка разбиения.
		/// </summary>
		public double End { get { return B; } }


		/// <summary>
		/// Заново разбивает отрезок АВ на новое количество интервалов.
		/// </summary>
		/// <param name="intervals">Целочисленное количество интервалов разбиения в диапазоне от 1 до бесконечности.</param>
		/// <exception cref="System.ArgumentException">Возникает при вводе некорректных параметров.</exception>
		public void Partitiate(int intervals)
		{
			if (intervals < 1) throw new ArgumentException("Intervals has to be between 1 and inf", "intervals");
			counter = new long[intervals];
			dx = (B - A) / intervals;
		}

		/// <summary>
		/// Перемещает отрезок на новые границы А* и В*, при этом количество интервалов разбиения остаётся тем же.
		/// </summary>
		/// <param name="a">Начало отрезка А.</param>
		/// <param name="b">Конец отрезка В.</param>
		/// <exception cref="System.ArgumentException">Возникает при вводе некорректных параметров.</exception>
		public void Move(double a, double b)
		{
			if (a >= b) throw new ArgumentException(string.Format("\"{0}\" is not legal. A has to be less than B", a), "a");
			dx = (b - a) / elements;
			A = a;
			B = b;
			for (int i = 0; i < elements; ++i) counter[i] = 0;
		}

		/// <summary>
		/// Полностью переформатирует текущий объект под новые параметры. Действует аналогично конструктору.
		/// </summary>
		/// <param name="a">Начало отрезка А. Долнжо быть строго меньше, чем В.</param>
		/// <param name="b">Конец отрезка В. Должен быть строго большe, чем А.</param>
		/// <param name="intervals">Количество интервалов разбиения в диапазоне от 1 до бесконечности.</param>
		/// <exception cref="System.ArgumentException">Возникает при вводе некорректных параметров.</exception>
		public void Recalculate(double a, double b, int intervals)
		{
			if (intervals <= 1) throw new ArgumentException("Intervals has to be between 1 and inf", "intervals");
			if (a >= b) throw new ArgumentException(string.Format("\"{0}\" is not legal. A has to be less than B", a), "a");
			elements = intervals;
			dx = (b - a) / intervals;
			counter = new long[intervals];
			A = a;
			B = b;
		}

		/// <summary>
		/// Возвращает количество попавших в интервал разбиения элементов.
		/// </summary>
		/// <param name="index">Номер интервала разбиения, начиная с 0.</param>
		/// <returns></returns>
		public long this[int index]
		{
			get
			{
				return counter[index];
			}
		}

		/// <summary>
		/// Получает массив-счетчик попаданий в тот или иной промежуток разбиения.
		/// </summary>
		public long[] Array { get { return counter; } }

		
		/// <summary>
		/// Проверяет попадание значения Х в промежуток и записывает данные в счетчик. Возвращает значение Х.
		/// </summary>
		/// <param name="x">Значение от А до В.</param>
		public double Push(double x)
		{
			if (x < A || x > B) return x;
			int before = (int)((x - A) / dx);
			++counter[before == elements ? before-1 : before];
			return x;
		}

		/// <summary>
		/// Очищает счетчик разбиения.
		/// </summary>
		public void Clear()
		{
			if (counter != null)
				for (int i = 0; i < elements; ++i) counter[i] = 0L;				
		}

	}
}
