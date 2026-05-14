namespace BoilerCalc
{
    public static class Global
    {
        // ==================== ИНФОРМАЦИЯ О ПОЛЬЗОВАТЕЛЕ ====================
        public static string FIO { get; set; }
        public static string BoilerName { get; set; }
        public static string FuelBrend { get; set; }
        public static string Marka { get; set; }
        
        // ==================== ВЫБРАННЫЙ УГОЛЬ ====================
        public static Coal SelectedCoal { get; set; } // Выбранный уголь из базы
        public static bool IsCustomCoal { get; set; } //true - ручной ввод, false - из базы
        
        // ==================== ПАРАМЕТРЫ ТОПЛИВА ====================
        public static double KiloDJ { get; set; }      // Q^p_н, кДж/кг
        public static double KiloKal { get; set; }     // Q^p_н, ккал/кг
        public static double TempUG { get; set; }      // Температура уходящих газов, °C
        public static double TempHolV { get; set; }    // Температура холодного воздуха, °C
        
        // ==================== ХАРАКТЕРИСТИКИ КОТЛА ====================
        public static double QBoiler { get; set; }     // Паропроизводительность, т/ч
        public static double PBaraban { get; set; }    // Давление в барабане, кгс/см²
        public static double PPar { get; set; }        // Давление перегретого пара, кгс/см²
        public static double TPar { get; set; }        // Температура перегретого пара, °C
        public static double TPitV { get; set; }       // Температура питательной воды, °C
        public static double VTop { get; set; }        // Объем топочной камеры, м³
        
        // ==================== ПАРАМЕТРЫ ПАРА И ВОДЫ (расчётные) ====================
        public static double PPerPar { get; set; }     // Давление перегретого пара, МПа
        public static double IPerPar { get; set; }     // Энтальпия перегретого пара, кДж/кг
        public static double PPitVc { get; set; }      // Давление питательной воды, МПа
        public static double IPitV { get; set; }       // Энтальпия питательной воды, кДж/кг
        
        // ==================== СОСТАВ ТОПЛИВА (рабочая масса) ====================
        public static double WР { get; set; }          // Влага, %
        public static double АР { get; set; }          // Зольность, %
        public static double SР { get; set; }          // Сера, %
        public static double СР { get; set; }          // Углерод, %
        public static double НР { get; set; }          // Водород, %
        public static double NР { get; set; }          // Азот, %
        public static double ОР { get; set; }          // Кислород, %
        public static double QРh { get; set; }         // Низшая теплота сгорания, МДж/кг
        
        // ==================== ПАРАМЕТРЫ ТОПКИ ====================
        public static double aT { get; set; }          // Коэффициент избытка воздуха в топке
        public static double q3 { get; set; }          // Потери от хим. неполноты, %
        public static double q4 { get; set; }          // Потери от мех. неполноты, %
        public static double aYN { get; set; }         // Доля золы, уносимой газами
        
        // ==================== ПРИСОСЫ ВОЗДУХА ====================
        public static double DaPP { get; set; }        // В пароперегревателе
        public static double DaVE { get; set; }        // В водяном экономайзере
        public static double DaVP { get; set; }        // В воздухоподогревателе
        public static double DaT { get; set; }         // В топке
        public static double DaPL { get; set; }        // В системе пылеприготовления
        
        // ==================== ХИМИЧЕСКИЙ СОСТАВ ЗОЛЫ ====================
        public static double SiO2 { get; set; }
        public static double Al2O3 { get; set; }
        public static double TiO2 { get; set; }
        public static double Fe2O3 { get; set; }
        public static double CaO { get; set; }
        public static double MgO { get; set; }
        public static double K2O { get; set; }
        public static double Na2O { get; set; }
        
        // ==================== РЕЗУЛЬТАТЫ РАСЧЁТОВ ====================
        public static double TerOB { get; private set; }
        public static double TerORO2 { get; private set; }
        public static double TerON2 { get; private set; }
        public static double TerOH2O { get; private set; }
        public static double TerOr { get; private set; }
        
        // Таблица 5
        public static double[,] Tabl5 { get; private set; }
        
        // Таблица 6
        public static double[,] Entalpii { get; private set; }
        public static double[,] ST1 { get; private set; }
        
        // Таблица 7
        public static double[] Tabl7 { get; private set; }
        
        // ==================== ТАБЛИЦЫ КОНВЕКТИВНЫХ ПОВЕРХНОСТЕЙ ====================
        public static double[,] Tabl8 { get; private set; }  // ВЗП
        public static double[,] Tabl9 { get; private set; }  // ВЭК
        public static double[,] Tabl10 { get; private set; } // КПП
        
        // ==================== ДАННЫЕ ДЛЯ ГРАФИКОВ ====================
        public static double[,] IThetaDiagram { get; private set; } // I-θ диаграмма
        
        // Тэги таблиц для Word
        public static string[,] TegTab5 { get; private set; }
        public static string[,] TegST1 { get; private set; }
        public static string[] TegTab7 { get; private set; }

        // ==================== МЕТОДЫ ДЛЯ ЗАПИСИ РЕЗУЛЬТАТОВ ====================
        
        public static void SetTabl8(double[,] t8) { Tabl8 = t8; }
        public static void SetTabl9(double[,] t9) { Tabl9 = t9; }
        public static void SetTabl10(double[,] t10) { Tabl10 = t10; }
        public static void SetIThetaDiagram(double[,] d) { IThetaDiagram = d; }
        
        public static void SetCalculationResults(double terOB, double terORO2, double terON2, double terOH2O, double terOr)
        {
            TerOB = terOB;
            TerORO2 = terORO2;
            TerON2 = terON2;
            TerOH2O = terOH2O;
            TerOr = terOr;
        }

        public static void SetCalSetCalculationTablica5(double[,] tabl5)
        {
            Tabl5 = tabl5;
        }
        
        public static void SetCalSetCalculationTablica6(double[,] sT1)
        {
            ST1 = sT1;
        }
        
        public static void SetCalSetCalculationTablica7(double[] tabl7)
        {
            Tabl7 = tabl7;
        }
        
        /// <summary>
        /// Установка параметров угля из базы данных
        /// </summary>
        public static void SetCoalFromDatabase(Coal coal)
        {
            SelectedCoal = coal;
            IsCustomCoal = false;
            
            WР = coal.Wp;
            АР = coal.Ap;
            SР = coal.SpTotal;
            СР = coal.Cp;
            НР = coal.Hp;
            NР = coal.Np;
            ОР = coal.Op;
            QРh = coal.Qpn;
            
            // Конвертация в ккал/кг
            KiloKal = Math.Round(coal.Qpn * 238.846, 0);
            KiloDJ = Math.Round(coal.Qpn * 1000, 0);
            
            // Установка марки угля
            Marka = coal.Mark;
        }
        
        /// <summary>
        /// Установка параметров угля вручную
        /// </summary>
        public static void SetCustomCoal(double wp, double ap, double spKolk, double spOrg, 
            double cp, double hp, double np, double op, double qpn, string marka = "")
        {
            SelectedCoal = null;
            IsCustomCoal = true;
            
            WР = wp;
            АР = ap;
            SР = spKolk + spOrg;
            СР = cp;
            НР = hp;
            NР = np;
            ОР = op;
            QРh = qpn;
            
            KiloKal = Math.Round(qpn * 238.846, 0);
            KiloDJ = Math.Round(qpn * 1000, 0);
            
            if (!string.IsNullOrEmpty(marka))
                Marka = marka;
        }
        
        /// <summary>
        /// Автоматический расчёт энтальпий пара и воды
        /// </summary>
        public static void CalculateSteamWaterEnthalpies()
        {
            // Энтальпия перегретого пара
            double pParMPa = PPar * 0.0980665; // из кгс/см² в МПа
            IPerPar = Calculations.CalculateSuperheatEnthalpy(pParMPa, TPar);
            PPerPar = Math.Round(pParMPa, 2);
            
            // Энтальпия питательной воды
            IPitV = Calculations.CalculateFeedWaterEnthalpy(TPitV);
            PPitVc = Math.Round(PPar * 0.0980665 * 1.1, 1); // давление пит. воды
            
            // Давление в барабане (если не задано)
            if (PBaraban == 0)
                PBaraban = Calculations.CalculateDrumPressure(pParMPa);
            
            // Объем топочной камеры (если не задан)
            if (VTop == 0)
                VTop = Calculations.CalculateFurnaceVolume(QBoiler);
        }
        
        public static void SetMassTegResults()
        {
            // Массив энтальпий газов
            Entalpii = new double[6, 25];
            
            // Заполняем первую строку - температуры
            for (int i = 0; i < 25; i++)
            {
                Entalpii[0, i] = 100 + i * 100;
            }
            
            // Заполняем энтальпии из WaterSteamTables
            for (int i = 0; i < 25; i++)
            {
                double temp = Entalpii[0, i];
                var gasProps = WaterSteamTables.InterpolateGasProperties(temp);
                var ashProps = WaterSteamTables.InterpolateAshProperties(temp);
                
                Entalpii[1, i] = gasProps.IkAir;      // Воздух
                Entalpii[2, i] = gasProps.IkRO2;      // RO₂
                Entalpii[3, i] = gasProps.IkN2;       // N₂
                Entalpii[4, i] = gasProps.IkH2O;      // H₂O
                Entalpii[5, i] = ashProps.IAsh;       // Зола
            }

            // Тэги для Таблицы 5 (9 строк × 7 столбцов)
            TegTab5 = new string[,] { 
                {"{Tab5S1S1}", "{Tab5S1S2}", "{Tab5S1S3}", "{Tab5S1S4}", "{Tab5S1S5}", "{Tab5S1S6}", "{Tab5S1S7}" },
                {"{Tab5S2S1}",  "{Tab5S2S2}",   "{Tab5S2S3}",   "{Tab5S2S4}",   "{Tab5S2S5}",   "{Tab5S2S6}",   "{Tab5S2S7}" },
                {"{Tab5S3S1}",  "{Tab5S3S2}",   "{Tab5S3S3}",   "{Tab5S3S4}",   "{Tab5S3S5}",   "{Tab5S3S6}",   "{Tab5S3S7}" },
                {"{Tab5S4S1}",  "{Tab5S4S2}",   "{Tab5S4S3}",   "{Tab5S4S4}",   "{Tab5S4S5}",   "{Tab5S4S6}",   "{Tab5S4S7}" },
                {"{Tab5S5S1}",  "{Tab5S5S2}",   "{Tab5S5S3}",   "{Tab5S5S4}",   "{Tab5S5S5}",   "{Tab5S5S6}",   "{Tab5S5S7}" },
                {"{Tab5S6S1}",  "{Tab5S6S2}",   "{Tab5S6S3}",   "{Tab5S6S4}",   "{Tab5S6S5}",   "{Tab5S6S6}",   "{Tab5S6S7}" },
                {"{Tab5S7S1}",  "{Tab5S7S2}",   "{Tab5S7S3}",   "{Tab5S7S4}",   "{Tab5S7S5}",   "{Tab5S7S6}",   "{Tab5S7S7}" },
                {"{Tab5S8S1}",  "{Tab5S8S2}",   "{Tab5S8S3}",   "{Tab5S8S4}",   "{Tab5S8S5}",   "{Tab5S8S6}",   "{Tab5S8S7}" },
                {"{Tab5S9S1}",  "{Tab5S9S2}",   "{Tab5S9S3}",   "{Tab5S9S4}",   "{Tab5S9S5}",   "{Tab5S9S6}",   "{Tab5S9S7}" } 
            };

            // Тэги для Таблицы 6 (11 строк × 20 столбцов)
            TegST1 = new string[,] {
                { "{ST10}", "{ST11}", "{ST12}", "{ST13}", "{ST14}", "{ST15}", "{ST16}", "{ST17}", "{ST18}", "{ST19}", "{ST110}", "{ST111}",
                  "{ST112}", "{ST113}", "{ST114}", "{ST115}", "{ST116}", "{ST117}", "{ST118}", "{ST119}"},
                { "{ST20}", "{ST21}", "{ST22}", "{ST23}", "{ST24}", "{ST25}", "{ST26}", "{ST27}", "{ST28}", "{ST29}", "{ST210}", "{ST211}",
                  "{ST212}", "{ST213}", "{ST214}", "{ST215}", "{ST216}", "{ST217}", "{ST218}", "{ST219}"},
                { "{ST30}", "{ST31}", "{ST32}", "{ST33}", "{ST34}", "{ST35}", "{ST36}", "{ST37}", "{ST38}", "{ST39}", "{ST310}", "{ST311}",
                  "{ST312}", "{ST313}", "{ST314}", "{ST315}", "{ST316}", "{ST317}", "{ST318}", "{ST319}"},
                { "{ST40}", "{ST41}", "{ST42}", "{ST43}", "{ST44}", "{ST45}", "{ST46}", "{ST47}", "{ST48}", "{ST49}", "{ST410}", "{ST411}",
                  "{ST412}", "{ST413}", "{ST414}", "{ST415}", "{ST416}", "{ST417}", "{ST418}", "{ST419}"},
                { "{ST50}", "{ST51}", "{ST52}", "{ST53}", "{ST54}", "{ST55}", "{ST56}", "{ST57}", "{ST58}", "{ST59}", "{ST510}", "{ST511}",
                  "{ST512}", "{ST513}", "{ST514}", "{ST515}", "{ST516}", "{ST517}", "{ST518}", "{ST519}"},
                { "{ST60}", "{ST61}", "{ST62}", "{ST63}", "{ST64}", "{ST65}", "{ST66}", "{ST67}", "{ST68}", "{ST69}", "{ST610}", "{ST611}",
                  "{ST612}", "{ST613}", "{ST614}", "{ST615}", "{ST616}", "{ST617}", "{ST618}", "{ST619}"},
                { "{ST70}", "{ST71}", "{ST72}", "{ST73}", "{ST74}", "{ST75}", "{ST76}", "{ST77}", "{ST78}", "{ST79}", "{ST710}", "{ST711}",
                  "{ST712}", "{ST713}", "{ST714}", "{ST715}", "{ST716}", "{ST717}", "{ST718}", "{ST719}"},
                { "{ST80}", "{ST81}", "{ST82}", "{ST83}", "{ST84}", "{ST85}", "{ST86}", "{ST87}", "{ST88}", "{ST89}", "{ST810}", "{ST811}",
                  "{ST812}", "{ST813}", "{ST814}", "{ST815}", "{ST816}", "{ST817}", "{ST818}", "{ST819}"},
                { "{ST90}", "{ST91}", "{ST92}", "{ST93}", "{ST94}", "{ST95}", "{ST96}", "{ST97}", "{ST98}", "{ST99}", "{ST910}", "{ST911}",
                  "{ST912}", "{ST913}", "{ST914}", "{ST915}", "{ST916}", "{ST917}", "{ST918}", "{ST919}"},
                { "{ST100}", "{ST101}", "{ST102}", "{ST103}", "{ST104}", "{ST105}", "{ST106}", "{ST107}", "{ST108}", "{ST109}", "{ST1010}", "{ST1011}",
                  "{ST1012}", "{ST1013}", "{ST1014}", "{ST1015}", "{ST1016}", "{ST1017}", "{ST1018}", "{ST1019}"},
                { "{ST110a}", "{ST111a}", "{ST112a}", "{ST113a}", "{ST114a}", "{ST115a}", "{ST116a}", "{ST117a}", "{ST118a}", "{ST119a}", "{ST1110a}", "{ST1111a}",
                  "{ST1112a}", "{ST1113a}", "{ST1114a}", "{ST1115a}", "{ST1116a}", "{ST1117a}", "{ST1118a}", "{ST1119a}"}
            };

            // Тэги для Таблицы 7 (23 элемента)
            TegTab7 = new string[] { 
                "{Tab7S1}",   // 0: Q^р_н, кДж/кг
                "{Tab7S1.2}", // 1: Q^р_н, ккал/кг
                "{Tab7S2}",   // 2: q3, %
                "{Tab7S3}",   // 3: q4, %
                "{Tab7S4}",   // 4: q5, %
                "{Tab7S5}",   // 5: q6, %
                "{Tab7S6}",   // 6: θух.г, °C
                "{Tab7S7}",   // 7: Iух.г, кДж/кг
                "{Tab7S8}",   // 8: tх.в, °C
                "{Tab7S9}",   // 9: Iх.в^0, кДж/кг
                "{Tab7S10}",  // 10: Iхв', кДж/кг
                "{Tab7S11}",  // 11: αшл
                "{Tab7S12}",  // 12: tзл, °C
                "{Tab7S13}",  // 13: Iзл, кДж/кг
                "{Tab7S14}",  // 14: q2, %
                "{Tab7S15}",  // 15: η_ка^бр, %
                "{Tab7S16}",  // 16: Q_ка, кДж/с (кВт)
                "{Tab7S17}",  // 17: B, кг/с
                "{Tab7S17.2}",// 18: B, кг/ч
                "{Tab7S18}",  // 19: B_р, кг/с
                "{Tab7S18.2}",// 20: B_р, кг/ч
                "{Tab7S19}",  // 21: φ
                "{Tab7S20}"   // 22: (cθ)_зл, кДж/кг
            };
        }
    }
}
