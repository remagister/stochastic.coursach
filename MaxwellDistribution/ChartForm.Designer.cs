namespace MaxwellDistribution
{
	partial class ChartForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
			this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.percentCompletedLabel = new System.Windows.Forms.Label();
			this.percentCompleted = new System.Windows.Forms.Label();
			this.controlGroupBox = new System.Windows.Forms.GroupBox();
			this.saveCheckBox = new System.Windows.Forms.CheckBox();
			this.smoothCheckBox = new System.Windows.Forms.CheckBox();
			this.metroRadioButton = new System.Windows.Forms.RadioButton();
			this.neymanRadioButton = new System.Windows.Forms.RadioButton();
			this.inverseRadioButton = new System.Windows.Forms.RadioButton();
			this.modeLabel = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.expSigmaLabel = new System.Windows.Forms.LinkLabel();
			this.expVarianceLabel = new System.Windows.Forms.LinkLabel();
			this.expMeanLabel = new System.Windows.Forms.LinkLabel();
			this.label10 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.sigmaLabel = new System.Windows.Forms.Label();
			this.varianceLabel = new System.Windows.Forms.Label();
			this.meanLabel = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.betaLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.sizeLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timeLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nStatLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.additionToolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.controlGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainChart
			// 
			this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			chartArea1.Name = "MainChart";
			this.mainChart.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.mainChart.Legends.Add(legend1);
			this.mainChart.Location = new System.Drawing.Point(233, 12);
			this.mainChart.Name = "mainChart";
			this.mainChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
			series1.ChartArea = "MainChart";
			series1.Color = System.Drawing.Color.LightBlue;
			series1.Legend = "Legend1";
			series1.LegendToolTip = "Гистограмма полученного распределения";
			series1.Name = "Histogram";
			series1.ToolTip = "#VAL{N2}";
			series2.BorderWidth = 2;
			series2.ChartArea = "MainChart";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series2.Color = System.Drawing.Color.Blue;
			series2.Legend = "Legend1";
			series2.LegendToolTip = "Плотность вероятности";
			series2.Name = "PDF";
			series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			series3.BorderWidth = 2;
			series3.ChartArea = "MainChart";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series3.Color = System.Drawing.Color.DarkViolet;
			series3.Legend = "Legend1";
			series3.LegendToolTip = "Функция распределения";
			series3.Name = "CDF";
			this.mainChart.Series.Add(series1);
			this.mainChart.Series.Add(series2);
			this.mainChart.Series.Add(series3);
			this.mainChart.Size = new System.Drawing.Size(623, 584);
			this.mainChart.TabIndex = 2;
			this.mainChart.Text = "chart1";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.percentCompletedLabel);
			this.groupBox1.Controls.Add(this.percentCompleted);
			this.groupBox1.Controls.Add(this.controlGroupBox);
			this.groupBox1.Controls.Add(this.modeLabel);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.expSigmaLabel);
			this.groupBox1.Controls.Add(this.expVarianceLabel);
			this.groupBox1.Controls.Add(this.expMeanLabel);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.okButton);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.sigmaLabel);
			this.groupBox1.Controls.Add(this.varianceLabel);
			this.groupBox1.Controls.Add(this.meanLabel);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.betaLabel);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.sizeLabel);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.timeLabel);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.nStatLabel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(215, 594);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Общая статистика";
			// 
			// percentCompletedLabel
			// 
			this.percentCompletedLabel.AutoSize = true;
			this.percentCompletedLabel.Location = new System.Drawing.Point(130, 55);
			this.percentCompletedLabel.Name = "percentCompletedLabel";
			this.percentCompletedLabel.Size = new System.Drawing.Size(54, 13);
			this.percentCompletedLabel.TabIndex = 29;
			this.percentCompletedLabel.Text = "(процент)";
			// 
			// percentCompleted
			// 
			this.percentCompleted.AutoSize = true;
			this.percentCompleted.Location = new System.Drawing.Point(8, 55);
			this.percentCompleted.Name = "percentCompleted";
			this.percentCompleted.Size = new System.Drawing.Size(125, 13);
			this.percentCompleted.TabIndex = 28;
			this.percentCompleted.Text = "Проц. зафиксировано: ";
			// 
			// controlGroupBox
			// 
			this.controlGroupBox.Controls.Add(this.saveCheckBox);
			this.controlGroupBox.Controls.Add(this.smoothCheckBox);
			this.controlGroupBox.Controls.Add(this.metroRadioButton);
			this.controlGroupBox.Controls.Add(this.neymanRadioButton);
			this.controlGroupBox.Controls.Add(this.inverseRadioButton);
			this.controlGroupBox.Location = new System.Drawing.Point(0, 388);
			this.controlGroupBox.Name = "controlGroupBox";
			this.controlGroupBox.Size = new System.Drawing.Size(215, 163);
			this.controlGroupBox.TabIndex = 27;
			this.controlGroupBox.TabStop = false;
			this.controlGroupBox.Text = "Управление";
			// 
			// saveCheckBox
			// 
			this.saveCheckBox.AutoSize = true;
			this.saveCheckBox.Checked = true;
			this.saveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.saveCheckBox.Location = new System.Drawing.Point(11, 140);
			this.saveCheckBox.Name = "saveCheckBox";
			this.saveCheckBox.Size = new System.Drawing.Size(117, 17);
			this.saveCheckBox.TabIndex = 4;
			this.saveCheckBox.Text = "Сохранить в файл";
			this.saveCheckBox.UseVisualStyleBackColor = true;
			// 
			// smoothCheckBox
			// 
			this.smoothCheckBox.AutoSize = true;
			this.smoothCheckBox.Location = new System.Drawing.Point(11, 117);
			this.smoothCheckBox.Name = "smoothCheckBox";
			this.smoothCheckBox.Size = new System.Drawing.Size(188, 17);
			this.smoothCheckBox.TabIndex = 3;
			this.smoothCheckBox.Text = "График в виде гладкой области";
			this.smoothCheckBox.UseVisualStyleBackColor = true;
			this.smoothCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// metroRadioButton
			// 
			this.metroRadioButton.AutoSize = true;
			this.metroRadioButton.Enabled = false;
			this.metroRadioButton.Location = new System.Drawing.Point(11, 66);
			this.metroRadioButton.Name = "metroRadioButton";
			this.metroRadioButton.Size = new System.Drawing.Size(128, 17);
			this.metroRadioButton.TabIndex = 2;
			this.metroRadioButton.Text = "Метод Метрополиса";
			this.metroRadioButton.UseVisualStyleBackColor = true;
			this.metroRadioButton.CheckedChanged += new System.EventHandler(this.metroRadioButton_CheckedChanged);
			// 
			// neymanRadioButton
			// 
			this.neymanRadioButton.AutoSize = true;
			this.neymanRadioButton.Enabled = false;
			this.neymanRadioButton.Location = new System.Drawing.Point(11, 43);
			this.neymanRadioButton.Name = "neymanRadioButton";
			this.neymanRadioButton.Size = new System.Drawing.Size(106, 17);
			this.neymanRadioButton.TabIndex = 1;
			this.neymanRadioButton.Text = "Метод Неймана";
			this.neymanRadioButton.UseVisualStyleBackColor = true;
			this.neymanRadioButton.CheckedChanged += new System.EventHandler(this.neymanRadioButton_CheckedChanged);
			// 
			// inverseRadioButton
			// 
			this.inverseRadioButton.AutoSize = true;
			this.inverseRadioButton.Checked = true;
			this.inverseRadioButton.Enabled = false;
			this.inverseRadioButton.Location = new System.Drawing.Point(11, 20);
			this.inverseRadioButton.Name = "inverseRadioButton";
			this.inverseRadioButton.Size = new System.Drawing.Size(154, 17);
			this.inverseRadioButton.TabIndex = 0;
			this.inverseRadioButton.TabStop = true;
			this.inverseRadioButton.Text = "Метод обратных функций";
			this.inverseRadioButton.UseVisualStyleBackColor = true;
			this.inverseRadioButton.CheckedChanged += new System.EventHandler(this.inverseRadioButton_CheckedChanged);
			// 
			// modeLabel
			// 
			this.modeLabel.AutoSize = true;
			this.modeLabel.Location = new System.Drawing.Point(130, 355);
			this.modeLabel.Name = "modeLabel";
			this.modeLabel.Size = new System.Drawing.Size(60, 13);
			this.modeLabel.TabIndex = 26;
			this.modeLabel.Text = "(значение)";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(8, 355);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(37, 13);
			this.label13.TabIndex = 25;
			this.label13.Text = "Мода:";
			// 
			// expSigmaLabel
			// 
			this.expSigmaLabel.AutoSize = true;
			this.expSigmaLabel.Location = new System.Drawing.Point(130, 325);
			this.expSigmaLabel.Name = "expSigmaLabel";
			this.expSigmaLabel.Size = new System.Drawing.Size(60, 13);
			this.expSigmaLabel.TabIndex = 24;
			this.expSigmaLabel.TabStop = true;
			this.expSigmaLabel.Text = "(значение)";
			// 
			// expVarianceLabel
			// 
			this.expVarianceLabel.AutoSize = true;
			this.expVarianceLabel.Location = new System.Drawing.Point(130, 295);
			this.expVarianceLabel.Name = "expVarianceLabel";
			this.expVarianceLabel.Size = new System.Drawing.Size(60, 13);
			this.expVarianceLabel.TabIndex = 23;
			this.expVarianceLabel.TabStop = true;
			this.expVarianceLabel.Text = "(значение)";
			// 
			// expMeanLabel
			// 
			this.expMeanLabel.AutoSize = true;
			this.expMeanLabel.Location = new System.Drawing.Point(130, 265);
			this.expMeanLabel.Name = "expMeanLabel";
			this.expMeanLabel.Size = new System.Drawing.Size(60, 13);
			this.expMeanLabel.TabIndex = 22;
			this.expMeanLabel.TabStop = true;
			this.expMeanLabel.Text = "(значение)";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 325);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 13);
			this.label10.TabIndex = 21;
			this.label10.Text = "Эксп. сигма:";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.okButton.Location = new System.Drawing.Point(3, 557);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(209, 34);
			this.okButton.TabIndex = 18;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 295);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(95, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "Эксп. дисперсия:";
			// 
			// sigmaLabel
			// 
			this.sigmaLabel.AutoSize = true;
			this.sigmaLabel.Location = new System.Drawing.Point(130, 235);
			this.sigmaLabel.Name = "sigmaLabel";
			this.sigmaLabel.Size = new System.Drawing.Size(60, 13);
			this.sigmaLabel.TabIndex = 14;
			this.sigmaLabel.Text = "(значение)";
			// 
			// varianceLabel
			// 
			this.varianceLabel.AutoSize = true;
			this.varianceLabel.Location = new System.Drawing.Point(130, 205);
			this.varianceLabel.Name = "varianceLabel";
			this.varianceLabel.Size = new System.Drawing.Size(71, 13);
			this.varianceLabel.TabIndex = 13;
			this.varianceLabel.Text = "(количество)";
			// 
			// meanLabel
			// 
			this.meanLabel.AutoSize = true;
			this.meanLabel.Location = new System.Drawing.Point(130, 175);
			this.meanLabel.Name = "meanLabel";
			this.meanLabel.Size = new System.Drawing.Size(60, 13);
			this.meanLabel.TabIndex = 12;
			this.meanLabel.Text = "(значение)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 265);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(110, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Эксп. матожидание:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 235);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Сигма:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 205);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Дисперсия:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 175);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Матожидание:";
			// 
			// betaLabel
			// 
			this.betaLabel.AutoSize = true;
			this.betaLabel.Location = new System.Drawing.Point(130, 145);
			this.betaLabel.Name = "betaLabel";
			this.betaLabel.Size = new System.Drawing.Size(60, 13);
			this.betaLabel.TabIndex = 7;
			this.betaLabel.Text = "(значение)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 145);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Параметр (β):";
			// 
			// sizeLabel
			// 
			this.sizeLabel.AutoSize = true;
			this.sizeLabel.Location = new System.Drawing.Point(130, 115);
			this.sizeLabel.Name = "sizeLabel";
			this.sizeLabel.Size = new System.Drawing.Size(59, 13);
			this.sizeLabel.TabIndex = 5;
			this.sizeLabel.Text = "(размеры)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Параметры отрезка: ";
			// 
			// timeLabel
			// 
			this.timeLabel.AutoSize = true;
			this.timeLabel.Location = new System.Drawing.Point(130, 85);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(45, 13);
			this.timeLabel.TabIndex = 3;
			this.timeLabel.Text = "(время)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Затрачено времени: ";
			// 
			// nStatLabel
			// 
			this.nStatLabel.AutoSize = true;
			this.nStatLabel.Location = new System.Drawing.Point(130, 25);
			this.nStatLabel.Name = "nStatLabel";
			this.nStatLabel.Size = new System.Drawing.Size(60, 13);
			this.nStatLabel.TabIndex = 1;
			this.nStatLabel.Text = "(итерации)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Всего итераций:";
			// 
			// ChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(868, 611);
			this.Controls.Add(this.mainChart);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ChartForm";
			this.Text = "Результаты генерации";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.controlGroupBox.ResumeLayout(false);
			this.controlGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label sigmaLabel;
		private System.Windows.Forms.Label varianceLabel;
		private System.Windows.Forms.Label meanLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label betaLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label sizeLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label nStatLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label modeLabel;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ToolTip additionToolTip;
		private System.Windows.Forms.GroupBox controlGroupBox;
		private System.Windows.Forms.LinkLabel expSigmaLabel;
		private System.Windows.Forms.LinkLabel expVarianceLabel;
		private System.Windows.Forms.LinkLabel expMeanLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox smoothCheckBox;
		private System.Windows.Forms.RadioButton metroRadioButton;
		private System.Windows.Forms.RadioButton neymanRadioButton;
		private System.Windows.Forms.RadioButton inverseRadioButton;
		private System.Windows.Forms.Label percentCompletedLabel;
		private System.Windows.Forms.Label percentCompleted;
		private System.Windows.Forms.CheckBox saveCheckBox;
	}
}