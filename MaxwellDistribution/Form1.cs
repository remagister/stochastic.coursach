using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using invfunc;

namespace MaxwellDistribution
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//Functions.beta = 1;
			//int parts = 200;
			//double max = 4.0 / Math.E * Math.Sqrt(Functions.beta / Math.PI), xmax = 3.5 / Math.Sqrt(Functions.beta);
			//double modex = xmax / 3.5, modey = k * Math.Sqrt(Functions.beta)/Math.E;			
			//InverseFunction func = new InverseFunction(xmax, 500, Functions.FMaxwell);
			//Partition part = new Partition(0.0, xmax, parts);
			//Random rand = new Random((int)DateTime.Now.Ticks);
			//Neyman nm = new Neyman(0, xmax, max, Maxwell);
			//Metropolis metro = new Metropolis(0.0, xmax, modex, Maxwell);
			//for (int i = 0; i < 1000000; ++i)
			//	part.Push(func.Generate(rand));
			concurrencyComboBox.SelectedIndex = 1;
			ApplicationOptions.Load();
			if (!Directory.Exists(ApplicationOptions.SaveDirectory))
				Directory.CreateDirectory(ApplicationOptions.SaveDirectory);
			headersTask = new Task<FileHeader[]>(getHeaders);
			headersTask.Start();
			dataDirectoryWatcher.Path = ApplicationOptions.SaveDirectory;
		}
		Task<FileHeader[]> headersTask;
		GeneratorMethod methods = GeneratorMethod.ALL;
		Generator gen = null;
		FileRecord record;

		FileHeader[] getHeaders()
		{
			return FileHeader.ReadDirectory(ApplicationOptions.SaveDirectory);
		}

		// запуск генератора
		private void startButton_Click(object sender, EventArgs e)
		{
			methods = (inverseCheckBox.Checked ? GeneratorMethod.INVERSE: GeneratorMethod.NONE) 
					| (neymanCheckBox.Checked ? GeneratorMethod.NEYMAN : GeneratorMethod.NONE )
					| (metroCheckBox.Checked ? GeneratorMethod.METROPOLIS : GeneratorMethod.NONE);
			if (methods == GeneratorMethod.NONE)
			{
				MessageBox.Show("Пожалуйста, выберите хотя бы один метод генерации чисел.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (minValueUpDown.Value > maxValueUpDown.Value)
			{
				MessageBox.Show("Левая граница отрезка не может быть расположена дальше правой границы.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			gen = new Generator(new GeneratorOptions
			{
				Advanced = fullStatCheckBox.Checked,
				Begin = (double)minValueUpDown.Value,
				End = (double)maxValueUpDown.Value,
				Beta = (double)bParamUpDown.Value,
				Methods = methods,
				Statistics = (long)nStatisticUpDown.Value,
				Partitions = (int)nDiagramUpDown.Value,
				ThreadingPlan = (GeneratorThreadingParameters)concurrencyComboBox.SelectedIndex
			});
			gen.StartGenerator();
			if (concurrencyComboBox.SelectedIndex == 0)
			{
				//MessageBox.Show("Elapsed: " + gen.Milliseconds + " ms", "Test");
				record = new FileRecord(gen);
				ChartForm form = new ChartForm(record);
				form.Show();
			}
			else
				concurrencyTimer.Start();
		}

		private void concurrencyTimer_Tick(object sender, EventArgs e)
		{
			if (progressBar.Value != 100)
			{
				progressBar.Value = (int)Math.Round(gen.AsyncProgress * 100);
				return;
			}
			concurrencyTimer.Stop();
			progressBar.Value = 100;
			while (!gen.IsCompleted) ;
			record = new FileRecord(gen);
			ChartForm form = new ChartForm(record);
			form.Show();
			progressBar.Value = 0;
		}

		private void bParamUpDown_ValueChanged(object sender, EventArgs e)
		{
			maxValueUpDown.Value = (decimal)(4.0 / Math.Sqrt((double)bParamUpDown.Value));
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			ApplicationOptions.SaveChanges();
		}

		bool uptodate = true;
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			openRecordButton.Enabled = false;
			if (tabControl1.SelectedIndex == 1 && uptodate)
			{
				if (headersTask.Wait(5000))
				{
					FileHeader[] headers = headersTask.Result;
					ListViewItem item;
					var row = (from header in headers
							   select new string[] { header.FriendlyFileName, header.TimeCreated.ToShortDateString(), 
						header.FriendlyMethodsString, header.FriendlyIntervalString + ";b=" + header.Options.Beta }).ToArray();
					filesListView.Items.Clear();
					for (int i = 0; i < headers.Length; ++i)
					{
						item = new ListViewItem(row[i], 0);
						item.ToolTipText = (headers[i].FileLength / 1024.0).ToString("F2") + " КБ";
						item.Tag = headers[i];
						filesListView.Items.Add(item);
					}
					uptodate = false;
				}
				else
					MessageBox.Show(headersTask.Exception.Message, "Ошибка чтения списка файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataDirectoryWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			uptodate = true;
			headersTask = new Task<FileHeader[]>(getHeaders);
			headersTask.Start();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Вы действительно хотите очистить файлы сохранений?","Подтверждение действия", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				try
				{
					foreach (ListViewItem item in filesListView.Items)
						if (File.Exists(ApplicationOptions.SaveDirectory + "/" + item.Text))
							File.Delete(ApplicationOptions.SaveDirectory + "/" + item.Text);
					filesListView.Items.Clear();
					ApplicationOptions.Savings = 0;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла устранимая ошибка при удалении файлов из каталога. Информация:\n" + ex.Message , "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		bool anySelected = false;
		private void filesListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (filesListView.SelectedItems.Count != 0)
			{
				FileHeader header = (FileHeader)filesListView.SelectedItems[0].Tag;
				nStatLabel.Text = header.Options.Statistics.ToString();
				intervalLabel.Text = string.Format("A= {0:F5} ; B= {1:F5}",header.Options.Begin, header.Options.End);
				betaLabel.Text = header.Options.Beta.ToString();
				openRecordButton.Enabled = true;
				anySelected = true;
			}
			else
			{
				nStatLabel.Text = "--";
				intervalLabel.Text = "--";
				betaLabel.Text = "--";
				anySelected = false;
				openRecordButton.Enabled = false;
			}
		}

		private void dataContextMenu_Opening(object sender, CancelEventArgs e)
		{
			openToolStripMenuItem.Enabled = anySelected;
			deleteContextMenuItem.Enabled = anySelected;
		}

		private void deleteContextMenuItem_Click(object sender, EventArgs e)
		{
			ListViewItem todelete = filesListView.SelectedItems[0];
			string filepath = ApplicationOptions.SaveDirectory + "/" + todelete.Text;
			if (File.Exists(filepath))
			{
				try
				{
					File.Delete(filepath);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Произошла ошибка при удалении файла\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			filesListView.Items.Remove(todelete);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			tabControl1.SelectedIndex = 2;
		}

		private void openRecordButton_Click(object sender, EventArgs e)
		{
			ListViewItem selected = filesListView.SelectedItems[0];
			string filepath = ApplicationOptions.SaveDirectory + "/" + selected.Text;
			FileRecord record = new FileRecord(filepath);
			ChartForm form = new ChartForm(record, false);
			form.Show();
		}
	}
}
