namespace BoilerCalc
{
    /// <summary>
    /// Главная форма приложения BoilerCalc - расчет тепловых параметров котельных установок
    /// </summary>
    public partial class Form1 : Form
    {
        private bool _isDarkMode = false;
        
        /// <summary>
        /// База данных химического состава золы для разных месторождений углей
        /// </summary>
        private readonly Dictionary<int, AshComposition> _ashDatabase = new Dictionary<int, AshComposition>
        {
            { 1, new AshComposition { SiO2 = 55.2, Al2O3 = 25.8, TiO2 = 1.1, Fe2O3 = 8.5, CaO = 3.2, MgO = 1.5, K2O = 1.8, Na2O = 2.9 } }, // Донецкий Д
            { 2, new AshComposition { SiO2 = 56.8, Al2O3 = 26.2, TiO2 = 1.2, Fe2O3 = 7.8, CaO = 2.8, MgO = 1.3, K2O = 1.6, Na2O = 2.3 } }, // Донецкий Г
            { 3, new AshComposition { SiO2 = 58.5, Al2O3 = 27.1, TiO2 = 1.3, Fe2O3 = 6.5, CaO = 2.5, MgO = 1.2, K2O = 1.4, Na2O = 1.5 } }, // Донецкий Ж
            { 4, new AshComposition { SiO2 = 52.5, Al2O3 = 28.5, TiO2 = 0.9, Fe2O3 = 9.2, CaO = 3.8, MgO = 1.8, K2O = 1.2, Na2O = 2.1 } }, // Кузнецкий Д
            { 5, new AshComposition { SiO2 = 53.8, Al2O3 = 29.2, TiO2 = 1.0, Fe2O3 = 8.5, CaO = 3.5, MgO = 1.6, K2O = 1.1, Na2O = 1.3 } }, // Кузнецкий Г
            { 6, new AshComposition { SiO2 = 58.2, Al2O3 = 26.5, TiO2 = 1.1, Fe2O3 = 7.2, CaO = 2.8, MgO = 1.4, K2O = 1.3, Na2O = 1.5 } }, // Кузнецкий 2СС
            { 7, new AshComposition { SiO2 = 54.5, Al2O3 = 30.2, TiO2 = 1.2, Fe2O3 = 7.5, CaO = 2.5, MgO = 1.3, K2O = 1.2, Na2O = 1.6 } }, // Карагандинский
            { 8, new AshComposition { SiO2 = 52.8, Al2O3 = 28.5, TiO2 = 1.0, Fe2O3 = 9.8, CaO = 3.2, MgO = 1.5, K2O = 1.4, Na2O = 1.8 } }, // Экибастузский
            { 9, new AshComposition { SiO2 = 48.5, Al2O3 = 22.5, TiO2 = 0.8, Fe2O3 = 12.5, CaO = 8.5, MgO = 2.8, K2O = 1.8, Na2O = 2.6 } }, // Подмосковный
            { 25, new AshComposition { SiO2 = 51.8, Al2O3 = 27.8, TiO2 = 0.7, Fe2O3 = 11.9, CaO = 5.3, MgO = 1.1, K2O = 0.9, Na2O = 0.5 } }, // Азейское (Азейский разрез)
            { 26, new AshComposition { SiO2 = 52.5, Al2O3 = 28.2, TiO2 = 0.8, Fe2O3 = 11.2, CaO = 4.8, MgO = 1.0, K2O = 0.8, Na2O = 0.7 } }, // Азейское (Тулунский разрез)
        };

        public Form1()
        {
            InitializeComponent();
            InitializeCoalComboBox();
            InitializeBoilerComboBox();
            ApplyTheme();
        }

