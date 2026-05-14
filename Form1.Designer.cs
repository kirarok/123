namespace BoilerCalc
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.titleLabel = new Label();
            this.subtitleLabel = new Label();
            this.themeToggleButton = new Button();
            
            this.mainPanel = new FlowLayoutPanel();
            
            // Панели секций
            this.userInfoPanel = new Panel();
            this.boilerParamsPanel = new Panel();
            this.fuelPanel = new Panel();
            this.ashPanel = new Panel();
            this.furnacePanel = new Panel();
            
            // Заголовки секций
            this.lblUserInfo = new Label();
            this.lblBoilerParams = new Label();
            this.lblFuel = new Label();
            this.lblAsh = new Label();
            this.lblFurnace = new Label();
            
            // Элементы управления
            this.CoalSelectComboBox = new ComboBox();
            this.BoilerSelectComboBox = new ComboBox();
            this.CustomCoalCheckBox = new CheckBox();
            this.CustomAshCheckBox = new CheckBox();
            this.calculateButton = new Button();
            
            // Поля ввода пользователя
            this.FIO = new TextBox();
            this.BoilerName = new TextBox();
            this.FuelBrend = new TextBox();
            this.Marka = new TextBox();
            
            // Параметры котла
            this.QBoiler = new TextBox();
            this.PBaraban = new TextBox();
            this.PPar = new TextBox();
            this.TPar = new TextBox();
            this.TPitV = new TextBox();
            this.VTop = new TextBox();
            this.IPerPar = new TextBox();
            this.IPitV = new TextBox();
            
            // Состав топлива
            this.WР = new TextBox();
            this.АР = new TextBox();
            this.SР = new TextBox();
            this.СР = new TextBox();
            this.НР = new TextBox();
            this.NР = new TextBox();
            this.ОР = new TextBox();
            this.QРh = new TextBox();
            this.KiloDJ = new TextBox();
            this.KiloKal = new TextBox();
            
            // Параметры топки
            this.aT = new TextBox();
            this.q3 = new TextBox();
            this.q4 = new TextBox();
            this.aYN = new TextBox();
            this.DaPP = new TextBox();
            this.DaVE = new TextBox();
            this.DaVP = new TextBox();
            this.DaT = new TextBox();
            this.DaPL = new TextBox();
            
            // Химсостав золы
            this.SiO2 = new TextBox();
            this.Al2O3 = new TextBox();
            this.TiO2 = new TextBox();
            this.Fe2O3 = new TextBox();
            this.CaO = new TextBox();
            this.MgO = new TextBox();
            this.K2O = new TextBox();
            this.Na2O = new TextBox();
            
            // Температура
            this.TempUG = new TextBox();
            this.TempHolV = new TextBox();
            
            // Labels
            this.lblCoalSelect = new Label();
            this.lblBoilerSelect = new Label();
            
            // headerPanel
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 90;
            this.headerPanel.BackColor = Color.FromArgb(25, 25, 25);
            this.headerPanel.Padding = new Padding(25);
            
            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.titleLabel.ForeColor = Color.White;
            this.titleLabel.Location = new Point(25, 12);
            this.titleLabel.Text = "🔥 Тепловой расчёт котлоагрегата";
            
            // subtitleLabel
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new Font("Segoe UI", 11F);
            this.subtitleLabel.ForeColor = Color.FromArgb(160, 160, 160);
            this.subtitleLabel.Location = new Point(25, 52);
            this.subtitleLabel.Text = "Курсовой проект по дисциплине «Тепловые электрические станции»";
            
            // themeToggleButton
            this.themeToggleButton.Anchor = AnchorStyles.None;
            this.themeToggleButton.BackColor = Color.FromArgb(70, 70, 70);
            this.themeToggleButton.FlatAppearance.BorderColor = Color.FromArgb(120, 120, 120);
            this.themeToggleButton.FlatAppearance.BorderSize = 1;
            this.themeToggleButton.FlatStyle = FlatStyle.Flat;
            this.themeToggleButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.themeToggleButton.ForeColor = Color.White;
            this.themeToggleButton.Location = new Point(75, 8);
            this.themeToggleButton.Size = new Size(200, 45);
            this.themeToggleButton.Text = "🌙 Ночной режим";
            this.themeToggleButton.Cursor = Cursors.Hand;
            this.themeToggleButton.Click += new EventHandler(this.themeToggleButton_Click);
            this.themeToggleButton.Padding = new Padding(5);
            this.themeToggleButton.MouseEnter += new EventHandler(this.themeToggleButton_MouseEnter);
            this.themeToggleButton.MouseLeave += new EventHandler(this.themeToggleButton_MouseLeave);
            
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            
            // mainPanel
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = Color.FromArgb(240, 242, 245);
            this.mainPanel.FlowDirection = FlowDirection.LeftToRight;
            this.mainPanel.WrapContents = true;
            this.mainPanel.Padding = new Padding(20);
            this.mainPanel.Size = new Size(1500, 850);
            
            // calculateButton
            this.calculateButton.BackColor = Color.FromArgb(0, 112, 201);
            this.calculateButton.FlatAppearance.BorderSize = 0;
            this.calculateButton.FlatStyle = FlatStyle.Flat;
            this.calculateButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.calculateButton.ForeColor = Color.White;
            this.calculateButton.Size = new Size(320, 60);
            this.calculateButton.Text = "📊 Рассчитать и\r\nэкспортировать в Word";
            this.calculateButton.Cursor = Cursors.Hand;
            this.calculateButton.Click += new EventHandler(this.button1_Click);

            // Создание панелей секций
            CreateUserInfoPanel();
            CreateBoilerParamsPanel();
            CreateFuelPanel();
            CreateFurnacePanel();
            CreateAshPanel();

            // Добавление кнопки расчёта
            this.mainPanel.Controls.Add(new Panel { Height = 20 });
            Panel buttonPanel = new Panel();
            buttonPanel.Size = new Size(380, 80);
            buttonPanel.BackColor = Color.Transparent;
            buttonPanel.Tag = "button";
            buttonPanel.Controls.Add(this.calculateButton);
            this.mainPanel.Controls.Add(buttonPanel);
            
            // Добавление кнопки темы вниз
            this.mainPanel.Controls.Add(new Panel { Height = 25 });
            Panel themePanel = new Panel();
            themePanel.Size = new Size(380, 60);
            themePanel.BackColor = Color.Transparent;
            themePanel.Controls.Add(this.themeToggleButton);
            this.mainPanel.Controls.Add(themePanel);
            
            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.ClientSize = new Size(1650, 950);
            this.MinimumSize = new Size(1200, 800);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Тепловой расчёт котлоагрегата";
            
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private void CreateUserInfoPanel()
        {
            this.userInfoPanel.Size = new Size(380, 360);
            this.userInfoPanel.BackColor = Color.White;
            this.userInfoPanel.Padding = new Padding(18);
            this.userInfoPanel.Margin = new Padding(10);
            
            int y = 12;
            int labelWidth = 140;
            int inputWidth = 190;
            int rowHeight = 36;
            
            // lblUserInfo
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblUserInfo.ForeColor = Color.FromArgb(25, 25, 25);
            this.lblUserInfo.Location = new Point(18, 12);
            this.lblUserInfo.Text = "👤 Информация о студенте";
            
            y = 48;
            
            // FIO
            CreateLabel(this.userInfoPanel, "Ф.И.О.:", 18, y, labelWidth);
            this.FIO.Location = new Point(18 + labelWidth, y);
            this.FIO.Size = new Size(inputWidth, 28);
            this.FIO.Font = new Font("Segoe UI", 9.5F);
            this.FIO.Text = "Тельнов К.А.";
            this.userInfoPanel.Controls.Add(this.FIO);
            y += rowHeight;
            
            // BoilerName
            CreateLabel(this.userInfoPanel, "Котельный агрегат:", 18, y, labelWidth);
            this.BoilerName.Location = new Point(18 + labelWidth, y);
            this.BoilerName.Size = new Size(inputWidth, 28);
            this.BoilerName.Font = new Font("Segoe UI", 9.5F);
            this.BoilerName.Text = "БКЗ-75-39ФБ";
            this.userInfoPanel.Controls.Add(this.BoilerName);
            y += rowHeight;
            
            // FuelBrend
            CreateLabel(this.userInfoPanel, "Топливо:", 18, y, labelWidth);
            this.FuelBrend.Location = new Point(18 + labelWidth, y);
            this.FuelBrend.Size = new Size(inputWidth, 28);
            this.FuelBrend.Font = new Font("Segoe UI", 9.5F);
            this.FuelBrend.Text = "Азейское месторождение";
            this.userInfoPanel.Controls.Add(this.FuelBrend);
            y += rowHeight + 5;
            
            // lblCoalSelect
            this.lblCoalSelect.AutoSize = true;
            this.lblCoalSelect.Font = new Font("Segoe UI", 9.5F);
            this.lblCoalSelect.ForeColor = Color.FromArgb(50, 50, 50);
            this.lblCoalSelect.Location = new Point(18, y);
            this.lblCoalSelect.Text = "🪨 Выберите месторождение угля:";
            this.userInfoPanel.Controls.Add(this.lblCoalSelect);
            
            y += 22;
            
            // CoalSelectComboBox
            this.CoalSelectComboBox.Location = new Point(18, y);
            this.CoalSelectComboBox.Size = new Size(344, 28);
            this.CoalSelectComboBox.Font = new Font("Segoe UI", 9.5F);
            this.CoalSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.userInfoPanel.Controls.Add(this.CoalSelectComboBox);
            y += 32;
            
            // CustomCoalCheckBox
            this.CustomCoalCheckBox.AutoSize = true;
            this.CustomCoalCheckBox.Font = new Font("Segoe UI", 9.5F);
            this.CustomCoalCheckBox.Location = new Point(18, y);
            this.CustomCoalCheckBox.Text = "✏️ Ручной ввод угля";
            this.userInfoPanel.Controls.Add(this.CustomCoalCheckBox);
            
            this.userInfoPanel.Controls.Add(this.lblUserInfo);
            this.mainPanel.Controls.Add(this.userInfoPanel);
        }
        
        private void CreateBoilerParamsPanel()
        {
            this.boilerParamsPanel.Size = new Size(380, 420);
            this.boilerParamsPanel.BackColor = Color.White;
            this.boilerParamsPanel.Padding = new Padding(18);
            this.boilerParamsPanel.Margin = new Padding(10);
            
            int y = 12;
            int labelWidth = 185;
            int inputWidth = 145;
            int rowHeight = 34;
            
            // lblBoilerParams
            this.lblBoilerParams.AutoSize = true;
            this.lblBoilerParams.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblBoilerParams.ForeColor = Color.FromArgb(25, 25, 25);
            this.lblBoilerParams.Location = new Point(18, 12);
            this.lblBoilerParams.Text = "🏭 Параметры котла";
            
            y = 48;
            
            // lblBoilerSelect
            this.lblBoilerSelect.AutoSize = true;
            this.lblBoilerSelect.Font = new Font("Segoe UI", 9.5F);
            this.lblBoilerSelect.ForeColor = Color.FromArgb(50, 50, 50);
            this.lblBoilerSelect.Location = new Point(18, y);
            this.lblBoilerSelect.Text = "🔧 Выберите модель котла:";
            this.boilerParamsPanel.Controls.Add(this.lblBoilerSelect);
            
            y += 22;
            
            // BoilerSelectComboBox
            this.BoilerSelectComboBox.Location = new Point(18, y);
            this.BoilerSelectComboBox.Size = new Size(344, 28);
            this.BoilerSelectComboBox.Font = new Font("Segoe UI", 9.5F);
            this.BoilerSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.boilerParamsPanel.Controls.Add(this.BoilerSelectComboBox);
            y += 35;
            
            // QBoiler
            CreateLabel(this.boilerParamsPanel, "Паропроизв. (т/ч):", 18, y, labelWidth);
            this.QBoiler.Location = new Point(18 + labelWidth, y);
            this.QBoiler.Size = new Size(inputWidth, 28);
            this.QBoiler.Font = new Font("Segoe UI", 9.5F);
            this.QBoiler.Text = "75";
            this.QBoiler.KeyPress += textBox1_KeyPress;
            this.boilerParamsPanel.Controls.Add(this.QBoiler);
            y += rowHeight;
            
            // PBaraban
            CreateLabel(this.boilerParamsPanel, "Давление в бараб.:", 18, y, labelWidth);
            this.PBaraban.Location = new Point(18 + labelWidth, y);
            this.PBaraban.Size = new Size(inputWidth, 28);
            this.PBaraban.Font = new Font("Segoe UI", 9.5F);
            this.PBaraban.Text = "44";
            this.PBaraban.KeyPress += textBox1_KeyPress;
            this.boilerParamsPanel.Controls.Add(this.PBaraban);
            y += rowHeight;
            
            // PPar
            CreateLabel(this.boilerParamsPanel, "Давление пара:", 18, y, labelWidth);
            this.PPar.Location = new Point(18 + labelWidth, y);
            this.PPar.Size = new Size(inputWidth, 28);
            this.PPar.Font = new Font("Segoe UI", 9.5F);
            this.PPar.Text = "39";
            this.PPar.KeyPress += textBox1_KeyPress;
            this.boilerParamsPanel.Controls.Add(this.PPar);
            y += rowHeight;
            
            // TPar
            CreateLabel(this.boilerParamsPanel, "Температура пара:", 18, y, labelWidth);
            this.TPar.Location = new Point(18 + labelWidth, y);
            this.TPar.Size = new Size(inputWidth, 28);
            this.TPar.Font = new Font("Segoe UI", 9.5F);
            this.TPar.Text = "450";
            this.TPar.KeyPress += textBox1_KeyPress;
            this.boilerParamsPanel.Controls.Add(this.TPar);
            y += rowHeight;
            
            // TPitV
            CreateLabel(this.boilerParamsPanel, "Температура пит.в.:", 18, y, labelWidth);
            this.TPitV.Location = new Point(18 + labelWidth, y);
            this.TPitV.Size = new Size(inputWidth, 28);
            this.TPitV.Font = new Font("Segoe UI", 9.5F);
            this.TPitV.Text = "104";
            this.TPitV.KeyPress += textBox1_KeyPress;
            this.boilerParamsPanel.Controls.Add(this.TPitV);
            y += rowHeight;
            
            // VTop
            CreateLabel(this.boilerParamsPanel, "Объём топки (м³):", 18, y, labelWidth);
            this.VTop.Location = new Point(18 + labelWidth, y);
            this.VTop.Size = new Size(inputWidth, 28);
            this.VTop.Font = new Font("Segoe UI", 9.5F);
            this.VTop.Text = "290";
            this.VTop.KeyPress += textBox1_KeyPress;
            this.boilerParamsPanel.Controls.Add(this.VTop);
            y += rowHeight + 5;
            
            // IPerPar (авто)
            CreateLabel(this.boilerParamsPanel, "📊 Энтальпия пара:", 18, y, labelWidth);
            this.IPerPar.Location = new Point(18 + labelWidth, y);
            this.IPerPar.Size = new Size(inputWidth, 28);
            this.IPerPar.Font = new Font("Segoe UI", 9.5F);
            this.IPerPar.ReadOnly = true;
            this.IPerPar.BackColor = Color.FromArgb(235, 235, 235);
            this.IPerPar.Text = "3244";
            this.boilerParamsPanel.Controls.Add(this.IPerPar);
            y += rowHeight;
            
            // IPitV (авто)
            CreateLabel(this.boilerParamsPanel, "📊 Энтальпия пит.в.:", 18, y, labelWidth);
            this.IPitV.Location = new Point(18 + labelWidth, y);
            this.IPitV.Size = new Size(inputWidth, 28);
            this.IPitV.Font = new Font("Segoe UI", 9.5F);
            this.IPitV.ReadOnly = true;
            this.IPitV.BackColor = Color.FromArgb(235, 235, 235);
            this.IPitV.Text = "436";
            this.boilerParamsPanel.Controls.Add(this.IPitV);
            
            this.boilerParamsPanel.Controls.Add(this.lblBoilerParams);
            this.mainPanel.Controls.Add(this.boilerParamsPanel);
        }
        
        private void CreateFuelPanel()
        {
            this.fuelPanel.Size = new Size(380, 360);
            this.fuelPanel.BackColor = Color.White;
            this.fuelPanel.Padding = new Padding(18);
            this.fuelPanel.Margin = new Padding(10);
            
            int y = 12;
            int col1X = 18, col2X = 195;
            int labelWidth = 35;
            int inputWidth = 145;
            int rowHeight = 34;
            
            // lblFuel
            this.lblFuel.AutoSize = true;
            this.lblFuel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblFuel.ForeColor = Color.FromArgb(25, 25, 25);
            this.lblFuel.Location = new Point(18, 12);
            this.lblFuel.Text = "⚗️ Состав топлива";
            
            y = 48;
            
            // Row 1: W, A
            CreateLabel(this.fuelPanel, "W⁠P:", col1X, y, labelWidth);
            this.WР.Location = new Point(col1X + labelWidth, y);
            this.WР.Size = new Size(inputWidth, 28);
            this.WР.Font = new Font("Segoe UI", 9.5F);
            this.WР.Text = "25.8";
            this.WР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.WР);
            
            CreateLabel(this.fuelPanel, "A⁠P:", col2X, y, labelWidth);
            this.АР.Location = new Point(col2X + labelWidth, y);
            this.АР.Size = new Size(inputWidth, 28);
            this.АР.Font = new Font("Segoe UI", 9.5F);
            this.АР.Text = "16.3";
            this.АР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.АР);
            y += rowHeight;
            
            // Row 2: C, H
            CreateLabel(this.fuelPanel, "C⁠P:", col1X, y, labelWidth);
            this.СР.Location = new Point(col1X + labelWidth, y);
            this.СР.Size = new Size(inputWidth, 28);
            this.СР.Font = new Font("Segoe UI", 9.5F);
            this.СР.Text = "42.7";
            this.СР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.СР);
            
            CreateLabel(this.fuelPanel, "H⁠P:", col2X, y, labelWidth);
            this.НР.Location = new Point(col2X + labelWidth, y);
            this.НР.Size = new Size(inputWidth, 28);
            this.НР.Font = new Font("Segoe UI", 9.5F);
            this.НР.Text = "3.2";
            this.НР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.НР);
            y += rowHeight;
            
            // Row 3: N, O
            CreateLabel(this.fuelPanel, "N⁠P:", col1X, y, labelWidth);
            this.NР.Location = new Point(col1X + labelWidth, y);
            this.NР.Size = new Size(inputWidth, 28);
            this.NР.Font = new Font("Segoe UI", 9.5F);
            this.NР.Text = "0.9";
            this.NР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.NР);
            
            CreateLabel(this.fuelPanel, "O⁠P:", col2X, y, labelWidth);
            this.ОР.Location = new Point(col2X + labelWidth, y);
            this.ОР.Size = new Size(inputWidth, 28);
            this.ОР.Font = new Font("Segoe UI", 9.5F);
            this.ОР.Text = "10.7";
            this.ОР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.ОР);
            y += rowHeight;
            
            // Row 4: S, Marka
            CreateLabel(this.fuelPanel, "S⁠P:", col1X, y, labelWidth);
            this.SР.Location = new Point(col1X + labelWidth, y);
            this.SР.Size = new Size(inputWidth, 28);
            this.SР.Font = new Font("Segoe UI", 9.5F);
            this.SР.Text = "0.3";
            this.SР.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.SР);
            
            CreateLabel(this.fuelPanel, "Марка:", col2X, y, labelWidth);
            this.Marka.Location = new Point(col2X + labelWidth, y);
            this.Marka.Size = new Size(inputWidth, 28);
            this.Marka.Font = new Font("Segoe UI", 9.5F);
            this.Marka.Text = "3Б";
            this.fuelPanel.Controls.Add(this.Marka);
            y += rowHeight;
            
            // Row 5: Q MJ, Q kcal
            CreateLabel(this.fuelPanel, "Q⁠н МДж:", col1X, y, labelWidth);
            this.QРh.Location = new Point(col1X + labelWidth, y);
            this.QРh.Size = new Size(inputWidth, 28);
            this.QРh.Font = new Font("Segoe UI", 9.5F);
            this.QРh.Text = "15.67";
            this.QРh.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.QРh);
            
            CreateLabel(this.fuelPanel, "Q⁠н ккал:", col2X, y, labelWidth);
            this.KiloKal.Location = new Point(col2X + labelWidth, y);
            this.KiloKal.Size = new Size(inputWidth, 28);
            this.KiloKal.Font = new Font("Segoe UI", 9.5F);
            this.KiloKal.Text = "3742";
            this.KiloKal.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.KiloKal);
            y += rowHeight;
            
            // Row 6: Q kJ
            CreateLabel(this.fuelPanel, "Q⁠н кДж:", col1X, y, labelWidth);
            this.KiloDJ.Location = new Point(col1X + labelWidth, y);
            this.KiloDJ.Size = new Size(inputWidth, 28);
            this.KiloDJ.Font = new Font("Segoe UI", 9.5F);
            this.KiloDJ.Text = "15670";
            this.KiloDJ.KeyPress += textBox1_KeyPress;
            this.fuelPanel.Controls.Add(this.KiloDJ);
            
            this.fuelPanel.Controls.Add(this.lblFuel);
            this.mainPanel.Controls.Add(this.fuelPanel);
        }
        
        private void CreateFurnacePanel()
        {
            this.furnacePanel.Size = new Size(380, 380);
            this.furnacePanel.BackColor = Color.White;
            this.furnacePanel.Padding = new Padding(18);
            this.furnacePanel.Margin = new Padding(10);
            
            int y = 12;
            int labelWidth = 185;
            int inputWidth = 145;
            int rowHeight = 32;
            
            // lblFurnace
            this.lblFurnace.AutoSize = true;
            this.lblFurnace.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblFurnace.ForeColor = Color.FromArgb(25, 25, 25);
            this.lblFurnace.Location = new Point(18, 12);
            this.lblFurnace.Text = "🔥 Параметры топки";
            
            y = 48;
            
            // aT
            CreateLabel(this.furnacePanel, "αт (избыток воздуха):", 18, y, labelWidth);
            this.aT.Location = new Point(18 + labelWidth, y);
            this.aT.Size = new Size(inputWidth, 26);
            this.aT.Font = new Font("Segoe UI", 9.5F);
            this.aT.Text = "1.2";
            this.aT.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.aT);
            y += rowHeight;
            
            // q3
            CreateLabel(this.furnacePanel, "q3 (хим. недожог):", 18, y, labelWidth);
            this.q3.Location = new Point(18 + labelWidth, y);
            this.q3.Size = new Size(inputWidth, 26);
            this.q3.Font = new Font("Segoe UI", 9.5F);
            this.q3.Text = "0";
            this.q3.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.q3);
            y += rowHeight;
            
            // q4
            CreateLabel(this.furnacePanel, "q4 (мех. недожог):", 18, y, labelWidth);
            this.q4.Location = new Point(18 + labelWidth, y);
            this.q4.Size = new Size(inputWidth, 26);
            this.q4.Font = new Font("Segoe UI", 9.5F);
            this.q4.Text = "0.5";
            this.q4.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.q4);
            y += rowHeight;
            
            // aYN
            CreateLabel(this.furnacePanel, "αун (доля уноса):", 18, y, labelWidth);
            this.aYN.Location = new Point(18 + labelWidth, y);
            this.aYN.Size = new Size(inputWidth, 26);
            this.aYN.Font = new Font("Segoe UI", 9.5F);
            this.aYN.Text = "0.95";
            this.aYN.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.aYN);
            y += rowHeight + 5;
            
            // DaPP
            CreateLabel(this.furnacePanel, "Δαпп (пароперегр.):", 18, y, labelWidth);
            this.DaPP.Location = new Point(18 + labelWidth, y);
            this.DaPP.Size = new Size(inputWidth, 26);
            this.DaPP.Font = new Font("Segoe UI", 9.5F);
            this.DaPP.Text = "0.03";
            this.DaPP.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.DaPP);
            y += rowHeight;
            
            // DaVE
            CreateLabel(this.furnacePanel, "Δαвэ (экономайз.):", 18, y, labelWidth);
            this.DaVE.Location = new Point(18 + labelWidth, y);
            this.DaVE.Size = new Size(inputWidth, 26);
            this.DaVE.Font = new Font("Segoe UI", 9.5F);
            this.DaVE.Text = "0.02";
            this.DaVE.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.DaVE);
            y += rowHeight;
            
            // DaVP
            CreateLabel(this.furnacePanel, "Δαвп (воздухопод.):", 18, y, labelWidth);
            this.DaVP.Location = new Point(18 + labelWidth, y);
            this.DaVP.Size = new Size(inputWidth, 26);
            this.DaVP.Font = new Font("Segoe UI", 9.5F);
            this.DaVP.Text = "0.06";
            this.DaVP.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.DaVP);
            y += rowHeight;
            
            // TempUG
            CreateLabel(this.furnacePanel, "T уходящих газов:", 18, y, labelWidth);
            this.TempUG.Location = new Point(18 + labelWidth, y);
            this.TempUG.Size = new Size(inputWidth, 26);
            this.TempUG.Font = new Font("Segoe UI", 9.5F);
            this.TempUG.Text = "125";
            this.TempUG.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.TempUG);
            y += rowHeight;
            
            // TempHolV
            CreateLabel(this.furnacePanel, "T холодного возд.:", 18, y, labelWidth);
            this.TempHolV.Location = new Point(18 + labelWidth, y);
            this.TempHolV.Size = new Size(inputWidth, 26);
            this.TempHolV.Font = new Font("Segoe UI", 9.5F);
            this.TempHolV.Text = "50";
            this.TempHolV.KeyPress += textBox1_KeyPress;
            this.furnacePanel.Controls.Add(this.TempHolV);
            
            this.furnacePanel.Controls.Add(this.lblFurnace);
            this.mainPanel.Controls.Add(this.furnacePanel);
        }
        
        private void CreateAshPanel()
        {
            this.ashPanel.Size = new Size(380, 380);
            this.ashPanel.BackColor = Color.White;
            this.ashPanel.Padding = new Padding(18);
            this.ashPanel.Margin = new Padding(10);
            
            int y = 12;
            int col1X = 18, col2X = 195;
            int labelWidth = 45;
            int inputWidth = 140;
            int rowHeight = 34;
            
            // lblAsh
            this.lblAsh.AutoSize = true;
            this.lblAsh.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblAsh.ForeColor = Color.FromArgb(25, 25, 25);
            this.lblAsh.Location = new Point(18, 12);
            this.lblAsh.Text = "🧪 Химсостав золы";
            
            y = 48;
            
            // CustomAshCheckBox
            this.CustomAshCheckBox.AutoSize = true;
            this.CustomAshCheckBox.Font = new Font("Segoe UI", 9.5F);
            this.CustomAshCheckBox.Location = new Point(18, y);
            this.CustomAshCheckBox.Text = "✏️ Ручной ввод состава";
            this.CustomAshCheckBox.CheckedChanged += CustomAshCheckBox_CheckedChanged;
            this.ashPanel.Controls.Add(this.CustomAshCheckBox);
            y += 30;
            
            // SiO2
            CreateLabel(this.ashPanel, "SiO₂:", col1X, y, labelWidth);
            this.SiO2.Location = new Point(col1X + labelWidth, y);
            this.SiO2.Size = new Size(inputWidth, 28);
            this.SiO2.Font = new Font("Segoe UI", 9.5F);
            this.SiO2.Text = "51.8";
            this.SiO2.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.SiO2);
            
            // Al2O3
            CreateLabel(this.ashPanel, "Al₂O₃:", col2X, y, labelWidth);
            this.Al2O3.Location = new Point(col2X + labelWidth, y);
            this.Al2O3.Size = new Size(inputWidth, 28);
            this.Al2O3.Font = new Font("Segoe UI", 9.5F);
            this.Al2O3.Text = "27.8";
            this.Al2O3.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.Al2O3);
            y += rowHeight;
            
            // TiO2
            CreateLabel(this.ashPanel, "TiO₂:", col1X, y, labelWidth);
            this.TiO2.Location = new Point(col1X + labelWidth, y);
            this.TiO2.Size = new Size(inputWidth, 28);
            this.TiO2.Font = new Font("Segoe UI", 9.5F);
            this.TiO2.Text = "0.7";
            this.TiO2.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.TiO2);
            
            // Fe2O3
            CreateLabel(this.ashPanel, "Fe₂O₃:", col2X, y, labelWidth);
            this.Fe2O3.Location = new Point(col2X + labelWidth, y);
            this.Fe2O3.Size = new Size(inputWidth, 28);
            this.Fe2O3.Font = new Font("Segoe UI", 9.5F);
            this.Fe2O3.Text = "11.9";
            this.Fe2O3.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.Fe2O3);
            y += rowHeight;
            
            // CaO
            CreateLabel(this.ashPanel, "CaO:", col1X, y, labelWidth);
            this.CaO.Location = new Point(col1X + labelWidth, y);
            this.CaO.Size = new Size(inputWidth, 28);
            this.CaO.Font = new Font("Segoe UI", 9.5F);
            this.CaO.Text = "5.3";
            this.CaO.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.CaO);
            
            // MgO
            CreateLabel(this.ashPanel, "MgO:", col2X, y, labelWidth);
            this.MgO.Location = new Point(col2X + labelWidth, y);
            this.MgO.Size = new Size(inputWidth, 28);
            this.MgO.Font = new Font("Segoe UI", 9.5F);
            this.MgO.Text = "1.1";
            this.MgO.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.MgO);
            y += rowHeight;
            
            // K2O
            CreateLabel(this.ashPanel, "K₂O:", col1X, y, labelWidth);
            this.K2O.Location = new Point(col1X + labelWidth, y);
            this.K2O.Size = new Size(inputWidth, 28);
            this.K2O.Font = new Font("Segoe UI", 9.5F);
            this.K2O.Text = "0.9";
            this.K2O.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.K2O);
            
            // Na2O
            CreateLabel(this.ashPanel, "Na₂O:", col2X, y, labelWidth);
            this.Na2O.Location = new Point(col2X + labelWidth, y);
            this.Na2O.Size = new Size(inputWidth, 28);
            this.Na2O.Font = new Font("Segoe UI", 9.5F);
            this.Na2O.Text = "0.5";
            this.Na2O.KeyPress += textBox1_KeyPress;
            this.ashPanel.Controls.Add(this.Na2O);
            
            this.ashPanel.Controls.Add(this.lblAsh);
            this.mainPanel.Controls.Add(this.ashPanel);
        }
        
        private void CreateLabel(Control parent, string text, int x, int y, int width)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(x, y + 7);
            lbl.Size = new Size(width, 20);
            lbl.Font = new Font("Segoe UI", 9.5F);
            lbl.ForeColor = Color.FromArgb(50, 50, 50);
            parent.Controls.Add(lbl);
        }
        
        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private FlowLayoutPanel mainPanel;
        
        private Panel userInfoPanel;
        private Panel boilerParamsPanel;
        private Panel fuelPanel;
        private Panel ashPanel;
        private Panel furnacePanel;
        
        private Label lblUserInfo;
        private Label lblBoilerParams;
        private Label lblFuel;
        private Label lblAsh;
        private Label lblFurnace;
        
        private ComboBox CoalSelectComboBox;
        private ComboBox BoilerSelectComboBox;
        private CheckBox CustomCoalCheckBox;
        private CheckBox CustomAshCheckBox;
        private Button calculateButton;
        
        private TextBox FIO;
        private TextBox BoilerName;
        private TextBox FuelBrend;
        private TextBox Marka;
        
        private TextBox QBoiler;
        private TextBox PBaraban;
        private TextBox PPar;
        private TextBox TPar;
        private TextBox TPitV;
        private TextBox VTop;
        private TextBox IPerPar;
        private TextBox IPitV;
        
        private TextBox WР;
        private TextBox АР;
        private TextBox SР;
        private TextBox СР;
        private TextBox НР;
        private TextBox NР;
        private TextBox ОР;
        private TextBox QРh;
        private TextBox KiloDJ;
        private TextBox KiloKal;
        
        private TextBox aT;
        private TextBox q3;
        private TextBox q4;
        private TextBox aYN;
        private TextBox DaPP;
        private TextBox DaVE;
        private TextBox DaVP;
        private TextBox DaT;
        private TextBox DaPL;
        
        private TextBox SiO2;
        private TextBox Al2O3;
        private TextBox TiO2;
        private TextBox Fe2O3;
        private TextBox CaO;
        private TextBox MgO;
        private TextBox K2O;
        private TextBox Na2O;
        
        private TextBox TempUG;
        private TextBox TempHolV;
        
        private Label lblCoalSelect;
        private Label lblBoilerSelect;
        private Button themeToggleButton;
    }
}
