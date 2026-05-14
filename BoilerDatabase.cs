namespace BoilerCalc
{
    /// <summary>
    /// Класс, представляющий характеристику котлоагрегата
    /// </summary>
    public class Boiler
    {
        public string Model { get; set; }              // Модель котла
        public string Type { get; set; }               // Тип котла (ПК, ЭК, ВП и т.д.)
        public double SteamCapacity { get; set; }      // Паропроизводительность, т/ч
        public double DrumPressure { get; set; }       // Давление в барабане, кгс/см² (МПа)
        public double SuperheatPressure { get; set; }  // Давление перегретого пара, кгс/см² (МПа)
        public double SuperheatTemp { get; set; }      // Температура перегретого пара, °C
        public double FeedWaterTemp { get; set; }      // Температура питательной воды, °C
        public double BoilerEfficiency { get; set; }   // КПД брутто, %
        public double FurnaceVolume { get; set; }      // Объем топочной камеры, м³
        public double HeatingSurface { get; set; }     // Площадь поверхности нагрева, м²
        public string FuelType { get; set; }           // Вид топлива (У, Г, М)
        public int Year { get; set; }                  // Год выпуска/модернизации

        /// <summary>
        /// Давление в барабане в МПа
        /// </summary>
        public double DrumPressureMPa => DrumPressure * 0.0980665;

        /// <summary>
        /// Давление перегретого пара в МПа
        /// </summary>
        public double SuperheatPressureMPa => SuperheatPressure * 0.0980665;

        public override string ToString()
        {
            return $"{Model} (D={SteamCapacity} т/ч, P={SuperheatPressure} кгс/см², T={SuperheatTemp}°C)";
        }
    }

    /// <summary>
    /// База данных характеристик котлоагрегатов
    /// На основе справочных данных заводов-изготовителей
    /// </summary>
    public static class BoilerDatabase
    {
        public static List<Boiler> Boilers { get; } = new List<Boiler>
        {
            // ==================== КОТЛЫ БКЗ (Барнаульский котельный завод) ====================
            // Котлы БКЗ-25 серии
            new Boiler { Model = "БКЗ-25-39ГМ", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.5, FurnaceVolume = 85, HeatingSurface = 650, FuelType = "Г/М", Year = 1980 },
            new Boiler { Model = "БКЗ-25-39Ф", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.0, FurnaceVolume = 120, HeatingSurface = 680, FuelType = "У", Year = 1985 },

            // Котлы БКЗ-35 серии
            new Boiler { Model = "БКЗ-35-39ГМ", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.8, FurnaceVolume = 110, HeatingSurface = 780, FuelType = "Г/М", Year = 1982 },
            new Boiler { Model = "БКЗ-35-39Ф", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.5, FurnaceVolume = 145, HeatingSurface = 820, FuelType = "У", Year = 1985 },
            new Boiler { Model = "БКЗ-35-39ФБ", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.8, FurnaceVolume = 150, HeatingSurface = 850, FuelType = "У", Year = 1990 },

            // Котлы БКЗ-50 серии
            new Boiler { Model = "БКЗ-50-39ГМ", Type = "ПК", SteamCapacity = 50, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 93.0, FurnaceVolume = 140, HeatingSurface = 950, FuelType = "Г/М", Year = 1983 },
            new Boiler { Model = "БКЗ-50-39Ф", Type = "ПК", SteamCapacity = 50, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.0, FurnaceVolume = 180, HeatingSurface = 1000, FuelType = "У", Year = 1986 },

            // Котлы БКЗ-75 серии (наиболее распространенные)
            new Boiler { Model = "БКЗ-75-39ГМ", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 93.2, FurnaceVolume = 200, HeatingSurface = 1250, FuelType = "Г/М", Year = 1985 },
            new Boiler { Model = "БКЗ-75-39Ф", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.5, FurnaceVolume = 280, HeatingSurface = 1320, FuelType = "У", Year = 1987 },
            new Boiler { Model = "БКЗ-75-39ФБ", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.8, FurnaceVolume = 290, HeatingSurface = 1350, FuelType = "У", Year = 1990 },
            new Boiler { Model = "БКЗ-75-39ФБТ", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 93.0, FurnaceVolume = 300, HeatingSurface = 1380, FuelType = "У", Year = 1995 },

            // Котлы БКЗ-160 серии
            new Boiler { Model = "БКЗ-160-100Ф", Type = "ПК", SteamCapacity = 160, DrumPressure = 110, SuperheatPressure = 100, SuperheatTemp = 510, FeedWaterTemp = 160, BoilerEfficiency = 93.5, FurnaceVolume = 550, HeatingSurface = 2800, FuelType = "У", Year = 1990 },
            new Boiler { Model = "БКЗ-160-100ГМ", Type = "ПК", SteamCapacity = 160, DrumPressure = 110, SuperheatPressure = 100, SuperheatTemp = 510, FeedWaterTemp = 160, BoilerEfficiency = 94.0, FurnaceVolume = 480, HeatingSurface = 2650, FuelType = "Г/М", Year = 1988 },

            // Котлы БКЗ-210 серии
            new Boiler { Model = "БКЗ-210-140Ф", Type = "ПК", SteamCapacity = 210, DrumPressure = 155, SuperheatPressure = 140, SuperheatTemp = 540, FeedWaterTemp = 170, BoilerEfficiency = 94.0, FurnaceVolume = 750, HeatingSurface = 3500, FuelType = "У", Year = 1992 },
            new Boiler { Model = "БКЗ-210-140ГМ", Type = "ПК", SteamCapacity = 210, DrumPressure = 155, SuperheatPressure = 140, SuperheatTemp = 540, FeedWaterTemp = 170, BoilerEfficiency = 94.5, FurnaceVolume = 680, HeatingSurface = 3350, FuelType = "Г/М", Year = 1990 },

            // ==================== КОТЛЫ Е (Бийский/Красноярский котельный завод) ====================
            // Котлы Е-25 серии
            new Boiler { Model = "Е-25-39ГМ", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.0, FurnaceVolume = 90, HeatingSurface = 640, FuelType = "Г/М", Year = 1980 },
            new Boiler { Model = "Е-25-39Ф", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 90.5, FurnaceVolume = 125, HeatingSurface = 670, FuelType = "У", Year = 1983 },

            // Котлы Е-35 серии
            new Boiler { Model = "Е-35-39ГМ", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.5, FurnaceVolume = 115, HeatingSurface = 770, FuelType = "Г/М", Year = 1982 },
            new Boiler { Model = "Е-35-39Ф", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.0, FurnaceVolume = 150, HeatingSurface = 810, FuelType = "У", Year = 1985 },

            // Котлы Е-50 серии
            new Boiler { Model = "Е-50-39ГМ", Type = "ПК", SteamCapacity = 50, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.8, FurnaceVolume = 145, HeatingSurface = 940, FuelType = "Г/М", Year = 1984 },
            new Boiler { Model = "Е-50-39Ф", Type = "ПК", SteamCapacity = 50, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.5, FurnaceVolume = 185, HeatingSurface = 990, FuelType = "У", Year = 1987 },

            // Котлы Е-75 серии
            new Boiler { Model = "Е-75-39ГМ", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 93.0, FurnaceVolume = 205, HeatingSurface = 1240, FuelType = "Г/М", Year = 1986 },
            new Boiler { Model = "Е-75-39Ф", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.0, FurnaceVolume = 285, HeatingSurface = 1310, FuelType = "У", Year = 1988 },

            // Котлы Е-160 серии
            new Boiler { Model = "Е-160-100Ф", Type = "ПК", SteamCapacity = 160, DrumPressure = 110, SuperheatPressure = 100, SuperheatTemp = 510, FeedWaterTemp = 160, BoilerEfficiency = 93.2, FurnaceVolume = 560, HeatingSurface = 2750, FuelType = "У", Year = 1991 },
            new Boiler { Model = "Е-160-100ГМ", Type = "ПК", SteamCapacity = 160, DrumPressure = 110, SuperheatPressure = 100, SuperheatTemp = 510, FeedWaterTemp = 160, BoilerEfficiency = 93.8, FurnaceVolume = 490, HeatingSurface = 2600, FuelType = "Г/М", Year = 1989 },

            // ==================== КОТЛЫ П (Подольский завод) ====================
            // Котлы П-50 серии
            new Boiler { Model = "П-50-39ГМ", Type = "ПК", SteamCapacity = 50, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.5, FurnaceVolume = 140, HeatingSurface = 930, FuelType = "Г/М", Year = 1982 },
            new Boiler { Model = "П-50-39Ф", Type = "ПК", SteamCapacity = 50, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.2, FurnaceVolume = 180, HeatingSurface = 980, FuelType = "У", Year = 1985 },

            // Котлы П-75 серии
            new Boiler { Model = "П-75-39ГМ", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.8, FurnaceVolume = 195, HeatingSurface = 1230, FuelType = "Г/М", Year = 1985 },
            new Boiler { Model = "П-75-39Ф", Type = "ПК", SteamCapacity = 75, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.8, FurnaceVolume = 275, HeatingSurface = 1300, FuelType = "У", Year = 1988 },

            // ==================== КОТЛЫ КЕ (Кировский завод) ====================
            // Котлы КЕ-25 серии
            new Boiler { Model = "КЕ-25-39ГМ", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.5, FurnaceVolume = 88, HeatingSurface = 630, FuelType = "Г/М", Year = 1979 },
            new Boiler { Model = "КЕ-25-39Ф", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 90.0, FurnaceVolume = 122, HeatingSurface = 660, FuelType = "У", Year = 1982 },

            // Котлы КЕ-35 серии
            new Boiler { Model = "КЕ-35-39ГМ", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.0, FurnaceVolume = 112, HeatingSurface = 760, FuelType = "Г/М", Year = 1981 },
            new Boiler { Model = "КЕ-35-39Ф", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 90.5, FurnaceVolume = 148, HeatingSurface = 800, FuelType = "У", Year = 1984 },

            // ==================== КОТЛЫ ДЕ (Дзержинский завод) ====================
            // Котлы ДЕ-25 серии
            new Boiler { Model = "ДЕ-25-39ГМ", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.2, FurnaceVolume = 92, HeatingSurface = 645, FuelType = "Г/М", Year = 1981 },
            new Boiler { Model = "ДЕ-25-39Ф", Type = "ПК", SteamCapacity = 25, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 90.8, FurnaceVolume = 128, HeatingSurface = 675, FuelType = "У", Year = 1984 },

            // Котлы ДЕ-35 серии
            new Boiler { Model = "ДЕ-35-39ГМ", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.6, FurnaceVolume = 118, HeatingSurface = 775, FuelType = "Г/М", Year = 1983 },
            new Boiler { Model = "ДЕ-35-39Ф", Type = "ПК", SteamCapacity = 35, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 91.2, FurnaceVolume = 152, HeatingSurface = 815, FuelType = "У", Year = 1986 },

            // ==================== КОТЛЫ СРЕДНЕГО ДАВЛЕНИЯ (13 ата) ====================
            new Boiler { Model = "БКЗ-20-13Ф", Type = "ПК", SteamCapacity = 20, DrumPressure = 15, SuperheatPressure = 13, SuperheatTemp = 350, FeedWaterTemp = 80, BoilerEfficiency = 89.0, FurnaceVolume = 65, HeatingSurface = 480, FuelType = "У", Year = 1975 },
            new Boiler { Model = "БКЗ-30-13Ф", Type = "ПК", SteamCapacity = 30, DrumPressure = 15, SuperheatPressure = 13, SuperheatTemp = 350, FeedWaterTemp = 80, BoilerEfficiency = 89.5, FurnaceVolume = 95, HeatingSurface = 580, FuelType = "У", Year = 1978 },
            new Boiler { Model = "БКЗ-40-13Ф", Type = "ПК", SteamCapacity = 40, DrumPressure = 15, SuperheatPressure = 13, SuperheatTemp = 350, FeedWaterTemp = 80, BoilerEfficiency = 90.0, FurnaceVolume = 125, HeatingSurface = 680, FuelType = "У", Year = 1980 },

            // ==================== КОТЛЫ ВЫСОКОГО ДАВЛЕНИЯ (240 ата) ====================
            new Boiler { Model = "ТГМП-114", Type = "ПК", SteamCapacity = 230, DrumPressure = 255, SuperheatPressure = 240, SuperheatTemp = 540, FeedWaterTemp = 210, BoilerEfficiency = 94.5, FurnaceVolume = 850, HeatingSurface = 3800, FuelType = "Г/М", Year = 1995 },
            new Boiler { Model = "ТГМП-204", Type = "ПК", SteamCapacity = 250, DrumPressure = 255, SuperheatPressure = 240, SuperheatTemp = 540, FeedWaterTemp = 215, BoilerEfficiency = 94.8, FurnaceVolume = 900, HeatingSurface = 4000, FuelType = "Г/М", Year = 1998 },
            new Boiler { Model = "ТГМП-314", Type = "ПК", SteamCapacity = 265, DrumPressure = 255, SuperheatPressure = 240, SuperheatTemp = 540, FeedWaterTemp = 220, BoilerEfficiency = 95.0, FurnaceVolume = 950, HeatingSurface = 4200, FuelType = "Г/М", Year = 2000 },

            // ==================== КОТЛЫ СВЕРХКРИТИЧЕСКОГО ДАВЛЕНИЯ ====================
            new Boiler { Model = "Пп-1000-255-545", Type = "ПК", SteamCapacity = 1000, DrumPressure = 0, SuperheatPressure = 255, SuperheatTemp = 545, FeedWaterTemp = 270, BoilerEfficiency = 95.5, FurnaceVolume = 3500, HeatingSurface = 12000, FuelType = "У/Г", Year = 2005 },
            new Boiler { Model = "Пп-1650-255-545", Type = "ПК", SteamCapacity = 1650, DrumPressure = 0, SuperheatPressure = 255, SuperheatTemp = 545, FeedWaterTemp = 280, BoilerEfficiency = 96.0, FurnaceVolume = 5000, HeatingSurface = 16000, FuelType = "У/Г", Year = 2010 },

            // ==================== ПРОМЫШЛЕННЫЕ КОТЛЫ НИЗКОГО ДАВЛЕНИЯ ====================
            new Boiler { Model = "Е-1-9ГМ", Type = "ПК", SteamCapacity = 1, DrumPressure = 10, SuperheatPressure = 0, SuperheatTemp = 0, FeedWaterTemp = 20, BoilerEfficiency = 88.0, FurnaceVolume = 5, HeatingSurface = 50, FuelType = "Г/М", Year = 1970 },
            new Boiler { Model = "Е-2.5-9ГМ", Type = "ПК", SteamCapacity = 2.5, DrumPressure = 10, SuperheatPressure = 0, SuperheatTemp = 0, FeedWaterTemp = 20, BoilerEfficiency = 89.0, FurnaceVolume = 12, HeatingSurface = 100, FuelType = "Г/М", Year = 1972 },
            new Boiler { Model = "Е-4-9ГМ", Type = "ПК", SteamCapacity = 4, DrumPressure = 10, SuperheatPressure = 0, SuperheatTemp = 0, FeedWaterTemp = 60, BoilerEfficiency = 90.0, FurnaceVolume = 20, HeatingSurface = 150, FuelType = "Г/М", Year = 1975 },
            new Boiler { Model = "Е-6.5-9ГМ", Type = "ПК", SteamCapacity = 6.5, DrumPressure = 10, SuperheatPressure = 0, SuperheatTemp = 0, FeedWaterTemp = 80, BoilerEfficiency = 90.5, FurnaceVolume = 35, HeatingSurface = 220, FuelType = "Г/М", Year = 1978 },
            new Boiler { Model = "Е-10-9ГМ", Type = "ПК", SteamCapacity = 10, DrumPressure = 10, SuperheatPressure = 0, SuperheatTemp = 0, FeedWaterTemp = 80, BoilerEfficiency = 91.0, FurnaceVolume = 50, HeatingSurface = 300, FuelType = "Г/М", Year = 1980 },

            // ==================== КОТЛЫ-УТИЛИЗАТОРЫ ====================
            new Boiler { Model = "П-80/100-39/10", Type = "КУ", SteamCapacity = 80, DrumPressure = 44, SuperheatPressure = 39, SuperheatTemp = 450, FeedWaterTemp = 104, BoilerEfficiency = 92.0, FurnaceVolume = 0, HeatingSurface = 1500, FuelType = "-", Year = 1990 },
            new Boiler { Model = "Е-160/240-100", Type = "КУ", SteamCapacity = 160, DrumPressure = 108, SuperheatPressure = 100, SuperheatTemp = 510, FeedWaterTemp = 160, BoilerEfficiency = 93.0, FurnaceVolume = 0, HeatingSurface = 3000, FuelType = "-", Year = 1995 }
        };

        /// <summary>
        /// Получить котел по модели
        /// </summary>
        public static Boiler GetByModel(string model)
        {
            return Boilers.FirstOrDefault(b => b.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Получить котлы по паропроизводительности
        /// </summary>
        public static List<Boiler> GetByCapacity(double capacity)
        {
            return Boilers.Where(b => Math.Abs(b.SteamCapacity - capacity) < 0.1).ToList();
        }

        /// <summary>
        /// Получить котлы по диапазону паропроизводительности
        /// </summary>
        public static List<Boiler> GetByCapacityRange(double min, double max)
        {
            return Boilers.Where(b => b.SteamCapacity >= min && b.SteamCapacity <= max).ToList();
        }

        /// <summary>
        /// Получить котлы по типу топлива
        /// </summary>
        public static List<Boiler> GetByFuelType(string fuelType)
        {
            return Boilers.Where(b => b.FuelType.Contains(fuelType, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Получить котлы по заводу-изготовителю
        /// </summary>
        public static List<Boiler> GetByManufacturer(string manufacturer)
        {
            return Boilers.Where(b => b.Model.StartsWith(manufacturer, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Получить все уникальные модели
        /// </summary>
        public static List<string> GetAllModels()
        {
            return Boilers.Select(b => b.Model).OrderBy(m => m).ToList();
        }

        /// <summary>
        /// Получить все доступные паропроизводительности
        /// </summary>
        public static List<double> GetAllCapacities()
        {
            return Boilers.Select(b => b.SteamCapacity).Distinct().OrderBy(c => c).ToList();
        }

        /// <summary>
        /// Поиск котла по параметрам
        /// </summary>
        public static List<Boiler> FindBoilers(double? capacity = null, string fuelType = null, double? pressure = null)
        {
            var result = Boilers.AsEnumerable();

            if (capacity.HasValue)
                result = result.Where(b => Math.Abs(b.SteamCapacity - capacity.Value) < 0.1);

            if (!string.IsNullOrEmpty(fuelType))
                result = result.Where(b => b.FuelType.Contains(fuelType, StringComparison.OrdinalIgnoreCase));

            if (pressure.HasValue)
                result = result.Where(b => Math.Abs(b.SuperheatPressure - pressure.Value) < 1);

            return result.ToList();
        }
    }
}