        private void InitializeCoalComboBox()
        {
            CoalSelectComboBox.DataSource = CoalDatabase.Coals;
            CoalSelectComboBox.DisplayMember = "Basin";
            CoalSelectComboBox.ValueMember = "Id";
            CoalSelectComboBox.SelectedIndex = 24; // Азейское по умолчанию
            CoalSelectComboBox.SelectedIndexChanged += CoalSelectComboBox_SelectedIndexChanged;
            CustomCoalCheckBox.CheckedChanged += CustomCoalCheckBox_CheckedChanged;
            
            // Заполняем поля при загрузке
            CoalSelectComboBox_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void InitializeBoilerComboBox()
        {
            BoilerSelectComboBox.DataSource = BoilerDatabase.Boilers;
            BoilerSelectComboBox.DisplayMember = "Model";
            BoilerSelectComboBox.ValueMember = "Model";
            BoilerSelectComboBox.SelectedIndex = 8; // БКЗ-75-39ФБ по умолчанию
            BoilerSelectComboBox.SelectedIndexChanged += BoilerSelectComboBox_SelectedIndexChanged;
            
            // Заполняем поля при загрузке
            BoilerSelectComboBox_SelectedIndexChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// При выборе угля из базы - заполняем поля автоматически
        /// </summary>
        private void CoalSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomCoalCheckBox.Checked)
                return;

            if (CoalSelectComboBox.SelectedItem is Coal selectedCoal)
            {
                try
                {
                    // Обновляем название топлива
                    FuelBrend.Text = selectedCoal.Basin;
                    
                    // Заполняем поля состава топлива
                    WР.Text = selectedCoal.Wp.ToString("F1");
                    АР.Text = selectedCoal.Ap.ToString("F1");
                    СР.Text = selectedCoal.Cp.ToString("F1");
                    НР.Text = selectedCoal.Hp.ToString("F1");
                    NР.Text = selectedCoal.Np.ToString("F1");
                    ОР.Text = selectedCoal.Op.ToString("F1");
                    
                    // S^p = S^p_колч + S^p_орг
                    double spTotal = selectedCoal.SpTotal;
                    SР.Text = spTotal.ToString("F1");
                    
                    // Теплота сгорания
                    QРh.Text = selectedCoal.Qpn.ToString("F2");
                    KiloDJ.Text = (selectedCoal.Qpn * 1000).ToString("F0");
                    KiloKal.Text = (selectedCoal.Qpn * 238.846).ToString("F0");
                    
                    // Марка угля
                    Marka.Text = selectedCoal.Mark;
                    
                    // Автоматический расчёт химсостава золы
                    CalculateAshComposition(selectedCoal.Id);
                    
                    // Сохраняем в Global
                    Global.SetCoalFromDatabase(selectedCoal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных угля: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Расчёт химсостава золы на основе месторождения
        /// </summary>
        private void CalculateAshComposition(int coalId)
        {
            if (CustomAshCheckBox.Checked)
                return;
            
            try
            {
                if (_ashDatabase.TryGetValue(coalId, out AshComposition ash))
                {
                    SiO2.Text = ash.SiO2.ToString("F1");
                    Al2O3.Text = ash.Al2O3.ToString("F1");
                    TiO2.Text = ash.TiO2.ToString("F1");
                    Fe2O3.Text = ash.Fe2O3.ToString("F1");
                    CaO.Text = ash.CaO.ToString("F1");
                    MgO.Text = ash.MgO.ToString("F1");
                    K2O.Text = ash.K2O.ToString("F1");
                    Na2O.Text = ash.Na2O.ToString("F1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке состава золы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// При выборе котла - заполняем параметры автоматически
        /// </summary>
        private void BoilerSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BoilerSelectComboBox.SelectedItem is Boiler selectedBoiler)
            {
                try
                {
                    // Обновляем название котельного агрегата
                    BoilerName.Text = selectedBoiler.Model;
                    
                    // Основные параметры котла
                    QBoiler.Text = selectedBoiler.SteamCapacity.ToString("F0");
                    PBaraban.Text = selectedBoiler.DrumPressure.ToString("F0");
                    PPar.Text = selectedBoiler.SuperheatPressure.ToString("F0");
                    TPar.Text = selectedBoiler.SuperheatTemp.ToString("F0");
                    TPitV.Text = selectedBoiler.FeedWaterTemp.ToString("F0");
                    VTop.Text = selectedBoiler.FurnaceVolume.ToString("F0");
                    
                    // Автоматический расчёт энтальпий
                    CalculateAndSetEnthalpies(selectedBoiler.SuperheatPressureMPa, selectedBoiler.SuperheatTemp, selectedBoiler.FeedWaterTemp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке параметров котла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Расчёт и установка энтальпий
        /// </summary>
        private void CalculateAndSetEnthalpies(double pressureMPa, double tempC, double feedWaterTemp)
        {
            try
            {
                // Validate pressure range (0.01 to 22 MPa for steam tables)
                if (pressureMPa < 0.01) pressureMPa = 0.01;
                if (pressureMPa > 22.0) pressureMPa = 22.0;
                
                // Validate temperature range
                if (tempC < 0) tempC = 0;
                if (tempC > 600) tempC = 600;
                
                // Энтальпия перегретого пара
                double iPerPar = Calculations.CalculateSuperheatEnthalpy(pressureMPa, tempC);
                IPerPar.Text = iPerPar.ToString("F0");
                
                // Validate feed water temperature
                if (feedWaterTemp < 0) feedWaterTemp = 0;
                if (feedWaterTemp > 370) feedWaterTemp = 370;
                
                // Энтальпия питательной воды
                double iPitV = Calculations.CalculateFeedWaterEnthalpy(feedWaterTemp);
                IPitV.Text = iPitV.ToString("F0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте энтальпий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                IPerPar.Text = "0";
                IPitV.Text = "0";
            }
        }

        /// <summary>
        /// При включении ручного ввода угля
        /// </summary>
        private void CustomCoalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomCoalCheckBox.Checked)
            {
                SetCoalFieldsEnabled(true);
                CoalSelectComboBox.Enabled = false;
            }
            else
            {
                SetCoalFieldsEnabled(false);
                CoalSelectComboBox.Enabled = true;
                if (CoalSelectComboBox.SelectedItem is Coal coal)
                {
                    CoalSelectComboBox_SelectedIndexChanged(sender, e);
                }
            }
        }

        /// <summary>
        /// При включении ручного ввода золы
        /// </summary>
        private void CustomAshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetAshFieldsEnabled(CustomAshCheckBox.Checked);
        }

        /// <summary>
        /// Включение/выключение полей ввода состава топлива
        /// </summary>
        private void SetCoalFieldsEnabled(bool enabled)
        {
            var coalFields = new[] { WР, АР, SР, СР, НР, NР, ОР, QРh, Marka };
            foreach (var field in coalFields)
                field.ReadOnly = !enabled;
        }

        /// <summary>
        /// Включение/выключение полей ввода состава золы
        /// </summary>
        private void SetAshFieldsEnabled(bool enabled)
        {
            var ashFields = new[] { SiO2, Al2O3, TiO2, Fe2O3, CaO, MgO, K2O, Na2O };
            foreach (var field in ashFields)
                field.ReadOnly = !enabled;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Рассчитать и экспортировать в Word"
        /// Выполняет полный цикл расчетов теплового баланса котельной установки
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Читаем все входные данные с формы
                if (!ReadInputsFromForm())
                    return;

                // Если ручной ввод угля - сохраняем параметры
                if (CustomCoalCheckBox.Checked)
                {
                    Global.SetCustomCoal(
                        Global.WР, Global.АР, 0, Global.SР,
                        Global.СР, Global.НР, Global.NР, Global.ОР, Global.QРh,
                        Global.Marka
                    );
                }

                // Автоматический расчёт энтальпий из таблиц
                CalculateAndSetEnthalpiesFromInputs();

                Global.SetMassTegResults();

                // ===== ОСНОВНЫЕ РАСЧЕТЫ =====
                
                // 1. Расчет теоретических объемов воздуха и продуктов сгорания
                var (terOB, terORO2, terON2, terOH2O, terOr) = Calculations.CalculateAirParameters(
                    Global.СР, Global.SР, Global.НР, Global.ОР, Global.WР, Global.АР, Global.NР, Global.QРh);

                Global.SetCalculationResults(terOB, terORO2, terON2, terOH2O, terOr);

                // 2. Таблица 5 (9×7) - параметры газов через 7 проходов котла
                var (tabl5, Nan0) = Calculations.Tablica5(
                    Global.aT, Global.DaPP, Global.DaVE, Global.DaVP, 
                    Global.TerOH2O, Global.TerOB, Global.TerOr, Global.TerORO2, 
                    Global.АР, Global.aYN);

                Global.SetCalSetCalculationTablica5(tabl5);

                // 3. Таблица 6 (12×20) - энтальпии газов в зависимости от температуры
                var (sT1, Nan1) = Calculations.Tablica6(
                    Global.АР, Global.TerOB, Global.aYN, 
                    Global.TerORO2, Global.TerON2, Global.TerOH2O, 
                    Global.aT, Global.Tabl5);

                Global.SetCalSetCalculationTablica6(sT1);

                // 4. Таблица 7 (23 элемента) - тепловой баланс и КПД
                var (tabl7, Nan2) = Calculations.Tablica7(
                    Global.KiloDJ, Global.KiloKal, Global.TempUG, Global.TempHolV, 
                    Global.q3, Global.q4, Global.aYN, Global.ST1, Global.АР,
                    Global.aT, new double[] { 
                        Global.aT, 
                        Global.aT + Global.DaPP/2, 
                        Global.aT + Global.DaPP, 
                        Global.aT + Global.DaPP + Global.DaVE, 
                        Global.aT + Global.DaPP + Global.DaVE + Global.DaVP,
                        Global.aT + Global.DaPP + Global.DaVE + Global.DaVP + Global.DaVE,
                        Global.aT + Global.DaPP + Global.DaVE + Global.DaVP + Global.DaVE + Global.DaVP 
                    });

                Global.SetCalSetCalculationTablica7(tabl7);

                // ===== 5. Расчёт конвективных поверхностей =====
                double Bp = tabl7[19]; // расчётный расход топлива, кг/с
                double phi = tabl7[21]; // коэффициент сохранения теплоты
                double Ixv0 = tabl7[9]; // энтальпия холодного воздуха

                // ВЗП (Таблица 8)
                var tabl8 = Calculations.Tablica8(Bp, phi, sT1,
                    Global.aT, Global.DaVP / 2, Ixv0, Global.TerOr);
                Global.SetTabl8(tabl8);

                // ВЭК (Таблица 9)
                var tabl9 = Calculations.Tablica9(Bp, phi, sT1,
                    Global.aT, Global.DaVE / 2, Ixv0);
                Global.SetTabl9(tabl9);

                // КПП (Таблица 10)
                var tabl10 = Calculations.Tablica10(Bp, phi, sT1,
                    Global.aT, Global.DaPP / 2, Ixv0);
                Global.SetTabl10(tabl10);

                // ===== 6. Создание данных для I-θ диаграммы =====
                var diagram = Calculations.CreateIThetaDiagram(sT1);
                Global.SetIThetaDiagram(diagram);

                // ===== ЭКСПОРТ РЕЗУЛЬТАТОВ =====
                
                // Сохраняем результаты в Word документ
                WordExporter.ExportToWord("Shablon.docx");
                
                MessageBox.Show("✅ Расчет успешно выполнен и экспортирован в Word!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка при выполнении расчета:\n\n{ex.Message}\n\nСтек ошибки:\n{ex.StackTrace}", 
                    "Ошибка расчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Расчёт энтальпий из текущих значений на форме
        /// </summary>
        private void CalculateAndSetEnthalpiesFromInputs()
        {
            double pParMPa = Global.PPar * 0.0980665;
            double iPerPar = Calculations.CalculateSuperheatEnthalpy(pParMPa, Global.TPar);
            Global.IPerPar = iPerPar;
            
            double iPitV = Calculations.CalculateFeedWaterEnthalpy(Global.TPitV);
            Global.IPitV = iPitV;
        }

        /// <summary>
        /// Чтение и валидация всех входных данных с формы
        /// Преобразует текстовые значения в числовые, проверяет корректность
        /// </summary>
        private bool ReadInputsFromForm()
        {
            try
            {
                // === Информация о пользователе ===
                Global.FIO = FIO.Text?.Trim() ?? "";
                Global.BoilerName = BoilerName.Text?.Trim() ?? "";
                Global.FuelBrend = FuelBrend.Text?.Trim() ?? "";
                Global.Marka = Marka.Text?.Trim() ?? "";
                
                // === Используем инвариантную культуру для парсинга (точка как разделитель) ===
                var culture = System.Globalization.CultureInfo.InvariantCulture;
                
                // === Тепловые параметры ===
                Global.KiloDJ = ParseDouble(KiloDJ.Text, culture, "Теплота сгорания (кДж/кг)");
                Global.KiloKal = ParseDouble(KiloKal.Text, culture, "Теплота сгорания (ккал/кг)");
                Global.TempUG = ParseDouble(TempUG.Text, culture, "Температура дымовых газов");
                Global.TempHolV = ParseDouble(TempHolV.Text, culture, "Температура холодной воды");
                
                // === Параметры котла ===
                Global.QBoiler = ParseDouble(QBoiler.Text, culture, "Производительность котла");
                if (Global.QBoiler <= 0)
                    throw new Exception("Производительность котла должна быть > 0");
                    
                Global.PBaraban = ParseDouble(PBaraban.Text, culture, "Давление барабана");
                if (Global.PBaraban <= 0)
                    throw new Exception("Давление барабана должно быть > 0");
                    
                Global.PPar = ParseDouble(PPar.Text, culture, "Давление пара");
                Global.TPar = ParseDouble(TPar.Text, culture, "Температура пара");
                Global.TPitV = ParseDouble(TPitV.Text, culture, "Температура питательной воды");
                Global.VTop = ParseDouble(VTop.Text, culture, "Объем топки");
                
                Global.IPerPar = ParseDouble(IPerPar.Text, culture, "Энтальпия перегретого пара");
                Global.IPitV = ParseDouble(IPitV.Text, culture, "Энтальпия питательной воды");
                
                // === Состав топлива ===
                Global.WР = ParseDouble(WР.Text, culture, "Влажность топлива");
                if (Global.WР < 0 || Global.WР > 100)
                    throw new Exception("Влажность топлива должна быть 0-100%");
                    
                Global.АР = ParseDouble(АР.Text, culture, "Зола топлива");
                if (Global.АР < 0 || Global.АР > 100)
                    throw new Exception("Содержание золы должно быть 0-100%");
                    
                Global.SР = ParseDouble(SР.Text, culture, "Сера");
                Global.СР = ParseDouble(СР.Text, culture, "Углерод");
                Global.НР = ParseDouble(НР.Text, culture, "Водород");
                Global.NР = ParseDouble(NР.Text, culture, "Азот");
                Global.ОР = ParseDouble(ОР.Text, culture, "Кислород");
                Global.QРh = ParseDouble(QРh.Text, culture, "Теплота сгорания");
                
                if (Global.QРh <= 0)
                    throw new Exception("Теплота сгорания должна быть > 0");
                
                // === Параметры горения ===
                Global.aT = ParseDouble(aT.Text, culture, "Коэффициент избытка воздуха");
                if (Global.aT < 1.0)
                    throw new Exception("Коэффициент избытка воздуха должен быть ≥ 1.0");
                    
                Global.q3 = ParseDouble(q3.Text, culture, "Потери от недожога");
                if (Global.q3 < 0 || Global.q3 > 10)
                    throw new Exception("Потери от недожога должны быть 0-10%");
                    
                Global.q4 = ParseDouble(q4.Text, culture, "Потери от механического недожога");
                if (Global.q4 < 0 || Global.q4 > 5)
                    throw new Exception("Потери от механического недожога должны быть 0-5%");
                    
                Global.aYN = ParseDouble(aYN.Text, culture, "Концентрация золы в газах");
                if (Global.aYN < 0)
                    throw new Exception("Концентрация золы должна быть >= 0");
                    
                Global.DaPP = ParseDouble(DaPP.Text, culture, "Утечка воздуха в печи");
                Global.DaVE = ParseDouble(DaVE.Text, culture, "Утечка воздуха в воздухоподогревателе");
                Global.DaVP = ParseDouble(DaVP.Text, culture, "Утечка воздуха в пароводяных экранах");
                Global.DaT = ParseDouble(DaT.Text, culture, "Утечка воздуха в трубах");
                Global.DaPL = ParseDouble(DaPL.Text, culture, "Утечка воздуха в плите");
                
                // === Состав золы (в процентах) ===
                Global.SiO2 = ParseDouble(SiO2.Text, culture, "SiO₂");
                if (Global.SiO2 < 0 || Global.SiO2 > 100)
                    throw new Exception("SiO₂ должен быть 0-100%");
                    
                Global.Al2O3 = ParseDouble(Al2O3.Text, culture, "Al₂O₃");
                Global.TiO2 = ParseDouble(TiO2.Text, culture, "TiO₂");
                Global.Fe2O3 = ParseDouble(Fe2O3.Text, culture, "Fe₂O₃");
                Global.CaO = ParseDouble(CaO.Text, culture, "CaO");
                Global.MgO = ParseDouble(MgO.Text, culture, "MgO");
                Global.K2O = ParseDouble(K2O.Text, culture, "K₂O");
                Global.Na2O = ParseDouble(Na2O.Text, culture, "Na₂O");
                
                // Проверяем сумму компонентов золы
                double ashSum = Global.SiO2 + Global.Al2O3 + Global.TiO2 + Global.Fe2O3 + 
                               Global.CaO + Global.MgO + Global.K2O + Global.Na2O;
                if (ashSum > 110 || ashSum < 90)
                {
                    if (MessageBox.Show($"⚠️ Сумма компонентов золы = {ashSum:F1}% (должна быть ~100%).\n\nПродолжить?", 
                        "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return false;
                }

                // Проверяем сумму компонентов топлива (W+A+S+C+H+N+O ≈ 100%)
                double fuelSum = Global.WР + Global.АР + Global.SР + Global.СР + Global.НР + Global.NР + Global.ОР;
                if (fuelSum > 105 || fuelSum < 95)
                {
                    if (MessageBox.Show($"⚠️ Сумма компонентов топлива = {fuelSum:F1}% (должна быть ~100%).\n\nПродолжить?", 
                        "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return false;
                }

                // Проверяем диапазон давления пара (0.1-22 МПа после конвертации)
                double pParMPa = Global.PPar * 0.0980665;
                if (pParMPa < 0.01 || pParMPa > 22.0)
                {
                    MessageBox.Show("⚠️ Давление пара должно быть в диапазоне 0.1-225 кгс/см² (0.01-22 МПа).", 
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Проверяем диапазон температуры пара (0-600°C)
                if (Global.TPar < 0 || Global.TPar > 600)
                {
                    MessageBox.Show("⚠️ Температура пара должна быть в диапазоне 0-600°C.", 
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Проверяем диапазон температуры питательной воды (0-370°C)
                if (Global.TPitV < 0 || Global.TPitV > 370)
                {
                    MessageBox.Show("⚠️ Температура питательной воды должна быть в диапазоне 0-370°C.", 
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Проверяем, что выбран уголь
                if (!CustomCoalCheckBox.Checked && CoalSelectComboBox.SelectedItem == null)
                {
                    MessageBox.Show("⚠️ Выберите уголь из списка или включите ручной ввод.", 
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Проверяем, что выбран котёл
                if (BoilerSelectComboBox.SelectedItem == null)
                {
                    MessageBox.Show("⚠️ Выберите модель котла из списка.", 
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка ввода данных:\n\n{ex.Message}\n\nПроверьте, что все поля заполнены корректно (числовые значения, используйте . или , как разделитель)", 
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Парсинг double с автоматической заменой запятой на точку
        /// </summary>
        /// <param name="text">Текстовое значение для парсинга</param>
        /// <param name="culture">Культура для парсинга (обычно InvariantCulture)</param>
        /// <param name="fieldName">Название поля (для сообщений об ошибках)</param>
        /// <returns>Распарсенное числовое значение</returns>
        private double ParseDouble(string text, System.Globalization.CultureInfo culture, string fieldName = "")
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;
            
            // Заменяем запятую на точку для совместимости с InvariantCulture
            text = text.Replace(',', '.').Trim();
            
            if (string.IsNullOrEmpty(text) || text == ".")
                return 0;
            
            try
            {
                return double.Parse(text, culture);
            }
            catch (FormatException)
            {
                throw new Exception($"'{text}' не является корректным числом для поля '{fieldName}'");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Переключение темы между светлой и тёмной
        /// </summary>
        private void ToggleTheme()
        {
            _isDarkMode = !_isDarkMode;
            ApplyTheme();
        }

        /// <summary>
        /// Применение темы оформления (темная/светлая)
        /// </summary>
        private void ApplyTheme()
        {
            // Определяем палитру цветов для текущей темы
            Color bgColor, panelColor, headerColor, textColor, labelColor, inputBg, buttonBg, buttonBorder;
            
            if (_isDarkMode)
            {
                // === Тёмная тема ===
                bgColor = Color.FromArgb(18, 18, 18);
                panelColor = Color.FromArgb(35, 35, 35);
                headerColor = Color.FromArgb(15, 15, 15);
                textColor = Color.White;
                labelColor = Color.FromArgb(180, 180, 180);
                inputBg = Color.FromArgb(45, 45, 45);
                buttonBg = Color.FromArgb(60, 60, 60);
                buttonBorder = Color.FromArgb(100, 100, 100);
                themeToggleButton.Text = "☀️ Светлая тема";
            }
            else
            {
                // === Светлая тема ===
                bgColor = Color.FromArgb(240, 242, 245);
                panelColor = Color.White;
                headerColor = Color.FromArgb(20, 20, 20);
                textColor = Color.FromArgb(25, 25, 25);
                labelColor = Color.FromArgb(60, 60, 60);
                inputBg = Color.White;
                buttonBg = Color.FromArgb(50, 50, 50);
                buttonBorder = Color.FromArgb(120, 120, 120);
                themeToggleButton.Text = "🌙 Тёмная тема";
            }
            
            // === Применяем цвета к главным элементам ===
            this.BackColor = bgColor;
            mainPanel.BackColor = bgColor;
            headerPanel.BackColor = headerColor;
            titleLabel.ForeColor = _isDarkMode ? Color.White : Color.FromArgb(25, 25, 25);
            subtitleLabel.ForeColor = _isDarkMode ? Color.FromArgb(180, 180, 180) : Color.FromArgb(100, 100, 100);
            
            // === Кнопка переключения темы ===
            themeToggleButton.BackColor = buttonBg;
            themeToggleButton.FlatAppearance.BorderColor = buttonBorder;
            themeToggleButton.ForeColor = textColor;
            
            // === Заголовки панелей (всегда жирным, но цвет под тему) ===
            Color panelHeaderColor = _isDarkMode ? Color.FromArgb(220, 220, 220) : Color.FromArgb(25, 25, 25);
            lblUserInfo.ForeColor = panelHeaderColor;
            lblBoilerParams.ForeColor = panelHeaderColor;
            lblFuel.ForeColor = panelHeaderColor;
            lblAsh.ForeColor = panelHeaderColor;
            lblFurnace.ForeColor = panelHeaderColor;
            lblCoalSelect.ForeColor = labelColor;
            lblBoilerSelect.ForeColor = labelColor;
            
            // === Кнопка "Рассчитать" ===
            calculateButton.BackColor = _isDarkMode ? Color.FromArgb(0, 90, 170) : Color.FromArgb(0, 112, 201);
            calculateButton.ForeColor = Color.White;
            
            // === Применяем ко всем панелям и элементам ===
            ApplyThemeToControls(mainPanel.Controls, panelColor, labelColor, inputBg, textColor);
        }

        /// <summary>
        /// Рекурсивно применяет тему ко всем элементам управления
        /// </summary>
        private void ApplyThemeToControls(Control.ControlCollection controls, 
            Color panelColor, Color labelColor, Color inputBg, Color textColor)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Panel p && p.Tag as string != "button")
                {
                    p.BackColor = panelColor;
                    ApplyThemeToControls(p.Controls, panelColor, labelColor, inputBg, textColor);
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = labelColor;
                }
                else if (ctrl is TextBox tb)
                {
                    tb.BackColor = inputBg;
                    tb.ForeColor = textColor;
                }
                else if (ctrl is CheckBox cb)
                {
                    cb.ForeColor = labelColor;
                }
                else if (ctrl is ComboBox cbx)
                {
                    cbx.BackColor = inputBg;
                    cbx.ForeColor = textColor;
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки переключения темы
        /// </summary>
        private void themeToggleButton_Click(object sender, EventArgs e)
        {
            ToggleTheme();
        }

        /// <summary>
        /// Эффект наведения курсора на кнопку темы (подсветка)
        /// </summary>
        private void themeToggleButton_MouseEnter(object sender, EventArgs e)
        {
            themeToggleButton.BackColor = Color.FromArgb(90, 90, 90);
        }

        /// <summary>
        /// Выход курсора с кнопки темы (восстановление цвета)
        /// </summary>
        private void themeToggleButton_MouseLeave(object sender, EventArgs e)
        {
            if (_isDarkMode)
                themeToggleButton.BackColor = Color.FromArgb(60, 60, 60);
            else
                themeToggleButton.BackColor = Color.FromArgb(50, 50, 50);
        }
    }

    /// <summary>
    /// Химический состав золы
    /// </summary>
    public class AshComposition
    {
        public double SiO2 { get; set; }
        public double Al2O3 { get; set; }
        public double TiO2 { get; set; }
        public double Fe2O3 { get; set; }
        public double CaO { get; set; }
        public double MgO { get; set; }
        public double K2O { get; set; }
        public double Na2O { get; set; }
    }
}
