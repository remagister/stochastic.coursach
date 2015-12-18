using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using invfunc;

namespace MaxwellDistribution
{
	/// <summary>
	/// Метод или комбинация методов генерации случайного числа.
	/// </summary>
	public enum GeneratorMethod
	{
		NONE = 0,
		INVERSE = 1,
		NEYMAN = 2,
		METROPOLIS = 4,
		INV_NEYMAN = INVERSE | NEYMAN,
		INV_METRO = INVERSE | METROPOLIS,
		METRO_NEYMAN = METROPOLIS | NEYMAN,
		ALL = INVERSE | METROPOLIS | NEYMAN
	}

	/// <summary>
	/// Параметры многопоточности
	/// </summary>
	public enum GeneratorThreadingParameters
	{
		SINGLE = 0,
		BACKGROUND = 1,
		MULTITHREAD = 2
	}

	/// <summary>
	/// Сохраняет основные настройки для симулятора.
	/// </summary>
	[Serializable]
	public class GeneratorOptions
	{
		public double Begin = 0.0;
		public double End = 4.0;
		public double Beta = 1.0;
		public long Statistics = 1000000;
		public int Partitions = 50;
		public GeneratorMethod Methods = GeneratorMethod.ALL;
		public bool Advanced = false;
		public GeneratorThreadingParameters ThreadingPlan = GeneratorThreadingParameters.BACKGROUND;

		/// <summary>
		/// Создаёт копию текущего объекта в новом экзмепляре класса GeneratorOptions.
		/// </summary>
		public GeneratorOptions Clone()
		{
			return new GeneratorOptions
			{
				Begin = Begin,
				End = End,
				Beta = Beta,
				Statistics = Statistics,
				Partitions = Partitions,
				Methods = Methods,
				Advanced = Advanced,
				ThreadingPlan = ThreadingPlan
			};
		}
	}

	/// <summary>
	/// Класс, предоставляющий функционал для генерации случайных чисел с заданным распределением, с использованием различных методов.
	/// </summary>
	public class Generator
	{
		GeneratorOptions myOptions = new GeneratorOptions();

		/// <summary>
		/// Получает копию текущих настроек генератора случайных чисел.
		/// </summary>
		public GeneratorOptions Options { get { return myOptions.Clone(); } }

		bool completed = false;
		// ===================================== матожидание, дисперсия, отклонение, мода ===================================================

		double mean, var, sigma, mode;

		/// <summary>
		/// Получает точное значение матожидания для текущих настроек распределения.
		/// </summary>
		public double Mean { get { return mean; } }

		/// <summary>
		/// Получает точное значение дисперсии для текущих настроек распределения.
		/// </summary>
		public double Variance { get { return var; } }

		/// <summary>
		/// Получает точное значение среднеквадратического отклонения для текущих настроек распределения.
		/// </summary>
		public double Sigma { get { return sigma; } }

		/// <summary>
		/// Получает точное значение моды для текущих настроек распределения. Соответствует максимальному значению функции плонтости вероятности на носителе.
		/// </summary>
		public double Mode { get { return mode; } }

		/// <summary>
		/// Точное значение асимметрии для распределения Максвелла. Константное поле.
		/// </summary>
		const double Skewness = 0.48569282804;

		// ============================== точки на абсциссе, соответствующие центральным моментам ============================================

		double xMode, xMax, xMean;

		/// <summary>
		/// Получает точное значение координаты Х такой, что в этой точке функция плотности вероятности обращается в максимум.
		/// </summary>
		public double XMode { get { return xMode; } }

		/// <summary>
		/// Получает точное значение координаты Х такой, что значение функции в этой точке равно математическому ожиданию.
		/// </summary>
		public double XMean { get { return xMean; } }

		// полученные характеристики
		double imean, nmean, mmean, ivar, nvar, mvar;

		/// <summary>
		/// Получает экспериментальное значение матожидания для текущих настроек распределения методом обратных функций.
		/// </summary>
		public double InverseMean { get { return imean; } }

		/// <summary>
		/// Получает экспериментальное значение дисперсии для текущих настроек распределения методом обратных функций.
		/// </summary>
		public double InverseVariance { get { return ivar; } }

		/// <summary>
		/// Получает экспериментальное значение среднеквадратического отклонения для текущих настроек распределения методом обратных функций.
		/// </summary>
		public double InverseSigma { get { return Math.Sqrt(ivar); } }

