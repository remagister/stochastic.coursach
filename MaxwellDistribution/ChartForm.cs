using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using invfunc;

namespace MaxwellDistribution
{
	public partial class ChartForm : Form
	{
		public ChartForm(FileRecord record, bool saveNeeded = true)
		{
			InitializeComponent();
			MinimumSize = Size;
			FileHeader header = record.Header;
			fileRecord = record;
			nStatLabel.Text = header.Options.Statistics.ToString();
			percentCompletedLabel.Text = header.PercentCompleted.ToString("P4");
			timeLabel.Text = header.Milliseconds + " мс";
			sizeLabel.Text = header.FriendlyIntervalString;
			betaLabel.Text = header.Options.Beta.ToString();
			meanLabel.Text = header.Mean.ToString("F5");
			varianceLabel.Text = header.Variance.ToString("F5");
			sigmaLabel.Text = header.Sigma.ToString("F5");
			//expMeanLabel.Text = header.iMean.ToString();
			//expVarianceLabel.Text = header.iVariance.ToString();
			//expSigmaLabel.Text = header.iSigma.ToString();
			modeLabel.Text = header.Mode.ToString("F5");
			saveCheckBox.Checked = saveNeeded;
			// pdf + cdf

			Functions.beta = header.Options.Beta;
			mainChart.ChartAreas["MainChart"].AxisX.LabelStyle.Format = "F4";
			var pdfSeries = mainChart.Series["PDF"];
			var cdfSeries = mainChart.Series["CDF"];
			double delta = (header.Options.End - header.Options.Begin)/50.0;
			double current;
			for (int i = 0; i < 50; ++i)
			{
				current = header.Options.Begin + i*delta;
				pdfSeries.Points.AddXY(current, Generator.Maxwell(current));
				cdfSeries.Points.AddXY(current, Functions.FMaxwell(current));
			}
			double deltaFx = Functions.FMaxwell(header.Options.End) - Functions.FMaxwell(header.Options.Begin);
			if (record.InversePartitions != null)
			{
				inverseSeries = new Series("Histogram");
				inverseSeries.ChartArea = "MainChart";
				inverseSeries.ChartType = SeriesChartType.Column;
				inverseSeries.Color = mainChart.Series["Histogram"].Color;
				double divider = (header.DX * record.InversePartitions.Sum())/deltaFx;
				for (int i = 0; i < header.Options.Partitions; ++i)
				{
					current = i * header.DX + header.Options.Begin;
					inverseSeries.Points.AddXY(current + header.DX/2.0, record.InversePartitions[i]/divider);
				}
				mainChart.Series["Histogram"] = inverseSeries;
				inverseRadioButton.Enabled = true;
				inverseRadioButton.Checked = true;
				inverseRadioButton_CheckedChanged(null, null);
			}
			if (record.NeymanPartitions != null)
			{
				neymanSeries = new Series("Histogram");
				neymanSeries.ChartArea = "MainChart";
				neymanSeries.ChartType = SeriesChartType.Column;
				neymanSeries.Color = mainChart.Series["Histogram"].Color;
				double divider = (header.DX * record.NeymanPartitions.Sum())/deltaFx;
				for (int i = 0; i < header.Options.Partitions; ++i)
				{
					current = i * header.DX + header.Options.Begin;
					neymanSeries.Points.AddXY(current + header.DX / 2.0, record.NeymanPartitions[i] / divider);
				}
				neymanRadioButton.Enabled = true;
				if (!inverseRadioButton.Enabled)
				{
					mainChart.Series["Histogram"] = neymanSeries;
					neymanRadioButton.Checked = true;
					neymanRadioButton_CheckedChanged(null, null);
				}
			}
			if (record.MetropolisPartitions != null)
			{
				metroSeries = new Series("Histogram");
				metroSeries.ChartArea = "MainChart";
				metroSeries.ChartType = SeriesChartType.Column;
				metroSeries.Color = mainChart.Series["Histogram"].Color;
				double divider = (header.DX * record.MetropolisPartitions.Sum())/deltaFx;
				for (int i = 0; i < header.Options.Partitions; ++i)
				{
					current = i * header.DX + header.Options.Begin;
					metroSeries.Points.AddXY(current + header.DX / 2.0, record.MetropolisPartitions[i] / divider);
				}
				metroRadioButton.Enabled = true;
				if (!inverseRadioButton.Enabled & !neymanRadioButton.Enabled)
				{
					mainChart.Series["Histogram"] = metroSeries;
					metroRadioButton.Checked = true;
					metroRadioButton_CheckedChanged(null, null);
				}
			}
		}
		Series inverseSeries, neymanSeries, metroSeries;
		FileRecord fileRecord;

		private void neymanRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (neymanRadioButton.Checked)
			{
				FileHeader header = fileRecord.Header;
				mainChart.Series["Histogram"] = neymanSeries;
				expMeanLabel.Text = header.nMean.ToString("F4");
				additionToolTip.SetToolTip(expMeanLabel, header.FriendlyNeymanMeanAccuracy);
				expVarianceLabel.Text = header.nVariance.ToString("F4");
				additionToolTip.SetToolTip(expVarianceLabel, header.FriendlyNeymanVarianceAccuracy);
				expSigmaLabel.Text = header.nSigma.ToString("F4");
				additionToolTip.SetToolTip(expSigmaLabel, header.FriendlyNeymanSigmaAccuracy);
			}
		}

		private void inverseRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (inverseRadioButton.Checked)
			{
				FileHeader header = fileRecord.Header;
				mainChart.Series["Histogram"] = inverseSeries;
				expMeanLabel.Text = header.iMean.ToString("F4");
				expVarianceLabel.Text = header.iVariance.ToString("F4");
				expSigmaLabel.Text = header.iSigma.ToString("F4");
				additionToolTip.SetToolTip(expMeanLabel, header.FriendlyInverseMeanAccuracy);
				additionToolTip.SetToolTip(expVarianceLabel, header.FriendlyInverseVarianceAccuracy);
				additionToolTip.SetToolTip(expSigmaLabel, header.FriendlyInverseSigmaAccuracy);
			}
		}

		private void metroRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (metroRadioButton.Checked)
			{
				FileHeader header = fileRecord.Header;
				mainChart.Series["Histogram"] = metroSeries;
				expMeanLabel.Text = header.mMean.ToString("F4");
				expVarianceLabel.Text = header.mVariance.ToString("F4");
				expSigmaLabel.Text = header.mSigma.ToString("F4");
				additionToolTip.SetToolTip(expMeanLabel, header.FriendlyMetropolisMeanAccuracy);
				additionToolTip.SetToolTip(expVarianceLabel, header.FriendlyMetropolisVarianceAccuracy);
				additionToolTip.SetToolTip(expSigmaLabel, header.FriendlyMetropolisSigmaAccuracy);
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (inverseSeries != null)
				inverseSeries.ChartType = smoothCheckBox.Checked ? SeriesChartType.SplineArea : SeriesChartType.Column;
			if (neymanSeries != null)
				neymanSeries.ChartType = smoothCheckBox.Checked ? SeriesChartType.SplineArea : SeriesChartType.Column;
			if (metroSeries != null)
				metroSeries.ChartType = smoothCheckBox.Checked ? SeriesChartType.SplineArea : SeriesChartType.Column;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChartForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (saveCheckBox.Checked)
			{
				ApplicationOptions.Savings++;
				fileRecord.SaveFile(ApplicationOptions.SaveDirectory + "/sav" + ApplicationOptions.Savings + ".bin");
			}
		}
	}
}
