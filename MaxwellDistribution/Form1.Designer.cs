namespace MaxwellDistribution
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.creationTab = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.concurrencyComboBox = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.fullStatCheckBox = new System.Windows.Forms.CheckBox();
			this.randomButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.distribGroupBox = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.minValueUpDown = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.maxValueUpDown = new System.Windows.Forms.NumericUpDown();
			this.bParamUpDown = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.generalGroupBox = new System.Windows.Forms.GroupBox();
			this.metroCheckBox = new System.Windows.Forms.CheckBox();
			this.neymanCheckBox = new System.Windows.Forms.CheckBox();
			this.inverseCheckBox = new System.Windows.Forms.CheckBox();
			this.nDiagramUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nStatisticUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.loadingTab = new System.Windows.Forms.TabPage();
			this.clearRecordsButton = new System.Windows.Forms.Button();
			this.openRecordButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.betaLabel = new System.Windows.Forms.Label();
			this.intervalLabel = new System.Windows.Forms.Label();
			this.nStatLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.filesListView = new System.Windows.Forms.ListView();
			this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.methodsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.generalColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.dataContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.infoTab = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.aboutTab = new System.Windows.Forms.TabPage();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.concurrencyTimer = new System.Windows.Forms.Timer(this.components);
			this.dataDirectoryWatcher = new System.IO.FileSystemWatcher();
			this.label16 = new System.Windows.Forms.Label();
			this.sourceLinkLabel = new System.Windows.Forms.LinkLabel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.deleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.progressBar = new Stochastic3.TextedProgressBar();
			this.tabControl1.SuspendLayout();
			this.creationTab.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.distribGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.minValueUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxValueUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bParamUpDown)).BeginInit();
			this.generalGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nDiagramUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatisticUpDown)).BeginInit();
			this.loadingTab.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.dataContextMenu.SuspendLayout();
			this.infoTab.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.aboutTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataDirectoryWatcher)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.creationTab);
			this.tabControl1.Controls.Add(this.loadingTab);
			this.tabControl1.Controls.Add(this.infoTab);
			this.tabControl1.Controls.Add(this.aboutTab);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(422, 468);
			this.tabControl1.TabIndex = 1;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// creationTab
			// 
			this.creationTab.Controls.Add(this.groupBox1);
			this.creationTab.Controls.Add(this.progressBar);
			this.creationTab.Controls.Add(this.randomButton);
			this.creationTab.Controls.Add(this.startButton);
			this.creationTab.Controls.Add(this.distribGroupBox);
			this.creationTab.Controls.Add(this.generalGroupBox);
			this.creationTab.Location = new System.Drawing.Point(4, 22);
			this.creationTab.Name = "creationTab";
			this.creationTab.Padding = new System.Windows.Forms.Padding(3);
			this.creationTab.Size = new System.Drawing.Size(414, 442);
			this.creationTab.TabIndex = 0;
			this.creationTab.Text = "Создание эксперимента";
			this.creationTab.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.concurrencyComboBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Controls.Add(this.fullStatCheckBox);
			this.groupBox1.Location = new System.Drawing.Point(7, 268);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(401, 84);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Дополнительно";
			// 
			// concurrencyComboBox
			// 
			this.concurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.concurrencyComboBox.FormattingEnabled = true;
			this.concurrencyComboBox.Items.AddRange(new object[] {
            "Однопоточное исполнение",
            "Фоновое исполнение",
            "По методам"});
			this.concurrencyComboBox.Location = new System.Drawing.Point(206, 48);
			this.concurrencyComboBox.Name = "concurrencyComboBox";
			this.concurrencyComboBox.Size = new System.Drawing.Size(187, 21);
			this.concurrencyComboBox.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 51);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(157, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Параметры многопоточности";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(237, 20);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(156, 13);
			this.linkLabel1.TabIndex = 10;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "О распределении Максвелла";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// fullStatCheckBox
			// 
			this.fullStatCheckBox.AutoSize = true;
			this.fullStatCheckBox.Checked = true;
			this.fullStatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fullStatCheckBox.Location = new System.Drawing.Point(8, 19);
			this.fullStatCheckBox.Name = "fullStatCheckBox";
			this.fullStatCheckBox.Size = new System.Drawing.Size(155, 17);
			this.fullStatCheckBox.TabIndex = 9;
			this.fullStatCheckBox.Text = "Расширенная статистика";
			this.fullStatCheckBox.UseVisualStyleBackColor = true;
			// 
			// randomButton
			// 
			this.randomButton.Location = new System.Drawing.Point(208, 377);
			this.randomButton.Name = "randomButton";
			this.randomButton.Size = new System.Drawing.Size(122, 30);
			this.randomButton.TabIndex = 4;
			this.randomButton.Text = "Случайное значение";
			this.randomButton.UseVisualStyleBackColor = true;
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(80, 377);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(122, 30);
			this.startButton.TabIndex = 3;
			this.startButton.Text = "Запуск генерации";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// distribGroupBox
			// 
			this.distribGroupBox.Controls.Add(this.label5);
			this.distribGroupBox.Controls.Add(this.minValueUpDown);
			this.distribGroupBox.Controls.Add(this.label4);
			this.distribGroupBox.Controls.Add(this.maxValueUpDown);
			this.distribGroupBox.Controls.Add(this.bParamUpDown);
			this.distribGroupBox.Controls.Add(this.label3);
			this.distribGroupBox.Location = new System.Drawing.Point(7, 156);
			this.distribGroupBox.Name = "distribGroupBox";
			this.distribGroupBox.Size = new System.Drawing.Size(401, 105);
			this.distribGroupBox.TabIndex = 1;
			this.distribGroupBox.TabStop = false;
			this.distribGroupBox.Text = "Параметры распределения";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 47);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(164, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Левая граница распределения";
			// 
			// minValueUpDown
			// 
			this.minValueUpDown.DecimalPlaces = 6;
			this.minValueUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.minValueUpDown.Location = new System.Drawing.Point(206, 45);
			this.minValueUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.minValueUpDown.Name = "minValueUpDown";
			this.minValueUpDown.Size = new System.Drawing.Size(187, 20);
			this.minValueUpDown.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(170, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Правая граница распределения";
			// 
			// maxValueUpDown
			// 
			this.maxValueUpDown.DecimalPlaces = 6;
			this.maxValueUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.maxValueUpDown.Location = new System.Drawing.Point(206, 71);
			this.maxValueUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.maxValueUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.maxValueUpDown.Name = "maxValueUpDown";
			this.maxValueUpDown.Size = new System.Drawing.Size(187, 20);
			this.maxValueUpDown.TabIndex = 8;
			this.maxValueUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// bParamUpDown
			// 
			this.bParamUpDown.DecimalPlaces = 6;
			this.bParamUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.bParamUpDown.Location = new System.Drawing.Point(206, 19);
			this.bParamUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.bParamUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			this.bParamUpDown.Name = "bParamUpDown";
			this.bParamUpDown.Size = new System.Drawing.Size(187, 20);
			this.bParamUpDown.TabIndex = 7;
			this.bParamUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.bParamUpDown.ValueChanged += new System.EventHandler(this.bParamUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(190, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Значение свободного параметра (β)";
			// 
			// generalGroupBox
			// 
			this.generalGroupBox.Controls.Add(this.metroCheckBox);
			this.generalGroupBox.Controls.Add(this.neymanCheckBox);
			this.generalGroupBox.Controls.Add(this.inverseCheckBox);
			this.generalGroupBox.Controls.Add(this.nDiagramUpDown);
			this.generalGroupBox.Controls.Add(this.label2);
			this.generalGroupBox.Controls.Add(this.nStatisticUpDown);
			this.generalGroupBox.Controls.Add(this.label1);
			this.generalGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.generalGroupBox.Location = new System.Drawing.Point(6, 6);
			this.generalGroupBox.Name = "generalGroupBox";
			this.generalGroupBox.Size = new System.Drawing.Size(402, 143);
			this.generalGroupBox.TabIndex = 0;
			this.generalGroupBox.TabStop = false;
			this.generalGroupBox.Text = "Общие параметры";
			// 
			// metroCheckBox
			// 
			this.metroCheckBox.AutoSize = true;
			this.metroCheckBox.Checked = true;
			this.metroCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.metroCheckBox.Location = new System.Drawing.Point(9, 117);
			this.metroCheckBox.Name = "metroCheckBox";
			this.metroCheckBox.Size = new System.Drawing.Size(129, 17);
			this.metroCheckBox.TabIndex = 8;
			this.metroCheckBox.Text = "Метод Метрополиса";
			this.metroCheckBox.UseVisualStyleBackColor = true;
			// 
			// neymanCheckBox
			// 
			this.neymanCheckBox.AutoSize = true;
			this.neymanCheckBox.Checked = true;
			this.neymanCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.neymanCheckBox.Location = new System.Drawing.Point(9, 94);
			this.neymanCheckBox.Name = "neymanCheckBox";
			this.neymanCheckBox.Size = new System.Drawing.Size(107, 17);
			this.neymanCheckBox.TabIndex = 7;
			this.neymanCheckBox.Text = "Метод Неймана";
			this.neymanCheckBox.UseVisualStyleBackColor = true;
			// 
			// inverseCheckBox
			// 
			this.inverseCheckBox.AutoSize = true;
			this.inverseCheckBox.Checked = true;
			this.inverseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.inverseCheckBox.Location = new System.Drawing.Point(9, 71);
			this.inverseCheckBox.Name = "inverseCheckBox";
			this.inverseCheckBox.Size = new System.Drawing.Size(155, 17);
			this.inverseCheckBox.TabIndex = 6;
			this.inverseCheckBox.Text = "Метод обратных функций";
			this.inverseCheckBox.UseVisualStyleBackColor = true;
			// 
			// nDiagramUpDown
			// 
			this.nDiagramUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nDiagramUpDown.Location = new System.Drawing.Point(207, 40);
			this.nDiagramUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nDiagramUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nDiagramUpDown.Name = "nDiagramUpDown";
			this.nDiagramUpDown.Size = new System.Drawing.Size(187, 20);
			this.nDiagramUpDown.TabIndex = 3;
			this.nDiagramUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(195, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Количество разбиений гистограммы";
			// 
			// nStatisticUpDown
			// 
			this.nStatisticUpDown.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nStatisticUpDown.Location = new System.Drawing.Point(207, 14);
			this.nStatisticUpDown.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.nStatisticUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nStatisticUpDown.Name = "nStatisticUpDown";
			this.nStatisticUpDown.Size = new System.Drawing.Size(187, 20);
			this.nStatisticUpDown.TabIndex = 1;
			this.nStatisticUpDown.ThousandsSeparator = true;
			this.nStatisticUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Количество элементов выборки";
			// 
			// loadingTab
			// 
			this.loadingTab.Controls.Add(this.clearRecordsButton);
			this.loadingTab.Controls.Add(this.openRecordButton);
			this.loadingTab.Controls.Add(this.groupBox2);
			this.loadingTab.Controls.Add(this.label7);
			this.loadingTab.Controls.Add(this.filesListView);
			this.loadingTab.Location = new System.Drawing.Point(4, 22);
			this.loadingTab.Name = "loadingTab";
			this.loadingTab.Padding = new System.Windows.Forms.Padding(3);
			this.loadingTab.Size = new System.Drawing.Size(414, 442);
			this.loadingTab.TabIndex = 1;
			this.loadingTab.Text = "Загрузка результатов";
			this.loadingTab.UseVisualStyleBackColor = true;
			// 
			// clearRecordsButton
			// 
			this.clearRecordsButton.Location = new System.Drawing.Point(137, 386);
			this.clearRecordsButton.Name = "clearRecordsButton";
			this.clearRecordsButton.Size = new System.Drawing.Size(122, 30);
			this.clearRecordsButton.TabIndex = 7;
			this.clearRecordsButton.Text = "Очистить записи";
			this.clearRecordsButton.UseVisualStyleBackColor = true;
			this.clearRecordsButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// openRecordButton
			// 
			this.openRecordButton.Enabled = false;
			this.openRecordButton.Location = new System.Drawing.Point(8, 386);
			this.openRecordButton.Name = "openRecordButton";
			this.openRecordButton.Size = new System.Drawing.Size(122, 30);
			this.openRecordButton.TabIndex = 6;
			this.openRecordButton.Text = "Открыть запись";
			this.openRecordButton.UseVisualStyleBackColor = true;
			this.openRecordButton.Click += new System.EventHandler(this.openRecordButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.betaLabel);
			this.groupBox2.Controls.Add(this.intervalLabel);
			this.groupBox2.Controls.Add(this.nStatLabel);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(8, 292);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(400, 88);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Информация";
			// 
			// betaLabel
			// 
			this.betaLabel.AutoSize = true;
			this.betaLabel.Location = new System.Drawing.Point(152, 63);
			this.betaLabel.Name = "betaLabel";
			this.betaLabel.Size = new System.Drawing.Size(13, 13);
			this.betaLabel.TabIndex = 5;
			this.betaLabel.Text = "--";
			// 
			// intervalLabel
			// 
			this.intervalLabel.AutoSize = true;
			this.intervalLabel.Location = new System.Drawing.Point(152, 39);
			this.intervalLabel.Name = "intervalLabel";
			this.intervalLabel.Size = new System.Drawing.Size(13, 13);
			this.intervalLabel.TabIndex = 4;
			this.intervalLabel.Text = "--";
			// 
			// nStatLabel
			// 
			this.nStatLabel.AutoSize = true;
			this.nStatLabel.Location = new System.Drawing.Point(152, 16);
			this.nStatLabel.Name = "nStatLabel";
			this.nStatLabel.Size = new System.Drawing.Size(13, 13);
			this.nStatLabel.TabIndex = 3;
			this.nStatLabel.Text = "--";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 63);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(131, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Значение параметра (β):";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(137, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "Отрезок распределения: ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(99, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Размер выборки: ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(254, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "Файлы сохранений результатов экспериментов";
			// 
			// filesListView
			// 
			this.filesListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
			this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.dateColumn,
            this.methodsColumn,
            this.generalColumn});
			this.filesListView.ContextMenuStrip = this.dataContextMenu;
			this.filesListView.FullRowSelect = true;
			this.filesListView.GridLines = true;
			this.filesListView.Location = new System.Drawing.Point(6, 30);
			this.filesListView.MultiSelect = false;
			this.filesListView.Name = "filesListView";
			this.filesListView.ShowItemToolTips = true;
			this.filesListView.Size = new System.Drawing.Size(402, 255);
			this.filesListView.SmallImageList = this.imageList1;
			this.filesListView.TabIndex = 0;
			this.filesListView.UseCompatibleStateImageBehavior = false;
			this.filesListView.View = System.Windows.Forms.View.Details;
			this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
			// 
			// nameColumn
			// 
			this.nameColumn.Text = "Имя записи";
			this.nameColumn.Width = 161;
			// 
			// dateColumn
			// 
			this.dateColumn.Text = "Дата";
			this.dateColumn.Width = 86;
			// 
			// methodsColumn
			// 
			this.methodsColumn.Text = "Методы";
			this.methodsColumn.Width = 58;
			// 
			// generalColumn
			// 
			this.generalColumn.Text = "Основные параметры";
			this.generalColumn.Width = 92;
			// 
			// dataContextMenu
			// 
			this.dataContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteContextMenuItem});
			this.dataContextMenu.Name = "dataContextMenu";
			this.dataContextMenu.Size = new System.Drawing.Size(162, 48);
			this.dataContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.dataContextMenu_Opening);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.openToolStripMenuItem.Text = "Открыть запись";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openRecordButton_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "data32.ico");
			// 
			// infoTab
			// 
			this.infoTab.Controls.Add(this.groupBox3);
			this.infoTab.Location = new System.Drawing.Point(4, 22);
			this.infoTab.Name = "infoTab";
			this.infoTab.Padding = new System.Windows.Forms.Padding(3);
			this.infoTab.Size = new System.Drawing.Size(414, 442);
			this.infoTab.TabIndex = 2;
			this.infoTab.Text = "Справка";
			this.infoTab.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.pictureBox3);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.pictureBox1);
			this.groupBox3.Location = new System.Drawing.Point(6, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(402, 396);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Распределение Максвелла";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(96, 18);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(208, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "Функция плотности вероятности (PDF):";
			// 
			// aboutTab
			// 
			this.aboutTab.Controls.Add(this.sourceLinkLabel);
			this.aboutTab.Controls.Add(this.label16);
			this.aboutTab.Controls.Add(this.label15);
			this.aboutTab.Controls.Add(this.label14);
			this.aboutTab.Controls.Add(this.label13);
			this.aboutTab.Controls.Add(this.label12);
			this.aboutTab.Controls.Add(this.pictureBox2);
			this.aboutTab.Location = new System.Drawing.Point(4, 22);
			this.aboutTab.Name = "aboutTab";
			this.aboutTab.Padding = new System.Windows.Forms.Padding(3);
			this.aboutTab.Size = new System.Drawing.Size(414, 442);
			this.aboutTab.TabIndex = 3;
			this.aboutTab.Text = "О программе";
			this.aboutTab.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label15.Location = new System.Drawing.Point(143, 3);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(218, 17);
			this.label15.TabIndex = 3;
			this.label15.Text = "Факультет Компьютерных Наук";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.Location = new System.Drawing.Point(190, 425);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(121, 14);
			this.label14.TabIndex = 2;
			this.label14.Text = "Serenium group © 2015";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.Location = new System.Drawing.Point(167, 410);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(171, 13);
			this.label13.TabIndex = 1;
			this.label13.Text = "Разработчик: Ефремов Арсений";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.Location = new System.Drawing.Point(154, 163);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(207, 34);
			this.label12.TabIndex = 0;
			this.label12.Text = "Генератор случайных чисел \r\nс распределением Максвелла";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// concurrencyTimer
			// 
			this.concurrencyTimer.Interval = 30;
			this.concurrencyTimer.Tick += new System.EventHandler(this.concurrencyTimer_Tick);
			// 
			// dataDirectoryWatcher
			// 
			this.dataDirectoryWatcher.EnableRaisingEvents = true;
			this.dataDirectoryWatcher.Filter = "*.bin";
			this.dataDirectoryWatcher.Path = "data";
			this.dataDirectoryWatcher.SynchronizingObject = this;
			this.dataDirectoryWatcher.Changed += new System.IO.FileSystemEventHandler(this.dataDirectoryWatcher_Changed);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(177, 388);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(75, 13);
			this.label16.TabIndex = 5;
			this.label16.Text = "Просмотреть";
			// 
			// sourceLinkLabel
			// 
			this.sourceLinkLabel.AutoSize = true;
			this.sourceLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.sourceLinkLabel.Location = new System.Drawing.Point(248, 388);
			this.sourceLinkLabel.Name = "sourceLinkLabel";
			this.sourceLinkLabel.Size = new System.Drawing.Size(77, 13);
			this.sourceLinkLabel.TabIndex = 6;
			this.sourceLinkLabel.TabStop = true;
			this.sourceLinkLabel.Text = "исходный код";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox1.Location = new System.Drawing.Point(6, 223);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(390, 171);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(117, 122);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(167, 13);
			this.label17.TabIndex = 4;
			this.label17.Text = "Функция распределения (CDF):";
			// 
			// deleteContextMenuItem
			// 
			this.deleteContextMenuItem.Image = global::MaxwellDistribution.Properties.Resources.delete;
			this.deleteContextMenuItem.Name = "deleteContextMenuItem";
			this.deleteContextMenuItem.Size = new System.Drawing.Size(161, 22);
			this.deleteContextMenuItem.Text = "Удалить запись";
			this.deleteContextMenuItem.Click += new System.EventHandler(this.deleteContextMenuItem_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = global::MaxwellDistribution.Properties.Resources.cdf;
			this.pictureBox3.Location = new System.Drawing.Point(43, 138);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(317, 70);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox3.TabIndex = 3;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::MaxwellDistribution.Properties.Resources.maxwell;
			this.pictureBox1.Location = new System.Drawing.Point(94, 35);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(212, 75);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::MaxwellDistribution.Properties.Resources.decor;
			this.pictureBox2.Location = new System.Drawing.Point(-5, -9);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(101, 459);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// progressBar
			// 
			this.progressBar.CustomText = null;
			this.progressBar.DisplayStyle = Stochastic3.ProgressBarDisplayText.Percentage;
			this.progressBar.InnerTextColor = System.Drawing.Color.Black;
			this.progressBar.Location = new System.Drawing.Point(6, 413);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(402, 23);
			this.progressBar.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 474);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Генератор случайных чисел";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.tabControl1.ResumeLayout(false);
			this.creationTab.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.distribGroupBox.ResumeLayout(false);
			this.distribGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.minValueUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxValueUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bParamUpDown)).EndInit();
			this.generalGroupBox.ResumeLayout(false);
			this.generalGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nDiagramUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nStatisticUpDown)).EndInit();
			this.loadingTab.ResumeLayout(false);
			this.loadingTab.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.dataContextMenu.ResumeLayout(false);
			this.infoTab.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.aboutTab.ResumeLayout(false);
			this.aboutTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataDirectoryWatcher)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage creationTab;
		private System.Windows.Forms.TabPage loadingTab;
		private System.Windows.Forms.GroupBox distribGroupBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown minValueUpDown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown maxValueUpDown;
		private System.Windows.Forms.NumericUpDown bParamUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox generalGroupBox;
		private System.Windows.Forms.CheckBox metroCheckBox;
		private System.Windows.Forms.CheckBox neymanCheckBox;
		private System.Windows.Forms.CheckBox inverseCheckBox;
		private System.Windows.Forms.NumericUpDown nDiagramUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nStatisticUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button randomButton;
		private System.Windows.Forms.Button startButton;
		private Stochastic3.TextedProgressBar progressBar;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox concurrencyComboBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.CheckBox fullStatCheckBox;
		private System.Windows.Forms.ListView filesListView;
		private System.Windows.Forms.ColumnHeader nameColumn;
		private System.Windows.Forms.ColumnHeader dateColumn;
		private System.Windows.Forms.ColumnHeader methodsColumn;
		private System.Windows.Forms.ColumnHeader generalColumn;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label betaLabel;
		private System.Windows.Forms.Label intervalLabel;
		private System.Windows.Forms.Label nStatLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ContextMenuStrip dataContextMenu;
		private System.Windows.Forms.ToolStripMenuItem deleteContextMenuItem;
		private System.Windows.Forms.Button clearRecordsButton;
		private System.Windows.Forms.Button openRecordButton;
		private System.Windows.Forms.TabPage infoTab;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TabPage aboutTab;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Timer concurrencyTimer;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.IO.FileSystemWatcher dataDirectoryWatcher;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.LinkLabel sourceLinkLabel;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.TextBox textBox1;

	}
}