		/// <summary>
		/// Получает экспериментальное значение матожидания для текущих настроек распределения методом Неймана.
		/// </summary>
		public double NeymanMean { get { return nmean; } }

		/// <summary>
		/// Получает экспериментальное значение дисперсии для текущих настроек распределения методом Неймана.
		/// </summary>
		public double NeymanVariance { get { return nvar; } }

		/// <summary>
		/// Получает экспериментальное значение среднеквадратического отклонения для текущих настроек распределения методом Неймана.
		/// </summary>
		public double NeymanSigma { get { return Math.Sqrt(nvar); } }

		/// <summary>
		/// Получает экспериментальное значение матожидания для текущих настроек распределения методом Метрополиса.
		/// </summary>
		public double MetropolisMean { get { return mmean; } }

		/// <summary>
		/// Получает экспериментальное значение дисперсии для текущих настроек распределения методом Метрополиса.
		/// </summary>
		public double MetropolisVariance { get { return mvar; } }

		/// <summary>
		/// Получает экспериментальное значение среднеквадратического отклонения для текущих настроек распределения методом Метрополиса.
		/// </summary>
		public double MetropolisSigma { get { return Math.Sqrt(mvar); } }

		// разбиения

		Partition partitionInverse = null;
		Partition partitionNeyman = null;
		Partition partitionMetro = null;

		/// <summary>
		/// Получает гистограмму разбиения для метода обратных функций.
		/// </summary>
		public Partition InversePartition { get { return partitionInverse; } }

		/// <summary>
		/// Получает гистограмму разбиения для метода Неймана.
		/// </summary>
		public Partition NeymanPartition { get { return partitionNeyman; } }

		/// <summary>
		/// Получает гистограмму разбиения для метода Метрополиса.
		/// </summary>
		public Partition MetropolisPartition { get { return partitionMetro; } }

		/// <summary>
		/// Возвращает количество действительно разыгранных элементов статистики.
		/// </summary>
		public long Count
		{
			get
			{
				long ret = 0L;
				if (partitionInverse != null) ret += partitionInverse.Array.Sum();
				if (partitionNeyman != null) ret += partitionNeyman.Array.Sum();
				if (partitionMetro != null) ret += partitionMetro.Array.Sum();
				return ret;
			}
		}

		/// <summary>
		/// Получает относительную величину оценки выполненной работы от 0.0 до 1.0
		/// </summary>
		public double PercentCompleted
		{
			get
			{
				double avg = (double)Count / countNotNull();
				return avg / myOptions.Statistics;
			}
		}

		// затраченное время
		long milliseconds;
		// прогресс
		double progress;

		/// <summary>
		/// Получает значение прогресса (от 0 до 1) при выполнении задач во вторичных потоках.
		/// </summary>
		public double AsyncProgress { get { return progress; } }

		/// <summary>
		/// Получает затраченное количество миллисекунд на выполнение всего эксперимента.
		/// </summary>
		public long Milliseconds
		{
			get
			{
				if (multitask == null) return milliseconds;
				else
				{
					long ret=0L;
					for (int i = 0; i < 3; ++i)
						if (multitask[i] != null && multitask[i].Result > ret) ret = multitask[i].Result;
					return ret;
				}
			}
		}

		// методы генератора
		InverseFunction inverse = null;
		Neyman neyman = null;
		Metropolis metropolis = null;

		// стандартный генератор случайных чисел
		Random rand;

		// настройки асинхронности, если требуется
		CancellationTokenSource tokenSrc = new CancellationTokenSource();
		Task background = null;		// для фонового исполнения
		Task<long>[] multitask = null;	// для исполнения в нескольких потоках (возвращает количество затраченного времени)

		/// <summary>
		/// Получает флаг, который указывает, завершен ли фоновый процесс или нет. Если фоновый процесс не был запущен - возвращает значение true.
		/// </summary>
		public bool IsCompleted
		{
			get
			{
				if (background != null) return background.IsCompleted;
				if (multitask != null)
				{
					bool ret = false;
					for (int i = 0; i < 3; ++i)
						if (multitask[i] != null) ret = multitask[i].IsCompleted;
					return ret;
				}
				return completed;
			}
		}

		/// <summary>
		/// Останавливает выполнение фоновых процессов.
		/// </summary>
		public void Stop()
		{
			tokenSrc.Cancel();
		}

