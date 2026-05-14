namespace BoilerCalc
{
    /// <summary>
    /// Свойства насыщенной воды и пара при заданной температуре
    /// </summary>
    public class SaturatedByTemp
    {
        public double Temp { get; set; }      // Температура, °C
        public double Pressure { get; set; }  // Давление, МПа
        public double VPrime { get; set; }    // Удельный объем воды, м³/кг
        public double VDoublePrime { get; set; } // Удельный объем пара, м³/кг
        public double HPrime { get; set; }    // Энтальпия воды, кДж/кг
        public double HDoublePrime { get; set; } // Энтальпия пара, кДж/кг
        public double R { get; set; }         // Теплота парообразования, кДж/кг
        public double SPrime { get; set; }    // Энтропия воды, кДж/(кг·К)
        public double SDoublePrime { get; set; } // Энтропия пара, кДж/(кг·К)
    }

    /// <summary>
    /// Свойства насыщенной воды и пара при заданном давлении
    /// </summary>
    public class SaturatedByPressure
    {
        public double Pressure { get; set; }  // Давление, МПа
        public double Temp { get; set; }      // Температура насыщения, °C
        public double VPrime { get; set; }    // Удельный объем воды, м³/кг
        public double VDoublePrime { get; set; } // Удельный объем пара, м³/кг
        public double HPrime { get; set; }    // Энтальпия воды, кДж/кг
        public double HDoublePrime { get; set; } // Энтальпия пара, кДж/кг
        public double R { get; set; }         // Теплота парообразования, кДж/кг
        public double SPrime { get; set; }    // Энтропия воды, кДж/(кг·К)
        public double SDoublePrime { get; set; } // Энтропия пара, кДж/(кг·К)
    }

    /// <summary>
    /// Свойства перегретого пара
    /// </summary>
    public class SuperheatedSteam
    {
        public double Pressure { get; set; }  // Давление, МПа
        public double Temp { get; set; }      // Температура, °C
        public double H { get; set; }         // Энтальпия, кДж/кг
        public double S { get; set; }         // Энтропия, кДж/(кг·К)
        public double V { get; set; }         // Удельный объем, м³/кг
    }

    /// <summary>
    /// Теплофизические свойства воздуха и продуктов сгорания
    /// </summary>
    public class GasProperties
    {
        public double Temp { get; set; }      // Температура, °C
        public double CkAir { get; set; }     // Теплоемкость воздуха, кДж/(м³·°C)
        public double CkRO2 { get; set; }     // Теплоемкость RO₂, кДж/(м³·°C)
        public double CkN2 { get; set; }      // Теплоемкость N₂, кДж/(м³·°C)
        public double CkH2O { get; set; }     // Теплоемкость H₂O, кДж/(м³·°C)
        public double IkAir { get; set; }     // Энтальпия воздуха, кДж/м³
        public double IkRO2 { get; set; }     // Энтальпия RO₂, кДж/м³
        public double IkN2 { get; set; }      // Энтальпия N₂, кДж/м³
        public double IkH2O { get; set; }     // Энтальпия H₂O, кДж/м³
    }

    /// <summary>
    /// Энтальпия золы
    /// </summary>
    public class AshProperties
    {
        public double Temp { get; set; }      // Температура, °C
        public double CAsh { get; set; }      // Теплоемкость золы, кДж/(кг·°C)
        public double IAsh { get; set; }      // Энтальпия золы, кДж/кг
    }

    /// <summary>
    /// База данных термодинамических свойств воды и водяного пара
    /// На основе справочных таблиц (Буянов О.Н., Архипова Л.М., 2005)
    /// </summary>
    public static class WaterSteamTables
    {
        /// <summary>
        /// Свойства насыщенной воды и пара по температуре (0-370°C)
        /// </summary>
        public static List<SaturatedByTemp> SaturatedTemp { get; } = new List<SaturatedByTemp>
        {
            new SaturatedByTemp { Temp = 0, Pressure = 0.00061, VPrime = 0.00100, VDoublePrime = 206.3, HPrime = 0.0, HDoublePrime = 2501.0, R = 2501.0, SPrime = 0.0000, SDoublePrime = 9.1562 },
            new SaturatedByTemp { Temp = 5, Pressure = 0.00087, VPrime = 0.00100, VDoublePrime = 147.1, HPrime = 21.0, HDoublePrime = 2510.0, R = 2489.0, SPrime = 0.0762, SDoublePrime = 9.0257 },
            new SaturatedByTemp { Temp = 10, Pressure = 0.00123, VPrime = 0.00100, VDoublePrime = 106.4, HPrime = 42.0, HDoublePrime = 2519.0, R = 2477.0, SPrime = 0.1510, SDoublePrime = 8.9002 },
            new SaturatedByTemp { Temp = 15, Pressure = 0.00170, VPrime = 0.00100, VDoublePrime = 77.9, HPrime = 63.0, HDoublePrime = 2528.0, R = 2465.0, SPrime = 0.2245, SDoublePrime = 8.7803 },
            new SaturatedByTemp { Temp = 20, Pressure = 0.00234, VPrime = 0.00100, VDoublePrime = 57.8, HPrime = 84.0, HDoublePrime = 2537.0, R = 2453.0, SPrime = 0.2966, SDoublePrime = 8.6660 },
            new SaturatedByTemp { Temp = 25, Pressure = 0.00317, VPrime = 0.00100, VDoublePrime = 43.3, HPrime = 105.0, HDoublePrime = 2546.0, R = 2441.0, SPrime = 0.3674, SDoublePrime = 8.5570 },
            new SaturatedByTemp { Temp = 30, Pressure = 0.00425, VPrime = 0.00100, VDoublePrime = 32.9, HPrime = 126.0, HDoublePrime = 2555.0, R = 2429.0, SPrime = 0.4369, SDoublePrime = 8.4533 },
            new SaturatedByTemp { Temp = 35, Pressure = 0.00563, VPrime = 0.00101, VDoublePrime = 25.2, HPrime = 147.0, HDoublePrime = 2564.0, R = 2417.0, SPrime = 0.5053, SDoublePrime = 8.3546 },
            new SaturatedByTemp { Temp = 40, Pressure = 0.00738, VPrime = 0.00101, VDoublePrime = 19.5, HPrime = 168.0, HDoublePrime = 2573.0, R = 2405.0, SPrime = 0.5725, SDoublePrime = 8.2607 },
            new SaturatedByTemp { Temp = 45, Pressure = 0.00959, VPrime = 0.00101, VDoublePrime = 15.3, HPrime = 189.0, HDoublePrime = 2582.0, R = 2393.0, SPrime = 0.6387, SDoublePrime = 8.1715 },
            new SaturatedByTemp { Temp = 50, Pressure = 0.01235, VPrime = 0.00101, VDoublePrime = 12.0, HPrime = 210.0, HDoublePrime = 2591.0, R = 2381.0, SPrime = 0.7038, SDoublePrime = 8.0769 },
            new SaturatedByTemp { Temp = 55, Pressure = 0.01576, VPrime = 0.00101, VDoublePrime = 9.57, HPrime = 231.0, HDoublePrime = 2600.0, R = 2369.0, SPrime = 0.7680, SDoublePrime = 7.9967 },
            new SaturatedByTemp { Temp = 60, Pressure = 0.01994, VPrime = 0.00102, VDoublePrime = 7.67, HPrime = 252.0, HDoublePrime = 2609.0, R = 2357.0, SPrime = 0.8313, SDoublePrime = 7.9096 },
            new SaturatedByTemp { Temp = 65, Pressure = 0.02504, VPrime = 0.00102, VDoublePrime = 6.20, HPrime = 273.0, HDoublePrime = 2618.0, R = 2345.0, SPrime = 0.8937, SDoublePrime = 7.8256 },
            new SaturatedByTemp { Temp = 70, Pressure = 0.03120, VPrime = 0.00102, VDoublePrime = 5.04, HPrime = 294.0, HDoublePrime = 2626.0, R = 2332.0, SPrime = 0.9551, SDoublePrime = 7.7445 },
            new SaturatedByTemp { Temp = 75, Pressure = 0.03858, VPrime = 0.00103, VDoublePrime = 4.13, HPrime = 315.0, HDoublePrime = 2635.0, R = 2320.0, SPrime = 1.0155, SDoublePrime = 7.6663 },
            new SaturatedByTemp { Temp = 80, Pressure = 0.04739, VPrime = 0.00103, VDoublePrime = 3.41, HPrime = 336.0, HDoublePrime = 2643.0, R = 2307.0, SPrime = 1.0753, SDoublePrime = 7.5909 },
            new SaturatedByTemp { Temp = 85, Pressure = 0.05783, VPrime = 0.00103, VDoublePrime = 2.83, HPrime = 357.0, HDoublePrime = 2651.0, R = 2294.0, SPrime = 1.1343, SDoublePrime = 7.5182 },
            new SaturatedByTemp { Temp = 90, Pressure = 0.07013, VPrime = 0.00104, VDoublePrime = 2.36, HPrime = 378.0, HDoublePrime = 2659.0, R = 2281.0, SPrime = 1.1925, SDoublePrime = 7.4481 },
            new SaturatedByTemp { Temp = 95, Pressure = 0.08455, VPrime = 0.00104, VDoublePrime = 1.98, HPrime = 399.0, HDoublePrime = 2667.0, R = 2268.0, SPrime = 1.2500, SDoublePrime = 7.3805 },
            new SaturatedByTemp { Temp = 100, Pressure = 0.10133, VPrime = 0.00104, VDoublePrime = 1.673, HPrime = 420.0, HDoublePrime = 2675.0, R = 2255.0, SPrime = 1.3069, SDoublePrime = 7.3549 },
            new SaturatedByTemp { Temp = 105, Pressure = 0.12080, VPrime = 0.00105, VDoublePrime = 1.419, HPrime = 441.0, HDoublePrime = 2683.0, R = 2242.0, SPrime = 1.3630, SDoublePrime = 7.2917 },
            new SaturatedByTemp { Temp = 110, Pressure = 0.14330, VPrime = 0.00105, VDoublePrime = 1.210, HPrime = 462.0, HDoublePrime = 2691.0, R = 2229.0, SPrime = 1.4185, SDoublePrime = 7.2305 },
            new SaturatedByTemp { Temp = 115, Pressure = 0.16910, VPrime = 0.00106, VDoublePrime = 1.037, HPrime = 483.0, HDoublePrime = 2698.0, R = 2215.0, SPrime = 1.4734, SDoublePrime = 7.1712 },
            new SaturatedByTemp { Temp = 120, Pressure = 0.19850, VPrime = 0.00106, VDoublePrime = 0.892, HPrime = 505.0, HDoublePrime = 2706.0, R = 2201.0, SPrime = 1.5276, SDoublePrime = 7.1137 },
            new SaturatedByTemp { Temp = 125, Pressure = 0.23210, VPrime = 0.00107, VDoublePrime = 0.771, HPrime = 526.0, HDoublePrime = 2713.0, R = 2187.0, SPrime = 1.5813, SDoublePrime = 7.0580 },
            new SaturatedByTemp { Temp = 130, Pressure = 0.27010, VPrime = 0.00107, VDoublePrime = 0.669, HPrime = 547.0, HDoublePrime = 2720.0, R = 2173.0, SPrime = 1.6344, SDoublePrime = 7.0040 },
            new SaturatedByTemp { Temp = 135, Pressure = 0.31300, VPrime = 0.00107, VDoublePrime = 0.582, HPrime = 569.0, HDoublePrime = 2727.0, R = 2158.0, SPrime = 1.6870, SDoublePrime = 6.9516 },
            new SaturatedByTemp { Temp = 140, Pressure = 0.36130, VPrime = 0.00108, VDoublePrime = 0.509, HPrime = 590.0, HDoublePrime = 2734.0, R = 2144.0, SPrime = 1.7391, SDoublePrime = 6.9008 },
            new SaturatedByTemp { Temp = 145, Pressure = 0.41540, VPrime = 0.00108, VDoublePrime = 0.446, HPrime = 612.0, HDoublePrime = 2740.0, R = 2128.0, SPrime = 1.7907, SDoublePrime = 6.8515 },
            new SaturatedByTemp { Temp = 150, Pressure = 0.47580, VPrime = 0.00109, VDoublePrime = 0.393, HPrime = 633.0, HDoublePrime = 2746.0, R = 2113.0, SPrime = 1.8418, SDoublePrime = 6.8036 },
            new SaturatedByTemp { Temp = 155, Pressure = 0.54310, VPrime = 0.00109, VDoublePrime = 0.347, HPrime = 655.0, HDoublePrime = 2752.0, R = 2097.0, SPrime = 1.8925, SDoublePrime = 6.7571 },
            new SaturatedByTemp { Temp = 160, Pressure = 0.61780, VPrime = 0.00110, VDoublePrime = 0.307, HPrime = 677.0, HDoublePrime = 2758.0, R = 2081.0, SPrime = 1.9427, SDoublePrime = 6.7120 },
            new SaturatedByTemp { Temp = 165, Pressure = 0.70050, VPrime = 0.00111, VDoublePrime = 0.272, HPrime = 699.0, HDoublePrime = 2763.0, R = 2064.0, SPrime = 1.9925, SDoublePrime = 6.6682 },
            new SaturatedByTemp { Temp = 170, Pressure = 0.79170, VPrime = 0.00111, VDoublePrime = 0.243, HPrime = 721.0, HDoublePrime = 2768.0, R = 2047.0, SPrime = 2.0419, SDoublePrime = 6.6257 },
            new SaturatedByTemp { Temp = 175, Pressure = 0.89200, VPrime = 0.00112, VDoublePrime = 0.217, HPrime = 743.0, HDoublePrime = 2773.0, R = 2030.0, SPrime = 2.0909, SDoublePrime = 6.5844 },
            new SaturatedByTemp { Temp = 180, Pressure = 1.00200, VPrime = 0.00113, VDoublePrime = 0.194, HPrime = 765.0, HDoublePrime = 2778.0, R = 2013.0, SPrime = 2.1396, SDoublePrime = 6.5443 },
            new SaturatedByTemp { Temp = 185, Pressure = 1.12200, VPrime = 0.00113, VDoublePrime = 0.174, HPrime = 788.0, HDoublePrime = 2782.0, R = 1994.0, SPrime = 2.1879, SDoublePrime = 6.5054 },
            new SaturatedByTemp { Temp = 190, Pressure = 1.25400, VPrime = 0.00114, VDoublePrime = 0.157, HPrime = 810.0, HDoublePrime = 2786.0, R = 1976.0, SPrime = 2.2359, SDoublePrime = 6.4676 },
            new SaturatedByTemp { Temp = 195, Pressure = 1.39800, VPrime = 0.00115, VDoublePrime = 0.141, HPrime = 833.0, HDoublePrime = 2790.0, R = 1957.0, SPrime = 2.2836, SDoublePrime = 6.4309 },
            new SaturatedByTemp { Temp = 200, Pressure = 1.55400, VPrime = 0.00116, VDoublePrime = 0.127, HPrime = 856.0, HDoublePrime = 2793.0, R = 1937.0, SPrime = 2.3310, SDoublePrime = 6.3953 },
            new SaturatedByTemp { Temp = 210, Pressure = 1.90600, VPrime = 0.00117, VDoublePrime = 0.104, HPrime = 904.0, HDoublePrime = 2799.0, R = 1895.0, SPrime = 2.4248, SDoublePrime = 6.3268 },
            new SaturatedByTemp { Temp = 220, Pressure = 2.31800, VPrime = 0.00119, VDoublePrime = 0.086, HPrime = 952.0, HDoublePrime = 2803.0, R = 1851.0, SPrime = 2.5178, SDoublePrime = 6.2616 },
            new SaturatedByTemp { Temp = 230, Pressure = 2.79500, VPrime = 0.00121, VDoublePrime = 0.072, HPrime = 1001.0, HDoublePrime = 2805.0, R = 1804.0, SPrime = 2.6099, SDoublePrime = 6.1995 },
            new SaturatedByTemp { Temp = 240, Pressure = 3.34400, VPrime = 0.00123, VDoublePrime = 0.060, HPrime = 1051.0, HDoublePrime = 2805.0, R = 1754.0, SPrime = 2.7015, SDoublePrime = 6.1402 },
            new SaturatedByTemp { Temp = 250, Pressure = 3.97300, VPrime = 0.00125, VDoublePrime = 0.050, HPrime = 1102.0, HDoublePrime = 2802.0, R = 1700.0, SPrime = 2.7927, SDoublePrime = 6.0835 },
            new SaturatedByTemp { Temp = 260, Pressure = 4.68800, VPrime = 0.00128, VDoublePrime = 0.042, HPrime = 1154.0, HDoublePrime = 2797.0, R = 1643.0, SPrime = 2.8838, SDoublePrime = 6.0292 },
            new SaturatedByTemp { Temp = 270, Pressure = 5.49300, VPrime = 0.00130, VDoublePrime = 0.036, HPrime = 1208.0, HDoublePrime = 2789.0, R = 1581.0, SPrime = 2.9751, SDoublePrime = 5.9771 },
            new SaturatedByTemp { Temp = 280, Pressure = 6.41200, VPrime = 0.00133, VDoublePrime = 0.030, HPrime = 1263.0, HDoublePrime = 2778.0, R = 1515.0, SPrime = 3.0668, SDoublePrime = 5.9270 },
            new SaturatedByTemp { Temp = 290, Pressure = 7.44100, VPrime = 0.00137, VDoublePrime = 0.026, HPrime = 1321.0, HDoublePrime = 2763.0, R = 1442.0, SPrime = 3.1594, SDoublePrime = 5.8787 },
            new SaturatedByTemp { Temp = 300, Pressure = 8.58100, VPrime = 0.00140, VDoublePrime = 0.022, HPrime = 1382.0, HDoublePrime = 2744.0, R = 1362.0, SPrime = 3.2534, SDoublePrime = 5.8320 },
            new SaturatedByTemp { Temp = 310, Pressure = 9.85600, VPrime = 0.00144, VDoublePrime = 0.019, HPrime = 1446.0, HDoublePrime = 2720.0, R = 1274.0, SPrime = 3.3495, SDoublePrime = 5.7867 },
            new SaturatedByTemp { Temp = 320, Pressure = 11.27400, VPrime = 0.00149, VDoublePrime = 0.017, HPrime = 1515.0, HDoublePrime = 2690.0, R = 1175.0, SPrime = 3.4486, SDoublePrime = 5.7425 },
            new SaturatedByTemp { Temp = 330, Pressure = 12.84800, VPrime = 0.00154, VDoublePrime = 0.015, HPrime = 1590.0, HDoublePrime = 2652.0, R = 1062.0, SPrime = 3.5518, SDoublePrime = 5.6992 },
            new SaturatedByTemp { Temp = 340, Pressure = 14.58600, VPrime = 0.00160, VDoublePrime = 0.013, HPrime = 1674.0, HDoublePrime = 2603.0, R = 929.0, SPrime = 3.6608, SDoublePrime = 5.6564 },
            new SaturatedByTemp { Temp = 350, Pressure = 16.51300, VPrime = 0.00167, VDoublePrime = 0.012, HPrime = 1773.0, HDoublePrime = 2538.0, R = 765.0, SPrime = 3.7789, SDoublePrime = 5.6136 },
            new SaturatedByTemp { Temp = 360, Pressure = 18.65100, VPrime = 0.00176, VDoublePrime = 0.011, HPrime = 1902.0, HDoublePrime = 2442.0, R = 540.0, SPrime = 3.9128, SDoublePrime = 5.5702 },
            new SaturatedByTemp { Temp = 370, Pressure = 21.03000, VPrime = 0.00189, VDoublePrime = 0.010, HPrime = 2099.0, HDoublePrime = 2283.0, R = 184.0, SPrime = 4.1075, SDoublePrime = 5.5255 }
        };

        /// <summary>
        /// Свойства насыщенной воды и пара по давлению (0.001-22.0 МПа)
        /// </summary>
        public static List<SaturatedByPressure> SaturatedPressure { get; } = new List<SaturatedByPressure>
        {
            new SaturatedByPressure { Pressure = 0.001, Temp = 6.9, VPrime = 0.00100, VDoublePrime = 129.2, HPrime = 29.0, HDoublePrime = 2513.0, R = 2484.0, SPrime = 0.1060, SDoublePrime = 8.9740 },
            new SaturatedByPressure { Pressure = 0.002, Temp = 17.5, VPrime = 0.00100, VDoublePrime = 67.0, HPrime = 73.0, HDoublePrime = 2533.0, R = 2460.0, SPrime = 0.2610, SDoublePrime = 8.7230 },
            new SaturatedByPressure { Pressure = 0.003, Temp = 24.1, VPrime = 0.00100, VDoublePrime = 45.7, HPrime = 101.0, HDoublePrime = 2545.0, R = 2444.0, SPrime = 0.3540, SDoublePrime = 8.5760 },
            new SaturatedByPressure { Pressure = 0.004, Temp = 29.0, VPrime = 0.00100, VDoublePrime = 34.8, HPrime = 121.0, HDoublePrime = 2554.0, R = 2433.0, SPrime = 0.4220, SDoublePrime = 8.4740 },
            new SaturatedByPressure { Pressure = 0.005, Temp = 32.9, VPrime = 0.00101, VDoublePrime = 28.2, HPrime = 138.0, HDoublePrime = 2561.0, R = 2423.0, SPrime = 0.4760, SDoublePrime = 8.3950 },
            new SaturatedByPressure { Pressure = 0.006, Temp = 36.2, VPrime = 0.00101, VDoublePrime = 23.7, HPrime = 152.0, HDoublePrime = 2567.0, R = 2415.0, SPrime = 0.5210, SDoublePrime = 8.3300 },
            new SaturatedByPressure { Pressure = 0.007, Temp = 39.0, VPrime = 0.00101, VDoublePrime = 20.5, HPrime = 164.0, HDoublePrime = 2572.0, R = 2408.0, SPrime = 0.5590, SDoublePrime = 8.2760 },
            new SaturatedByPressure { Pressure = 0.008, Temp = 41.5, VPrime = 0.00101, VDoublePrime = 18.1, HPrime = 174.0, HDoublePrime = 2576.0, R = 2402.0, SPrime = 0.5920, SDoublePrime = 8.2290 },
            new SaturatedByPressure { Pressure = 0.009, Temp = 43.8, VPrime = 0.00101, VDoublePrime = 16.2, HPrime = 184.0, HDoublePrime = 2580.0, R = 2396.0, SPrime = 0.6220, SDoublePrime = 8.1880 },
            new SaturatedByPressure { Pressure = 0.01, Temp = 45.8, VPrime = 0.00101, VDoublePrime = 14.7, HPrime = 192.0, HDoublePrime = 2584.0, R = 2392.0, SPrime = 0.6490, SDoublePrime = 8.1500 },
            new SaturatedByPressure { Pressure = 0.015, Temp = 54.0, VPrime = 0.00101, VDoublePrime = 10.0, HPrime = 226.0, HDoublePrime = 2598.0, R = 2372.0, SPrime = 0.7540, SDoublePrime = 8.0080 },
            new SaturatedByPressure { Pressure = 0.02, Temp = 60.1, VPrime = 0.00102, VDoublePrime = 7.65, HPrime = 252.0, HDoublePrime = 2609.0, R = 2357.0, SPrime = 0.8320, SDoublePrime = 7.9080 },
            new SaturatedByPressure { Pressure = 0.025, Temp = 65.0, VPrime = 0.00102, VDoublePrime = 6.20, HPrime = 272.0, HDoublePrime = 2617.0, R = 2345.0, SPrime = 0.8930, SDoublePrime = 7.8300 },
            new SaturatedByPressure { Pressure = 0.03, Temp = 69.1, VPrime = 0.00102, VDoublePrime = 5.23, HPrime = 289.0, HDoublePrime = 2624.0, R = 2335.0, SPrime = 0.9440, SDoublePrime = 7.7670 },
            new SaturatedByPressure { Pressure = 0.04, Temp = 75.9, VPrime = 0.00103, VDoublePrime = 3.99, HPrime = 318.0, HDoublePrime = 2636.0, R = 2318.0, SPrime = 1.0260, SDoublePrime = 7.6690 },
            new SaturatedByPressure { Pressure = 0.05, Temp = 81.3, VPrime = 0.00103, VDoublePrime = 3.24, HPrime = 340.0, HDoublePrime = 2645.0, R = 2305.0, SPrime = 1.0910, SDoublePrime = 7.5930 },
            new SaturatedByPressure { Pressure = 0.06, Temp = 85.9, VPrime = 0.00103, VDoublePrime = 2.73, HPrime = 360.0, HDoublePrime = 2653.0, R = 2293.0, SPrime = 1.1450, SDoublePrime = 7.5320 },
            new SaturatedByPressure { Pressure = 0.07, Temp = 90.0, VPrime = 0.00104, VDoublePrime = 2.36, HPrime = 377.0, HDoublePrime = 2660.0, R = 2283.0, SPrime = 1.1920, SDoublePrime = 7.4800 },
            new SaturatedByPressure { Pressure = 0.08, Temp = 93.5, VPrime = 0.00104, VDoublePrime = 2.09, HPrime = 392.0, HDoublePrime = 2666.0, R = 2274.0, SPrime = 1.2330, SDoublePrime = 7.4350 },
            new SaturatedByPressure { Pressure = 0.09, Temp = 96.7, VPrime = 0.00104, VDoublePrime = 1.87, HPrime = 406.0, HDoublePrime = 2671.0, R = 2265.0, SPrime = 1.2700, SDoublePrime = 7.3950 },
            new SaturatedByPressure { Pressure = 0.1, Temp = 99.6, VPrime = 0.00104, VDoublePrime = 1.694, HPrime = 417.0, HDoublePrime = 2675.0, R = 2258.0, SPrime = 1.3030, SDoublePrime = 7.3590 },
            new SaturatedByPressure { Pressure = 0.12, Temp = 104.8, VPrime = 0.00105, VDoublePrime = 1.428, HPrime = 439.0, HDoublePrime = 2683.0, R = 2244.0, SPrime = 1.3610, SDoublePrime = 7.2980 },
            new SaturatedByPressure { Pressure = 0.14, Temp = 109.3, VPrime = 0.00105, VDoublePrime = 1.237, HPrime = 458.0, HDoublePrime = 2690.0, R = 2232.0, SPrime = 1.4110, SDoublePrime = 7.2470 },
            new SaturatedByPressure { Pressure = 0.16, Temp = 113.3, VPrime = 0.00105, VDoublePrime = 1.091, HPrime = 475.0, HDoublePrime = 2696.0, R = 2221.0, SPrime = 1.4550, SDoublePrime = 7.2020 },
            new SaturatedByPressure { Pressure = 0.18, Temp = 116.9, VPrime = 0.00106, VDoublePrime = 0.978, HPrime = 491.0, HDoublePrime = 2701.0, R = 2210.0, SPrime = 1.4950, SDoublePrime = 7.1620 },
            new SaturatedByPressure { Pressure = 0.2, Temp = 120.2, VPrime = 0.00106, VDoublePrime = 0.886, HPrime = 505.0, HDoublePrime = 2706.0, R = 2201.0, SPrime = 1.5300, SDoublePrime = 7.1270 },
            new SaturatedByPressure { Pressure = 0.25, Temp = 127.4, VPrime = 0.00107, VDoublePrime = 0.719, HPrime = 535.0, HDoublePrime = 2716.0, R = 2181.0, SPrime = 1.6070, SDoublePrime = 7.0520 },
            new SaturatedByPressure { Pressure = 0.3, Temp = 133.5, VPrime = 0.00107, VDoublePrime = 0.606, HPrime = 561.0, HDoublePrime = 2724.0, R = 2163.0, SPrime = 1.6720, SDoublePrime = 6.9910 },
            new SaturatedByPressure { Pressure = 0.35, Temp = 138.9, VPrime = 0.00108, VDoublePrime = 0.524, HPrime = 584.0, HDoublePrime = 2731.0, R = 2147.0, SPrime = 1.7270, SDoublePrime = 6.9400 },
            new SaturatedByPressure { Pressure = 0.4, Temp = 143.6, VPrime = 0.00108, VDoublePrime = 0.462, HPrime = 604.0, HDoublePrime = 2737.0, R = 2133.0, SPrime = 1.7770, SDoublePrime = 6.8940 },
            new SaturatedByPressure { Pressure = 0.45, Temp = 147.9, VPrime = 0.00109, VDoublePrime = 0.414, HPrime = 623.0, HDoublePrime = 2742.0, R = 2119.0, SPrime = 1.8210, SDoublePrime = 6.8540 },
            new SaturatedByPressure { Pressure = 0.5, Temp = 151.8, VPrime = 0.00109, VDoublePrime = 0.375, HPrime = 640.0, HDoublePrime = 2747.0, R = 2107.0, SPrime = 1.8610, SDoublePrime = 6.8190 },
            new SaturatedByPressure { Pressure = 0.55, Temp = 155.5, VPrime = 0.00110, VDoublePrime = 0.343, HPrime = 656.0, HDoublePrime = 2751.0, R = 2095.0, SPrime = 1.8980, SDoublePrime = 6.7870 },
            new SaturatedByPressure { Pressure = 0.6, Temp = 158.8, VPrime = 0.00110, VDoublePrime = 0.316, HPrime = 670.0, HDoublePrime = 2755.0, R = 2085.0, SPrime = 1.9310, SDoublePrime = 6.7590 },
            new SaturatedByPressure { Pressure = 0.65, Temp = 162.0, VPrime = 0.00110, VDoublePrime = 0.293, HPrime = 684.0, HDoublePrime = 2759.0, R = 2075.0, SPrime = 1.9620, SDoublePrime = 6.7330 },
            new SaturatedByPressure { Pressure = 0.7, Temp = 165.0, VPrime = 0.00111, VDoublePrime = 0.273, HPrime = 697.0, HDoublePrime = 2762.0, R = 2065.0, SPrime = 1.9920, SDoublePrime = 6.7080 },
            new SaturatedByPressure { Pressure = 0.75, Temp = 167.8, VPrime = 0.00111, VDoublePrime = 0.255, HPrime = 709.0, HDoublePrime = 2765.0, R = 2056.0, SPrime = 2.0200, SDoublePrime = 6.6850 },
            new SaturatedByPressure { Pressure = 0.8, Temp = 170.4, VPrime = 0.00111, VDoublePrime = 0.240, HPrime = 721.0, HDoublePrime = 2768.0, R = 2047.0, SPrime = 2.0460, SDoublePrime = 6.6630 },
            new SaturatedByPressure { Pressure = 0.85, Temp = 172.9, VPrime = 0.00112, VDoublePrime = 0.227, HPrime = 732.0, HDoublePrime = 2770.0, R = 2038.0, SPrime = 2.0710, SDoublePrime = 6.6430 },
            new SaturatedByPressure { Pressure = 0.9, Temp = 175.4, VPrime = 0.00112, VDoublePrime = 0.215, HPrime = 743.0, HDoublePrime = 2773.0, R = 2030.0, SPrime = 2.0950, SDoublePrime = 6.6230 },
            new SaturatedByPressure { Pressure = 0.95, Temp = 177.7, VPrime = 0.00112, VDoublePrime = 0.204, HPrime = 753.0, HDoublePrime = 2775.0, R = 2022.0, SPrime = 2.1170, SDoublePrime = 6.6050 },
            new SaturatedByPressure { Pressure = 1.0, Temp = 179.9, VPrime = 0.00113, VDoublePrime = 0.194, HPrime = 763.0, HDoublePrime = 2777.0, R = 2014.0, SPrime = 2.1390, SDoublePrime = 6.5870 },
            new SaturatedByPressure { Pressure = 1.1, Temp = 184.1, VPrime = 0.00113, VDoublePrime = 0.177, HPrime = 781.0, HDoublePrime = 2781.0, R = 2000.0, SPrime = 2.1790, SDoublePrime = 6.5540 },
            new SaturatedByPressure { Pressure = 1.2, Temp = 188.0, VPrime = 0.00114, VDoublePrime = 0.163, HPrime = 798.0, HDoublePrime = 2784.0, R = 1986.0, SPrime = 2.2160, SDoublePrime = 6.5240 },
            new SaturatedByPressure { Pressure = 1.3, Temp = 191.6, VPrime = 0.00114, VDoublePrime = 0.151, HPrime = 814.0, HDoublePrime = 2787.0, R = 1973.0, SPrime = 2.2510, SDoublePrime = 6.4960 },
            new SaturatedByPressure { Pressure = 1.4, Temp = 195.0, VPrime = 0.00115, VDoublePrime = 0.141, HPrime = 830.0, HDoublePrime = 2789.0, R = 1959.0, SPrime = 2.2840, SDoublePrime = 6.4700 },
            new SaturatedByPressure { Pressure = 1.5, Temp = 198.3, VPrime = 0.00115, VDoublePrime = 0.132, HPrime = 844.0, HDoublePrime = 2791.0, R = 1947.0, SPrime = 2.3150, SDoublePrime = 6.4450 },
            new SaturatedByPressure { Pressure = 1.6, Temp = 201.4, VPrime = 0.00116, VDoublePrime = 0.124, HPrime = 858.0, HDoublePrime = 2793.0, R = 1935.0, SPrime = 2.3440, SDoublePrime = 6.4220 },
            new SaturatedByPressure { Pressure = 1.7, Temp = 204.3, VPrime = 0.00116, VDoublePrime = 0.117, HPrime = 872.0, HDoublePrime = 2795.0, R = 1923.0, SPrime = 2.3720, SDoublePrime = 6.4000 },
            new SaturatedByPressure { Pressure = 1.8, Temp = 207.1, VPrime = 0.00117, VDoublePrime = 0.110, HPrime = 884.0, HDoublePrime = 2796.0, R = 1912.0, SPrime = 2.3980, SDoublePrime = 6.3790 },
            new SaturatedByPressure { Pressure = 1.9, Temp = 209.8, VPrime = 0.00117, VDoublePrime = 0.104, HPrime = 897.0, HDoublePrime = 2797.0, R = 1900.0, SPrime = 2.4230, SDoublePrime = 6.3600 },
            new SaturatedByPressure { Pressure = 2.0, Temp = 212.4, VPrime = 0.00118, VDoublePrime = 0.0996, HPrime = 908.0, HDoublePrime = 2798.0, R = 1890.0, SPrime = 2.4470, SDoublePrime = 6.3410 },
            new SaturatedByPressure { Pressure = 2.2, Temp = 217.2, VPrime = 0.00118, VDoublePrime = 0.0906, HPrime = 931.0, HDoublePrime = 2800.0, R = 1869.0, SPrime = 2.4920, SDoublePrime = 6.3060 },
            new SaturatedByPressure { Pressure = 2.4, Temp = 221.8, VPrime = 0.00119, VDoublePrime = 0.0832, HPrime = 952.0, HDoublePrime = 2801.0, R = 1849.0, SPrime = 2.5340, SDoublePrime = 6.2740 },
            new SaturatedByPressure { Pressure = 2.6, Temp = 226.0, VPrime = 0.00120, VDoublePrime = 0.0769, HPrime = 972.0, HDoublePrime = 2802.0, R = 1830.0, SPrime = 2.5740, SDoublePrime = 6.2440 },
            new SaturatedByPressure { Pressure = 2.8, Temp = 230.0, VPrime = 0.00121, VDoublePrime = 0.0715, HPrime = 990.0, HDoublePrime = 2802.0, R = 1812.0, SPrime = 2.6110, SDoublePrime = 6.2170 },
            new SaturatedByPressure { Pressure = 3.0, Temp = 233.8, VPrime = 0.00122, VDoublePrime = 0.0667, HPrime = 1008.0, HDoublePrime = 2802.0, R = 1794.0, SPrime = 2.6460, SDoublePrime = 6.1920 },
            new SaturatedByPressure { Pressure = 3.5, Temp = 242.6, VPrime = 0.00123, VDoublePrime = 0.0571, HPrime = 1049.0, HDoublePrime = 2801.0, R = 1752.0, SPrime = 2.7240, SDoublePrime = 6.1370 },
            new SaturatedByPressure { Pressure = 4.0, Temp = 250.4, VPrime = 0.00125, VDoublePrime = 0.0498, HPrime = 1087.0, HDoublePrime = 2798.0, R = 1711.0, SPrime = 2.7960, SDoublePrime = 6.0890 },
            new SaturatedByPressure { Pressure = 4.5, Temp = 257.4, VPrime = 0.00127, VDoublePrime = 0.0441, HPrime = 1121.0, HDoublePrime = 2793.0, R = 1672.0, SPrime = 2.8610, SDoublePrime = 6.0470 },
            new SaturatedByPressure { Pressure = 5.0, Temp = 263.9, VPrime = 0.00129, VDoublePrime = 0.0394, HPrime = 1154.0, HDoublePrime = 2786.0, R = 1632.0, SPrime = 2.9210, SDoublePrime = 6.0090 },
            new SaturatedByPressure { Pressure = 5.5, Temp = 270.0, VPrime = 0.00130, VDoublePrime = 0.0356, HPrime = 1184.0, HDoublePrime = 2778.0, R = 1594.0, SPrime = 2.9760, SDoublePrime = 5.9740 },
            new SaturatedByPressure { Pressure = 6.0, Temp = 275.6, VPrime = 0.00132, VDoublePrime = 0.0324, HPrime = 1213.0, HDoublePrime = 2768.0, R = 1555.0, SPrime = 3.0270, SDoublePrime = 5.9430 },
            new SaturatedByPressure { Pressure = 6.5, Temp = 280.9, VPrime = 0.00134, VDoublePrime = 0.0297, HPrime = 1241.0, HDoublePrime = 2757.0, R = 1516.0, SPrime = 3.0750, SDoublePrime = 5.9140 },
            new SaturatedByPressure { Pressure = 7.0, Temp = 285.8, VPrime = 0.00135, VDoublePrime = 0.0274, HPrime = 1267.0, HDoublePrime = 2744.0, R = 1477.0, SPrime = 3.1200, SDoublePrime = 5.8870 },
            new SaturatedByPressure { Pressure = 7.5, Temp = 290.5, VPrime = 0.00137, VDoublePrime = 0.0255, HPrime = 1292.0, HDoublePrime = 2730.0, R = 1438.0, SPrime = 3.1630, SDoublePrime = 5.8620 },
            new SaturatedByPressure { Pressure = 8.0, Temp = 295.0, VPrime = 0.00138, VDoublePrime = 0.0238, HPrime = 1317.0, HDoublePrime = 2714.0, R = 1397.0, SPrime = 3.2040, SDoublePrime = 5.8390 },
            new SaturatedByPressure { Pressure = 8.5, Temp = 299.3, VPrime = 0.00140, VDoublePrime = 0.0223, HPrime = 1340.0, HDoublePrime = 2697.0, R = 1357.0, SPrime = 3.2430, SDoublePrime = 5.8170 },
            new SaturatedByPressure { Pressure = 9.0, Temp = 303.3, VPrime = 0.00142, VDoublePrime = 0.0210, HPrime = 1363.0, HDoublePrime = 2678.0, R = 1315.0, SPrime = 3.2800, SDoublePrime = 5.7960 },
            new SaturatedByPressure { Pressure = 9.5, Temp = 307.2, VPrime = 0.00143, VDoublePrime = 0.0198, HPrime = 1385.0, HDoublePrime = 2657.0, R = 1272.0, SPrime = 3.3160, SDoublePrime = 5.7770 },
            new SaturatedByPressure { Pressure = 10.0, Temp = 311.0, VPrime = 0.00145, VDoublePrime = 0.0188, HPrime = 1407.0, HDoublePrime = 2634.0, R = 1227.0, SPrime = 3.3500, SDoublePrime = 5.7590 },
            new SaturatedByPressure { Pressure = 10.5, Temp = 314.6, VPrime = 0.00147, VDoublePrime = 0.0178, HPrime = 1428.0, HDoublePrime = 2609.0, R = 1181.0, SPrime = 3.3830, SDoublePrime = 5.7420 },
            new SaturatedByPressure { Pressure = 11.0, Temp = 318.0, VPrime = 0.00149, VDoublePrime = 0.0169, HPrime = 1449.0, HDoublePrime = 2582.0, R = 1133.0, SPrime = 3.4150, SDoublePrime = 5.7260 },
            new SaturatedByPressure { Pressure = 11.5, Temp = 321.3, VPrime = 0.00151, VDoublePrime = 0.0161, HPrime = 1469.0, HDoublePrime = 2552.0, R = 1083.0, SPrime = 3.4460, SDoublePrime = 5.7110 },
            new SaturatedByPressure { Pressure = 12.0, Temp = 324.6, VPrime = 0.00153, VDoublePrime = 0.0154, HPrime = 1489.0, HDoublePrime = 2520.0, R = 1031.0, SPrime = 3.4760, SDoublePrime = 5.6970 },
            new SaturatedByPressure { Pressure = 12.5, Temp = 327.7, VPrime = 0.00155, VDoublePrime = 0.0147, HPrime = 1509.0, HDoublePrime = 2485.0, R = 976.0, SPrime = 3.5050, SDoublePrime = 5.6840 },
            new SaturatedByPressure { Pressure = 13.0, Temp = 330.7, VPrime = 0.00157, VDoublePrime = 0.0141, HPrime = 1529.0, HDoublePrime = 2447.0, R = 918.0, SPrime = 3.5340, SDoublePrime = 5.6720 },
            new SaturatedByPressure { Pressure = 13.5, Temp = 333.6, VPrime = 0.00159, VDoublePrime = 0.0135, HPrime = 1549.0, HDoublePrime = 2405.0, R = 856.0, SPrime = 3.5620, SDoublePrime = 5.6610 },
            new SaturatedByPressure { Pressure = 14.0, Temp = 336.4, VPrime = 0.00161, VDoublePrime = 0.0130, HPrime = 1570.0, HDoublePrime = 2359.0, R = 789.0, SPrime = 3.5900, SDoublePrime = 5.6510 },
            new SaturatedByPressure { Pressure = 14.5, Temp = 339.1, VPrime = 0.00164, VDoublePrime = 0.0125, HPrime = 1592.0, HDoublePrime = 2308.0, R = 716.0, SPrime = 3.6180, SDoublePrime = 5.6420 },
            new SaturatedByPressure { Pressure = 15.0, Temp = 341.7, VPrime = 0.00166, VDoublePrime = 0.0120, HPrime = 1616.0, HDoublePrime = 2251.0, R = 635.0, SPrime = 3.6460, SDoublePrime = 5.6340 },
            new SaturatedByPressure { Pressure = 15.5, Temp = 344.2, VPrime = 0.00169, VDoublePrime = 0.0116, HPrime = 1643.0, HDoublePrime = 2187.0, R = 544.0, SPrime = 3.6750, SDoublePrime = 5.6270 },
            new SaturatedByPressure { Pressure = 16.0, Temp = 346.6, VPrime = 0.00171, VDoublePrime = 0.0112, HPrime = 1675.0, HDoublePrime = 2114.0, R = 439.0, SPrime = 3.7060, SDoublePrime = 5.6210 },
            new SaturatedByPressure { Pressure = 16.5, Temp = 348.9, VPrime = 0.00174, VDoublePrime = 0.0108, HPrime = 1717.0, HDoublePrime = 2025.0, R = 308.0, SPrime = 3.7410, SDoublePrime = 5.6160 },
            new SaturatedByPressure { Pressure = 17.0, Temp = 351.1, VPrime = 0.00177, VDoublePrime = 0.0105, HPrime = 1785.0, HDoublePrime = 1899.0, R = 114.0, SPrime = 3.7930, SDoublePrime = 5.6120 },
            new SaturatedByPressure { Pressure = 17.5, Temp = 353.2, VPrime = 0.00181, VDoublePrime = 0.0102, HPrime = 1935.0, HDoublePrime = 1692.0, R = 0.0, SPrime = 3.9020, SDoublePrime = 5.6090 },
            new SaturatedByPressure { Pressure = 18.0, Temp = 355.2, VPrime = 0.00185, VDoublePrime = 0.0099, HPrime = 2530.0, HDoublePrime = 2530.0, R = 0.0, SPrime = 4.3160, SDoublePrime = 5.6070 },
            new SaturatedByPressure { Pressure = 19.0, Temp = 357.0, VPrime = 0.00192, VDoublePrime = 0.0094, HPrime = 2700.0, HDoublePrime = 2700.0, R = 0.0, SPrime = 4.4200, SDoublePrime = 5.6040 },
            new SaturatedByPressure { Pressure = 20.0, Temp = 358.6, VPrime = 0.00204, VDoublePrime = 0.0089, HPrime = 2800.0, HDoublePrime = 2800.0, R = 0.0, SPrime = 4.4800, SDoublePrime = 5.6020 },
            new SaturatedByPressure { Pressure = 21.0, Temp = 360.0, VPrime = 0.00236, VDoublePrime = 0.0082, HPrime = 2900.0, HDoublePrime = 2900.0, R = 0.0, SPrime = 4.5400, SDoublePrime = 5.6000 },
            new SaturatedByPressure { Pressure = 22.0, Temp = 361.2, VPrime = 0.00310, VDoublePrime = 0.0072, HPrime = 3000.0, HDoublePrime = 3000.0, R = 0.0, SPrime = 4.6000, SDoublePrime = 5.5980 },
            // Критическая точка: P=22.115 МПа, T=374.1°C (справочные данные)
            new SaturatedByPressure { Pressure = 22.115, Temp = 374.1, VPrime = 0.00317, VDoublePrime = 0.00317, HPrime = 2107.0, HDoublePrime = 2107.0, R = 0.0, SPrime = 4.4429, SDoublePrime = 4.4429 }
        };

        /// <summary>
        /// Свойства перегретого пара (давление 0.01-22 МПа, температура 100-600°C)
        /// </summary>
        public static List<SuperheatedSteam> SuperheatedSteam { get; } = new List<SuperheatedSteam>
        {
            // P = 0.01 МПа (Tнас = 45.8°C)
            new SuperheatedSteam { Pressure = 0.01, Temp = 100, H = 2685, S = 8.449, V = 17.2 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 150, H = 2782, S = 8.688, V = 19.5 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 200, H = 2880, S = 8.903, V = 21.8 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 250, H = 2980, S = 9.100, V = 24.1 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 300, H = 3082, S = 9.283, V = 26.4 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 400, H = 3290, S = 9.617, V = 31.0 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 500, H = 3505, S = 9.917, V = 35.7 },
            new SuperheatedSteam { Pressure = 0.01, Temp = 600, H = 3728, S = 10.192, V = 40.3 },

            // P = 0.05 МПа (Tнас = 81.3°C)
            new SuperheatedSteam { Pressure = 0.05, Temp = 100, H = 2683, S = 7.694, V = 3.24 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 150, H = 2780, S = 7.940, V = 3.89 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 200, H = 2878, S = 8.158, V = 4.36 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 250, H = 2978, S = 8.356, V = 4.82 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 300, H = 3080, S = 8.540, V = 5.28 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 400, H = 3288, S = 8.875, V = 6.20 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 500, H = 3503, S = 9.176, V = 7.13 },
            new SuperheatedSteam { Pressure = 0.05, Temp = 600, H = 3726, S = 9.452, V = 8.05 },

            // P = 0.1 МПа (Tнас = 99.6°C)
            new SuperheatedSteam { Pressure = 0.1, Temp = 100, H = 2676, S = 7.361, V = 1.696 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 150, H = 2776, S = 7.613, V = 1.936 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 200, H = 2875, S = 7.834, V = 2.172 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 250, H = 2975, S = 8.033, V = 2.406 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 300, H = 3076, S = 8.217, V = 2.639 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 400, H = 3284, S = 8.553, V = 3.103 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 500, H = 3499, S = 8.854, V = 3.565 },
            new SuperheatedSteam { Pressure = 0.1, Temp = 600, H = 3722, S = 9.130, V = 4.028 },

            // P = 0.2 МПа (Tнас = 120.2°C)
            new SuperheatedSteam { Pressure = 0.2, Temp = 150, H = 2769, S = 7.280, V = 0.960 },
            new SuperheatedSteam { Pressure = 0.2, Temp = 200, H = 2871, S = 7.506, V = 1.080 },
            new SuperheatedSteam { Pressure = 0.2, Temp = 250, H = 2972, S = 7.708, V = 1.199 },
            new SuperheatedSteam { Pressure = 0.2, Temp = 300, H = 3073, S = 7.893, V = 1.316 },
            new SuperheatedSteam { Pressure = 0.2, Temp = 400, H = 3281, S = 8.230, V = 1.549 },
            new SuperheatedSteam { Pressure = 0.2, Temp = 500, H = 3496, S = 8.532, V = 1.781 },
            new SuperheatedSteam { Pressure = 0.2, Temp = 600, H = 3719, S = 8.808, V = 2.013 },

            // P = 0.3 МПа (Tнас = 133.5°C)
            new SuperheatedSteam { Pressure = 0.3, Temp = 150, H = 2761, S = 7.079, V = 0.634 },
            new SuperheatedSteam { Pressure = 0.3, Temp = 200, H = 2866, S = 7.311, V = 0.716 },
            new SuperheatedSteam { Pressure = 0.3, Temp = 250, H = 2968, S = 7.516, V = 0.796 },
            new SuperheatedSteam { Pressure = 0.3, Temp = 300, H = 3070, S = 7.702, V = 0.875 },
            new SuperheatedSteam { Pressure = 0.3, Temp = 400, H = 3278, S = 8.040, V = 1.031 },
            new SuperheatedSteam { Pressure = 0.3, Temp = 500, H = 3493, S = 8.342, V = 1.187 },
            new SuperheatedSteam { Pressure = 0.3, Temp = 600, H = 3716, S = 8.619, V = 1.341 },

            // P = 0.4 МПа (Tнас = 143.6°C)
            new SuperheatedSteam { Pressure = 0.4, Temp = 150, H = 2753, S = 6.929, V = 0.471 },
            new SuperheatedSteam { Pressure = 0.4, Temp = 200, H = 2861, S = 7.170, V = 0.534 },
            new SuperheatedSteam { Pressure = 0.4, Temp = 250, H = 2964, S = 7.378, V = 0.595 },
            new SuperheatedSteam { Pressure = 0.4, Temp = 300, H = 3067, S = 7.566, V = 0.655 },
            new SuperheatedSteam { Pressure = 0.4, Temp = 400, H = 3275, S = 7.906, V = 0.773 },
            new SuperheatedSteam { Pressure = 0.4, Temp = 500, H = 3490, S = 8.209, V = 0.891 },
            new SuperheatedSteam { Pressure = 0.4, Temp = 600, H = 3713, S = 8.486, V = 1.008 },

            // P = 0.5 МПа (Tнас = 151.8°C)
            new SuperheatedSteam { Pressure = 0.5, Temp = 200, H = 2856, S = 7.061, V = 0.425 },
            new SuperheatedSteam { Pressure = 0.5, Temp = 250, H = 2961, S = 7.271, V = 0.474 },
            new SuperheatedSteam { Pressure = 0.5, Temp = 300, H = 3064, S = 7.460, V = 0.523 },
            new SuperheatedSteam { Pressure = 0.5, Temp = 400, H = 3272, S = 7.801, V = 0.617 },
            new SuperheatedSteam { Pressure = 0.5, Temp = 500, H = 3488, S = 8.104, V = 0.711 },
            new SuperheatedSteam { Pressure = 0.5, Temp = 600, H = 3711, S = 8.382, V = 0.804 },

            // P = 0.6 МПа (Tнас = 158.8°C)
            new SuperheatedSteam { Pressure = 0.6, Temp = 200, H = 2851, S = 6.968, V = 0.352 },
            new SuperheatedSteam { Pressure = 0.6, Temp = 250, H = 2958, S = 7.181, V = 0.394 },
            new SuperheatedSteam { Pressure = 0.6, Temp = 300, H = 3062, S = 7.372, V = 0.434 },
            new SuperheatedSteam { Pressure = 0.6, Temp = 400, H = 3270, S = 7.714, V = 0.513 },
            new SuperheatedSteam { Pressure = 0.6, Temp = 500, H = 3486, S = 8.018, V = 0.592 },
            new SuperheatedSteam { Pressure = 0.6, Temp = 600, H = 3709, S = 8.296, V = 0.670 },

            // P = 0.8 МПа (Tнас = 170.4°C)
            new SuperheatedSteam { Pressure = 0.8, Temp = 200, H = 2840, S = 6.815, V = 0.261 },
            new SuperheatedSteam { Pressure = 0.8, Temp = 250, H = 2950, S = 7.038, V = 0.293 },
            new SuperheatedSteam { Pressure = 0.8, Temp = 300, H = 3056, S = 7.233, V = 0.324 },
            new SuperheatedSteam { Pressure = 0.8, Temp = 400, H = 3266, S = 7.578, V = 0.384 },
            new SuperheatedSteam { Pressure = 0.8, Temp = 500, H = 3483, S = 7.883, V = 0.443 },
            new SuperheatedSteam { Pressure = 0.8, Temp = 600, H = 3706, S = 8.162, V = 0.502 },

            // P = 1.0 МПа (Tнас = 179.9°C)
            new SuperheatedSteam { Pressure = 1.0, Temp = 200, H = 2828, S = 6.694, V = 0.206 },
            new SuperheatedSteam { Pressure = 1.0, Temp = 250, H = 2943, S = 6.926, V = 0.233 },
            new SuperheatedSteam { Pressure = 1.0, Temp = 300, H = 3051, S = 7.124, V = 0.258 },
            new SuperheatedSteam { Pressure = 1.0, Temp = 400, H = 3263, S = 7.472, V = 0.307 },
            new SuperheatedSteam { Pressure = 1.0, Temp = 500, H = 3480, S = 7.778, V = 0.354 },
            new SuperheatedSteam { Pressure = 1.0, Temp = 600, H = 3703, S = 8.058, V = 0.401 },

            // P = 1.2 МПа (Tнас = 188.0°C)
            new SuperheatedSteam { Pressure = 1.2, Temp = 250, H = 2936, S = 6.830, V = 0.192 },
            new SuperheatedSteam { Pressure = 1.2, Temp = 300, H = 3046, S = 7.032, V = 0.214 },
            new SuperheatedSteam { Pressure = 1.2, Temp = 400, H = 3260, S = 7.382, V = 0.255 },
            new SuperheatedSteam { Pressure = 1.2, Temp = 500, H = 3478, S = 7.689, V = 0.295 },
            new SuperheatedSteam { Pressure = 1.2, Temp = 600, H = 3701, S = 7.970, V = 0.335 },

            // P = 1.4 МПа (Tнас = 195.0°C)
            new SuperheatedSteam { Pressure = 1.4, Temp = 250, H = 2928, S = 6.747, V = 0.164 },
            new SuperheatedSteam { Pressure = 1.4, Temp = 300, H = 3041, S = 6.953, V = 0.182 },
            new SuperheatedSteam { Pressure = 1.4, Temp = 400, H = 3257, S = 7.306, V = 0.217 },
            new SuperheatedSteam { Pressure = 1.4, Temp = 500, H = 3475, S = 7.614, V = 0.251 },
            new SuperheatedSteam { Pressure = 1.4, Temp = 600, H = 3699, S = 7.896, V = 0.285 },

            // P = 1.6 МПа (Tнас = 201.4°C)
            new SuperheatedSteam { Pressure = 1.6, Temp = 300, H = 3035, S = 6.884, V = 0.158 },
            new SuperheatedSteam { Pressure = 1.6, Temp = 400, H = 3254, S = 7.239, V = 0.188 },
            new SuperheatedSteam { Pressure = 1.6, Temp = 500, H = 3473, S = 7.548, V = 0.217 },
            new SuperheatedSteam { Pressure = 1.6, Temp = 600, H = 3697, S = 7.830, V = 0.246 },

            // P = 1.8 МПа (Tнас = 207.1°C)
            new SuperheatedSteam { Pressure = 1.8, Temp = 300, H = 3029, S = 6.822, V = 0.140 },
            new SuperheatedSteam { Pressure = 1.8, Temp = 400, H = 3251, S = 7.179, V = 0.166 },
            new SuperheatedSteam { Pressure = 1.8, Temp = 500, H = 3471, S = 7.489, V = 0.192 },
            new SuperheatedSteam { Pressure = 1.8, Temp = 600, H = 3695, S = 7.771, V = 0.217 },

            // P = 2.0 МПа (Tнас = 212.4°C)
            new SuperheatedSteam { Pressure = 2.0, Temp = 300, H = 3024, S = 6.766, V = 0.125 },
            new SuperheatedSteam { Pressure = 2.0, Temp = 400, H = 3248, S = 7.127, V = 0.148 },
            new SuperheatedSteam { Pressure = 2.0, Temp = 500, H = 3468, S = 7.438, V = 0.171 },
            new SuperheatedSteam { Pressure = 2.0, Temp = 600, H = 3693, S = 7.720, V = 0.194 },

            // P = 2.5 МПа (Tнас = 223.9°C)
            new SuperheatedSteam { Pressure = 2.5, Temp = 300, H = 3009, S = 6.645, V = 0.099 },
            new SuperheatedSteam { Pressure = 2.5, Temp = 400, H = 3240, S = 7.015, V = 0.118 },
            new SuperheatedSteam { Pressure = 2.5, Temp = 500, H = 3462, S = 7.328, V = 0.136 },
            new SuperheatedSteam { Pressure = 2.5, Temp = 600, H = 3688, S = 7.611, V = 0.154 },

            // P = 3.0 МПа (Tнас = 233.8°C)
            new SuperheatedSteam { Pressure = 3.0, Temp = 300, H = 2994, S = 6.541, V = 0.081 },
            new SuperheatedSteam { Pressure = 3.0, Temp = 400, H = 3232, S = 6.923, V = 0.097 },
            new SuperheatedSteam { Pressure = 3.0, Temp = 500, H = 3456, S = 7.237, V = 0.112 },
            new SuperheatedSteam { Pressure = 3.0, Temp = 600, H = 3682, S = 7.521, V = 0.127 },

            // P = 3.5 МПа (Tнас = 242.6°C)
            new SuperheatedSteam { Pressure = 3.5, Temp = 350, H = 3110, S = 6.660, V = 0.077 },
            new SuperheatedSteam { Pressure = 3.5, Temp = 400, H = 3224, S = 6.842, V = 0.084 },
            new SuperheatedSteam { Pressure = 3.5, Temp = 500, H = 3450, S = 7.158, V = 0.097 },
            new SuperheatedSteam { Pressure = 3.5, Temp = 600, H = 3677, S = 7.443, V = 0.110 },

            // P = 4.0 МПа (Tнас = 250.4°C)
            new SuperheatedSteam { Pressure = 4.0, Temp = 350, H = 3094, S = 6.584, V = 0.066 },
            new SuperheatedSteam { Pressure = 4.0, Temp = 400, H = 3215, S = 6.771, V = 0.073 },
            new SuperheatedSteam { Pressure = 4.0, Temp = 500, H = 3444, S = 7.092, V = 0.085 },
            new SuperheatedSteam { Pressure = 4.0, Temp = 600, H = 3672, S = 7.378, V = 0.096 },

            // P = 4.5 МПа (Tнас = 257.4°C)
            new SuperheatedSteam { Pressure = 4.5, Temp = 400, H = 3206, S = 6.707, V = 0.064 },
            new SuperheatedSteam { Pressure = 4.5, Temp = 500, H = 3438, S = 7.031, V = 0.074 },
            new SuperheatedSteam { Pressure = 4.5, Temp = 600, H = 3667, S = 7.318, V = 0.084 },

            // P = 5.0 МПа (Tнас = 263.9°C)
            new SuperheatedSteam { Pressure = 5.0, Temp = 400, H = 3197, S = 6.648, V = 0.057 },
            new SuperheatedSteam { Pressure = 5.0, Temp = 500, H = 3432, S = 6.975, V = 0.066 },
            new SuperheatedSteam { Pressure = 5.0, Temp = 600, H = 3662, S = 7.262, V = 0.075 },

            // P = 6.0 МПа (Tнас = 275.6°C)
            new SuperheatedSteam { Pressure = 6.0, Temp = 400, H = 3178, S = 6.543, V = 0.047 },
            new SuperheatedSteam { Pressure = 6.0, Temp = 500, H = 3420, S = 6.880, V = 0.055 },
            new SuperheatedSteam { Pressure = 6.0, Temp = 600, H = 3652, S = 7.169, V = 0.062 },

            // P = 7.0 МПа (Tнас = 285.8°C)
            new SuperheatedSteam { Pressure = 7.0, Temp = 400, H = 3159, S = 6.450, V = 0.040 },
            new SuperheatedSteam { Pressure = 7.0, Temp = 500, H = 3408, S = 6.797, V = 0.046 },
            new SuperheatedSteam { Pressure = 7.0, Temp = 600, H = 3642, S = 7.088, V = 0.053 },

            // P = 8.0 МПа (Tнас = 295.0°C)
            new SuperheatedSteam { Pressure = 8.0, Temp = 400, H = 3140, S = 6.365, V = 0.034 },
            new SuperheatedSteam { Pressure = 8.0, Temp = 500, H = 3396, S = 6.721, V = 0.040 },
            new SuperheatedSteam { Pressure = 8.0, Temp = 600, H = 3632, S = 7.014, V = 0.045 },

            // P = 9.0 МПа (Tнас = 303.3°C)
            new SuperheatedSteam { Pressure = 9.0, Temp = 400, H = 3121, S = 6.287, V = 0.030 },
            new SuperheatedSteam { Pressure = 9.0, Temp = 500, H = 3384, S = 6.652, V = 0.035 },
            new SuperheatedSteam { Pressure = 9.0, Temp = 600, H = 3622, S = 6.947, V = 0.039 },

            // P = 10.0 МПа (Tнас = 311.0°C)
            new SuperheatedSteam { Pressure = 10.0, Temp = 400, H = 3102, S = 6.215, V = 0.026 },
            new SuperheatedSteam { Pressure = 10.0, Temp = 500, H = 3372, S = 6.588, V = 0.031 },
            new SuperheatedSteam { Pressure = 10.0, Temp = 600, H = 3612, S = 6.885, V = 0.035 },

            // P = 11.0 МПа (Tнас = 318.0°C)
            new SuperheatedSteam { Pressure = 11.0, Temp = 400, H = 3083, S = 6.148, V = 0.024 },
            new SuperheatedSteam { Pressure = 11.0, Temp = 500, H = 3360, S = 6.528, V = 0.028 },
            new SuperheatedSteam { Pressure = 11.0, Temp = 600, H = 3602, S = 6.827, V = 0.031 },

            // P = 12.0 МПа (Tнас = 324.6°C)
            new SuperheatedSteam { Pressure = 12.0, Temp = 400, H = 3064, S = 6.085, V = 0.022 },
            new SuperheatedSteam { Pressure = 12.0, Temp = 500, H = 3348, S = 6.472, V = 0.025 },
            new SuperheatedSteam { Pressure = 12.0, Temp = 600, H = 3592, S = 6.773, V = 0.028 },

            // P = 13.0 МПа (Tнас = 330.7°C)
            new SuperheatedSteam { Pressure = 13.0, Temp = 400, H = 3045, S = 6.025, V = 0.020 },
            new SuperheatedSteam { Pressure = 13.0, Temp = 500, H = 3336, S = 6.419, V = 0.023 },
            new SuperheatedSteam { Pressure = 13.0, Temp = 600, H = 3582, S = 6.722, V = 0.026 },

            // P = 14.0 МПа (Tнас = 336.4°C)
            new SuperheatedSteam { Pressure = 14.0, Temp = 400, H = 3026, S = 5.968, V = 0.019 },
            new SuperheatedSteam { Pressure = 14.0, Temp = 500, H = 3324, S = 6.369, V = 0.021 },
            new SuperheatedSteam { Pressure = 14.0, Temp = 600, H = 3572, S = 6.674, V = 0.024 },

            // P = 15.0 МПа (Tнас = 341.7°C)
            new SuperheatedSteam { Pressure = 15.0, Temp = 400, H = 3007, S = 5.914, V = 0.018 },
            new SuperheatedSteam { Pressure = 15.0, Temp = 500, H = 3312, S = 6.322, V = 0.020 },
            new SuperheatedSteam { Pressure = 15.0, Temp = 600, H = 3562, S = 6.628, V = 0.022 },

            // P = 16.0 МПа (Tнас = 346.6°C)
            new SuperheatedSteam { Pressure = 16.0, Temp = 400, H = 2988, S = 5.862, V = 0.017 },
            new SuperheatedSteam { Pressure = 16.0, Temp = 500, H = 3300, S = 6.277, V = 0.019 },
            new SuperheatedSteam { Pressure = 16.0, Temp = 600, H = 3552, S = 6.584, V = 0.021 },

            // P = 17.0 МПа (Tнас = 351.1°C)
            new SuperheatedSteam { Pressure = 17.0, Temp = 400, H = 2969, S = 5.812, V = 0.016 },
            new SuperheatedSteam { Pressure = 17.0, Temp = 500, H = 3288, S = 6.234, V = 0.018 },
            new SuperheatedSteam { Pressure = 17.0, Temp = 600, H = 3542, S = 6.542, V = 0.020 },

            // P = 18.0 МПа (Tнас = 355.2°C)
            new SuperheatedSteam { Pressure = 18.0, Temp = 400, H = 2950, S = 5.764, V = 0.015 },
            new SuperheatedSteam { Pressure = 18.0, Temp = 500, H = 3276, S = 6.193, V = 0.017 },
            new SuperheatedSteam { Pressure = 18.0, Temp = 600, H = 3532, S = 6.502, V = 0.019 },

            // P = 19.0 МПа (Tнас = 357.0°C)
            new SuperheatedSteam { Pressure = 19.0, Temp = 500, H = 3264, S = 6.154, V = 0.016 },
            new SuperheatedSteam { Pressure = 19.0, Temp = 600, H = 3522, S = 6.464, V = 0.018 },

            // P = 20.0 МПа (Tнас = 358.6°C)
            new SuperheatedSteam { Pressure = 20.0, Temp = 500, H = 3252, S = 6.116, V = 0.015 },
            new SuperheatedSteam { Pressure = 20.0, Temp = 600, H = 3512, S = 6.427, V = 0.017 },

            // P = 21.0 МПа (Tнас = 360.0°C)
            new SuperheatedSteam { Pressure = 21.0, Temp = 500, H = 3240, S = 6.080, V = 0.014 },
            new SuperheatedSteam { Pressure = 21.0, Temp = 600, H = 3502, S = 6.392, V = 0.016 },

            // P = 22.0 МПа (Tнас = 361.2°C)
            new SuperheatedSteam { Pressure = 22.0, Temp = 500, H = 3228, S = 6.045, V = 0.013 },
            new SuperheatedSteam { Pressure = 22.0, Temp = 600, H = 3492, S = 6.358, V = 0.015 }
        };

        /// <summary>
        /// Теплофизические свойства воздуха и продуктов сгорания
        /// </summary>
        public static List<GasProperties> GasPropertiesTable { get; } = new List<GasProperties>
        {
            new GasProperties { Temp = 0, CkAir = 1.297, CkRO2 = 1.602, CkN2 = 1.296, CkH2O = 1.507, IkAir = 0, IkRO2 = 0, IkN2 = 0, IkH2O = 0 },
            new GasProperties { Temp = 100, CkAir = 1.300, CkRO2 = 1.644, CkN2 = 1.296, CkH2O = 1.513, IkAir = 132, IkRO2 = 165, IkN2 = 130, IkH2O = 151 },
            new GasProperties { Temp = 200, CkAir = 1.307, CkRO2 = 1.697, CkN2 = 1.300, CkH2O = 1.526, IkAir = 266, IkRO2 = 340, IkN2 = 260, IkH2O = 305 },
            new GasProperties { Temp = 300, CkAir = 1.317, CkRO2 = 1.754, CkN2 = 1.307, CkH2O = 1.542, IkAir = 403, IkRO2 = 527, IkN2 = 392, IkH2O = 463 },
            new GasProperties { Temp = 400, CkAir = 1.328, CkRO2 = 1.810, CkN2 = 1.317, CkH2O = 1.560, IkAir = 543, IkRO2 = 723, IkN2 = 527, IkH2O = 624 },
            new GasProperties { Temp = 500, CkAir = 1.340, CkRO2 = 1.863, CkN2 = 1.328, CkH2O = 1.578, IkAir = 687, IkRO2 = 928, IkN2 = 664, IkH2O = 789 },
            new GasProperties { Temp = 600, CkAir = 1.352, CkRO2 = 1.911, CkN2 = 1.340, CkH2O = 1.596, IkAir = 834, IkRO2 = 1140, IkN2 = 804, IkH2O = 958 },
            new GasProperties { Temp = 700, CkAir = 1.364, CkRO2 = 1.954, CkN2 = 1.352, CkH2O = 1.613, IkAir = 984, IkRO2 = 1359, IkN2 = 946, IkH2O = 1130 },
            new GasProperties { Temp = 800, CkAir = 1.375, CkRO2 = 1.992, CkN2 = 1.364, CkH2O = 1.629, IkAir = 1137, IkRO2 = 1583, IkN2 = 1091, IkH2O = 1303 },
            new GasProperties { Temp = 900, CkAir = 1.386, CkRO2 = 2.025, CkN2 = 1.375, CkH2O = 1.644, IkAir = 1293, IkRO2 = 1811, IkN2 = 1238, IkH2O = 1479 },
            new GasProperties { Temp = 1000, CkAir = 1.395, CkRO2 = 2.054, CkN2 = 1.386, CkH2O = 1.658, IkAir = 1451, IkRO2 = 2043, IkN2 = 1387, IkH2O = 1658 },
            new GasProperties { Temp = 1100, CkAir = 1.404, CkRO2 = 2.079, CkN2 = 1.395, CkH2O = 1.671, IkAir = 1612, IkRO2 = 2278, IkN2 = 1538, IkH2O = 1838 },
            new GasProperties { Temp = 1200, CkAir = 1.412, CkRO2 = 2.101, CkN2 = 1.404, CkH2O = 1.683, IkAir = 1775, IkRO2 = 2515, IkN2 = 1690, IkH2O = 2020 },
            new GasProperties { Temp = 1300, CkAir = 1.419, CkRO2 = 2.120, CkN2 = 1.412, CkH2O = 1.694, IkAir = 1940, IkRO2 = 2754, IkN2 = 1844, IkH2O = 2203 },
            new GasProperties { Temp = 1400, CkAir = 1.425, CkRO2 = 2.137, CkN2 = 1.419, CkH2O = 1.704, IkAir = 2107, IkRO2 = 2994, IkN2 = 1999, IkH2O = 2387 },
            new GasProperties { Temp = 1500, CkAir = 1.431, CkRO2 = 2.152, CkN2 = 1.425, CkH2O = 1.713, IkAir = 2276, IkRO2 = 3235, IkN2 = 2156, IkH2O = 2572 },
            new GasProperties { Temp = 1600, CkAir = 1.436, CkRO2 = 2.165, CkN2 = 1.431, CkH2O = 1.721, IkAir = 2447, IkRO2 = 3477, IkN2 = 2314, IkH2O = 2758 },
            new GasProperties { Temp = 1700, CkAir = 1.440, CkRO2 = 2.177, CkN2 = 1.436, CkH2O = 1.729, IkAir = 2620, IkRO2 = 3720, IkN2 = 2473, IkH2O = 2945 },
            new GasProperties { Temp = 1800, CkAir = 1.444, CkRO2 = 2.188, CkN2 = 1.440, CkH2O = 1.736, IkAir = 2794, IkRO2 = 3963, IkN2 = 2633, IkH2O = 3133 },
            new GasProperties { Temp = 1900, CkAir = 1.448, CkRO2 = 2.198, CkN2 = 1.444, CkH2O = 1.743, IkAir = 2970, IkRO2 = 4207, IkN2 = 2794, IkH2O = 3322 },
            new GasProperties { Temp = 2000, CkAir = 1.451, CkRO2 = 2.207, CkN2 = 1.448, CkH2O = 1.749, IkAir = 3148, IkRO2 = 4451, IkN2 = 2956, IkH2O = 3512 },
            new GasProperties { Temp = 2100, CkAir = 1.454, CkRO2 = 2.216, CkN2 = 1.451, CkH2O = 1.755, IkAir = 3327, IkRO2 = 4696, IkN2 = 3119, IkH2O = 3703 },
            new GasProperties { Temp = 2200, CkAir = 1.457, CkRO2 = 2.224, CkN2 = 1.454, CkH2O = 1.761, IkAir = 3508, IkRO2 = 4941, IkN2 = 3283, IkH2O = 3895 },
            new GasProperties { Temp = 2300, CkAir = 1.460, CkRO2 = 2.232, CkN2 = 1.457, CkH2O = 1.767, IkAir = 3690, IkRO2 = 5187, IkN2 = 3448, IkH2O = 4088 },
            new GasProperties { Temp = 2400, CkAir = 1.463, CkRO2 = 2.239, CkN2 = 1.460, CkH2O = 1.772, IkAir = 3874, IkRO2 = 5433, IkN2 = 3614, IkH2O = 4282 },
            new GasProperties { Temp = 2500, CkAir = 1.465, CkRO2 = 2.246, CkN2 = 1.463, CkH2O = 1.777, IkAir = 4059, IkRO2 = 5680, IkN2 = 3781, IkH2O = 4477 }
        };

        /// <summary>
        /// Энтальпия золы (по температуре)
        /// </summary>
        public static List<AshProperties> AshPropertiesTable { get; } = new List<AshProperties>
        {
            new AshProperties { Temp = 0, CAsh = 0.81, IAsh = 0 },
            new AshProperties { Temp = 100, CAsh = 0.84, IAsh = 84 },
            new AshProperties { Temp = 200, CAsh = 0.88, IAsh = 176 },
            new AshProperties { Temp = 300, CAsh = 0.92, IAsh = 276 },
            new AshProperties { Temp = 400, CAsh = 0.96, IAsh = 384 },
            new AshProperties { Temp = 500, CAsh = 1.00, IAsh = 500 },
            new AshProperties { Temp = 600, CAsh = 1.04, IAsh = 624 },
            new AshProperties { Temp = 700, CAsh = 1.08, IAsh = 756 },
            new AshProperties { Temp = 800, CAsh = 1.12, IAsh = 896 },
            new AshProperties { Temp = 900, CAsh = 1.16, IAsh = 1044 },
            new AshProperties { Temp = 1000, CAsh = 1.20, IAsh = 1200 },
            new AshProperties { Temp = 1100, CAsh = 1.24, IAsh = 1364 },
            new AshProperties { Temp = 1200, CAsh = 1.28, IAsh = 1536 },
            new AshProperties { Temp = 1300, CAsh = 1.32, IAsh = 1716 },
            new AshProperties { Temp = 1400, CAsh = 1.36, IAsh = 1904 },
            new AshProperties { Temp = 1500, CAsh = 1.40, IAsh = 2100 },
            new AshProperties { Temp = 1600, CAsh = 1.44, IAsh = 2304 },
            new AshProperties { Temp = 1700, CAsh = 1.48, IAsh = 2516 },
            new AshProperties { Temp = 1800, CAsh = 1.52, IAsh = 2736 },
            new AshProperties { Temp = 1900, CAsh = 1.56, IAsh = 2964 },
            new AshProperties { Temp = 2000, CAsh = 1.60, IAsh = 3200 }
        };

        #region Методы интерполяции

        /// <summary>
        /// Линейная интерполяция свойств насыщенной воды по температуре
        /// </summary>
        public static SaturatedByTemp InterpolateSaturatedByTemp(double temp)
        {
            if (temp <= SaturatedTemp[0].Temp)
                return SaturatedTemp[0];
            if (temp >= SaturatedTemp[^1].Temp)
                return SaturatedTemp[^1];

            for (int i = 0; i < SaturatedTemp.Count - 1; i++)
            {
                if (SaturatedTemp[i].Temp <= temp && temp <= SaturatedTemp[i + 1].Temp)
                {
                    double t = (temp - SaturatedTemp[i].Temp) / (SaturatedTemp[i + 1].Temp - SaturatedTemp[i].Temp);
                    return new SaturatedByTemp
                    {
                        Temp = temp,
                        Pressure = Lerp(SaturatedTemp[i].Pressure, SaturatedTemp[i + 1].Pressure, t),
                        VPrime = Lerp(SaturatedTemp[i].VPrime, SaturatedTemp[i + 1].VPrime, t),
                        VDoublePrime = Lerp(SaturatedTemp[i].VDoublePrime, SaturatedTemp[i + 1].VDoublePrime, t),
                        HPrime = Lerp(SaturatedTemp[i].HPrime, SaturatedTemp[i + 1].HPrime, t),
                        HDoublePrime = Lerp(SaturatedTemp[i].HDoublePrime, SaturatedTemp[i + 1].HDoublePrime, t),
                        R = Lerp(SaturatedTemp[i].R, SaturatedTemp[i + 1].R, t),
                        SPrime = Lerp(SaturatedTemp[i].SPrime, SaturatedTemp[i + 1].SPrime, t),
                        SDoublePrime = Lerp(SaturatedTemp[i].SDoublePrime, SaturatedTemp[i + 1].SDoublePrime, t)
                    };
                }
            }
            return SaturatedTemp[0];
        }

        /// <summary>
        /// Линейная интерполяция свойств насыщенной воды по давлению
        /// </summary>
        public static SaturatedByPressure InterpolateSaturatedByPressure(double pressure)
        {
            if (pressure <= SaturatedPressure[0].Pressure)
                return SaturatedPressure[0];
            if (pressure >= SaturatedPressure[^1].Pressure)
                return SaturatedPressure[^1];

            for (int i = 0; i < SaturatedPressure.Count - 1; i++)
            {
                if (SaturatedPressure[i].Pressure <= pressure && pressure <= SaturatedPressure[i + 1].Pressure)
                {
                    double t = (pressure - SaturatedPressure[i].Pressure) / (SaturatedPressure[i + 1].Pressure - SaturatedPressure[i].Pressure);
                    return new SaturatedByPressure
                    {
                        Pressure = pressure,
                        Temp = Lerp(SaturatedPressure[i].Temp, SaturatedPressure[i + 1].Temp, t),
                        VPrime = Lerp(SaturatedPressure[i].VPrime, SaturatedPressure[i + 1].VPrime, t),
                        VDoublePrime = Lerp(SaturatedPressure[i].VDoublePrime, SaturatedPressure[i + 1].VDoublePrime, t),
                        HPrime = Lerp(SaturatedPressure[i].HPrime, SaturatedPressure[i + 1].HPrime, t),
                        HDoublePrime = Lerp(SaturatedPressure[i].HDoublePrime, SaturatedPressure[i + 1].HDoublePrime, t),
                        R = Lerp(SaturatedPressure[i].R, SaturatedPressure[i + 1].R, t),
                        SPrime = Lerp(SaturatedPressure[i].SPrime, SaturatedPressure[i + 1].SPrime, t),
                        SDoublePrime = Lerp(SaturatedPressure[i].SDoublePrime, SaturatedPressure[i + 1].SDoublePrime, t)
                    };
                }
            }
            return SaturatedPressure[0];
        }

        /// <summary>
        /// Линейная интерполяция свойств перегретого пара
        /// </summary>
        public static SuperheatedSteam InterpolateSuperheatedSteam(double pressure, double temp)
        {
            // Find the two pressures that bracket the target pressure
            var pressures = SuperheatedSteam.Select(s => s.Pressure).Distinct().OrderBy(p => p).ToList();
            
            double pLower = pressures.Where(p => p <= pressure).LastOrDefault();
            double pUpper = pressures.Where(p => p >= pressure).FirstOrDefault();
            
            // Clamp if out of range
            if (pLower == 0) pLower = pressures.First();
            if (pUpper == 0) pUpper = pressures.Last();
            
            // If pressure matches exactly, use that
            if (pLower == pUpper)
            {
                return InterpolateAtPressure(pLower, temp);
            }
            
            // Interpolate at lower and upper pressures
            var steamLower = InterpolateAtPressure(pLower, temp);
            var steamUpper = InterpolateAtPressure(pUpper, temp);
            
            // Bilinear interpolation between pressures
            double pFrac = (pressure - pLower) / (pUpper - pLower);
            return new SuperheatedSteam
            {
                Pressure = pressure,
                Temp = temp,
                H = Lerp(steamLower.H, steamUpper.H, pFrac),
                S = Lerp(steamLower.S, steamUpper.S, pFrac),
                V = Lerp(steamLower.V, steamUpper.V, pFrac)
            };
        }
        
        /// <summary>
        /// Интерполяция свойств пара при заданном давлении по температуре
        /// </summary>
        private static SuperheatedSteam InterpolateAtPressure(double pressure, double temp)
        {
            var entries = SuperheatedSteam.Where(s => Math.Abs(s.Pressure - pressure) < 1e-6)
                .OrderBy(s => s.Temp).ToList();
            
            if (entries.Count == 0)
                return SuperheatedSteam[0];
            
            if (entries.Count == 1)
                return entries[0];
            
            // Below minimum temperature
            if (temp <= entries[0].Temp)
                return entries[0];
            
            // Above maximum temperature
            if (temp >= entries[^1].Temp)
                return entries[^1];
            
            // Find bracketing temperatures
            for (int i = 0; i < entries.Count - 1; i++)
            {
                if (entries[i].Temp <= temp && temp <= entries[i + 1].Temp)
                {
                    double t = (temp - entries[i].Temp) / (entries[i + 1].Temp - entries[i].Temp);
                    return new SuperheatedSteam
                    {
                        Pressure = pressure,
                        Temp = temp,
                        H = Lerp(entries[i].H, entries[i + 1].H, t),
                        S = Lerp(entries[i].S, entries[i + 1].S, t),
                        V = Lerp(entries[i].V, entries[i + 1].V, t)
                    };
                }
            }
            
            return entries[^1];
        }

        /// <summary>
        /// Линейная интерполяция свойств газов
        /// </summary>
        public static GasProperties InterpolateGasProperties(double temp)
        {
            if (temp <= GasPropertiesTable[0].Temp)
                return GasPropertiesTable[0];
            if (temp >= GasPropertiesTable[^1].Temp)
                return GasPropertiesTable[^1];

            for (int i = 0; i < GasPropertiesTable.Count - 1; i++)
            {
                if (GasPropertiesTable[i].Temp <= temp && temp <= GasPropertiesTable[i + 1].Temp)
                {
                    double t = (temp - GasPropertiesTable[i].Temp) / (GasPropertiesTable[i + 1].Temp - GasPropertiesTable[i].Temp);
                    return new GasProperties
                    {
                        Temp = temp,
                        CkAir = Lerp(GasPropertiesTable[i].CkAir, GasPropertiesTable[i + 1].CkAir, t),
                        CkRO2 = Lerp(GasPropertiesTable[i].CkRO2, GasPropertiesTable[i + 1].CkRO2, t),
                        CkN2 = Lerp(GasPropertiesTable[i].CkN2, GasPropertiesTable[i + 1].CkN2, t),
                        CkH2O = Lerp(GasPropertiesTable[i].CkH2O, GasPropertiesTable[i + 1].CkH2O, t),
                        IkAir = Lerp(GasPropertiesTable[i].IkAir, GasPropertiesTable[i + 1].IkAir, t),
                        IkRO2 = Lerp(GasPropertiesTable[i].IkRO2, GasPropertiesTable[i + 1].IkRO2, t),
                        IkN2 = Lerp(GasPropertiesTable[i].IkN2, GasPropertiesTable[i + 1].IkN2, t),
                        IkH2O = Lerp(GasPropertiesTable[i].IkH2O, GasPropertiesTable[i + 1].IkH2O, t)
                    };
                }
            }
            return GasPropertiesTable[0];
        }

        /// <summary>
        /// Линейная интерполяция энтальпии золы
        /// </summary>
        public static AshProperties InterpolateAshProperties(double temp)
        {
            if (temp <= AshPropertiesTable[0].Temp)
                return AshPropertiesTable[0];
            if (temp >= AshPropertiesTable[^1].Temp)
                return AshPropertiesTable[^1];

            for (int i = 0; i < AshPropertiesTable.Count - 1; i++)
            {
                if (AshPropertiesTable[i].Temp <= temp && temp <= AshPropertiesTable[i + 1].Temp)
                {
                    double t = (temp - AshPropertiesTable[i].Temp) / (AshPropertiesTable[i + 1].Temp - AshPropertiesTable[i].Temp);
                    return new AshProperties
                    {
                        Temp = temp,
                        CAsh = Lerp(AshPropertiesTable[i].CAsh, AshPropertiesTable[i + 1].CAsh, t),
                        IAsh = Lerp(AshPropertiesTable[i].IAsh, AshPropertiesTable[i + 1].IAsh, t)
                    };
                }
            }
            return AshPropertiesTable[0];
        }

        private static double Lerp(double a, double b, double t)
        {
            return a + (b - a) * t;
        }

        #endregion
    }
}
