using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MaxwellDistribution
{
	/// <summary>
	/// Статический класс настроек приложения.
	/// </summary>
	public static class ApplicationOptions
	{
		/// <summary>
		/// Загружает файл настроек settings.xml.
		/// </summary>
		public static void Load()
		{
			try
			{
				using (var stream = File.OpenRead("settings.xml"))
				{
					XmlSerializer reader = new XmlSerializer(typeof(Options));
					instance = (Options)reader.Deserialize(stream);
				}
			}
			catch (InvalidOperationException f)
			{
				File.Delete("settings.xml");
				using (var stream = File.OpenWrite("settings.xml"))
				{
					XmlSerializer writer = new XmlSerializer(typeof(Options));
					writer.Serialize(stream, instance);
				}
			}
			catch (FileNotFoundException f)
			{
				using (var stream = File.OpenWrite("settings.xml"))
				{
					XmlSerializer writer = new XmlSerializer(typeof(Options));
					writer.Serialize(stream, instance);
				}
			}
		}

		/// <summary>
		/// Сохраняет изменения в файле конфигурации settings.xml если они есть.
		/// </summary>
		public static void SaveChanges()
		{
			if (changed)
			{
				File.Delete("settings.xml");
				using (var stream = File.OpenWrite("settings.xml"))
				{
					XmlSerializer writer = new XmlSerializer(typeof(Options));
					writer.Serialize(stream, instance);
				}
			}
		}

		static Options instance = new Options();

		/// <summary>
		/// Получает или задает количество сохранений, созданных приложением.
		/// </summary>
		public static int Savings
		{
			get { return instance.TotalSaved; }
			set { changed = true; instance.TotalSaved = value; }
		}
		/// <summary>
		/// Получает или задает текущую рабочую папку приложения.
		/// </summary>
		public static string SaveDirectory
		{
			get { return instance.SaveDirectory; }
			set
			{
				changed = true;
				instance.SaveDirectory = value;
			}
		}

		static bool changed = false;
	}

	[Serializable]
	public class Options
	{
		public int TotalSaved = 0;
		public string SaveDirectory = "data";
	}
}