		/// <summary>
		/// Возвращает метод или их комбинацию, использующиеся генератором.
		/// </summary>
		public GeneratorMethod Methods { get { return myOptions.Methods; } }

		/// <summary>
		/// Создаёт новый экземпляр генератора случайных чисел с заданными настройками.
		/// </summary>
		/// <param name="options">Экзмепляр класса настроек GeneratorOptions, который содержит необходимую информацию.</param>
		public Generator(GeneratorOptions options)
		{
			const double _2pi = Math.PI * 2.0, _3pi = Math.PI * 3.0;
			myOptions = options;

			// CDF beta static field
			Functions.beta = options.Beta;

			// central moments
			mean = 2.0 / Math.Sqrt(Math.PI * options.Beta);
			var = (_3pi - 8.0)/(_2pi*options.Beta);
			sigma = Math.Sqrt(var);
			mode = k * (Math.Sqrt(options.Beta) / Math.E);

			// x-central moments' solutions
			xMode = 1.0 / Math.Sqrt(options.Beta);
			xMax = 4.0 * xMode;
			// however, find xMean and xSigma is 2 difficult now

			// generators
			if ((options.Methods & GeneratorMethod.INVERSE) == GeneratorMethod.INVERSE)
			{
				inverse = new InverseFunction(xMax, 200, Functions.FMaxwell);
				partitionInverse = new Partition(options.Begin, options.End, options.Partitions);
			}
			if ((options.Methods & GeneratorMethod.NEYMAN) == GeneratorMethod.NEYMAN)
			{
				neyman = new Neyman(0.0, xMax, mode, Maxwell);
				partitionNeyman = new Partition(options.Begin, options.End, options.Partitions);
			}
			if ((options.Methods & GeneratorMethod.METROPOLIS) == GeneratorMethod.METROPOLIS)
			{
				metropolis = new Metropolis(0.0, xMax, xMode, Maxwell);
				partitionMetro = new Partition(options.Begin, options.End, options.Partitions);
			}
		}

		/// <summary>
		/// Создаёт экземпляр генератора со стандарными настройками.
		/// </summary>
		public Generator()
		{
			const double _2pi = Math.PI * 2.0, _3pi = Math.PI * 3.0;

			// CDF beta static field
			Functions.beta = myOptions.Beta;

			// central moments
			mean = 2.0 / Math.Sqrt(Math.PI * myOptions.Beta);
			var = (_3pi - 8.0) / (_2pi * myOptions.Beta);
			sigma = Math.Sqrt(var);
			mode = k * (Math.Sqrt(myOptions.Beta) / Math.E);

			// x-central moments' solutions
			xMode = 1.0 / Math.Sqrt(myOptions.Beta);
			xMax = 4.0 * xMode;
			// however, find xMean and xSigma is 2 difficult now

			// generators
			inverse = new InverseFunction(xMax, 100, Functions.FMaxwell);
			partitionInverse = new Partition(0.0, xMax, myOptions.Partitions);
			neyman = new Neyman(0.0, xMax, mode, Maxwell);
			partitionNeyman = new Partition(0.0, xMax, myOptions.Partitions);
			metropolis = new Metropolis(0.0, xMax, xMode, Maxwell);
			partitionMetro = new Partition(0.0, xMax, myOptions.Partitions);
		}


		public void StartGenerator()
		{
			// value from 0 to intmax
			rand = new Random((int)DateTime.Now.Ticks & int.MaxValue);
			// refill progress scale
			progress = 0.0;
			completed = false;

			// refill counters if needed

			if (partitionInverse != null) partitionInverse.Clear();
			if (partitionNeyman != null) partitionNeyman.Clear();
			if (partitionMetro != null) partitionMetro.Clear();

			// threading plan interpreting
			switch (myOptions.ThreadingPlan)
			{
				case GeneratorThreadingParameters.SINGLE:		// current thread
					{
						testSynchronioulsy();
						completed = true;
						break;
					}

				case GeneratorThreadingParameters.BACKGROUND:	// background exec
					{
						background = new Task(testAsync);
						background.Start();
						break;
					}
				case GeneratorThreadingParameters.MULTITHREAD:	// many threads exec
					{
						multitask = new Task<long>[3];
						if (inverse != null)
						{
							multitask[0] = new Task<long>(inverseTaskAsync, new Random((int)DateTime.Now.Ticks & int.MaxValue), tokenSrc.Token, TaskCreationOptions.LongRunning);
							multitask[0].Start();
						}
						if (neyman != null)
						{
							multitask[1] = new Task<long>(neymanTaskAsync, new Random((int)DateTime.Now.Ticks & int.MaxValue), tokenSrc.Token, TaskCreationOptions.LongRunning);
							multitask[1].Start();
						}
						if (metropolis != null)
						{
							multitask[2] = new Task<long>(metropolisTaskAsync, new Random((int)DateTime.Now.Ticks & int.MaxValue), tokenSrc.Token, TaskCreationOptions.LongRunning);
							multitask[2].Start();
						}
						break;
					}
			}

		}

