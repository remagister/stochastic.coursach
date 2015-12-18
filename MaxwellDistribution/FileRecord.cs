using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace MaxwellDistribution
{
	/// <summary>
	/// Представляет класс, содержащий форматированную основную информацию для записи в файл и считывания с него.
	/// </summary>
	[Serializable]
	public class FileRecord
	{
		// creating automatically
		FileHeader header;

		/// <summary>
		/// Получает заголовок данных из данной записи.
		/// </summary>
		public FileHeader Header { get { return header; } }

		long[] partitionInverse;
		long[] partitionNeyman;
		long[] partitionMetropolis;

		/// <summary>
		/// Получает гистограмму для метода обратных функций.
		/// </summary>
		public long[] InversePartitions { get { return partitionInverse; } }

		/// <summary>
		/// Получает гистограмму для метода Неймана.
		/// </summary>
		public long[] NeymanPartitions { get { return partitionNeyman; } }

		/// <summary>
		/// Получает гистограмму для метода Метрополиса.
		/// </summary>
		public long[] MetropolisPartitions { get { return partitionMetropolis; } }


		/// <summary>
		/// Создает новый экземпляр класса FileRecord на основе данных, полученных из генератора случайных чисел.
		/// </summary>
		/// <param name="gen">Экземпляр класса генератора чисел, который уже завершил работу.</param>
		public FileRecord(Generator gen)
		{
			header = new FileHeader
			{
				Options = gen.Options,
				PercentCompleted = gen.PercentCompleted,
				Mean = gen.Mean,
				xMean = gen.XMean,
				iMean = gen.InverseMean,
				Variance = gen.Variance,
				iVariance = gen.InverseVariance,
				nMean = gen.NeymanMean,
				nVariance = gen.NeymanVariance,
				mMean = gen.MetropolisMean,
				mVariance = gen.MetropolisVariance,
				Mode = gen.Mode,
				xMode = gen.XMode,
				TimeCreated = DateTime.Now,
				Milliseconds = gen.Milliseconds
			};
			if (gen.InversePartition != null)
			{
				partitionInverse = gen.InversePartition.Array;
				header.DX = gen.InversePartition.Delta;
			}
			if (gen.NeymanPartition != null)
			{
				partitionNeyman = gen.NeymanPartition.Array;
				header.DX = gen.NeymanPartition.Delta;
			}
			if (gen.MetropolisPartition != null)
			{
				partitionMetropolis = gen.MetropolisPartition.Array;
				header.DX = gen.MetropolisPartition.Delta;
			}
		}

		/// <summary>
		/// Создает новый экземпляр класса, считываясь из файла сохранения.
		/// </summary>
		/// <param name="filename"></param>
		public FileRecord(string filename)
		{
			using (FileStream cin = File.OpenRead(filename))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				// probably can throw an exception here?
				header = (FileHeader)formatter.Deserialize(cin);
				if ((header.Options.Methods & GeneratorMethod.INVERSE) == GeneratorMethod.INVERSE)
					partitionInverse = (long[])formatter.Deserialize(cin);
				if ((header.Options.Methods & GeneratorMethod.NEYMAN) == GeneratorMethod.NEYMAN)
					partitionNeyman = (long[])formatter.Deserialize(cin);
				if ((header.Options.Methods & GeneratorMethod.METROPOLIS) == GeneratorMethod.METROPOLIS)
					partitionMetropolis = (long[])formatter.Deserialize(cin);
				header.FileName = cin.Name;
			}
		}

		/// <summary>
		/// Сохраняет текущий экземпляр сведений о результатах генерации случайной выборки. Может выкидывать исключения,
		/// связанные с записью или открытием файлов.
		/// </summary>
		/// <param name="filename">Имя файла, в который нужно сохранить данные.</param>
		public void SaveFile(string filename)
		{
			using (FileStream cout = File.OpenWrite(filename))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				// write header object to the file in binary mode
				formatter.Serialize(cout, header);
				if (partitionInverse != null) formatter.Serialize(cout, partitionInverse);
				if (partitionNeyman != null) formatter.Serialize(cout, partitionNeyman);
				if (partitionMetropolis != null) formatter.Serialize(cout, partitionMetropolis);
			}
		}

		/// <summary>
		/// Сохраняет текущий экземпляр сведений о результатах генерации случайной выборки, если этот объект был уже прочтён из некоторого файла. Может выкидывать исключения,
		/// связанные с записью или открытием файлов.
		/// </summary>
		public void SaveFile()
		{
			using (FileStream cout = File.OpenWrite(header.FileName))
			{
				cout.Position = 0L;
				BinaryFormatter formatter = new BinaryFormatter();
				// write header object to the file in binary mode
				formatter.Serialize(cout, header);
				if (partitionInverse != null) formatter.Serialize(cout, partitionInverse);
				if (partitionNeyman != null) formatter.Serialize(cout, partitionNeyman);
				if (partitionMetropolis != null) formatter.Serialize(cout, partitionMetropolis);
			}
		}
	}

	/// <summary>
	/// Структура данных, представляющая собой заголовок файла с основной информацией об эксперименте.
	/// </summary>
	[Serializable]
	public struct FileHeader
	{
		/// <summary>
		/// Считывает заголовок данных из указанного файла.
		/// </summary>
		/// <param name="filename">Имя файла, из которого необходимо считать заголовок.</param>
		public static FileHeader ReadFromFile(string filename)
		{
			FileHeader ret;
			using (FileStream cin = File.OpenRead(filename))
			{
				BinaryFormatter formatter = new BinaryFormatter();
			    ret = (FileHeader)formatter.Deserialize(cin);
				ret.FileName = cin.Name;
			}
			return ret; 
		}

		/// <summary>
		/// Считывает необходимые заголовки файлов из списка файлов в указанной директории с расширением .bin.
		/// </summary>
		/// <param name="directory">Имя папки, в которой нужно искать файлы.</param>
		public static FileHeader[] ReadDirectory(string directory)
		{
			var files = Directory.EnumerateFiles(directory, "*.bin");
			List<FileHeader> retList = new List<FileHeader>();
			foreach (string file in files)
			{
				try
				{
					retList.Add(FileHeader.ReadFromFile(file));
				}
				catch (System.Runtime.Serialization.SerializationException)
				{
					continue;
				}
			}
			return retList.ToArray();
		}


		/// <summary>
		/// Получает строковое представление отрезка разбиения в формате (X;Y).
		/// </summary>
		public string FriendlyIntervalString { get { return string.Format("({0};{1})", Options.Begin, Math.Round(Options.End,4)); } }

		/// <summary>
		/// Получает дружественное имя файла без расширения. В случае, если файл не может быть найден на диске - выбрасывает исключение.
		/// </summary>
		public string FriendlyFileName
		{
			get
			{
				if (FileName == null) return null;
				if (friendly != null) return friendly;
				FileInfo inf = new FileInfo(FileName);
				friendly = inf.Name.Replace("." + inf.Extension, "");
				return friendly;
			}
		}

		/// <summary>
		/// Возвращает код, указывающий, какие методы были использованы в генерации случайной выборки.
		/// </summary>
		public string FriendlyMethodsString
		{
			get
			{
				int methods = (int)Options.Methods;
				return ((methods & 1 ) == 1 ? "I" : "_") + ((methods >> 1 & 1) == 1 ? "N" : "_") + ((methods >> 2 & 1) == 1 ? "M" : "_"); 
			}
		}

		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения матожидания метода обратных функций от ее аналитического значения.
		/// </summary>
		public string FriendlyInverseMeanAccuracy { get { return Math.Abs((Mean - iMean) / Mean).ToString("P5"); } }
		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения дисперсии метода обратных функций от ее аналитического значения.
		/// </summary>
		public string FriendlyInverseVarianceAccuracy { get { return Math.Abs((Variance - iVariance) / Variance).ToString("P5"); } }

		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения среднеквадратического отклонения метода обратных функций от его аналитического значения.
		/// </summary>
		public string FriendlyInverseSigmaAccuracy { get { return Math.Abs((Sigma - iSigma) / Sigma).ToString("P5"); } }


		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения матожидания метода Неймана от ее аналитического значения.
		/// </summary>
		public string FriendlyNeymanMeanAccuracy { get { return Math.Abs((Mean - nMean) / Mean).ToString("P5"); } }
		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения дисперсии метода Неймана от ее аналитического значения.
		/// </summary>
		public string FriendlyNeymanVarianceAccuracy { get { return Math.Abs((Variance - nVariance) / Variance).ToString("P5"); } }

		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения среднеквадратического отклонения метода Неймана от его аналитического значения.
		/// </summary>
		public string FriendlyNeymanSigmaAccuracy { get { return Math.Abs((Sigma - nSigma) / Sigma).ToString("P5"); } }


		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения матожидания метода Метрополиса от ее аналитического значения.
		/// </summary>
		public string FriendlyMetropolisMeanAccuracy { get { return Math.Abs((Mean - mMean) / Mean).ToString("P5"); } }
		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения дисперсии метода Метрополиса от ее аналитического значения.
		/// </summary>
		public string FriendlyMetropolisVarianceAccuracy { get { return Math.Abs((Variance - mVariance) / Variance).ToString("P5"); } }

		/// <summary>
		/// Возвращает процентную погрешность экспериментального значения среднеквадратического отклонения метода Метрополиса от его аналитического значения.
		/// </summary>
		public string FriendlyMetropolisSigmaAccuracy { get { return Math.Abs((Sigma - mSigma) / Sigma).ToString("P5"); } } 



		/// <summary>
		/// Получает размер файла в байтах. В случае, если файл не может быть найден на диске - выбрасывает исключение.
		/// </summary>
		public long FileLength
		{
			get
			{
				if (FileName == null) return 0L;
				if (temporaryLength != 0L) return temporaryLength;
				FileInfo inf = new FileInfo(FileName);
				temporaryLength = inf.Length;
				return inf.Length;
			}
		}

		[NonSerialized]
		long temporaryLength;
		[NonSerialized]
		string friendly;
		[NonSerialized]
		public string FileName;

		public GeneratorOptions Options;
		public double Mean;
		public double xMean;
		public double iMean;	// inverse
		public double nMean;	// neyman
		public double mMean;	// metropolis

		public double Variance;
		public double PercentCompleted;
		public long Milliseconds;
		/// <summary>
		/// Вычисляет точное среднеквадратическое отклонение распределения, если указана дисперсия.
		/// </summary>
		public double Sigma { get { return Math.Sqrt(Variance); } }

		/// <summary>
		/// Вычисляет экспериментально полученное методом обратных функций среднеквадратическое отклонение распределения, если указана экспериментальная дисперсия.
		/// </summary>
		public double iSigma { get { return Math.Sqrt(iVariance); } }
		public double nSigma { get { return Math.Sqrt(nVariance); } }
		public double mSigma { get { return Math.Sqrt(mVariance); } }

		public double iVariance;
		public double nVariance;
		public double mVariance;

		public double Mode;
		public double xMode;
		public double DX;
		public DateTime TimeCreated;
	}

	/// <summary>
	/// Структура данных, представляющая собой краткую информацию о сохранении эксперимента.
	/// </summary>
	public struct FileShortInfo
	{
		public string FileName;
		public string IntervalAB;
		public string Beta;
		public string Methods;
	}
}