		// executes main program in the current thread
		void testSynchronioulsy()
		{
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			double inv_summ = 0.0, inv_summ2 = 0.0, ney_summ = 0.0, ney_summ2 = 0.0, met_summ = 0.0, met_summ2 = 0.0;
			double ksi;
			for (long i = 0L; i < myOptions.Statistics; ++i)
			{
				if (inverse != null)
				{
					ksi = partitionInverse.Push(inverse.SolveFor(rand.NextDouble()));
					inv_summ += ksi;
					inv_summ2 += ksi * ksi;
				}
				if (neyman != null)
				{
					ksi = partitionNeyman.Push(neyman.Generate(rand));
					ney_summ += ksi;
					ney_summ2 += ksi * ksi;
				}
				if (metropolis != null)
				{
					ksi = partitionMetro.Push(metropolis.Generate(rand));
					met_summ += ksi;
					met_summ2 += ksi * ksi;
				}
			}

			// integral values
			if (inverse != null)
			{
				imean = inv_summ / myOptions.Statistics;
				ivar = inv_summ2 / myOptions.Statistics - imean * imean;
			}
			if (neyman != null)
			{
				nmean = ney_summ / myOptions.Statistics;
				nvar = ney_summ2 / myOptions.Statistics - nmean * nmean;
			}

			if (metropolis != null)
			{
				mmean = met_summ / myOptions.Statistics;
				mvar = met_summ2 / myOptions.Statistics - mmean * mmean;
			}

			watch.Stop();
			milliseconds = watch.ElapsedMilliseconds;
		}
		
		// асинхронная версия однопоточного метода
		void testAsync()
		{
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			// local progress counter
			double dt = 100.0 / myOptions.Statistics;
			double inv_summ = 0.0, inv_summ2 = 0.0, ney_summ = 0.0, ney_summ2 = 0.0, met_summ = 0.0, met_summ2 = 0.0;
			double ksi;
			watch.Start();
			for (long i = 0L; i < myOptions.Statistics; ++i)
			{
				// suddenly works better than 3 loops with outer if-statements
				if (inverse != null)
				{
					ksi = partitionInverse.Push(inverse.SolveFor(rand.NextDouble()));
					inv_summ += ksi;
					inv_summ2 += ksi * ksi;
				}
				if (neyman != null)
				{
					ksi = partitionNeyman.Push(neyman.Generate(rand));
					ney_summ += ksi;
					ney_summ2 += ksi * ksi;
				}
				if (metropolis != null)
				{
					ksi = partitionMetro.Push(metropolis.Generate(rand));
					met_summ += ksi;
					met_summ2 += ksi * ksi;
				}
				// count progress every 100 times
				if(i % 100L == 99L) progress += dt;
			}
			// integral values
			if (inverse != null)
			{
				imean = inv_summ / myOptions.Statistics;
				ivar = inv_summ2 / myOptions.Statistics - imean * imean;
			}
			if (neyman != null)
			{
				nmean = ney_summ / myOptions.Statistics;
				nvar = ney_summ2 / myOptions.Statistics - nmean * nmean;
			}

			if (metropolis != null)
			{
				mmean = met_summ / myOptions.Statistics;
				mvar = met_summ2 / myOptions.Statistics - mmean * mmean;
			}
			progress = 1.0;
			watch.Stop();
			milliseconds = watch.ElapsedMilliseconds;
		}

		int countNotNull()
		{
			int ret = 0;
			if (partitionInverse != null) ++ret;
			if (partitionMetro != null) ++ret;
			if (partitionNeyman != null) ++ret;
			return ret;
		}

		// асинхронная версия задачи для одного генератора
		// должна использоваться с гарантированно инициализированным генератором, чтобы избежать лишних проверок
		long inverseTaskAsync(object rand)
		{
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			Random random = rand as Random;
			// local progress counter (divided by 3 cause we have same 3 tasks
			double dt = (100.0/countNotNull()) / myOptions.Statistics;
			double summ = 0.0, summ2 = 0.0, ksi;
			watch.Start();
			for (long i = 0L; i < myOptions.Statistics; ++i)
			{
				ksi = partitionInverse.Push(inverse.SolveFor(random.NextDouble()));
				summ += ksi;
				summ2 += ksi * ksi;
				if (i % 100L == 99L) progress += dt;
			}
			imean = summ / myOptions.Statistics;
			ivar = summ2 / myOptions.Statistics - imean * imean;
			watch.Stop();
			return watch.ElapsedMilliseconds;
		}
		long neymanTaskAsync(object rand)
		{
			Random random = rand as Random;
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			double dt = (100.0 / countNotNull()) / myOptions.Statistics;
			double summ = 0.0, summ2 = 0.0, ksi;
			watch.Start();
			for (long i = 0L; i < myOptions.Statistics; ++i)
			{
				ksi = partitionNeyman.Push(neyman.Generate(random));
				summ += ksi;
				summ2 += ksi * ksi;
				// adding every 100 counts anyway
				if (i % 100L == 99L) progress += dt;
			}
			nmean = summ / myOptions.Statistics;
			nvar = summ2 / myOptions.Statistics - nmean * nmean;
			watch.Stop();
			return watch.ElapsedMilliseconds;
		}
		long metropolisTaskAsync(object rand)
		{
			Random random = rand as Random;
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			double dt = (100.0 / countNotNull()) / myOptions.Statistics;
			double summ = 0.0, summ2 = 0.0, ksi;
			watch.Start();
			for (long i = 0L; i < myOptions.Statistics; ++i)
			{
				ksi = partitionMetro.Push(metropolis.Generate(random));
				summ += ksi;
				summ2 += ksi * ksi;
				// adding every 100 counts anyway
				if (i % 100L == 99L) progress += dt;
			}
			mmean = summ / myOptions.Statistics;
			mvar = summ2 / myOptions.Statistics - mmean*mmean;
			watch.Stop();
			return watch.ElapsedMilliseconds;
		}

		/// <summary>
		/// Активирует указанные методы в генераторе случайных чисел. Возвращает количество активированных методов. Если метод уже был активирован
		/// то повторно инициализация производиться не будет.
		/// </summary>
		/// <param name="methods">Необходимый метод или сочетание методов генерации чисел.</param>
		/// <returns></returns>
		public int ActivateMethods(GeneratorMethod methods)
		{
			int count = 0;
			if ((methods & GeneratorMethod.INVERSE) == GeneratorMethod.INVERSE && inverse == null) {
				partitionInverse = new Partition(0.0, xMax, myOptions.Partitions);
				inverse = new InverseFunction(xMax, 100, Functions.FMaxwell);
				count++; 
			}
			if ((methods & GeneratorMethod.NEYMAN) == GeneratorMethod.NEYMAN && neyman == null) {
				partitionNeyman = new Partition(0.0, xMax, myOptions.Partitions);
				neyman = new Neyman(0.0, xMax, mode, Maxwell); 
				count++;
			}
			if ((methods & GeneratorMethod.METROPOLIS) == GeneratorMethod.METROPOLIS && metropolis == null) {
				partitionMetro = new Partition(0.0, xMax, myOptions.Partitions);
				metropolis = new Metropolis(0.0, xMax, xMode, Maxwell); 
				count++; 
			}
			return count;
		}

		/// <summary>
		/// Константа, равная отношению 4/sqrt(pi).
		/// </summary>
		public static readonly double k = 4.0 / Math.Sqrt(Math.PI);
		/// <summary>
		/// Функция плотности вероятности распределения Максвелла.
		/// </summary>
		/// <param name="x">Аргумент функции от 0 до бесконечности.</param>
		/// <returns></returns>
		public static double Maxwell(double x)
		{
			double quad = x * x;
			return k * Math.Pow(Functions.beta, 1.5) * Math.Exp(-quad * Functions.beta) * quad;
		}
	}
}
